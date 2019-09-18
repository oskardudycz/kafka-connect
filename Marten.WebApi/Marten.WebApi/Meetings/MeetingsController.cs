using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Marten.WebApi.Meetings.Commands;
using Marten.WebApi.Meetings.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Marten.WebApi.Meetings
{
    [Route("api/[controller]")]
    public class MeetingsController : Controller
    {
        private readonly IMediator mediator;

        public MeetingsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public Task<IReadOnlyList<Meeting>> Get()
        {
            return mediator.Send(new GetMeetings());
        }

        [HttpGet("{id}")]
        public Task<Meeting> Get(Guid id)
        {
            return mediator.Send(new GetMeeting(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateMeeting command)
        {
            await mediator.Send(command);

            return Created("api/Meetings", command.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Post([FromRoute] Guid id, [FromBody]string name)
        {
            var command = new UpdateMeeting(id, name);
            await mediator.Send(command);

            return Ok();
        }
    }
}