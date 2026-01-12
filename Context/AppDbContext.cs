using KutuphaneAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneAPI.Context;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<BorrowRecord> Borrows { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        // İLİŞKİ AYARLARINI SİLDİK (EF Core bunu otomatik anlar)
        // O kısım "AuthorId1" hatasına sebep oluyordu.
        
        // --- YAZARLAR EKLENİYOR ---
        modelBuilder.Entity<Author>().HasData(
            new Author { Id = 1, Name = "J.K. Rowling" },
            new Author { Id = 2, Name = "George Orwell" },
            new Author { Id = 3, Name = "J.R.R. Tolkien" },
            new Author { Id = 4, Name = "Stefan Zweig" },
            new Author { Id = 5, Name = "Fyodor Dostoyevski" }
        );

        // --- KİTAPLAR EKLENİYOR ---
        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "Harry Potter ve Felsefe Taşı", ISBN = "978-1", AuthorId = 1 },
            new Book { Id = 2, Title = "Harry Potter ve Sırlar Odası", ISBN = "978-2", AuthorId = 1 },
            new Book { Id = 3, Title = "1984", ISBN = "978-3", AuthorId = 2 },
            new Book { Id = 4, Title = "Hayvan Çiftliği", ISBN = "978-4", AuthorId = 2 },
            new Book { Id = 5, Title = "Yüzüklerin Efendisi: Yüzük Kardeşliği", ISBN = "978-5", AuthorId = 3 },
            new Book { Id = 6, Title = "Satranç", ISBN = "978-6", AuthorId = 4 },
            new Book { Id = 7, Title = "Suç ve Ceza", ISBN = "978-7", AuthorId = 5 }
        );

        // --- KULLANICI EKLENİYOR ---
        modelBuilder.Entity<User>().HasData(
            new User { 
                Id = 1, 
                Name = "Ahmet", 
                LastName = "Yılmaz", 
                Email = "ahmet@gmail.com", 
                Address = "İstanbul", 
                Password = "123", 
                IsDeleted = false 
            }
        );
    }
}