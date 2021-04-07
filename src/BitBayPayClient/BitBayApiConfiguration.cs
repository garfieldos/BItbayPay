using System;

namespace BitBayPayClient
{
    public class BitBayApiConfiguration
    {
        public BitBayApiConfiguration()
        {
        }

        public BitBayApiConfiguration(string publicKey, string privateKey)
        {
            if (string.IsNullOrWhiteSpace(publicKey))
                throw new ArgumentNullException(nameof(publicKey));
            if (string.IsNullOrWhiteSpace(privateKey))
                throw new ArgumentNullException(nameof(privateKey));
            PublicKey = publicKey;
            PrivateKey = privateKey;
        }

        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
    }
}