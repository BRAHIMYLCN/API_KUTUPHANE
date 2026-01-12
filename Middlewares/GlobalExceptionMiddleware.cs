using KutuphaneAPI.Models;
using System.Net;
using System.Text.Json;

namespace KutuphaneAPI.Middlewares;

public class GlobalExceptionMiddleware {
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next) {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext) {
        try {
            await _next(httpContext);
        } catch (Exception ex) {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception) {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = ApiResponse<string>.Hatali($"Sunucu Hatası: {exception.Message}");
        
        var json = JsonSerializer.Serialize(response);
        await context.Response.WriteAsync(json);
    }
}