﻿using System;
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
    public class TeachersController : Controller
    {
        private readonly AppDBContext _context;

        public TeachersController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Teachers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Teachers.ToListAsync());
        }

        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachers = await _context.Teachers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teachers == null)
            {
                return NotFound();
            }

            return View(teachers);
        }

        // GET: Teachers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,MiddleName")] Teachers teachers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teachers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teachers);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachers = await _context.Teachers.FindAsync(id);
            if (teachers == null)
            {
                return NotFound();
            }
            return View(teachers);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,MiddleName")] Teachers teachers)
        {
            if (id != teachers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teachers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeachersExists(teachers.Id))
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
            return View(teachers);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachers = await _context.Teachers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teachers == null)
            {
                return NotFound();
            }

            return View(teachers);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teachers = await _context.Teachers.FindAsync(id);
            _context.Teachers.Remove(teachers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeachersExists(int id)
        {
            return _context.Teachers.Any(e => e.Id == id);
        }
    }
}
