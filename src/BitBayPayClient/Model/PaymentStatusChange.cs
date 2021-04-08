using System;

namespace BitBayPayClient.Model
{
    public class PaymentStatusChange
    {
        public Guid PaymentId { get; set; }
        public Guid OrderId { get; set; }
        public decimal AmountToPayInSourceCurrency { get; set; }
        public decimal AmountToPayInDestinationCurrency { get; set; }
        public PaymentStatus Status { get; set; }
        public decimal? PaidAmount { get; set; }
        public decimal Price { get; set; }
    }

    public enum PaymentStatus
    {
        PAID,
        PENDING,
        COMPLETED,
        EXPIRED
    }
}