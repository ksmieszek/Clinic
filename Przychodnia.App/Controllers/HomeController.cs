using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Przychodnia.App.Models;
using Przychodnia.Data;
using System.Diagnostics;
using System.Linq;

namespace Przychodnia.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly PrzychodniaDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(PrzychodniaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id)
        {
            ViewBag.ModelAktualnosci =
                (
                from aktualnosc in _context.Aktualnosci
                orderby aktualnosc.Priorytet descending
                where aktualnosc.Odbiorca == "Wszyscy"
                select aktualnosc
                ).Take(4).ToList();

            ViewBag.ModelSpecjalisci =
               (
               from uzytkownik in _context.Uzytkownicy
               where (uzytkownik.RolaId == 2 && uzytkownik.CzyAktywny == true)
               orderby uzytkownik.Id descending
               select uzytkownik
               ).Select(u => new Specialista(u) { NazwaSpecialnosci = u.Specjalizacje.Nazwa, TytulNaukowy = u.TytulNaukowy.Nazwa }).ToList();

            var stronaONasElements = (
                from StronaOnas in _context.StronaOnas
                orderby StronaOnas.Pozycja descending
                select StronaOnas
                ).ToList();

            //TempData["StronaONas"] = JsonConvert.SerializeObject(stronaONasElements);
            HttpContext.Session.SetString("StronaONas", JsonConvert.SerializeObject(stronaONasElements));

            ViewBag.ModelOnas =
                (
                from StronaOnas in _context.StronaOnas
                orderby StronaOnas.Pozycja ascending
                select StronaOnas
                ).ToList();

            var stronaElements = _context.Strony.Include(x => x.Ikona).OrderBy(i => i.IdStrony).ToList();
            //var stronaElements = (
            //    from Strona in _context.Strony
            //    orderby Strona.IdStrony descending
            //    select Strona
            //    ).ToList();

            //TempData["ModelStrona"] = JsonConvert.SerializeObject(stronaElements);
            HttpContext.Session.SetString("ModelStrona", JsonConvert.SerializeObject(stronaElements));


            ViewBag.ModelStrona = _context.Strony.Include(x => x.Ikona).OrderBy(i => i.IdStrony).ToList();
                //(
                //from Strona in _context.Strony
                //orderby Strona.IdStrony descending
                //select Strona
                //).ToList();

            var poradniaElements = (
                from Poradnie in _context.Poradnie
                orderby Poradnie.Id descending
                select Poradnie
                ).ToList();


            ViewBag.ModelPoradnie =
                (
                from Poradnie in _context.Poradnie
                orderby Poradnie.Id descending
                select Poradnie
                ).ToList();

            ViewBag.ModelParametry =
                (
                from Parametry in _context.Parametry where Parametry.Aktywny==true
                orderby Parametry.Pozycja, Parametry.Wartosc
                select Parametry
                ).ToList();

            return View();
        }

        [Authorize]
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
