using System;
using System.Collections.Generic;
using System.Text;

namespace UserAPI.Core.Domain
{
    class EventHeader
    {
        public bool PublicEvent { get; protected set; }
        public int Id { get; protected set; }
        public DateTime Time { get; protected set; }
        public string Name { get; protected set; }

        //public int LocationId { get; set; }
        //public int OrganizationId { get; set; }
        //public int AgeLimit { get; set; }
        //public int MaxParticipants {get; set; }
        //public int Score { get; set; }
        // public int Duration { get; set; }

    }
}
