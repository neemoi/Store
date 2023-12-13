using Application.DTOModels.Models.Admin.Authorization;
using Application.DTOModels.Response.Admin.Authorization;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Interfaces.IServices.Admin
{
    public interface IAccountService
    {
        Task<LoginResponseDto> LoginAsync(LoginDto model);

        Task<RegisterResponseDto> RegisterAsync(RegisterDto model);

        Task<LogoutResponseDto> LogoutAsync(HttpContext httpContext);
    }
}
