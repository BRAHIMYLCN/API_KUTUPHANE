using KutuphaneAPI.Interfaces;
using KutuphaneAPI.Models;
using KutuphaneAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class BorrowController : ControllerBase {
    private readonly IBorrowService _borrowService;

    public BorrowController(IBorrowService borrowService) {
        _borrowService = borrowService;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<BorrowResponseDto>>>> GetAll() {
        var borrows = await _borrowService.GetAllBorrowsAsync();
        
        // Entity -> DTO Dönüşümü (Kurala Uygunluk)
        var dtos = borrows.Select(b => new BorrowResponseDto {
            Id = b.Id,
            UserName = $"{b.User?.Name} {b.User?.LastName}", // İsim Soyisim birleşti
            BookTitle = b.Book?.Title ?? "Silinmiş Kitap",
            BorrowDate = b.BorrowDate,
            ReturnDate = b.ReturnDate,
            IsReturned = b.IsReturned
        }).ToList();

        return Ok(ApiResponse<List<BorrowResponseDto>>.Basarili(dtos, "Ödünç kayıtları listelendi."));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<BorrowRecord>>> Borrow([FromBody] BorrowCreateDto dto) {
        try {
            var borrow = await _borrowService.BorrowBookAsync(dto);
            // KURAL: Oluşturulan kaynak için 201 Created dönülür
            return StatusCode(201, ApiResponse<BorrowRecord>.Basarili(borrow, "Kitap ödünç alındı."));
        } catch (Exception ex) {
            return BadRequest(ApiResponse<BorrowRecord>.Hatali("Ödünç alma başarısız: " + ex.Message));
        }
    }

    [HttpPut("return/{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> ReturnBook(int id) {
        var result = await _borrowService.ReturnBookAsync(id);
        if (!result) return NotFound(ApiResponse<bool>.Hatali("Kayıt bulunamadı."));
        return Ok(ApiResponse<bool>.Basarili(true, "Kitap iade edildi."));
    }
}