using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EE.KapsalonX.Web.Models
{
    public class BehandelingVm
    {
        public string Coupe { get; set; }
        public string Optie { get; set; }
        public TimeSpan Tijdsduur { get; set; }
    }
}
