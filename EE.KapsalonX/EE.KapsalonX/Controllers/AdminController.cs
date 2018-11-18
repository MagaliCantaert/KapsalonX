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

        // GET: Admin
        public async Task<IActionResult> Index()
        {
            var viewModel = new AdminIndexVm
            {
                Klanten = await _context.Klanten.ToListAsync(),
                Behandenlingen = await _context.Behandelingen.ToListAsync(),
                Afspraken = await _context.Afspraken.Include(a => a.KlantGegevens).OrderBy(b => b.Datum).ThenBy(c => c.Tijdstip).ToListAsync()
            };
            //ViewBag.Afspraken = GetData();
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
            ViewBag.Afspraken = GetData();
            return View(viewModel);
        }

        public List<Event> GetData()
        {
            var vm = new AdminIndexVm()
            {
                Klanten = _context.Klanten.ToList(),
                Behandenlingen = _context.Behandelingen.ToList(),
                Afspraken = _context.Afspraken.Include(a => a.KlantGegevens).ToList()
            };

            List<Event> appData = new List<Event>();
            foreach (var item in vm.Afspraken)
            {
                appData.Add(new Event
                {
                    Id = item.AfspraakId,
                    Subject = item.BehandelingGegevens.GekozenBehandeling,
                    StartTime = DateTime.Parse(item.Datum + " " + item.Tijdstip),
                    EndTime = DateTime.Parse(item.Datum + " " + item.Tijdstip) + new TimeSpan(1, 0, 0)
                });
            }
            return appData;
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
            return View(viewModel);
            //ViewData["AfspraakId"] = new SelectList(_context.Klanten, "KlantId", "Achternaam");
            //return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdminCreateVm createVm)
        {
            if (ModelState.IsValid)
            {
                Afspraak createdAfspraak = new Afspraak
                {
                    AfspraakId = Guid.NewGuid(),
                    KlantGegevens = createVm.Klant,
                    BehandelingGegevens = createVm.Behandeling,
                    Datum = createVm.Datum,
                    Tijdstip = createVm.Tijdstip,
                    Opmerking = createVm.Opmerking
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

            var viewModel = new AdminEditVm
            {
                Id = afspraak.AfspraakId,
                Klant = afspraak.KlantGegevens,
                Behandeling = afspraak.BehandelingGegevens,
                Datum = afspraak.Datum,
                Tijdstip = afspraak.Tijdstip,
                Opmerking = afspraak.Opmerking
            };
            return View(viewModel);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                        KlantId = editVm.Id,
                        Achternaam = editVm.Klant.Achternaam,
                        Voornaam = editVm.Klant.Voornaam,
                        Emailadres = editVm.Klant.Emailadres,
                        Telefoonnummer = editVm.Klant.Telefoonnummer
                    };
                    _context.Update(updateKlant);

                    Afspraak updateAfspraak = new Afspraak
                    {
                        AfspraakId = editVm.Id,
                        BehandelingGegevens = editVm.Behandeling,
                        Datum = editVm.Datum,
                        Tijdstip = editVm.Tijdstip,
                        Opmerking = editVm.Opmerking,
                    };
                    _context.Update(updateAfspraak);
                    TempData[Constants.SuccessMessage] = $"De afspraak voor {updateAfspraak.KlantGegevens.Achternaam} {updateAfspraak.KlantGegevens.Voornaam} werd succesvol gewijzigd.";
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
    }
}
