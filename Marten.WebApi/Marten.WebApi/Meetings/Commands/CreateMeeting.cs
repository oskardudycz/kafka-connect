using System;
using MediatR;

namespace Marten.WebApi.Meetings.Commands
{
    public class CreateMeeting : IRequest
    {
        public Guid Id { get; }
        public string Name { get; }

        public CreateMeeting(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}