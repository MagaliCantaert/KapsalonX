using System;
using System.Collections.Generic;
using System.Text;

namespace EE.KapsalonX.Domain.Kalender
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Behandeling { get; set; }
        public DateTime StartTijd { get; set; }
        public DateTime EindTijd { get; set; }
        public string Klant { get; set; }

    }
}
