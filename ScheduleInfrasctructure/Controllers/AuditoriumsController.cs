using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScheduleInfrasctructure;
using UniversityScheduleDomain.Model;

namespace ScheduleInfrasctructure.Controllers
{
    public class AuditoriumsController : Controller
    {
        private readonly lab_1Context _context;

        public AuditoriumsController(lab_1Context context)
        {
            _context = context;
        }

        // GET: Auditoriums
        public async Task<IActionResult> Index()
        {
              return _context.Auditoriums != null ? 
                          View(await _context.Auditoriums.ToListAsync()) :
                          Problem("Entity set 'lab_1Context.Auditoriums'  is null.");
        }

        // GET: Auditoriums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Auditoriums == null)
            {
                return NotFound();
            }

            var auditorium = await _context.Auditoriums
                .FirstOrDefaultAsync(m => m.AuditoriumId == id);
            if (auditorium == null)
            {
                return NotFound();
            }

            return View(auditorium);
        }

        // GET: Auditoriums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Auditoriums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuditoriumId,Name,Info")] Auditorium auditorium)
        {
            if (_context.Auditoriums.Any(a => a.Name == auditorium.Name))
            {
                ModelState.AddModelError("Name", "This auditorium already exists.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(auditorium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(auditorium);
        }

        // GET: Auditoriums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Auditoriums == null)
            {
                return NotFound();
            }

            var auditorium = await _context.Auditoriums.FindAsync(id);
            if (auditorium == null)
            {
                return NotFound();
            }
            return View(auditorium);
        }

        // POST: Auditoriums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuditoriumId,Name,Info")] Auditorium auditorium)
        {
            if (id != auditorium.AuditoriumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auditorium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuditoriumExists(auditorium.AuditoriumId))
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
            return View(auditorium);
        }

        // GET: Auditoriums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Auditoriums == null)
            {
                return NotFound();
            }

            var auditorium = await _context.Auditoriums
                .FirstOrDefaultAsync(m => m.AuditoriumId == id);
            if (auditorium == null)
            {
                return NotFound();
            }

            return View(auditorium);
        }

        // POST: Auditoriums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Auditoriums == null)
            {
                return Problem("Entity set 'lab_1Context.Auditoriums'  is null.");
            }
            var auditorium = await _context.Auditoriums.FindAsync(id);
            if (auditorium != null)
            {
                _context.Auditoriums.Remove(auditorium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuditoriumExists(int id)
        {
          return (_context.Auditoriums?.Any(e => e.AuditoriumId == id)).GetValueOrDefault();
        }
    }
}
