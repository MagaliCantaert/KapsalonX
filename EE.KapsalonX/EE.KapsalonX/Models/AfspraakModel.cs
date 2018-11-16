﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EE.KapsalonX.Web.Models
{
    public class AfspraakModel
    {
        public int Stap { get; set; }

        [Display(Name = "Behandeling voor")]
        public string Geslacht { get; set; }
        public string Behandeling { get; set; }
        public string Datum { get; set; }
        public string Tijdstip { get; set; }

        public List<SelectListItem> Behandelingen { get; set; }
        public List<BehandelingModel> BehandelingenDames { get; set; }
        public List<BehandelingModel> BehandelingenHeren { get; set; }
        public List<BehandelingModel> BehandelingenKinderen { get; set; }

        [Display(Name = "Datum")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Tijdstip")]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        [Required(ErrorMessage = "Dit is een verplicht veld")]
        public string Voornaam { get; set; }

        [Required(ErrorMessage = "Dit is een verplicht veld")]
        public string Achternaam { get; set; }

        [Required(ErrorMessage = "Dit is een verplicht veld")]
        public string Telefoonnummer { get; set; }

        [Display(Name = "Email-adres")]
        [Required(ErrorMessage = "Dit is een verplicht veld")]
        public string Emailadres { get; set; }

        public string Opmerkingen { get; set; }


        public AfspraakModel()
        {
        }

        public AfspraakModel(int stap)
        {
            Stap = stap;
        }
    }
}