using KutuphaneAPI.Interfaces;
using KutuphaneAPI.Models;
using KutuphaneAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase {
    private readonly IBookService _bookService;
    // HOCANIN İSTEDİĞİ LOGGING SERVİSİ
    private readonly ILogger<BookController> _logger;

    public BookController(IBookService bookService, ILogger<BookController> logger) {
        _bookService = bookService;
        _logger = logger;
    }

    // GET: Tüm Kitaplar (DTO + Log)
    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<BookResponseDto>>>> GetAll() {
        // LOG ATIYORUZ
        _logger.LogInformation("Kullanıcı kitap listesini çağırdı.");
        
        var books = await _bookService.GetAllBooksAsync();
        
        // Entity -> DTO Dönüşümü
        var dtos = books.Select(b => new BookResponseDto {
            Id = b.Id,
            Title = b.Title,
            ISBN = b.ISBN,
            AuthorName = b.Author?.Name ?? "Bilinmiyor"
        }).ToList();

        return Ok(ApiResponse<List<BookResponseDto>>.Basarili(dtos, "Kitaplar listelendi."));
    }

    // GET: ID (DTO + Log)
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<BookResponseDto>>> GetById(int id) {
        var book = await _bookService.GetBookByIdAsync(id);
        if (book == null) {
            _logger.LogWarning($"GetById: {id} numaralı kitap bulunamadı.");
            return NotFound(ApiResponse<BookResponseDto>.Hatali("Kitap bulunamadı."));
        }
        
        var dto = new BookResponseDto {
            Id = book.Id, Title = book.Title, ISBN = book.ISBN, AuthorName = book.Author?.Name ?? "Bilinmiyor"
        };
        
        return Ok(ApiResponse<BookResponseDto>.Basarili(dto));
    }

    // POST: Ekleme (201 Created + Log)
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<ApiResponse<BookResponseDto>>> Create([FromBody] BookCreateDto dto) {
        _logger.LogInformation($"Yeni kitap ekleniyor: {dto.Title}");
        
        var book = await _bookService.CreateBookAsync(dto);
        
        var responseDto = new BookResponseDto {
            Id = book.Id, Title = book.Title, ISBN = book.ISBN, AuthorName = "ID ile eklendi"
        };

        // HOCANIN İSTEDİĞİ 201 CREATED KODU
        return StatusCode(201, ApiResponse<BookResponseDto>.Basarili(responseDto, "Kitap başarıyla eklendi."));
    }

    // PUT: Güncelleme
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<ApiResponse<BookResponseDto>>> Update(int id, [FromBody] BookCreateDto dto) {
        var book = await _bookService.UpdateBookAsync(id, dto);
        if (book == null) return NotFound(ApiResponse<BookResponseDto>.Hatali("Güncellenecek kitap bulunamadı."));

        var responseDto = new BookResponseDto {
             Id = book.Id, Title = book.Title, ISBN = book.ISBN, AuthorName = "Güncellendi"
        };

        return Ok(ApiResponse<BookResponseDto>.Basarili(responseDto, "Kitap güncellendi."));
    }

    // DELETE: Silme
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(int id) {
        var result = await _bookService.DeleteBookAsync(id);
        if (!result) {
            _logger.LogError($"Silme başarısız. ID: {id}");
            return NotFound(ApiResponse<bool>.Hatali("Silinecek kitap yok."));
        }
        
        _logger.LogInformation($"Kitap silindi. ID: {id}");
        return Ok(ApiResponse<bool>.Basarili(true, "Kitap silindi."));
    }
}