using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Marten.WebApi.Core
{
    public static class MediatRConfig
    {
        public static void AddMediatR(this IServiceCollection services)
        {
            services.AddScoped<IMediator, Mediator>();
            services.AddTransient<ServiceFactory>(sp => sp.GetService);
        }
    }
}