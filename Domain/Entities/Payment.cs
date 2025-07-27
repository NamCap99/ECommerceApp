namespace E_Commerce.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order? Order { get; set; }

        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; } = "CreditCard";

        public string? TransactionId { get; set; }

        public string Status { get; set; } = "Pending";

        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
    }

}
