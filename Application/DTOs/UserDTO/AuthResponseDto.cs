using System.ComponentModel.DataAnnotations;


namespace E_Commerce.Application.DTOs.UserDTO
{
    public class AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
    }

}
