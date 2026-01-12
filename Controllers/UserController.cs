using KutuphaneAPI.Interfaces;
using KutuphaneAPI.Models;
using KutuphaneAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneAPI.Controllers;

[Authorize] 
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase {
    private readonly IUserService _userService;
    private readonly KutuphaneAPI.Context.AppDbContext _context;

    public UserController(IUserService userService, KutuphaneAPI.Context.AppDbContext context) { 
        _userService = userService; 
        _context = context; 
    }

    // GET: Tüm Kullanıcılar (DTO'lu ve Standart Cevaplı)
    [HttpGet] 
    public async Task<ActionResult<ApiResponse<List<UserResponseDto>>>> GetAll() {
        var users = await _userService.GetAllUsersAsync();
        
        // Entity'leri DTO'ya çeviriyoruz (Şifreleri temizliyoruz)
        var userDtos = users.Select(u => new UserResponseDto {
            Id = u.Id,
            Name = u.Name,
            LastName = u.LastName,
            Email = u.Email,
            Address = u.Address
        }).ToList();

        return Ok(ApiResponse<List<UserResponseDto>>.Basarili(userDtos, "Kullanıcılar listelendi."));
    }

    // POST: Kullanıcı Ekleme
    [HttpPost] 
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<ApiResponse<UserResponseDto>>> Create([FromBody] UserCreateDto dto) {
        var user = await _userService.CreateUserAsync(dto);
        
        // Geriye dönerken yine şifresiz DTO dönüyoruz
        var responseDto = new UserResponseDto {
            Id = user.Id, Name = user.Name, LastName = user.LastName, Email = user.Email, Address = user.Address
        };

        return Ok(ApiResponse<UserResponseDto>.Basarili(responseDto, "Kullanıcı oluşturuldu."));
    }

    // UPDATE: Güncelleme
    [HttpPut("{id}")] 
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<ApiResponse<UserResponseDto>>> Update(int id, [FromBody] UserCreateDto dto) {
        var user = await _userService.UpdateUserAsync(id, dto);
        if (user == null) return NotFound(ApiResponse<UserResponseDto>.Hatali("Kullanıcı bulunamadı."));
        
        // Veritabanında güncelleme tarihini de işleyelim (Manuel)
        user.UpdatedAt = DateTime.Now;
        await _context.SaveChangesAsync();

        var responseDto = new UserResponseDto {
            Id = user.Id, Name = user.Name, LastName = user.LastName, Email = user.Email, Address = user.Address
        };

        return Ok(ApiResponse<UserResponseDto>.Basarili(responseDto, "Kullanıcı güncellendi."));
    }

    // PATCH: Kısmi Güncelleme
    [HttpPatch("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<ApiResponse<User>>> Patch(int id, [FromBody] User userUpdate) {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return NotFound(ApiResponse<User>.Hatali("Kullanıcı bulunamadı."));
        
        if (!string.IsNullOrEmpty(userUpdate.Name)) user.Name = userUpdate.Name;
        if (!string.IsNullOrEmpty(userUpdate.LastName)) user.LastName = userUpdate.LastName;
        if (!string.IsNullOrEmpty(userUpdate.Email)) user.Email = userUpdate.Email;
        
        user.UpdatedAt = DateTime.Now; // Güncellenme tarihini bastık
        await _context.SaveChangesAsync();
        
        return Ok(ApiResponse<User>.Basarili(user, "Kullanıcı kısmen güncellendi."));
    }

    // DELETE: Silme
    [HttpDelete("{id}")] 
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(int id) {
        var result = await _userService.DeleteUserAsync(id);
        if (!result) return NotFound(ApiResponse<bool>.Hatali("Silinecek kullanıcı yok."));
        return Ok(ApiResponse<bool>.Basarili(true, "Kullanıcı silindi."));
    }
}