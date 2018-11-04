using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EE.KapsalonX.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EE.KapsalonX.Web.Controllers
{
    public class AfspraakController : Controller
    {
        List<AfspraakBehandelingVm> Geslacht = new List<AfspraakBehandelingVm>
        {
            new AfspraakBehandelingVm { Geslacht = "Dames"},
            new AfspraakBehandelingVm { Geslacht = "Heren" },
            new AfspraakBehandelingVm { Geslacht = "Kinderen" }
        };

        List<AfspraakBehandelingVm> BehandelingenDames = new List<AfspraakBehandelingVm>
        {
            new AfspraakBehandelingVm { Coupe = "Kort haar", Optie = "Knippen", Tijdsduur = new TimeSpan(00,30,00)},
            new AfspraakBehandelingVm { Coupe = "Kort haar", Optie = "Kleuren", Tijdsduur = new TimeSpan(00,45,00)},
            new AfspraakBehandelingVm { Coupe = "Kort haar", Optie = "Brushing", Tijdsduur = new TimeSpan(00,30,00)},
            new AfspraakBehandelingVm { Coupe = "Kort haar", Optie = "Knippen + kleuren", Tijdsduur = new TimeSpan(01,15,00)},
            new AfspraakBehandelingVm { Coupe = "Kort haar", Optie = "Knippen + kleuren + brushing", Tijdsduur = new TimeSpan(01,45,00)},

            new AfspraakBehandelingVm { Coupe = "Lang haar", Optie = "Knippen", Tijdsduur = new TimeSpan(00,40,00)},
            new AfspraakBehandelingVm { Coupe = "Lang haar", Optie = "Kleuren", Tijdsduur = new TimeSpan(01,00,00)},
            new AfspraakBehandelingVm { Coupe = "Lang haar", Optie = "Brushing", Tijdsduur = new TimeSpan(00,40,00)},
            new AfspraakBehandelingVm { Coupe = "Lang haar", Optie = "Knippen + kleuren", Tijdsduur = new TimeSpan(01,40,00)},
            new AfspraakBehandelingVm { Coupe = "Lang haar", Optie = "Knippen + kleuren + brushing", Tijdsduur = new TimeSpan(02,20,00)}
        };

        List<AfspraakBehandelingVm> BehandelingenHeren = new List<AfspraakBehandelingVm>
        {
            new AfspraakBehandelingVm { Optie = "Snit", Tijdsduur = new TimeSpan(00,30,00) },
            new AfspraakBehandelingVm { Optie = "Tondeuse", Tijdsduur = new TimeSpan(00,30,00) },
            new AfspraakBehandelingVm { Optie = "Knippen + kleuren", Tijdsduur = new TimeSpan(01,00,00)}
        };

        List<AfspraakBehandelingVm> BehandelingenKinderen = new List<AfspraakBehandelingVm>
        {
            new AfspraakBehandelingVm { Optie = "Snit meisjes", Tijdsduur = new TimeSpan(00,30,00)},
            new AfspraakBehandelingVm { Optie = "Snit jongens", Tijdsduur = new TimeSpan(00,30,00)}
        };

        public IActionResult Index()
        {
            var wizard = new WizardViewModel();
            wizard.Initialize();
            return View(wizard);
        }

        [HttpPost]
        public IActionResult Index(
            [Deserialize] WizardViewModel wizard,
            IStepViewModel step)
    }
}