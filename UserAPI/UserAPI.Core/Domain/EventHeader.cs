using System;
using System.Collections.Generic;
using System.Text;

namespace UserAPI.Core.Domain
{
    public class EventHeader : Entity
    {
        public string Name { get; set; }

        public EventHeader()
        {

        }

        public EventHeader(Guid id, string name)
        {
            Name = name;
            Id = id;
        }

    }
}
