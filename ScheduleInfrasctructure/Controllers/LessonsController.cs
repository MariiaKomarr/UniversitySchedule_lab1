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
    public class LessonsController : Controller
    {
        private readonly lab_1Context _context;

        public LessonsController(lab_1Context context)
        {
            _context = context;
        }

        // GET: Lessons
        public async Task<IActionResult> Index()
        {
            var lab_1Context = _context.Lessons.Include(l => l.Auditorium).Include(l => l.Course).Include(l => l.Group).Include(l => l.Teacher);
            return View(await lab_1Context.ToListAsync());
        }

        // GET: Lessons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lessons == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lessons
                .Include(l => l.Auditorium)
                .Include(l => l.Course)
                .Include(l => l.Group)
                .Include(l => l.Teacher)
                .FirstOrDefaultAsync(m => m.LessonId == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // GET: Lessons/Create
        public IActionResult Create()
        {
            ViewData["AuditoriumId"] = new SelectList(_context.Auditoriums, "AuditoriumId", "Name");
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "Name");
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "Name");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "FullName");
            return View();
        }

        // POST: Lessons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LessonId,CourseId,TeacherId,AuditoriumId,GroupId,DayOfWeek,StartTime,EndTime")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lesson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuditoriumId"] = new SelectList(_context.Auditoriums, "AuditoriumId", "Name", lesson.AuditoriumId);
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "Name", lesson.CourseId);
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "Name", lesson.GroupId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "FullName", lesson.TeacherId);
            return View(lesson);
        }

        // GET: Lessons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lessons == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
            ViewData["AuditoriumId"] = new SelectList(_context.Auditoriums, "AuditoriumId", "Name", lesson.AuditoriumId);
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "Name", lesson.CourseId);
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "Name", lesson.GroupId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "FullName", lesson.TeacherId);
            return View(lesson);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LessonId,CourseId,TeacherId,AuditoriumId,GroupId,DayOfWeek,StartTime,EndTime")] Lesson lesson)
        {
            if (id != lesson.LessonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lesson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonExists(lesson.LessonId))
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
            ViewData["AuditoriumId"] = new SelectList(_context.Auditoriums, "AuditoriumId", "Name", lesson.AuditoriumId);
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "Name", lesson.CourseId);
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "Name", lesson.GroupId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "FullName", lesson.TeacherId);
            return View(lesson);
        }

        // GET: Lessons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lessons == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lessons
                .Include(l => l.Auditorium)
                .Include(l => l.Course)
                .Include(l => l.Group)
                .Include(l => l.Teacher)
                .FirstOrDefaultAsync(m => m.LessonId == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lessons == null)
            {
                return Problem("Entity set 'lab_1Context.Lessons'  is null.");
            }
            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson != null)
            {
                _context.Lessons.Remove(lesson);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LessonExists(int id)
        {
          return (_context.Lessons?.Any(e => e.LessonId == id)).GetValueOrDefault();
        }
    }
}
