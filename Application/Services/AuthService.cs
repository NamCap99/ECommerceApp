using E_Commerce.Application.Interfaces;
using E_Commerce.Domain.Entities;
using E_Commerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using E_Commerce.Application.DTOs.UserDTO;

public class AuthService : IAuthService
{
    private readonly ECommerceDbContext _db;
    private readonly ITokenService _tokenService;

    public AuthService(ECommerceDbContext db, ITokenService tokenService)
    {
        _db = db;
        _tokenService = tokenService;
    }

    public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request)
    {
        if (await _db.Users.AnyAsync(u => u.Email == request.Email))
            throw new Exception("Email already exists");

        var hasher = new PasswordHasher<User>();
        var user = new User
        {
            FullName = request.FullName,
            Email = request.Email,
            Role = "User"
        };
        user.PasswordHash = hasher.HashPassword(user, request.Password);

        var refreshToken = _tokenService.GenerateRefreshToken();

        _db.Users.Add(user);
        await _db.SaveChangesAsync();

        return new AuthResponseDto
        {
            Token = _tokenService.GenerateJwtToken(user),
            RefreshToken = refreshToken,
            Expiration = DateTime.UtcNow.AddMinutes(15)
        };
    }

    public async Task<AuthResponseDto> LoginAsync(LoginRequestDto request)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
        if (user == null) throw new Exception("Invalid credentials");

        var hasher = new PasswordHasher<User>();
        var result = hasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
        if (result == PasswordVerificationResult.Failed) throw new Exception("Invalid credentials");

        return new AuthResponseDto
        {
            Token = _tokenService.GenerateJwtToken(user),
            RefreshToken = _tokenService.GenerateRefreshToken(),
            Expiration = DateTime.UtcNow.AddMinutes(15)
        };
    }
}
