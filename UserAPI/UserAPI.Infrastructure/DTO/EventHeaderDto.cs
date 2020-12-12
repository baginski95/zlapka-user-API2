using System;
using System.Collections.Generic;
using System.Text;

namespace UserAPI.Infrastructure.DTO
{
    class EventHeaderDto
    {
        public bool PublicEvent { get; protected set; }
        public int Id { get; protected set; }
        public DateTime Time { get; protected set; }
        public string Name { get; protected set; }

        public EventHeaderDto()
        {

        }

        public EventHeaderDto(int id, string name, DateTime time, bool publicEvent)
        {
            Id = id;
            Name = name;
            Time = time;
            PublicEvent = publicEvent;
        }

    }
}
