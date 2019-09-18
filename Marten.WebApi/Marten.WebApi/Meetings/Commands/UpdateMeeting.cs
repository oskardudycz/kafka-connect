using System;
using MediatR;

namespace Marten.WebApi.Meetings.Commands
{
    public class UpdateMeeting : IRequest
    {
        public Guid Id { get; }
        public string Name { get; }

        public UpdateMeeting(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}