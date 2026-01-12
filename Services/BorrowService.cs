using KutuphaneAPI.Context;
using KutuphaneAPI.Interfaces;
using KutuphaneAPI.Models;
using KutuphaneAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneAPI.Services;

public class BorrowService : IBorrowService {
    private readonly AppDbContext _context;

    public BorrowService(AppDbContext context) {
        _context = context;
    }

    public async Task<List<BorrowRecord>> GetAllBorrowsAsync() {
        // HATA BURADAYDI: BorrowRecords yerine Borrows yazdık
        return await _context.Borrows
            .Include(b => b.User) // Kullanıcı bilgisini de getir
            .Include(b => b.Book) // Kitap bilgisini de getir
            .ToListAsync();
    }

    public async Task<BorrowRecord> BorrowBookAsync(BorrowCreateDto dto) {
        var borrow = new BorrowRecord {
            UserId = dto.UserId,
            BookId = dto.BookId,
            BorrowDate = DateTime.UtcNow,
            IsReturned = false
        };

        // HATA BURADAYDI: BorrowRecords yerine Borrows
        _context.Borrows.Add(borrow);
        await _context.SaveChangesAsync();
        return borrow;
    }

    public async Task<bool> ReturnBookAsync(int recordId) {
        // HATA BURADAYDI: BorrowRecords yerine Borrows
        var record = await _context.Borrows.FindAsync(recordId);
        if (record == null) return false;

        record.IsReturned = true;
        record.ReturnDate = DateTime.UtcNow;
        
        await _context.SaveChangesAsync();
        return true;
    }
}