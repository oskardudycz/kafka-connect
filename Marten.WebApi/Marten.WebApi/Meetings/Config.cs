using System.Collections.Generic;
using Marten.WebApi.Meetings.Commands;
using Marten.WebApi.Meetings.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Marten.WebApi.Meetings
{
    public static class Config
    {
        public static void AddMeeting(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<CreateMeeting, Unit>, MeetingCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateMeeting, Unit>, MeetingCommandHandler>();

            services.AddScoped<IRequestHandler<GetMeetings, IReadOnlyList<Meeting>>, MeetingQueryHandler>();
            services.AddScoped<IRequestHandler<GetMeeting, Meeting>, MeetingQueryHandler>();
        }

        public static void ConfigureMarten(StoreOptions options)
        {
            options.Events.InlineProjections.AggregateStreamsWith<Meeting>();
            options.Events.InlineProjections.Add<MeetingViewProjection>();
        }
    }
}