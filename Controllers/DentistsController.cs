using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DentalWebApp.Data;
using DentalWebApp.Models;

namespace DentalWebApp.Controllers
{
    public class DentistsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DentistsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dentists
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dentists.ToListAsync());
        }

        // GET: Dentists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dentist = await _context.Dentists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dentist == null)
            {
                return NotFound();
            }

            return View(dentist);
        }

        // GET: Dentists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dentists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Description")] Dentist dentist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dentist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dentist);
        }

        // GET: Dentists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dentist = await _context.Dentists.FindAsync(id);
            if (dentist == null)
            {
                return NotFound();
            }
            return View(dentist);
        }

        // POST: Dentists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Description")] Dentist dentist)
        {
            if (id != dentist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dentist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DentistExists(dentist.Id))
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
            return View(dentist);
        }

        // GET: Dentists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dentist = await _context.Dentists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dentist == null)
            {
                return NotFound();
            }

            return View(dentist);
        }

        // POST: Dentists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dentist = await _context.Dentists.FindAsync(id);
            if (dentist != null)
            {
                _context.Dentists.Remove(dentist);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DentistExists(int id)
        {
            return _context.Dentists.Any(e => e.Id == id);
        }
    }
}
