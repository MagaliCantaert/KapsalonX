using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EE.KapsalonX.Web.Models
{
    public class BoekenModel
    {
        public int Stap { get; set; }
        public string Geslacht { get; set; }
        public string Behandeling { get; set; }
        public string GekozenDatum { get; set; }
        public string GekozenTijd { get; set; }

        public List<SelectListItem> Behandelingen { get; set; }
        public List<BehandelingModel> BehandelingenDames { get; set; }
        public List<BehandelingModel> BehandelingenHeren { get; set; }
        public List<BehandelingModel> BehandelingenKinderen { get; set; }

        public string Vandaag = DateTime.Now.ToString();

        [Display(Name = "Datum")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Datum { get; set; }

        [Display(Name = "Tijdstip")]
        [DataType(DataType.Time)]
        public DateTime Tijdstip { get; set; }

        public BoekenModel()
        {

        }

        public BoekenModel(int stap)
        {
            Stap = stap;
        }
    }
}
