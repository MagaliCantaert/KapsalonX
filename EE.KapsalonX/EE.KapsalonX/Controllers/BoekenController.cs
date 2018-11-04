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
    public class BoekenController : Controller
    {

        List<BehandelingVm> BehandelingenDames = new List<BehandelingVm>
        {
            new BehandelingVm { Coupe = "Kort haar", Optie = "Knippen", Tijdsduur = new TimeSpan(00,30,00)},
            new BehandelingVm { Coupe = "Kort haar", Optie = "Kleuren", Tijdsduur = new TimeSpan(00,45,00)},
            new BehandelingVm { Coupe = "Kort haar", Optie = "Brushing", Tijdsduur = new TimeSpan(00,30,00)},
            new BehandelingVm { Coupe = "Kort haar", Optie = "Knippen + kleuren", Tijdsduur = new TimeSpan(01,15,00)},
            new BehandelingVm { Coupe = "Kort haar", Optie = "Knippen + kleuren + brushing", Tijdsduur = new TimeSpan(01,45,00)},

            new BehandelingVm { Coupe = "Lang haar", Optie = "Knippen", Tijdsduur = new TimeSpan(00,40,00)},
            new BehandelingVm { Coupe = "Lang haar", Optie = "Kleuren", Tijdsduur = new TimeSpan(01,00,00)},
            new BehandelingVm { Coupe = "Lang haar", Optie = "Brushing", Tijdsduur = new TimeSpan(00,40,00)},
            new BehandelingVm { Coupe = "Lang haar", Optie = "Knippen + kleuren", Tijdsduur = new TimeSpan(01,40,00)},
            new BehandelingVm { Coupe = "Lang haar", Optie = "Knippen + kleuren + brushing", Tijdsduur = new TimeSpan(02,20,00)}
        };

        List<BehandelingVm> BehandelingenHeren = new List<BehandelingVm>
        {
            new BehandelingVm { Optie = "Snit", Tijdsduur = new TimeSpan(00,30,00) },
            new BehandelingVm { Optie = "Tondeuse", Tijdsduur = new TimeSpan(00,30,00) },
            new BehandelingVm { Optie = "Knippen + kleuren", Tijdsduur = new TimeSpan(01,00,00)}
        };

        List<BehandelingVm> BehandelingenKinderen = new List<BehandelingVm>
        {
            new BehandelingVm { Optie = "Snit meisjes", Tijdsduur = new TimeSpan(00,30,00)},
            new BehandelingVm { Optie = "Snit jongens", Tijdsduur = new TimeSpan(00,30,00)}
        };

        public IActionResult Index()
        {
            BoekenIndexVm viewModel = new BoekenIndexVm();
            viewModel.BehandelingenDames = BehandelingenDames;
            return View(viewModel);
        }
    }
}