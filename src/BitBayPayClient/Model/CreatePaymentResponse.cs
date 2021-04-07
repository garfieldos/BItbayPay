using System;

namespace BitBayPayClient.Model
{
    public class CreatePaymentResponse
    {
        public Guid PaymentId { get; set; }
        public string Url { get; set; }
    }
}