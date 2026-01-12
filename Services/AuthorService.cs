using KutuphaneAPI.Context;
using KutuphaneAPI.Interfaces;
using KutuphaneAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneAPI.Services;

public class AuthorService : IAuthorService {
    private readonly AppDbContext _context;
    public AuthorService(AppDbContext context) { _context = context; }

    public async Task<List<Author>> GetAllAuthorsAsync() => await _context.Authors.ToListAsync();

    public async Task<Author> GetAuthorByIdAsync(int id) => await _context.Authors.FindAsync(id) ?? null!;

    public async Task<Author> CreateAuthorAsync(Author author) {
        _context.Authors.Add(author);
        await _context.SaveChangesAsync();
        return author;
    }

    public async Task<Author> UpdateAuthorAsync(int id, Author authorUpdate) {
        var author = await _context.Authors.FindAsync(id);
        if (author == null) return null!;
        author.Name = authorUpdate.Name;
        await _context.SaveChangesAsync();
        return author;
    }

    public async Task<bool> DeleteAuthorAsync(int id) {
        var author = await _context.Authors.FindAsync(id);
        if (author == null) return false;
        _context.Authors.Remove(author);
        await _context.SaveChangesAsync();
        return true;
    }
}