using System;
using System.Collections.Generic;
using System.Text;

namespace EE.KapsalonX.Domain.Afspraken
{
    public class Behandeling
    {
        public Guid BehandelingId { get; set; }
        public string Geslacht { get; set; }
        public string GekozenBehandeling { get; set; }
    }
}
