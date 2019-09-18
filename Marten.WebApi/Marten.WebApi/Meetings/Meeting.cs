using System;

namespace Marten.WebApi.Meetings
{
    public class Meeting
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
    }
}