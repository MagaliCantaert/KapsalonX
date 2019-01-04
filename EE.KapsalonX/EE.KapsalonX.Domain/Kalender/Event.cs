using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EE.KapsalonX.Domain.Kalender
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Behandeling { get; set; }
        public DateTime StartTijd { get; set; }
        public DateTime EindTijd { get; set; }
        [NotMapped]
        public TimeSpan DuurTijd { get; set; }
        public string Klant { get; set; }

    }
}
