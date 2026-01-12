using KutuphaneAPI.Context;
using KutuphaneAPI.Interfaces;
using KutuphaneAPI.Models;
using KutuphaneAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneAPI.Services;

public class BookService : IBookService 
{
    private readonly AppDbContext _context;
    public BookService(AppDbContext context) { _context = context; }

    public async Task<List<Book>> GetAllBooksAsync() 
    {
        return await _context.Books
            .Include(b => b.Author)
            .Where(b => !b.IsDeleted)
            .ToListAsync();
    }

    public async Task<Book> GetBookByIdAsync(int id) 
    {
        var book = await _context.Books
            .Include(b => b.Author)
            .FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted);
        return book!;
    }

    public async Task<Book> CreateBookAsync(BookCreateDto dto) 
    {
        var book = new Book { Title = dto.Title, ISBN = dto.ISBN, AuthorId = dto.AuthorId };
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return book;
    }

    public async Task<Book> UpdateBookAsync(int id, BookCreateDto dto) 
    {
        var book = await _context.Books.FindAsync(id);
        if (book != null) {
            book.Title = dto.Title; book.ISBN = dto.ISBN; book.AuthorId = dto.AuthorId;
            await _context.SaveChangesAsync();
        }
        return book!;
    }

    public async Task<bool> DeleteBookAsync(int id) 
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null) return false;
        book.IsDeleted = true;
        await _context.SaveChangesAsync();
        return true;
    }
}