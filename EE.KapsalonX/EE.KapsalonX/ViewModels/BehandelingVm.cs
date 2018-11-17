using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EE.KapsalonX.Web.ViewModels
{
    public class BehandelingVm
    {
        public int Id { get; set; }
        public string Behandeling { get; set; }
        public TimeSpan Tijdsduur { get; set; }

        public BehandelingVm()
        {

        }
    }
}
