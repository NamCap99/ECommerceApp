using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Application.DTOs.Product
{
    public class ProductCreateDto
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stock must be a non-negative number.")]
        public int StockQuantity { get; set; }
    }
}
