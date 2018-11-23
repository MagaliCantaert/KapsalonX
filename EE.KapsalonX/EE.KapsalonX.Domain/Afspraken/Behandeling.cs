using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EE.KapsalonX.Domain.Afspraken
{
    public class Behandeling
    {
        public Guid BehandelingId { get; set; }
        public string Geslacht { get; set; }

        [Display(Name = "Behandeling")]
        public string GekozenBehandeling { get; set; }

        //public DateTime DuurTijd { get; set; }
    }
}
