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
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Appointments.Include(a => a.Dentist).Include(a => a.Patient);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.Dentist)
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            ViewData["DentistId"] = new SelectList(_context.Dentists, "Id", "FullName");
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "FullName");
            return View();
        }


        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AppointmentDate,Duration,DentistId,PatientId,Description")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                if (IsAppointmentOverlapping(appointment))
                {
                    ModelState.AddModelError("", "The appointment overlaps with another appointment for the same dentist.");
                    ViewData["DentistId"] = new SelectList(_context.Dentists, "Id", "FullName", appointment.DentistId);
                    ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "FullName", appointment.PatientId);
                    return View(appointment);
                }

                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DentistId"] = new SelectList(_context.Dentists, "Id", "FullName", appointment.DentistId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "FullName", appointment.PatientId);
            return View(appointment);
        }

        // GET: Appointments/Edit/5

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            ViewData["DentistId"] = new SelectList(_context.Dentists, "Id", "FullName", appointment.DentistId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "FullName", appointment.PatientId);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AppointmentDate,Duration,DentistId,PatientId,Description")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (IsAppointmentOverlapping(appointment))
                {
                    ModelState.AddModelError("", "The appointment overlaps with another appointment for the same dentist.");
                    ViewData["DentistId"] = new SelectList(_context.Dentists, "Id", "FullName", appointment.DentistId);
                    ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "FullName", appointment.PatientId);
                    return View(appointment);
                }

                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.Id))
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
            ViewData["DentistId"] = new SelectList(_context.Dentists, "Id", "FullName", appointment.DentistId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "FullName", appointment.PatientId);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.Dentist)
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.Id == id);
        }

        private bool IsAppointmentOverlapping(Appointment appointment)
        {
            return _context.Appointments.Any(a =>
                a.DentistId == appointment.DentistId &&
                a.Id != appointment.Id &&
                ((a.AppointmentDate <= appointment.AppointmentDate && a.AppointmentDate.AddMinutes(a.Duration) > appointment.AppointmentDate) ||
                 (appointment.AppointmentDate <= a.AppointmentDate && appointment.AppointmentDate.AddMinutes(appointment.Duration) > a.AppointmentDate)));
        }
    }
}
