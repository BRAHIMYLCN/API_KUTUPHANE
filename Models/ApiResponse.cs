namespace KutuphaneAPI.Models;

public class ApiResponse<T> {
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }

    // Başarılı olduğunda çağır
    public static ApiResponse<T> Basarili(T data, string mesaj = "İşlem başarılı") {
        return new ApiResponse<T> { Success = true, Message = mesaj, Data = data };
    }

    // Hata olduğunda çağır
    public static ApiResponse<T> Hatali(string mesaj) {
        return new ApiResponse<T> { Success = false, Message = mesaj, Data = default };
    }
}