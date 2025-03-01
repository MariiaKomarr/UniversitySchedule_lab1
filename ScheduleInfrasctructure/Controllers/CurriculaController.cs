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
    public class CurriculaController : Controller
    {
        private readonly lab_1Context _context;

        public CurriculaController(lab_1Context context)
        {
            _context = context;
        }

        // GET: Curricula
        public async Task<IActionResult> Index()
        {
            var lab_1Context = _context.Curricula.Include(c => c.Course);
            return View(await lab_1Context.ToListAsync());
        }

        // GET: Curricula/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Curricula == null)
            {
                return NotFound();
            }

            var curriculum = await _context.Curricula
                .Include(c => c.Course)
                .FirstOrDefaultAsync(m => m.CurriculumId == id);
            if (curriculum == null)
            {
                return NotFound();
            }

            return View(curriculum);
        }

        // GET: Curricula/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "Name");
            return View();
        }

        // POST: Curricula/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CurriculumId,CourseId,Semester,Year")] Curriculum curriculum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curriculum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "Name", curriculum.CourseId);
            return View(curriculum);
        }

        // GET: Curricula/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Curricula == null)
            {
                return NotFound();
            }

            var curriculum = await _context.Curricula.FindAsync(id);
            if (curriculum == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "Name", curriculum.CourseId);
            return View(curriculum);
        }

        // POST: Curricula/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CurriculumId,CourseId,Semester,Year")] Curriculum curriculum)
        {
            if (id != curriculum.CurriculumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curriculum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurriculumExists(curriculum.CurriculumId))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "Name", curriculum.CourseId);
            return View(curriculum);
        }

        // GET: Curricula/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Curricula == null)
            {
                return NotFound();
            }

            var curriculum = await _context.Curricula
                .Include(c => c.Course)
                .FirstOrDefaultAsync(m => m.CurriculumId == id);
            if (curriculum == null)
            {
                return NotFound();
            }

            return View(curriculum);
        }

        // POST: Curricula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Curricula == null)
            {
                return Problem("Entity set 'lab_1Context.Curricula'  is null.");
            }
            var curriculum = await _context.Curricula.FindAsync(id);
            if (curriculum != null)
            {
                _context.Curricula.Remove(curriculum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurriculumExists(int id)
        {
          return (_context.Curricula?.Any(e => e.CurriculumId == id)).GetValueOrDefault();
        }
    }
}
