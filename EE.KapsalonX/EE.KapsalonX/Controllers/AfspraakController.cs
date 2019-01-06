using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using EE.KapsalonX.Data;
using EE.KapsalonX.Domain.Afspraken;
using EE.KapsalonX.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
        List<BehandelingVm> BehandelingenDames = new List<BehandelingVm>
        {
            new BehandelingVm { Behandeling = "KORT HAAR - Knippen", Tijdsduur = new TimeSpan(00,30,00), FotoPad = "kort-haar.jpg"},
            new BehandelingVm { Behandeling = "KORT HAAR - Kleuren", Tijdsduur = new TimeSpan(00,45,00), FotoPad = "kort-haar.jpg"},
            new BehandelingVm { Behandeling = "KORT HAAR - Brushing", Tijdsduur = new TimeSpan(00,30,00), FotoPad = "kort-haar.jpg"},
            new BehandelingVm { Behandeling = "KORT HAAR - Knippen + kleuren", Tijdsduur = new TimeSpan(01,15,00), FotoPad = "kort-haar.jpg"},
            new BehandelingVm { Behandeling = "KORT HAAR - Knippen + kleuren + brushing", Tijdsduur = new TimeSpan(01,45,00), FotoPad = "kort-haar.jpg"},

            new BehandelingVm { Behandeling = "LANG HAAR - Knippen", Tijdsduur = new TimeSpan(00,40,00), FotoPad = "women-hair.jpg"},
            new BehandelingVm { Behandeling = "LANG HAAR - Kleuren", Tijdsduur = new TimeSpan(01,00,00), FotoPad = "women-hair.jpg"},
            new BehandelingVm { Behandeling = "LANG HAAR - Brushing", Tijdsduur = new TimeSpan(00,40,00), FotoPad = "women-hair.jpg"},
            new BehandelingVm { Behandeling = "LANG HAAR - Knippen + kleuren", Tijdsduur = new TimeSpan(01,40,00), FotoPad = "women-hair.jpg"},
            new BehandelingVm { Behandeling = "LANG HAAR - Knippen + kleuren + brushing", Tijdsduur = new TimeSpan(02,20,00), FotoPad = "women-hair.jpg"}
        };
        List<BehandelingVm> BehandelingenHeren = new List<BehandelingVm>
        {
            new BehandelingVm { Behandeling = "Snit", Tijdsduur = new TimeSpan(00,30,00), FotoPad = "heren-knippen.jpg" },
            new BehandelingVm { Behandeling = "Tondeuse", Tijdsduur = new TimeSpan(00,30,00), FotoPad = "mannen-tondeuse.jpg" },
            new BehandelingVm { Behandeling = "Knippen + kleuren", Tijdsduur = new TimeSpan(01,00,00), FotoPad = "mannen-knipkleur.jpg"}
        };
        List<BehandelingVm> BehandelingenKinderen = new List<BehandelingVm>
        {
            new BehandelingVm { Behandeling = "Snit meisjes", Tijdsduur = new TimeSpan(00,30,00), FotoPad = "meisjes-snit.jpg" },
            new BehandelingVm { Behandeling = "Snit jongens", Tijdsduur = new TimeSpan(00,30,00), FotoPad = "kids-hair.jpg" }
        };
        #endregion

        [HttpGet]
        public IActionResult Index(int? stapId)
        {
            AfspraakVm viewModel = new AfspraakVm(stapId.GetValueOrDefault(1));
            viewModel.BehandelingenDames = BehandelingenDames;
            viewModel.BehandelingenHeren = BehandelingenHeren;
            viewModel.BehandelingenKinderen = BehandelingenKinderen;   
            BasisDatumTijd();
            WaardenNaarViewModel(viewModel);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(AfspraakVm viewModel)
        {
            if (viewModel.Stap == 3)
            {
                AdminIndexVm adminVm = new AdminIndexVm
                {
                    Behandenlingen = _context.Behandelingen.ToList(),
                    Afspraken = _context.Afspraken.ToList()
                };
                WaardenNaarTempData(viewModel);
                WaardenNaarViewModel(viewModel);

                var nieuweBehandeling = new Behandeling();
                nieuweBehandeling.Geslacht = viewModel.Geslacht;
                nieuweBehandeling.GekozenBehandeling = viewModel.Behandeling;
                var StartDateTimeNieuweAfspraak = Convert.ToDateTime(viewModel.Datum + " " + viewModel.Tijdstip);
                DateTime EndDateTimeNieuweAfspraak;

                if (nieuweBehandeling.Geslacht == "Dames")
                {
                    EndDateTimeNieuweAfspraak = StartDateTimeNieuweAfspraak.Add(BehandelingenDames.Single(b => b.Behandeling == nieuweBehandeling.GekozenBehandeling).Tijdsduur);
                    foreach (var item in adminVm.Afspraken)
                    {
                        var TimeBetweenInAfspraken = TimeSpan.Parse(item.BehandelingGegevens.Duur);
                        var StartDateTimeInAfspraken = Convert.ToDateTime(item.Datum + " " + item.Tijdstip);
                        var EndDateTimeInAfspraken = Convert.ToDateTime(item.Datum + " " + item.Tijdstip).Add(TimeBetweenInAfspraken);

                        if (StartDateTimeNieuweAfspraak <= StartDateTimeInAfspraken && StartDateTimeNieuweAfspraak >= EndDateTimeInAfspraken
                            || EndDateTimeNieuweAfspraak >= StartDateTimeInAfspraken && EndDateTimeNieuweAfspraak <= EndDateTimeInAfspraken)                           
                        {
                            BasisDatumTijd();
                            ViewBag.Error = "Het gekozen tijdstip is reeds ingevuld. Kies een andere datum en/of tijdstip a.u.b.";
                            return View(viewModel);
                        }
                    }
                }
                else if (nieuweBehandeling.Geslacht == "Heren")
                {
                    EndDateTimeNieuweAfspraak = StartDateTimeNieuweAfspraak.Add(BehandelingenHeren.Single(b => b.Behandeling == nieuweBehandeling.GekozenBehandeling).Tijdsduur);
                    foreach (var item in adminVm.Afspraken)
                    {
                        var TimeBetweenInAfspraken = TimeSpan.Parse(item.BehandelingGegevens.Duur);
                        var StartDateTimeInAfspraken = Convert.ToDateTime(item.Datum + " " + item.Tijdstip);
                        var EndDateTimeInAfspraken = Convert.ToDateTime(item.Datum + " " + item.Tijdstip).Add(TimeBetweenInAfspraken);

                        if (StartDateTimeNieuweAfspraak <= StartDateTimeInAfspraken && StartDateTimeNieuweAfspraak >= EndDateTimeInAfspraken
                            || EndDateTimeNieuweAfspraak >= StartDateTimeInAfspraken && EndDateTimeNieuweAfspraak <= EndDateTimeInAfspraken)
                        {
                            Debug.WriteLine("Datum zit ertussen");
                            BasisDatumTijd();
                            ViewBag.Error = "Kies een andere datum en/of tijdstip a.u.b.";
                            return View(viewModel);
                        }
                    }
                }
                else if (nieuweBehandeling.Geslacht == "Kinderen")
                {
                    EndDateTimeNieuweAfspraak = StartDateTimeNieuweAfspraak.Add(BehandelingenKinderen.Single(b => b.Behandeling == nieuweBehandeling.GekozenBehandeling).Tijdsduur);
                    foreach (var item in adminVm.Afspraken)
                    {
                        var TimeBetweenInAfspraken = TimeSpan.Parse(item.BehandelingGegevens.Duur);
                        var StartDateTimeInAfspraken = Convert.ToDateTime(item.Datum + " " + item.Tijdstip);
                        var EndDateTimeInAfspraken = Convert.ToDateTime(item.Datum + " " + item.Tijdstip).Add(TimeBetweenInAfspraken);

                        if (StartDateTimeNieuweAfspraak <= StartDateTimeInAfspraken && StartDateTimeNieuweAfspraak >= EndDateTimeInAfspraken
                            || EndDateTimeNieuweAfspraak >= StartDateTimeInAfspraken && EndDateTimeNieuweAfspraak <= EndDateTimeInAfspraken)
                        {
                            Debug.WriteLine("Datum zit ertussen");
                            BasisDatumTijd();
                            ViewBag.Error = "Kies een andere datum en/of tijdstip a.u.b.";
                            return View(viewModel);
                        }
                    }
                }
            }

            if (viewModel.Stap == 4)
            {
                if (ModelState.IsValid)
                {
                    viewModel.Stap++;
                    return RedirectToAction("Overzicht", viewModel);
                }
                else
                {
                    viewModel.BehandelingenDames = BehandelingenDames;
                    viewModel.BehandelingenHeren = BehandelingenHeren;
                    viewModel.BehandelingenKinderen = BehandelingenKinderen;
                    return View(viewModel);
                }
            }
            else
            {
                viewModel.Stap++;
            }
            WaardenNaarTempData(viewModel);
            return RedirectToAction("Index", new { stapId = viewModel.Stap, viewModel });
        }

        [HttpGet]
        public IActionResult Overzicht(int? stapId, AfspraakVm viewModel)
        {
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Overzicht(AfspraakVm viewModel)
        {
            var nieuweKlant = new Klant();
            var nieuweBehandeling = new Behandeling();
            var nieuweAfspraak = new Afspraak();

            if (_context.Klanten.FirstOrDefault(k => k.Emailadres == viewModel.Emailadres) != null)
            {
                Debug.WriteLine("gekend");
                nieuweAfspraak.KlantGegevensId = _context.Klanten.FirstOrDefault(k => k.Emailadres == viewModel.Emailadres).KlantId;
            }
            else
            {
                nieuweKlant.Voornaam = viewModel.Voornaam;
                nieuweKlant.Achternaam = viewModel.Achternaam;
                nieuweKlant.Telefoonnummer = viewModel.Telefoonnummer;
                nieuweKlant.Emailadres = viewModel.Emailadres;
                nieuweAfspraak.KlantGegevens = nieuweKlant;
                _context.Add(nieuweKlant);
            }

            nieuweBehandeling.Geslacht = viewModel.Geslacht;
            nieuweBehandeling.GekozenBehandeling = viewModel.Behandeling;
            var StartDateTime = Convert.ToDateTime(viewModel.Datum + " " + viewModel.Tijdstip);
            DateTime EndDateTime;

            if (nieuweBehandeling.Geslacht == "Dames")
            {
                EndDateTime = StartDateTime.Add(BehandelingenDames.Single(b => b.Behandeling == nieuweBehandeling.GekozenBehandeling).Tijdsduur);
                TimeSpan Duur = EndDateTime - StartDateTime;
                nieuweBehandeling.DuurTijd = Duur;
                nieuweBehandeling.Duur = Duur.ToString();
            }
            else if (nieuweBehandeling.Geslacht == "Heren")
            {
                EndDateTime = StartDateTime.Add(BehandelingenHeren.Single(b => b.Behandeling == nieuweBehandeling.GekozenBehandeling).Tijdsduur);
                TimeSpan Duur = EndDateTime - StartDateTime;
                nieuweBehandeling.DuurTijd = Duur;
                nieuweBehandeling.Duur = Duur.ToString();
            }
            else if (nieuweBehandeling.Geslacht == "Kinderen")
            {
                EndDateTime = StartDateTime.Add(BehandelingenKinderen.Single(b => b.Behandeling == nieuweBehandeling.GekozenBehandeling).Tijdsduur);
                TimeSpan Duur = EndDateTime - StartDateTime;
                nieuweBehandeling.DuurTijd = Duur;
                nieuweBehandeling.Duur = Duur.ToString();
            }
            _context.Add(nieuweBehandeling);

            nieuweAfspraak.BehandelingGegevens = nieuweBehandeling;
            viewModel.Tijdsduur = nieuweAfspraak.BehandelingGegevens.DuurTijd.ToString();
            nieuweAfspraak.Datum = viewModel.Datum;
            nieuweAfspraak.Tijdstip = viewModel.Tijdstip;
            nieuweAfspraak.Opmerking = viewModel.Opmerkingen;

            _context.Add(nieuweAfspraak);
            _context.SaveChanges();

            return new RedirectToActionResult("Bevestiging", "Afspraak", viewModel);
        }

        public IActionResult Bevestiging(AfspraakVm viewModel)
        {
            return View(viewModel);
        }

        private void WaardenNaarViewModel(AfspraakVm viewModel)
        {
            viewModel.Geslacht = TempData["Geslacht"]?.ToString();
            viewModel.Behandeling = TempData["Behandeling"]?.ToString();
            viewModel.Datum = TempData["Datum"]?.ToString();
            viewModel.Tijdstip = TempData["Tijdstip"]?.ToString();
            viewModel.Voornaam = TempData["Voornaam"]?.ToString();
            viewModel.Achternaam = TempData["Achternaam"]?.ToString();
            viewModel.Telefoonnummer = TempData["Telefoonnummer"]?.ToString();
            viewModel.Emailadres = TempData["Emailadres"]?.ToString();
            viewModel.Opmerkingen = TempData["Opmerkingen"]?.ToString();
        }

        private void WaardenNaarTempData(AfspraakVm viewModel)
        {
            TempData["Geslacht"] = viewModel.Geslacht;
            TempData["Behandeling"] = viewModel.Behandeling?.ToString();
            TempData["Datum"] = viewModel.Date.ToShortDateString();
            TempData["Tijdstip"] = viewModel.Time.ToShortTimeString();
            TempData["Voornaam"] = viewModel.Voornaam;
            TempData["Achternaam"] = viewModel.Achternaam;
            TempData["Telefoonnummer"] = viewModel.Telefoonnummer;
            TempData["Emailadres"] = viewModel.Emailadres;
            TempData["Opmerkingen"] = viewModel.Opmerkingen;
        }

        void BasisDatumTijd()
        {
            ViewBag.valueDate = DateTime.Now;
            ViewBag.minDate = DateTime.Now;
            ViewBag.maxDate = new DateTime(DateTime.Now.Year, 12, 31);
            ViewBag.minTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 09, 00, 00);
            ViewBag.maxTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 00, 00);
            ViewBag.valueTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 09, 00, 00);
        }
    }
}

