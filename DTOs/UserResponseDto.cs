namespace KutuphaneAPI.DTOs;

public class UserResponseDto {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    // Password YOK! Gizledik.
}