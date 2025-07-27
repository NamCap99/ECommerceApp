namespace E_Commerce.Domain.Entities
{
    public class Cart
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsCheckedOut { get; set; }

        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
