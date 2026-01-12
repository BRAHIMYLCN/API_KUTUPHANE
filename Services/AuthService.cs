using KutuphaneAPI.Context;
using KutuphaneAPI.Interfaces;
using KutuphaneAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KutuphaneAPI.Services;

public class AuthService : IAuthService {
    private readonly AppDbContext _context;
    public AuthService(AppDbContext context) { _context = context; }

    public string Login(string username, string password) {
        // 1. ADMIN GİRİŞİ (Burası değişmedi, hala patron sensin)
        if (username == "admin" && password == "admin1905") {
            return GenerateToken(username, "Admin");
        }

        // 2. KULLANICI GİRİŞİ (Burası güncellendi)
        // Kullanıcı adı (veya email) VE şifre eşleşiyor mu?
        var user = _context.Users.FirstOrDefault(u => 
            (u.Email == username || u.Name == username) && 
            u.Password == password && 
            !u.IsDeleted);

        if (user != null) {
            // Şifre doğruysa "User" rolüyle token ver
            return GenerateToken(user.Name, "User");
        }

        // Kimse bulunamadı
        return null!;
    }

    private string GenerateToken(string userName, string role) {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes("BuSizinCokGizliVeUzunAnahtariniz123!");
        var tokenDescriptor = new SecurityTokenDescriptor {
            Subject = new ClaimsIdentity(new[] { 
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, role) 
            }),
            Expires = DateTime.UtcNow.AddHours(3),
            Issuer = "KutuphaneAPI",
            Audience = "KutuphaneUser",
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
    }
}