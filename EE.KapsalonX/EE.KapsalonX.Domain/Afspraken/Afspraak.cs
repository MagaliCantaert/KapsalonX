using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EE.KapsalonX.Domain.Afspraken
{
    public class Afspraak
    {
        public Guid AfspraakId { get; set; }
        public Klant KlantGegevens { get; set; }
        public Behandeling BehandelingGegevens { get; set; }

        [NotMapped]
        public string Datum { get; set; }
        public string Tijdstip { get; set; }
        public string Opmerking { get; set; }



    }
}
