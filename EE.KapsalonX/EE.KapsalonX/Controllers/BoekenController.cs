using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EE.KapsalonX.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace EE.KapsalonX.Web.Controllers
{
    public class BoekenController : Controller
    {
        //const string STATEKEY = "SessionOpties";

        List<BehandelingModel> BehandelingenDames = new List<BehandelingModel>
        {
            new BehandelingModel {Coupe = "Kort haar", Optie = "Knippen", Tijdsduur = new TimeSpan(00,30,00)},
            new BehandelingModel {Coupe = "Kort haar", Optie = "Kleuren", Tijdsduur = new TimeSpan(00,45,00)},
            new BehandelingModel {Coupe = "Kort haar", Optie = "Brushing", Tijdsduur = new TimeSpan(00,30,00)},
            new BehandelingModel {Coupe = "Kort haar", Optie = "Knippen + kleuren", Tijdsduur = new TimeSpan(01,15,00)},
            new BehandelingModel {Coupe = "Kort haar", Optie = "Knippen + kleuren + brushing", Tijdsduur = new TimeSpan(01,45,00)},

            new BehandelingModel {Coupe = "Lang haar", Optie = "Knippen", Tijdsduur = new TimeSpan(00,40,00)},
            new BehandelingModel {Coupe = "Lang haar", Optie = "Kleuren", Tijdsduur = new TimeSpan(01,00,00)},
            new BehandelingModel {Coupe = "Lang haar", Optie = "Brushing", Tijdsduur = new TimeSpan(00,40,00)},
            new BehandelingModel {Coupe = "Lang haar", Optie = "Knippen + kleuren", Tijdsduur = new TimeSpan(01,40,00)},
            new BehandelingModel {Coupe = "Lang haar", Optie = "Knippen + kleuren + brushing", Tijdsduur = new TimeSpan(02,20,00)}
        };
        List<BehandelingModel> BehandelingenHeren = new List<BehandelingModel>
        {
            new BehandelingModel { Optie = "Snit", Tijdsduur = new TimeSpan(00,30,00) },
            new BehandelingModel { Optie = "Tondeuse", Tijdsduur = new TimeSpan(00,30,00) },
            new BehandelingModel { Optie = "Knippen + kleuren", Tijdsduur = new TimeSpan(01,00,00)}
        };
        List<BehandelingModel> BehandelingenKinderen = new List<BehandelingModel>
        {
            new BehandelingModel { Optie = "Snit meisjes", Tijdsduur = new TimeSpan(00,30,00)},
            new BehandelingModel { Optie = "Snit jongens", Tijdsduur = new TimeSpan(00,30,00)}
        };
        
        [HttpGet]
        public IActionResult Index(int? stapId)
        {
            BoekenModel boekenModel = new BoekenModel(stapId.GetValueOrDefault(1));
            WaardenNaarViewModel(boekenModel);
            return View(boekenModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(BoekenModel boekenModel)
        {
            if (boekenModel.Stap == 2)
            {
                return RedirectToAction("Kalender", boekenModel);
            }
            else
            {
                boekenModel.Stap++;
            }
            WaardenNaarTempDate(boekenModel);
            return RedirectToAction("Index", new { stapId = boekenModel.Stap });
        }

        [HttpGet]
        public IActionResult Kalender(BoekenModel boekenModel)
        {
            return View(boekenModel);
        }

        private void WaardenNaarViewModel(BoekenModel boekenModel)
        {
            boekenModel.Geslacht = TempData["Geslacht"]?.ToString();
            boekenModel.Optie = TempData["Optie"]?.ToString();
        }

        private void WaardenNaarTempDate(BoekenModel boekenModel)
        {
            TempData["Geslacht"] = boekenModel.Geslacht;
            TempData["Optie"] = boekenModel.Optie;
        }
    }
}