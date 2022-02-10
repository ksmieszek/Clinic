using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Przychodnia.Data;
using Przychodnia.Intranet.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Przychodnia.Intranet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PrzychodniaDbContext _context;

        public HomeController(ILogger<HomeController> logger, PrzychodniaDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.LekarzeIlość = _context.Uzytkownicy.Where(u => u.RolaId != 1).Count();
            ViewBag.PacjenciIlość = _context.Uzytkownicy.Where(u => u.RolaId == 1).Count();
            ViewBag.PoradnieiIlość = _context.Poradnie.Where(p => p.Aktywna).Count();
            ViewBag.AktywneWizytyIlość = _context.Wizyty.Include(w => w.Harmonogram).Where(w => w.Harmonogram != null && w.Harmonogram.DatoGodzina > DateTime.Now).Where(w => !w.CzyZrealizowana).Count();


            ViewBag.NadchodzaceZabiegi = _context.Wizyty.Include(w => w.Harmonogram).
                                                         Include(w => w.Harmonogram.Lekarz).
                                                         Include(w => w.Pacjent).
                                                         Where(w => w.Harmonogram != null && w.Harmonogram.DatoGodzina > DateTime.Now).
                                                         OrderBy(w => w.Harmonogram.DatoGodzina).
                                                         Take(5).ToList();


            ViewBag.NowiPacjenci = _context.Uzytkownicy.Where(u => u.RolaId == 1).
                                                        OrderByDescending(u => u.Id).
                                                        Take(5).ToList();

            ViewBag.Lekarze = _context.Uzytkownicy.Where(u => u.RolaId != 1).
                                                        OrderBy(u => u.Id).
                                                        Take(5).ToList();
            ViewBag.Poradnie = _context.Poradnie.       OrderBy(u => u.Id).
                                                        Take(5).ToList();

            return View();
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
