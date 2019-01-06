using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EE.KapsalonX.Data;
using EE.KapsalonX.Domain.Afspraken;
using EE.KapsalonX.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using EE.KapsalonX.Domain.Kalender;

namespace EE.KapsalonX.Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
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

        // GET: Admin
        public async Task<IActionResult> Index()
        {
            var viewModel = new AdminIndexVm
            {
                Klanten = await _context.Klanten.ToListAsync(),
                Behandenlingen = await _context.Behandelingen.ToListAsync(),
                Afspraken = await _context.Afspraken.Include(a => a.KlantGegevens).OrderBy(b => b.Datum).ThenBy(c => c.Tijdstip).ToListAsync()
            }; 
            return View(viewModel);
        }

        public async Task<IActionResult> Kalender()
        {     
            var viewModel = new AdminIndexVm
            {
                Klanten = await _context.Klanten.ToListAsync(),
                Behandenlingen = await _context.Behandelingen.ToListAsync(),
                Afspraken = await _context.Afspraken.Include(a => a.KlantGegevens).OrderBy(b => b.Datum).ThenBy(c => c.Tijdstip).ToListAsync()
            };
            ViewBag.Afspraken = ToonAlleAfspraken();
            return View(viewModel);
        }

        public List<Event> ToonAlleAfspraken()
        {
            var viewModel = new AdminIndexVm()
            {
                Klanten = _context.Klanten.ToList(),
                Behandenlingen = _context.Behandelingen.ToList(),
                Afspraken = _context.Afspraken.Include(a => a.KlantGegevens).ToList()            
            };

            List<Event> afspraakData = new List<Event>();

            foreach (var item in viewModel.Afspraken)
            {         
                var End = TimeSpan.Parse(item.BehandelingGegevens.Duur);

                afspraakData.Add(new Event
                {
                    Id = item.AfspraakId,
                    Behandeling = $"{item.BehandelingGegevens.GekozenBehandeling} - {item.KlantGegevens.Voornaam} {item.KlantGegevens.Achternaam}",
                    StartTijd = DateTime.Parse(item.Datum + " " + item.Tijdstip),
                    EindTijd = DateTime.Parse(item.Datum + " " + item.Tijdstip).Add(End),
                    Klant = $"Klant: {item.KlantGegevens.Voornaam} {item.KlantGegevens.Achternaam}"
                });
            }
            return afspraakData;
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afspraak = await _context.Afspraken
                .Include(a => a.KlantGegevens)
                .Include(b => b.BehandelingGegevens)
                .FirstOrDefaultAsync(m => m.AfspraakId == id);
            if (afspraak == null)
            {
                return NotFound();
            }

            return View(afspraak);
        }

        // GET: Admin/Create
        public IActionResult Create()
        {
            var viewModel = new AdminCreateVm();
            ViewBag.valueDate = DateTime.Now;
            ViewBag.minDate = DateTime.Now;
            ViewBag.maxDate = new DateTime(DateTime.Now.Year, 12, 31);

            ViewBag.minTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 09, 00, 00);
            ViewBag.maxTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 00, 00);
            ViewBag.valueTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 09, 00, 00);

            return View(viewModel);
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdminCreateVm createVm)
        {
            WaardenNaarTempData(createVm);
            WaardenNaarViewModel(createVm);

            if (ModelState.IsValid)
            {
                Afspraak createdAfspraak = new Afspraak
                {
                    AfspraakId = Guid.NewGuid(),
                    KlantGegevens = createVm.Klant,
                    BehandelingGegevens = createVm.Behandeling,     
                    Datum = createVm.Datum,
                    Tijdstip = createVm.Tijdstip,
                    Opmerking = createVm.Opmerkingen
                };
                //afspraak.AfspraakId = Guid.NewGuid();
                _context.Add(createdAfspraak);
                await _context.SaveChangesAsync();
                TempData[Constants.SuccessMessage] = $"De afspraak voor {createdAfspraak.KlantGegevens.Achternaam} {createdAfspraak.KlantGegevens.Voornaam} werd succesvol toegevoegd.";
                return RedirectToAction(nameof(Index));
            }
            //ViewData["AfspraakId"] = new SelectList(_context.Klanten, "KlantId", "Achternaam", afspraak.AfspraakId);
            return View(createVm);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afspraak = await _context.Afspraken.FindAsync(id);
            var klant = await _context.Klanten.ToListAsync();
            var behandeling = await _context.Behandelingen.ToListAsync();
            if (afspraak == null)
            {
                return NotFound();
            }

            var nieuweBehandeling = new Behandeling();
            nieuweBehandeling.Geslacht = afspraak.BehandelingGegevens.Geslacht;
            nieuweBehandeling.GekozenBehandeling = afspraak.BehandelingGegevens.GekozenBehandeling;
            var StartDateTime = Convert.ToDateTime(afspraak.Datum + " " + afspraak.Tijdstip);
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

            var viewModel = new AdminEditVm
            {
                Id = afspraak.AfspraakId,
                Klant = afspraak.KlantGegevens,
                Behandeling = afspraak.BehandelingGegevens,
                Datum = afspraak.Datum,
                Date = DateTime.Parse(afspraak.Datum),
                Tijdstip = afspraak.Tijdstip,
                Time = DateTime.Parse(afspraak.Tijdstip),
                Opmerkingen = afspraak.Opmerking,              
            };
            viewModel.Behandeling.Duur = nieuweBehandeling.Duur;
            viewModel.Tijdsduur = nieuweBehandeling.Duur;
            return View(viewModel);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AdminEditVm editVm)
        {
            if (id != editVm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Klant updateKlant = new Klant
                    {
                        KlantId = editVm.Klant.KlantId,
                        Achternaam = editVm.Klant.Achternaam,
                        Voornaam = editVm.Klant.Voornaam,
                        Emailadres = editVm.Klant.Emailadres,
                        Telefoonnummer = editVm.Klant.Telefoonnummer,
                        Afspraken = editVm.Klant.Afspraken,
                    };
                    _context.Update(updateKlant);

                    Afspraak updateAfspraak = new Afspraak
                    {
                        AfspraakId = editVm.Id,
                        BehandelingGegevens = editVm.Behandeling,
                        KlantGegevens = editVm.Klant,
                        KlantGegevensId = editVm.Klant.KlantId,
                        Datum = editVm.Date.ToShortDateString(),
                        Tijdstip = editVm.Time.ToShortTimeString(),
                        Opmerking = editVm.Opmerkingen,
                    };
                    _context.Update(updateAfspraak);

                    Behandeling updateBehandeling  = new Behandeling();
                    updateBehandeling.Geslacht = editVm.Behandeling.Geslacht;
                    updateBehandeling.GekozenBehandeling = editVm.Behandeling.GekozenBehandeling;
                    var StartDateTime = DateTime.Parse(updateAfspraak.Datum + " " + updateAfspraak.Tijdstip);
                    //var StartDateTime = DateTime.Parse(editVm.Datum + " " + editVm.Tijdstip);
                    DateTime EndDateTime;

                    if (updateBehandeling.Geslacht == "Dames")
                    {
                        EndDateTime = StartDateTime.Add(BehandelingenDames.Single(b => b.Behandeling == updateBehandeling.GekozenBehandeling).Tijdsduur);
                        TimeSpan Duur = EndDateTime - StartDateTime;
                        updateBehandeling.DuurTijd = Duur;
                        updateBehandeling.Duur = Duur.ToString();
                    }
                    else if (updateBehandeling.Geslacht == "Heren")
                    {
                        EndDateTime = StartDateTime.Add(BehandelingenHeren.Single(b => b.Behandeling == updateBehandeling.GekozenBehandeling).Tijdsduur);
                        TimeSpan Duur = EndDateTime - StartDateTime;
                        updateBehandeling.DuurTijd = Duur;
                        updateBehandeling.Duur = Duur.ToString();
                    }
                    else if (updateBehandeling.Geslacht == "Kinderen")
                    {
                        EndDateTime = StartDateTime.Add(BehandelingenKinderen.Single(b => b.Behandeling == updateBehandeling.GekozenBehandeling).Tijdsduur);
                        TimeSpan Duur = EndDateTime - StartDateTime;
                        updateBehandeling.DuurTijd = Duur;
                        updateBehandeling.Duur = Duur.ToString();
                    }

                    editVm.Tijdsduur = updateAfspraak.BehandelingGegevens.Duur;
                    editVm.Behandeling.Duur = updateBehandeling.Duur;
                    editVm.Tijdsduur = updateBehandeling.Duur;

                    TempData[Constants.SuccessMessage] = $"De afspraak voor {updateKlant.Achternaam} {updateKlant.Voornaam} werd succesvol gewijzigd.";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AfspraakExists(editVm.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(editVm);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afspraak = await _context.Afspraken
                .Include(a => a.KlantGegevens)
                .Include(b => b.BehandelingGegevens)
                .FirstOrDefaultAsync(m => m.AfspraakId == id);
            if (afspraak == null)
            {
                return NotFound();
            }

            return View(afspraak);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var afspraak = await _context.Afspraken
                                        .Include(a => a.KlantGegevens)
                                        .Include(b => b.BehandelingGegevens).SingleOrDefaultAsync(c => c.AfspraakId == id);
            _context.Afspraken.Remove(afspraak);
            await _context.SaveChangesAsync();
            TempData[Constants.SuccessMessage] = $"De afspraak voor {afspraak.KlantGegevens.Achternaam} {afspraak.KlantGegevens.Voornaam} werd succesvol verwijderd.";
            return RedirectToAction(nameof(Index));
        }

        private bool AfspraakExists(Guid id)
        {
            return _context.Afspraken.Any(e => e.AfspraakId == id);
        }

        private void WaardenNaarViewModel(AdminCreateVm viewModel)
        {
            viewModel.Klant.Voornaam = TempData["Voornaam"]?.ToString();
            viewModel.Klant.Achternaam = TempData["Achternaam"]?.ToString();
            viewModel.Klant.Emailadres = TempData["Telefoonnummer"]?.ToString();
            viewModel.Klant.Telefoonnummer = TempData["Emailadres"]?.ToString();

            viewModel.Datum = TempData["Datum"]?.ToString();
            viewModel.Tijdstip = TempData["Tijdstip"]?.ToString();

            viewModel.Behandeling.Geslacht = TempData["Geslacht"]?.ToString();
            viewModel.Behandeling.GekozenBehandeling = TempData["Behandeling"]?.ToString();
            viewModel.Opmerkingen = TempData["Opmerkingen"]?.ToString();
        }

        private void WaardenNaarTempData(AdminCreateVm viewModel)
        {
            TempData["Voornaam"] = viewModel.Klant.Voornaam;
            TempData["Achternaam"] = viewModel.Klant.Achternaam;
            TempData["Telefoonnummer"] = viewModel.Klant.Telefoonnummer;
            TempData["Emailadres"] = viewModel.Klant.Emailadres;

            TempData["Datum"] = viewModel.Date.ToShortDateString();
            TempData["Tijdstip"] = viewModel.Time.ToShortTimeString();

            TempData["Geslacht"] = viewModel.Behandeling.Geslacht;
            TempData["Behandeling"] = viewModel.Behandeling.GekozenBehandeling?.ToString();
            TempData["Opmerkingen"] = viewModel.Opmerkingen;
        }

    }
}
