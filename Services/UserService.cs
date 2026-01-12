using KutuphaneAPI.Context;
using KutuphaneAPI.Interfaces;
using KutuphaneAPI.Models;
using KutuphaneAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneAPI.Services;

public class UserService : IUserService {
    private readonly AppDbContext _context;
    public UserService(AppDbContext context) { _context = context; }

    public async Task<List<User>> GetAllUsersAsync() => 
        await _context.Users.Where(u => !u.IsDeleted).ToListAsync();

    public async Task<User> GetUserByIdAsync(int id) => 
        await _context.Users.FirstOrDefaultAsync(u => u.Id == id && !u.IsDeleted) ?? null!;

    public async Task<User> CreateUserAsync(UserCreateDto dto) {
        var user = new User { 
            Name = dto.Name, 
            LastName = dto.LastName, 
            Email = dto.Email, 
            Address = dto.Address,
            Password = dto.Password // Şifreyi kaydettik
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateUserAsync(int id, UserCreateDto dto) {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return null!;

        user.Name = dto.Name;
        user.LastName = dto.LastName;
        user.Email = dto.Email;
        user.Address = dto.Address;
        
        // Eğer yeni bir şifre gönderdiyse güncelle, göndermediyse eskisini koru
        if (!string.IsNullOrEmpty(dto.Password)) {
            user.Password = dto.Password;
        }

        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<bool> DeleteUserAsync(int id) {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return false;
        user.IsDeleted = true;
        await _context.SaveChangesAsync();
        return true;
    }
}