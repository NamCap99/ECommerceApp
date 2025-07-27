using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Application.DTOs.OrderDTO
{
    public class OrderUpdateDto
    {
        [Required]
        public string PaymentStatus { get; set; } = string.Empty;

        [Required]
        public string ShippingAddress { get; set; } = string.Empty;
    }
}
