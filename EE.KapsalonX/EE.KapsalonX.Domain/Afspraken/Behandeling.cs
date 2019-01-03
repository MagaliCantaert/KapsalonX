using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EE.KapsalonX.Domain.Afspraken
{
    public class Behandeling
    {
        public Guid BehandelingId { get; set; }
        public string Geslacht { get; set; }

        [Display(Name = "Behandeling")]
        public string GekozenBehandeling { get; set; }

        [NotMapped]
        public DateTime DuurTijd { get; set; }
    }
}
