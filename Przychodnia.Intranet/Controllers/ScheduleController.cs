using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Przychodnia.Data;
using Przychodnia.Data.Entities;
using Przychodnia.Intranet.Models.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Przychodnia.Intranet.Controllers
{
    [Route("[controller]")]
    public class ScheduleController : Controller
    {
        private readonly PrzychodniaDbContext _context;

        public ScheduleController(PrzychodniaDbContext context)
        {
            _context = context;
        }

        [HttpGet("Edit/{userId}/{year:int:min(2000)}")]
        public IActionResult YearMonthsList([FromRoute] int userId, [FromRoute] int year)
        {
            var uzytkownik = _context.Uzytkownicy.Include(u => u.TytulNaukowy).FirstOrDefault(u => u.Id == userId);

            if (uzytkownik == null)
            {
                return BadRequest();
            }

            var model = new ScheduleYearMonthsList {
                UserId = userId,
                UserTitle = uzytkownik.TytulNaukowy.Nazwa,
                UserFullName = $"{uzytkownik.Imie} {uzytkownik.Nazwisko}",
                Year = year
            };
            return View(model);
        }

        [HttpGet("Edit/{userId}/{year:int:min(2000)}/{month:int:min(1):max(12)}")]
        public IActionResult EditMonthHours(
            [FromRoute] int userId,
            [FromRoute] int year,
            [FromRoute] int month,
            [FromForm] EditScheduleMonthHours editSchedule)
        {
            var uzytkownik = _context.Uzytkownicy.Include(u => u.TytulNaukowy).FirstOrDefault(u => u.Id == userId);

            if (uzytkownik == null)
            {
                return BadRequest();
            }

            var times = _context.Harmonogramy.Where(h => h.DatoGodzina.Year == year && h.DatoGodzina.Month == month && h.Lekarz.Id == userId).ToList();

            var model = new EditScheduleMonthHours
            {
                UserId = userId,
                UserTitle = uzytkownik?.TytulNaukowy?.Nazwa,
                UserFullName = $"{uzytkownik.Imie} {uzytkownik.Nazwisko}",
                Days = new List<EditScheduleDay>(),
                Month = month,
                Year = year,
                Times = times,
            };

            return View(model);
        }

        [HttpPost("Edit/{userId}/{year:int:min(2000)}/{month:int:min(1):max(12)}")]
        public IActionResult PerformEdit(
            [FromRoute] int userId,
            [FromRoute] int year,
            [FromRoute] int month,
            [FromForm] EditScheduleFormModel editSchedule)
        {
            var savedMonthHours = _context.Harmonogramy.Where(h => h.DatoGodzina.Year == year && h.DatoGodzina.Month == month && h.Lekarz.Id == userId).ToList();
            var uzytkownik = _context.Uzytkownicy.FirstOrDefault(u => u.Id == userId);

            if (uzytkownik == null) {
                return BadRequest();
            }

            var toDelete = savedMonthHours.Where(s => {
                var included = editSchedule.Times.Where(t => t.Hour == s.DatoGodzina.Hour && t.Minute == s.DatoGodzina.Minute && s.DatoGodzina.Date == t.Date).ToList();
                return included.Count == 0;
            }).ToList();

            var toAdd = editSchedule.Times.Where(t => {
                var included = savedMonthHours.Where(s => s.DatoGodzina.Hour == t.Hour && s.DatoGodzina.Minute == t.Minute && s.DatoGodzina.Date == t.Date).ToList();
                return included.Count == 0;
            }).Select(t => new Harmonogram {
                DatoGodzina = t,
                Lekarz = uzytkownik,
            }).ToList();            

            foreach (var toDel in toDelete)
            {
                toDel.Aktywny = false;
            }

            //_context.Harmonogramy.RemoveRange(toDelete);
            _context.Harmonogramy.UpdateRange(toDelete);
            
            _context.Harmonogramy.AddRange(toAdd);

            _context.SaveChanges();

            return Redirect(Request.Headers["Referer"]);
        }
    }
}
