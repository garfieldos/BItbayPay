using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Flurl.Http;

namespace BitBayPayClient
{
    public static class UrlExtensions
    {
        public static IFlurlRequest WithBitBayAuth(this IFlurlRequest request,
            BitBayApiConfiguration configuration,
            Guid operationId,
            string? jsonParams = null)
        {
            var requestTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
            var hashSource =
                jsonParams != null
                    ? $"{configuration.PublicKey}{requestTimestamp}{jsonParams}"
                    : $"{configuration.PublicKey}{requestTimestamp}";
            var hash = GetHash(hashSource, configuration.PrivateKey);
            var headers = new Dictionary<string, object>
            {
                {"API-Key", configuration.PublicKey},
                {"API-Hash", hash},
                {"operation-id", operationId},
                {"Request-Timestamp", requestTimestamp},
                {"Content-Type", "application/json"}
            };
            request.WithHeaders(headers);
            return request;
        }

        private static string GetHash(string text, string secretKey)
        {
            var hash = new StringBuilder();
            byte[] secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
            byte[] inputBytes = Encoding.UTF8.GetBytes(text);
            using var hmac = new HMACSHA512(secretKeyBytes);
            byte[] hashValue = hmac.ComputeHash(inputBytes);
            foreach (var theByte in hashValue)
                hash.Append(theByte.ToString("x2"));
            return hash.ToString();
        }
    }
}