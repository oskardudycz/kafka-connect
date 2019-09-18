using System.Collections.Generic;
using MediatR;

namespace Marten.WebApi.Meetings.Queries
{
    public class GetMeetings : IRequest<IReadOnlyList<Meeting>>
    {
    }
}