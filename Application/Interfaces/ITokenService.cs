using E_Commerce.Application.DTOs.UserDTO;
using E_Commerce.Domain.Entities;
using System.Security.Claims;

namespace E_Commerce.Application.Interfaces
{

public interface ITokenService
{
    string GenerateJwtToken(User user);
    string GenerateRefreshToken();
    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
}
}