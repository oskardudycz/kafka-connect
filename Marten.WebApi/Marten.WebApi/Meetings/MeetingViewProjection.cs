using System;
using Marten.Events.Projections;
using Marten.WebApi.Meetings.Events;

namespace Marten.WebApi.Meetings
{
    public class MeetingViewProjection : ViewProjection<Meeting, Guid>
    {
        public MeetingViewProjection()
        {
            ProjectEvent<MeetingCreated>(e => e.MeetingId, Apply);
            ProjectEvent<MeetingUpdated>(e => e.MeetingId, Apply);
        }

        private void Apply(Meeting view, MeetingCreated @event)
        {
            view.Id = @event.MeetingId;
            view.Name = @event.Name;
            view.Created = @event.Created;
        }

        private void Apply(Meeting view, MeetingUpdated @event)
        {
            view.Name = @event.Name;
        }
    }
}