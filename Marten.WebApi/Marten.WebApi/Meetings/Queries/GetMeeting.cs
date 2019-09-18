using System;
using MediatR;

namespace Marten.WebApi.Meetings.Queries
{
    public class GetMeeting : IRequest<Meeting>
    {
        public Guid MeetingId { get; }

        public GetMeeting(Guid meetingId)
        {
            MeetingId = meetingId;
        }
    }
}