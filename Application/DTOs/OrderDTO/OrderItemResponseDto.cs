using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Application.DTOs.OrderDTO
{
    public class OrderItemResponseDto
    {
        public string ProductName { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Total => UnitPrice * Quantity;
    }

}
