using System;
using System.Collections.Generic;
using System.Text;

namespace EE.KapsalonX.Domain.Kalender
{
    public class Event
    {
        public int Id { get; set; }
        public string Tekst { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
    }
}
