using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentSubjectRatesController : Controller
    {
        private readonly AppDBContext _context;

        public StudentSubjectRatesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: StudentSubjectRates
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.StudentSubjectRate.Include(s => s.Student).Include(s => s.Subject);
            return View(await appDBContext.ToListAsync());
        }

        // GET: StudentSubjectRates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentSubjectRate = await _context.StudentSubjectRate
                .Include(s => s.Student)
                .Include(s => s.Subject)
                .FirstOrDefaultAsync(m => m.StudentSubjectRateId == id);
            if (studentSubjectRate == null)
            {
                return NotFound();
            }

            return View(studentSubjectRate);
        }

        // GET: StudentSubjectRates/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId");
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId");
            return View();
        }

        // POST: StudentSubjectRates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentSubjectRateId,StudentId,SubjectId,Rate,Month")] StudentSubjectRate studentSubjectRate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentSubjectRate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", studentSubjectRate.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId", studentSubjectRate.SubjectId);
            return View(studentSubjectRate);
        }

        // GET: StudentSubjectRates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentSubjectRate = await _context.StudentSubjectRate.FindAsync(id);
            if (studentSubjectRate == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", studentSubjectRate.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId", studentSubjectRate.SubjectId);
            return View(studentSubjectRate);
        }

        // POST: StudentSubjectRates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentSubjectRateId,StudentId,SubjectId,Rate,Month")] StudentSubjectRate studentSubjectRate)
        {
            if (id != studentSubjectRate.StudentSubjectRateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentSubjectRate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentSubjectRateExists(studentSubjectRate.StudentSubjectRateId))
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
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", studentSubjectRate.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId", studentSubjectRate.SubjectId);
            return View(studentSubjectRate);
        }

        // GET: StudentSubjectRates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentSubjectRate = await _context.StudentSubjectRate
                .Include(s => s.Student)
                .Include(s => s.Subject)
                .FirstOrDefaultAsync(m => m.StudentSubjectRateId == id);
            if (studentSubjectRate == null)
            {
                return NotFound();
            }

            return View(studentSubjectRate);
        }

        // POST: StudentSubjectRates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentSubjectRate = await _context.StudentSubjectRate.FindAsync(id);
            _context.StudentSubjectRate.Remove(studentSubjectRate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentSubjectRateExists(int id)
        {
            return _context.StudentSubjectRate.Any(e => e.StudentSubjectRateId == id);
        }
    }
}
