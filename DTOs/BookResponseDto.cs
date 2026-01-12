namespace KutuphaneAPI.DTOs;

public class BookResponseDto {
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public string AuthorName { get; set; } = string.Empty;
}