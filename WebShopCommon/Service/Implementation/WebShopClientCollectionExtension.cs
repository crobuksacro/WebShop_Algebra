using Microsoft.Extensions.DependencyInjection;
using WebShopCommon.Service.Interface;

namespace WebShopCommon.Service.Implementation
{
    public static class WebShopClientCollectionExtension
    {
        public static IServiceCollection WebShoopServiceClient(this IServiceCollection services, string webShopBaseUrl)
        {
            services.AddHttpClient(nameof(IWebShopServiceClient))
                .AddTypedClient<IWebShopServiceClient>(c => new WebShopServiceClient(c))
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri(webShopBaseUrl);
                }
                );

            return services;
        }
    }
}
