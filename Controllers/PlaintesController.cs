using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GogoDriverWeb.Data;
using GogoDriverWeb.Models;
using Microsoft.AspNetCore.Authorization;

namespace GogoDriverWeb.Controllers
{
    [Authorize]
    public class PlaintesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlaintesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Plaintes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Plaintes.Include(p => p.PersonneIdNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Plaintes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Plaintes == null)
            {
                return NotFound();
            }

            var plainte = await _context.Plaintes
                .Include(p => p.PersonneIdNavigation)
                .FirstOrDefaultAsync(m => m.PlainteId == id);
            if (plainte == null)
            {
                return NotFound();
            }

            return View(plainte);
        }

        // GET: Plaintes/Create
        public IActionResult Create()
        {
            ViewData["PersonneId"] = new SelectList(_context.Set<Personne>(), "Id", "Id");
            return View();
        }

        // POST: Plaintes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlainteId,PersonneId,LibellePlainte,DatePlainte")] Plainte plainte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plainte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonneId"] = new SelectList(_context.Set<Personne>(), "Id", "Id", plainte.PersonneId);
            return View(plainte);
        }

        // GET: Plaintes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Plaintes == null)
            {
                return NotFound();
            }

            var plainte = await _context.Plaintes.FindAsync(id);
            if (plainte == null)
            {
                return NotFound();
            }
            ViewData["PersonneId"] = new SelectList(_context.Set<Personne>(), "Id", "Id", plainte.PersonneId);
            return View(plainte);
        }

        // POST: Plaintes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PlainteId,PersonneId,LibellePlainte,DatePlainte")] Plainte plainte)
        {
            if (id != plainte.PlainteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plainte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlainteExists(plainte.PlainteId))
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
            ViewData["PersonneId"] = new SelectList(_context.Set<Personne>(), "Id", "Id", plainte.PersonneId);
            return View(plainte);
        }

        // GET: Plaintes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Plaintes == null)
            {
                return NotFound();
            }

            var plainte = await _context.Plaintes
                .Include(p => p.PersonneIdNavigation)
                .FirstOrDefaultAsync(m => m.PlainteId == id);
            if (plainte == null)
            {
                return NotFound();
            }

            return View(plainte);
        }

        // POST: Plaintes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Plaintes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Plaintes'  is null.");
            }
            var plainte = await _context.Plaintes.FindAsync(id);
            if (plainte != null)
            {
                _context.Plaintes.Remove(plainte);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlainteExists(string id)
        {
          return (_context.Plaintes?.Any(e => e.PlainteId == id)).GetValueOrDefault();
        }
    }
}
