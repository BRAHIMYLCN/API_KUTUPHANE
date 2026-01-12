using KutuphaneAPI.Models;
using KutuphaneAPI.DTOs;

namespace KutuphaneAPI.Interfaces;

public interface IUserService {
    Task<List<User>> GetAllUsersAsync();
    Task<User> GetUserByIdAsync(int id);
    Task<User> CreateUserAsync(UserCreateDto dto); // POST İÇİN
    Task<User> UpdateUserAsync(int id, UserCreateDto dto); // PUT İÇİN
    Task<bool> DeleteUserAsync(int id); // DELETE İÇİN
}