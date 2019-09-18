using Marten.WebApi.Meetings;
using Marten.WebApi.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Marten.WebApi
{
    public static class Config
    {
        public static void AddMeetingsManagement(this IServiceCollection services, IConfiguration config)
        {
            services.AddMarten(config, options =>
            {
                Meetings.Config.ConfigureMarten(options);
            });
            services.AddMeeting();
        }
    }
}