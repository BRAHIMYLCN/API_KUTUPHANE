namespace KutuphaneAPI.Models;

public class Author {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    // YENİ EKLENEN
    public DateTime? UpdatedAt { get; set; }
}