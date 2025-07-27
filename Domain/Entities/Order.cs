namespace E_Commerce.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public string OrderStatus { get; set; } = "Pending"; // Enum preferred

        public string PaymentStatus { get; set; } = "Unpaid";

        public decimal TotalAmount { get; set; }

        public string? ShippingAddress { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Payment? Payment { get; set; }

        public Shipping? Shipping { get; set; }
    }
}
