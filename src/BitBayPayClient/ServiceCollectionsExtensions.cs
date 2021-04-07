using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BitBayPayClient
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection AddBitBayPayClient(this IServiceCollection services,
            IConfiguration configuration)
        {
            var bitBayConfiguration = configuration.GetSection("BitBayPay").Get<BitBayApiConfiguration>();
            services.AddTransient<IBitBayPayService>(c =>
                new BitBayPayService(bitBayConfiguration));
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