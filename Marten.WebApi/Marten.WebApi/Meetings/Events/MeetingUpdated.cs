using System;

namespace Marten.WebApi.Meetings.Events
{
    public class MeetingUpdated
    {
        public Guid MeetingId { get; }
        public string Name { get; }

        public MeetingUpdated(Guid meetingId, string name)
        {
            MeetingId = meetingId;
            Name = name;
        }
    }
}