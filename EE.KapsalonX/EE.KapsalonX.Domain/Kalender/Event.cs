using System;
using System.Collections.Generic;
using System.Text;

namespace EE.KapsalonX.Domain.Kalender
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAllDay { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

    }
}
