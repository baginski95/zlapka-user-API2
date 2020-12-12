using System;
using System.Collections.Generic;
using System.Text;

namespace UserAPI.Infrastructure.DTO
{
    public class EventHeaderDto
    {
        public bool PublicEvent { get; set; }
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Name { get; set; }

    }
}
