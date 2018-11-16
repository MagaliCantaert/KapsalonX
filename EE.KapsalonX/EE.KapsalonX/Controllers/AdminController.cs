using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EE.KapsalonX.Data;
using EE.KapsalonX.Domain.Boeken;
using EE.KapsalonX.Web.Models;

namespace EE.KapsalonX.Web.Controllers
{
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
            var applicationDbContext = _context.Afspraken.Include(a => a.KlantGegevens);
            return View(await applicationDbContext.ToListAsync());
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
            ViewData["AfspraakId"] = new SelectList(_context.Klanten, "KlantId", "Achternaam");
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AfspraakId,Datum,Tijdstip,Opmerking")] Afspraak afspraak)
        {
            if (ModelState.IsValid)
            {
                afspraak.AfspraakId = Guid.NewGuid();
                _context.Add(afspraak);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AfspraakId"] = new SelectList(_context.Klanten, "KlantId", "Achternaam", afspraak.AfspraakId);
            return View(afspraak);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afspraak = await _context.Afspraken.FindAsync(id);
            if (afspraak == null)
            {
                return NotFound();
            }
            ViewData["AfspraakId"] = new SelectList(_context.Klanten, "KlantId", "Achternaam", afspraak.AfspraakId);
            return View(afspraak);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("AfspraakId,Datum,Tijdstip,Opmerking")] Afspraak afspraak)
        {
            if (id != afspraak.AfspraakId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(afspraak);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AfspraakExists(afspraak.AfspraakId))
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
            ViewData["AfspraakId"] = new SelectList(_context.Klanten, "KlantId", "Achternaam", afspraak.AfspraakId);
            return View(afspraak);
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
            var afspraak = await _context.Afspraken.FindAsync(id);
            _context.Afspraken.Remove(afspraak);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AfspraakExists(Guid id)
        {
            return _context.Afspraken.Any(e => e.AfspraakId == id);
        }
    }
}
