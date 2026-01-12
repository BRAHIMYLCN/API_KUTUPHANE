using KutuphaneAPI.Models;

namespace KutuphaneAPI.Interfaces;

public interface IAuthorService {
    Task<List<Author>> GetAllAuthorsAsync();
    Task<Author> GetAuthorByIdAsync(int id);
    Task<Author> CreateAuthorAsync(Author author);
    Task<Author> UpdateAuthorAsync(int id, Author author);
    Task<bool> DeleteAuthorAsync(int id);
}