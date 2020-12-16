using System;

namespace UserAPI.Core.Domain
{
    public class LocationHeader : Entity
    {
        public string Name { get; set; }

        public LocationHeader()
        {

        }

        public LocationHeader(Guid id, string name)
        {
            Name = name;
            Id = id;
        }
    }
}

