using System;
using System.Threading.Tasks;
using BitBayPayClient.Model;
using Flurl;
using Flurl.Http;

namespace BitBayPayClient
{
    public class BitBayPayService : IBitBayPayService
    {
        private const string _apiBaseurl = "https://api.bitbaypay.com/rest/bitbaypay";
        private BitBayApiConfiguration _bitBayApiConfiguration;

        public BitBayPayService(BitBayApiConfiguration bitBayApiConfiguration)
        {
            _bitBayApiConfiguration = bitBayApiConfiguration;
        }

        public async Task<BitBayPayResponse<AvailableCurrency[]>> GetAvailablePaymentCurrencyPairs(
            PaymentType paymentType)
        {
            var operationId = Guid.NewGuid();
            return await _apiBaseurl
                .AppendPathSegment("stores/markets")
                .AllowHttpStatus("*")
                .WithBitBayAuth(_bitBayApiConfiguration, operationId)
                .SetQueryParams(new
                {
                    paymentType
                })
                .GetAsync()
                .ReceiveJson<BitBayPayResponse<AvailableCurrency[]>>();
        }

        public async Task<BitBayPayResponse<CreatePaymentResponse>> CreatePayment(string destinationCurrency,
            double price,
            Guid orderId,
            string sourceCurrency,
            string successCallbackUrl,
            string failureCallbackUrl,
            string notificationsUrl,
            CoveredBy coveredBy,
            bool keepSourceCurrency
        )
        {
            var operationId = Guid.NewGuid();
            var requestParams = new
            {
                destinationCurrency,
                price,
                orderId = orderId.ToString(),
                sourceCurrency,
                coveredBy,
                keepSourceCurrency,
                successCallbackUrl,
                failureCallbackUrl,
                notificationsUrl
            };
            var jsonContent = new JsonContent(requestParams);
            var result = await _apiBaseurl
                .AppendPathSegment("payments")
                .AllowHttpStatus("*")
                .WithBitBayAuth(_bitBayApiConfiguration, operationId, jsonContent.Content)
                .PostAsync(jsonContent)
                .ReceiveJson<BitBayPayResponse<CreatePaymentResponse>>();
            return result;
        }
    }
}