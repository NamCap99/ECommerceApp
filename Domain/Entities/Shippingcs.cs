namespace E_Commerce.Domain.Entities
{
    public class Shipping
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order? Order { get; set; }

        public string Address { get; set; } = null!;

        public string Status { get; set; } = "Pending";

        public DateTime ShippingDate { get; set; }

        public string? TrackingNumber { get; set; }
    }

}
