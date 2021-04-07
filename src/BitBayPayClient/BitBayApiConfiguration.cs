namespace BitBayPayClient
{
    public class BitBayApiConfiguration
    {
        public BitBayApiConfiguration()
        {
        }

        public BitBayApiConfiguration(string publicKey, string privateKey)
        {
            PublicKey = publicKey;
            PrivateKey = privateKey;
        }

        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
    }
}