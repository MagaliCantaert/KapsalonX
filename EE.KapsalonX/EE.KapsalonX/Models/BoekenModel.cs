using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EE.KapsalonX.Web.Models
{
    public class BoekenModel
    {
        public int Stap { get; set; }
        public string Geslacht { get; set; }
        public string Optie { get; set; }

        public List<BehandelingModel> BehandelingenDames { get; set; }
        public List<BehandelingModel> BehandelingenHeren { get; set; }
        public List<BehandelingModel> BehandelingenKinderen { get; set; }        

        public BoekenModel()
        {

        }

        public BoekenModel(int stap)
        {
            Stap = stap;
        }
    }
}
