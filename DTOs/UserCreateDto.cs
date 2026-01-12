namespace KutuphaneAPI.DTOs;

public class UserCreateDto {
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    
    // YENİ: Kayıt ekranında şifre kutusu açtık
    public string Password { get; set; } = string.Empty; 
}