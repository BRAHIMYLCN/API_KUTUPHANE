using KutuphaneAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase {
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService) { _authService = authService; }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel model) {
        // Burada senin istediðin 'username' ve 'password' kontrolü yapýlýyor
        var token = _authService.Login(model.Username, model.Password);
        if (token == null) return Unauthorized("Kullanýcý adý veya þifre hatalý!");
        return Ok(new { Token = token });
    }
}

public class LoginModel {
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}