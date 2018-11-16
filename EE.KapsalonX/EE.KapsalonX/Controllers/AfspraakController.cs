using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EE.KapsalonX.Data;
using EE.KapsalonX.Domain.Boeken;
using EE.KapsalonX.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace EE.KapsalonX.Web.Controllers
{
    public class AfspraakController : Controller
    {
        private ApplicationDbContext _context;
        public AfspraakController(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Opvullen van behandelinglijst
        List<BehandelingModel> BehandelingenDames = new List<BehandelingModel>
        {
            new BehandelingModel { Behandeling = "KORT HAAR - Knippen", Tijdsduur = new TimeSpan(00,30,00)},
            new BehandelingModel { Behandeling = "KORT HAAR - Kleuren", Tijdsduur = new TimeSpan(00,45,00)},
            new BehandelingModel { Behandeling = "KORT HAAR - Brushing", Tijdsduur = new TimeSpan(00,30,00)},
            new BehandelingModel { Behandeling = "KORT HAAR - Knippen + kleuren", Tijdsduur = new TimeSpan(01,15,00)},
            new BehandelingModel { Behandeling = "KORT HAAR - Knippen + kleuren + brushing", Tijdsduur = new TimeSpan(01,45,00)},

            new BehandelingModel { Behandeling = "LANG HAAR - Knippen", Tijdsduur = new TimeSpan(00,40,00)},
            new BehandelingModel { Behandeling = "LANG HAAR - Kleuren", Tijdsduur = new TimeSpan(01,00,00)},
            new BehandelingModel { Behandeling = "LANG HAAR - Brushing", Tijdsduur = new TimeSpan(00,40,00)},
            new BehandelingModel { Behandeling = "LANG HAAR - Knippen + kleuren", Tijdsduur = new TimeSpan(01,40,00)},
            new BehandelingModel { Behandeling = "LANG HAAR - Knippen + kleuren + brushing", Tijdsduur = new TimeSpan(02,20,00)}
        };
        List<BehandelingModel> BehandelingenHeren = new List<BehandelingModel>
        {
            new BehandelingModel { Behandeling = "Snit", Tijdsduur = new TimeSpan(00,30,00) },
            new BehandelingModel { Behandeling = "Tondeuse", Tijdsduur = new TimeSpan(00,30,00) },
            new BehandelingModel { Behandeling = "Knippen + kleuren", Tijdsduur = new TimeSpan(01,00,00)}
        };
        List<BehandelingModel> BehandelingenKinderen = new List<BehandelingModel>
        {
            new BehandelingModel { Behandeling = "Snit meisjes", Tijdsduur = new TimeSpan(00,30,00)},
            new BehandelingModel { Behandeling = "Snit jongens", Tijdsduur = new TimeSpan(00,30,00)}
        };
        #endregion

        [HttpGet]
        public IActionResult Index(int? stapId)
        {
            AfspraakModel boekenModel = new AfspraakModel(stapId.GetValueOrDefault(1));
            boekenModel.BehandelingenDames = BehandelingenDames;
            boekenModel.BehandelingenHeren = BehandelingenHeren;
            boekenModel.BehandelingenKinderen = BehandelingenKinderen;
            WaardenNaarViewModel(boekenModel);
            return View(boekenModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(AfspraakModel boekenModel)
        {
            if (boekenModel.Stap == 4)
            {
                if (ModelState.IsValid)
                {
                    boekenModel.Stap++;
                    return RedirectToAction("Overzicht", boekenModel);
                }
                else
                {
                    boekenModel.BehandelingenDames = BehandelingenDames;
                    boekenModel.BehandelingenHeren = BehandelingenHeren;
                    boekenModel.BehandelingenKinderen = BehandelingenKinderen;
                    return View(boekenModel);
                }
            }
            else
            {
                boekenModel.Stap++;
            }
            WaardenNaarTempData(boekenModel);
            return RedirectToAction("Index", new { stapId = boekenModel.Stap, boekenModel });
        }

        [HttpGet]
        public IActionResult Overzicht(int? stapId, AfspraakModel boekenModel)
        {
            return View(boekenModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Overzicht(AfspraakModel boekenModel)
        {
            var nieuweKlant = new Klant
            {
                Voornaam = boekenModel.Voornaam,
                Achternaam = boekenModel.Achternaam,
                Telefoonnummer = boekenModel.Telefoonnummer,
                Emailadres = boekenModel.Emailadres
            };
            _context.Add(nieuweKlant);
            _context.SaveChanges();

            var nieuweBehandeling = new Behandeling
            {
                Geslacht = boekenModel.Geslacht,
                GekozenBehandeling = boekenModel.Behandeling
            };
            _context.Add(nieuweBehandeling);
            _context.SaveChanges();

            var nieuweAfspraak = new Afspraak();
            nieuweAfspraak.KlantGegevens = nieuweKlant;
            nieuweAfspraak.BehandelingGegevens = nieuweBehandeling;
            nieuweAfspraak.Datum = boekenModel.Datum;
            nieuweAfspraak.Tijdstip = boekenModel.Tijdstip;
            nieuweAfspraak.Opmerking = boekenModel.Opmerkingen;
            _context.Add(nieuweAfspraak);
            _context.SaveChanges();

            //HIER LATER VERSTUREN VAN MAIL NAAR KLANT MET GEGEVENS AFSPRAAK
            return new RedirectToActionResult("Bevestiging", "Afspraak", boekenModel);
        }

        
        public IActionResult Bevestiging (AfspraakModel boekenModel)
        {
            return View(boekenModel);
        }



        private void WaardenNaarViewModel(AfspraakModel boekenModel)
        {
            boekenModel.Geslacht = TempData["Geslacht"]?.ToString();
            boekenModel.Behandeling = TempData["Behandeling"]?.ToString();
            boekenModel.Datum = TempData["Datum"]?.ToString();
            boekenModel.Tijdstip = TempData["Tijdstip"]?.ToString();

            boekenModel.Voornaam = TempData["Voornaam"]?.ToString();
            boekenModel.Achternaam = TempData["Achternaam"]?.ToString();
            boekenModel.Telefoonnummer = TempData["Telefoonnummer"]?.ToString();
            boekenModel.Emailadres = TempData["Emailadres"]?.ToString();
            boekenModel.Opmerkingen = TempData["Opmerkingen"]?.ToString();
        }

        private void WaardenNaarTempData(AfspraakModel boekenModel)
        {
            TempData["Geslacht"] = boekenModel.Geslacht;
            TempData["Behandeling"] = boekenModel.Behandeling?.ToString();
            TempData["Datum"] = boekenModel.Date.ToShortDateString();
            TempData["Tijdstip"] = boekenModel.Time.ToShortTimeString();

            TempData["Voornaam"] = boekenModel.Voornaam;
            TempData["Achternaam"] = boekenModel.Achternaam;
            TempData["Telefoonnummer"] = boekenModel.Telefoonnummer;
            TempData["Emailadres"] = boekenModel.Emailadres;
            TempData["Opmerkingen"] = boekenModel.Opmerkingen;

        }
    }
}