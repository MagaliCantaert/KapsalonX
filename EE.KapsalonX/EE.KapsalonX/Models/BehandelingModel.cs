using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EE.KapsalonX.Web.Models
{
    public class BehandelingModel
    {
        public int Id { get; set; }
        public string Geslacht { get; set; }
        public string Coupe { get; set; }
        public string Optie { get; set; }
        public TimeSpan Tijdsduur { get; set; }

        public BehandelingModel()
        {

        }
    }
}
