using System;
using System.Threading;
using System.Threading.Tasks;
using Marten.WebApi.Meetings.Commands;
using Marten.WebApi.Meetings.Events;
using MediatR;

namespace Marten.WebApi.Meetings
{
    public class MeetingCommandHandler :
        IRequestHandler<UpdateMeeting, Unit>,
        IRequestHandler<CreateMeeting, Unit>
    {
        private readonly IDocumentSession documentSession;

        public MeetingCommandHandler(IDocumentSession documentSession)
        {
            this.documentSession = documentSession;
        }

        public async Task<Unit> Handle(CreateMeeting request, CancellationToken cancellationToken)
        {
            var @event = new MeetingCreated(request.Id, request.Name, DateTime.UtcNow);

            documentSession.Events.StartStream(request.Id, @event);

            await documentSession.SaveChangesAsync();

            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateMeeting request, CancellationToken cancellationToken)
        {
            var @event = new MeetingUpdated(request.Id, request.Name);

            documentSession.Events.Append(request.Id, @event);

            await documentSession.SaveChangesAsync();

            return Unit.Value;
        }
    }
}