using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Marten.WebApi.Meetings.Queries;
using MediatR;

namespace Marten.WebApi.Meetings
{
    public class MeetingQueryHandler :
        IRequestHandler<GetMeetings, IReadOnlyList<Meeting>>,
        IRequestHandler<GetMeeting, Meeting>
    {
        private readonly IDocumentSession documentSession;

        public MeetingQueryHandler(IDocumentSession documentSession)
        {
            this.documentSession = documentSession;
        }

        public Task<IReadOnlyList<Meeting>> Handle(GetMeetings query, CancellationToken cancellationToken)
        {
            return documentSession.Query<Meeting>().ToListAsync();
        }

        public Task<Meeting> Handle(GetMeeting query, CancellationToken cancellationToken)
        {
            return documentSession.Query<Meeting>().SingleOrDefaultAsync(m => m.Id == query.MeetingId);
        }
    }
}