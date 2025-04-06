using System.Diagnostics;
using DentalWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DentalWebApp.Data;

namespace DentalWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var totalDentists = await _context.Dentists.CountAsync();
            var totalPatients = await _context.Patients.CountAsync();
            var totalAppointments = await _context.Appointments.CountAsync();
            var upcomingAppointments = await _context.Appointments.CountAsync(a => a.AppointmentDate > DateTime.Now);

            var statistics = new Statistics
            {
                TotalDentists = totalDentists,
                TotalPatients = totalPatients,
                TotalAppointments = totalAppointments,
                UpcomingAppointments = upcomingAppointments
            };

            return View(statistics);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
