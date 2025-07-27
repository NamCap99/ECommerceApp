namespace E_Commerce.Application.DTOs.OrderDTO
{
    public class OrderResponseDto
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public List<OrderItemResponseDto> Items { get; set; } = new();

        public decimal TotalAmount { get; set; }

        public string PaymentStatus { get; set; } = string.Empty;

        public string ShippingAddress { get; set; } = string.Empty;
    }
}
