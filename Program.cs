using KutuphaneAPI.Context;
using KutuphaneAPI.Interfaces;
using KutuphaneAPI.Models; 
using KutuphaneAPI.Services;
using KutuphaneAPI.Middlewares; 
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// --- 1. AYARLAR ---
builder.Services.AddControllers()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();

// Swagger Ayarları
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Kutuphane API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme { 
        In = ParameterLocation.Header, Description = "Token yapıştır", Name = "Authorization", Type = SecuritySchemeType.Http, BearerFormat = "JWT", Scheme = "Bearer" 
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement { 
        { new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } }, new string[] { } } 
    });
});

// DB ve Servisler
builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlite("Data Source=Kutuphane.db"));
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBorrowService, BorrowService>();

// JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o => {
    o.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuer = true, ValidateAudience = true, ValidateLifetime = true, ValidateIssuerSigningKey = true,
        ValidIssuer = "KutuphaneAPI", ValidAudience = "KutuphaneUser",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("BuSizinCokGizliVeUzunAnahtariniz123!")),
        RoleClaimType = ClaimTypes.Role
    };
});
builder.Services.AddAuthorization(); 

var app = builder.Build();

// --- 2. BAŞLANGIÇ ---
using (var scope = app.Services.CreateScope()) {
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

app.UseSwagger(); 
app.UseSwaggerUI();

// Middleware Sırası: Hata Yakala -> Kimlik Doğrula -> Yetkilendir
app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseAuthentication(); 
app.UseAuthorization(); 

// --- 3. MINIMAL API (Author - DTO'lu ve 201 Kodlu) ---
var authorGroup = app.MapGroup("/api/minimal/author").WithTags("Author Minimal API");

// GET: Tüm Yazarlar (DTO Dönüyor)
authorGroup.MapGet("/", async (IAuthorService service) => {
    var authors = await service.GetAllAuthorsAsync();
    
    // Entity -> DTO Çevrimi
    var dtos = authors.Select(a => new KutuphaneAPI.DTOs.AuthorResponseDto {
        Id = a.Id,
        Name = a.Name
    }).ToList();

    return Results.Ok(ApiResponse<List<KutuphaneAPI.DTOs.AuthorResponseDto>>.Basarili(dtos));
}).RequireAuthorization(); 

// GET BY ID (DTO Dönüyor)
authorGroup.MapGet("/{id}", async (int id, IAuthorService service) => {
    var author = await service.GetAuthorByIdAsync(id);
    if (author == null) return Results.NotFound(ApiResponse<KutuphaneAPI.DTOs.AuthorResponseDto>.Hatali("Yazar bulunamadı."));
    
    var dto = new KutuphaneAPI.DTOs.AuthorResponseDto { Id = author.Id, Name = author.Name };
    return Results.Ok(ApiResponse<KutuphaneAPI.DTOs.AuthorResponseDto>.Basarili(dto));
}).RequireAuthorization();

// POST: Yazar Ekle (201 Created Dönüyor)
authorGroup.MapPost("/", async ([FromBody] Author author, IAuthorService service) => {
    var newAuthor = await service.CreateAuthorAsync(author);
    var dto = new KutuphaneAPI.DTOs.AuthorResponseDto { Id = newAuthor.Id, Name = newAuthor.Name };
    
    // HOCANIN İSTEDİĞİ 201 KODU
    return Results.Created($"/api/minimal/author/{newAuthor.Id}", ApiResponse<KutuphaneAPI.DTOs.AuthorResponseDto>.Basarili(dto));
}).RequireAuthorization(policy => policy.RequireRole("Admin"));

app.MapControllers();
app.Run();