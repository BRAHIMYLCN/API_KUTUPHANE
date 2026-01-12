namespace KutuphaneAPI.Models;

public class Book {
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    
    public int AuthorId { get; set; }
    public Author? Author { get; set; } 

    // YENİ EKLENEN: Ödev gereksinimi (CreatedAt zaten vardı, UpdatedAt'i de ekledim)
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; } // Güncellenme tarihi boş olabilir

    // HATAYI ÇÖZEN KISIM: Silindi mi? (Soft Delete)
    public bool IsDeleted { get; set; } = false; 
}