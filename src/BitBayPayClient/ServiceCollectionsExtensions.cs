using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BitBayPayClient
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection AddBitBayPayClient(this IServiceCollection services,
            IConfiguration configuration)
        {
            var bitBayConfiguration = configuration.GetSection("BitBayPay");
            var privateKey = bitBayConfiguration[nameof(BitBayApiConfiguration.PrivateKey)];
            var publicKey = bitBayConfiguration[nameof(BitBayApiConfiguration.PublicKey)];
            services.AddTransient<IBitBayPayService>(c =>
                new BitBayPayService(new BitBayApiConfiguration(publicKey, privateKey)));
            return services;
        }

        public static IServiceCollection AddBitBayPayClient(this IServiceCollection services, string privateKey,
            string publicKey)
        {
            services.AddTransient<IBitBayPayService>(c =>
                new BitBayPayService(new BitBayApiConfiguration(publicKey, privateKey)));
            return services;
        }
    }
}