using E_Commerce.Domain.Entities;
using System.ComponentModel.DataAnnotations;

public class OrderCreateDto
{
    [Required]
    public int UserId { get; set; }

    [Required]
    [MinLength(1, ErrorMessage = "At least one order item is required.")]
    public List<OrderCreateDto> Items { get; set; } = new();

    [Required]
    [MaxLength(250)]
    public string ShippingAddress { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string PaymentMethod { get; set; } = "CreditCard";

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Total amount must be greater than 0.")]
    public decimal TotalAmount { get; set; }
}
