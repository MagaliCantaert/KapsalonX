using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EE.KapsalonX.Web.Models
{
    public class BehandelingModel
    {
        public int Id { get; set; }
        public string Behandeling { get; set; }
        public TimeSpan Tijdsduur { get; set; }

        public BehandelingModel()
        {

        }
    }
}
