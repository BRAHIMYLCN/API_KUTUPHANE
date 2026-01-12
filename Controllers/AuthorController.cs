using KutuphaneAPI.Interfaces;
using KutuphaneAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase {
    private readonly IAuthorService _authorService;
    private readonly KutuphaneAPI.Context.AppDbContext _context;

    public AuthorController(IAuthorService authorService, KutuphaneAPI.Context.AppDbContext context) { 
        _authorService = authorService; 
        _context = context;
    }

    [HttpGet] 
    public async Task<ActionResult<ApiResponse<List<Author>>>> GetAll() {
        var authors = await _authorService.GetAllAuthorsAsync();
        return Ok(ApiResponse<List<Author>>.Basarili(authors, "Yazarlar listelendi."));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<Author>>> GetById(int id) {
        var author = await _authorService.GetAuthorByIdAsync(id);
        if (author == null) return NotFound(ApiResponse<Author>.Hatali("Yazar bulunamadı."));
        return Ok(ApiResponse<Author>.Basarili(author));
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<ApiResponse<Author>>> Create([FromBody] Author author) {
        var newAuthor = await _authorService.CreateAuthorAsync(author);
        return Ok(ApiResponse<Author>.Basarili(newAuthor, "Yazar eklendi."));
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<ApiResponse<Author>>> Update(int id, [FromBody] Author author) {
        var updatedAuthor = await _authorService.UpdateAuthorAsync(id, author);
        if (updatedAuthor == null) return NotFound(ApiResponse<Author>.Hatali("Güncellenecek yazar bulunamadı."));
        
        // UpdatedAt'i elle tetikleyelim
        updatedAuthor.UpdatedAt = DateTime.Now;
        await _context.SaveChangesAsync();

        return Ok(ApiResponse<Author>.Basarili(updatedAuthor, "Yazar güncellendi."));
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(int id) {
        var result = await _authorService.DeleteAuthorAsync(id);
        if (!result) return NotFound(ApiResponse<bool>.Hatali("Silinecek yazar yok."));
        return Ok(ApiResponse<bool>.Basarili(true, "Yazar silindi."));
    }
}