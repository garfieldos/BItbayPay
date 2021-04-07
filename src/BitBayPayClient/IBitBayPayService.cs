using System;
using System.Threading.Tasks;
using BitBayPayClient.Model;

namespace BitBayPayClient
{
    public interface IBitBayPayService
    {
        Task<BitBayPayResponse<AvailableCurrency[]>> GetAvailablePaymentCurrencyPairs(
            PaymentType paymentType);

        Task<BitBayPayResponse<CreatePaymentResponse>> CreatePayment(string destinationCurrency,
            double price,
            Guid orderId,
            string? sourceCurrency,
            string successCallbackUrl,
            string failureCallbackUrl,
            string notificationsUrl,
            CoveredBy coveredBy,
            bool keepSourceCurrency
        );
    }
}