using Microsoft.Extensions.DependencyInjection;

namespace Marten.WebApi.Core
{
    public static class Config
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddMediatR();
        }
    }
}