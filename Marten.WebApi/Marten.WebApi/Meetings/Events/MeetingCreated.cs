using System;

namespace Marten.WebApi.Meetings.Events
{
    public class MeetingCreated
    {
        public Guid MeetingId { get; }
        public string Name { get; }
        public DateTime Created { get; }

        public MeetingCreated(Guid meetingId, string name, DateTime created)
        {
            MeetingId = meetingId;
            Name = name;
            Created = created;
        }
    }
}