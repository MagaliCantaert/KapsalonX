using EE.KapsalonX.Domain.Boeken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EE.KapsalonX.Web.Models
{
    public class AdminModel
    {
        public IEnumerable<Klant> Klanten { get; set; }
        public IEnumerable<Behandeling> Behandenlingen { get; set; }
        public IEnumerable<Afspraak> Afspraken { get; set; }
    }
}
