namespace KutuphaneAPI.DTOs;

public class BorrowResponseDto {
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty; // Kullanıcı ID değil İsmi
    public string BookTitle { get; set; } = string.Empty; // Kitap ID değil Başlığı
    public DateTime BorrowDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public bool IsReturned { get; set; }
}