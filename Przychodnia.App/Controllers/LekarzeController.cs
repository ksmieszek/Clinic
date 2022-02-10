using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Przychodnia.App.Models;
using Przychodnia.Data;
using Przychodnia.Data.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Przychodnia.App.Controllers
{
    [Route("[controller]")]
    public class LekarzeController : Controller
    {
        private readonly PrzychodniaDbContext _context;
        private IMapper _mapper;

        public LekarzeController(PrzychodniaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string searchString, string Specjalizacje, int PageNumber = 1, bool prom = false)
        {
            List<SelectListItem> items = _context.Specjalizacje.Select(s => new SelectListItem
            {
                Text = s.Nazwa,
                Value = s.Id.ToString(),
            }).ToList();

            items.Insert(0, new SelectListItem() { Value = "0", Text = "Wszystkie" });

            ViewBag.Specjalizacje = items;
            ViewData["GetLekarze"] = searchString;

            var lekarz = _context.Uzytkownicy.Where(m => m.RolaId == 2).Include(m => m.Specjalizacje).AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                lekarz = lekarz.Where(s => s.Nazwisko.Contains(searchString) || s.Imie.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(Specjalizacje))
            {
                lekarz = lekarz.Where(s => s.SpecjalizacjeId.ToString() == Specjalizacje);
            }
            if (prom)
            {
                lekarz = lekarz.Where(s => s.Promowany).Where(s => s.CzyAktywny);
            }


            ViewBag.TotalPages = Math.Ceiling(lekarz.Count() / 8.0);
            ViewBag.PageNumber = PageNumber;

            lekarz = lekarz.Skip((PageNumber - 1) * 8).Take(8);

            return View(await lekarz.AsNoTracking().ToListAsync());
        }

        [HttpGet("Szczegoly/{userId}")]
        public async Task<ActionResult> Szczegoly([FromRoute] int userId, [FromQuery] int? year, [FromQuery] int? month)
        {
            if (year == null)
            {
                year = DateTime.Now.Year;
            }

            if (month == null)
            {
                month = DateTime.Now.Month;
            }

            var lekarz = _context.Uzytkownicy.FirstOrDefault(u => u.Id == userId);

            try
            {
                var referer = new Uri(Request.Headers["Referer"].ToString());
                ViewBag.FromPath = referer.AbsolutePath;
            }
            catch(Exception)
            {
                ViewBag.FromPath = "/Lekarze";
            }
                        
            ViewBag.UserId = userId;
            ViewBag.Year = year;
            ViewBag.Month = month;
            ViewBag.Cennik =
            (
                from cennik in _context.CennikiLekarze
                orderby cennik.Cena descending
                where cennik.Lekarz.Id == userId
                select cennik
            ).ToList();
            if (ViewBag.Cennik.Count == 0)
            {
                ViewBag.Cennik =
                (
                    from cennik in _context.CennikiPoradnie
                    orderby cennik.Cena descending
                    where cennik.Poradnia.Lekarze.Contains(lekarz)
                    select cennik
                ).ToList();
            }

            ViewBag.Schedules = _context.Harmonogramy
                .Where(h => h.DatoGodzina.Year == year && h.DatoGodzina.Month == month && h.Lekarz.Id == userId).Select(h =>
                    new ScheduleForDoctorDetailView
                    {
                        DateTime = h.DatoGodzina,
                        IsTaken = _context.Wizyty.FirstOrDefault(w => w.Harmonogram == h) != null ? true : false
                    }).OrderBy(h => h.DateTime).ToList();

            ViewBag.Szczegoly = _context.Uzytkownicy.Include(u => u.TytulNaukowy).FirstOrDefault(u => u.Id == userId);
            ViewBag.Specjalizacja = _context.Uzytkownicy.Include(u => u.Specjalizacje).FirstOrDefault(u => u.Id == userId);

            return View(await _context.Uzytkownicy.Where(t => t.Id == userId).FirstOrDefaultAsync());
        }

        [HttpGet("UmowWizyte/{lekarzId}")]
        [Authorize]
        public async Task<ActionResult> UmowWizyte([FromRoute] int lekarzId, [FromQuery] DateTime dateTime)
        
        {
            ViewBag.Lekarz = _context.Uzytkownicy.Include(u => u.TytulNaukowy).FirstOrDefault(u => u.Id == lekarzId);
            ViewBag.DateTime = dateTime;
            return View();
        }

        [HttpPost("UmowWizyte/{lekarzId}")]
        public async Task<ActionResult> ProceedUmowWizyte([FromRoute] int lekarzId, [FromQuery] DateTime dateTime)
        {
            var foo = _context.Harmonogramy.ToList();
            var harmonogram = await _context.Harmonogramy.FirstOrDefaultAsync(h =>
                h.DatoGodzina.Year == dateTime.Year &&
                h.DatoGodzina.Month == dateTime.Month &&
                h.DatoGodzina.Day == dateTime.Day &&
                h.DatoGodzina.Hour == dateTime.Hour &&
                h.DatoGodzina.Minute == dateTime.Minute &&
                h.Lekarz.Id == lekarzId
            );
            var user = _context.Uzytkownicy.FirstOrDefault(x => x.Email == HttpContext.User.Identity.Name);

            if (harmonogram == null || user == null)
            {
                return BadRequest();
            }

            var alreadySavedWizyta =
                await _context.Wizyty.FirstOrDefaultAsync(w => DateTime.Equals(w.Harmonogram.DatoGodzina, dateTime));

            if (alreadySavedWizyta != null)
            {
                return BadRequest();
            }

            _context.Wizyty.Add(new Wizyta
            {
                Harmonogram = harmonogram,
                Pacjent = user,
            });

            await _context.SaveChangesAsync();

            return RedirectToAction("Szczegoly", new {userId = lekarzId});
        }

        [HttpPost("filters")]
        public List<LekarzeDto> Filter([FromBody]LekarzeFilter lekarzeFilter)
        {
            if(!String.IsNullOrEmpty(lekarzeFilter.searchString))
            {
                if (lekarzeFilter.Specjalizacje == 0)
                {
                    var lekarze = _context.Uzytkownicy
                    .Include(m => m.Rola)
                    .Include(d => d.Specjalizacje)
                    .Where(x => x.Imie.Contains(lekarzeFilter.searchString) || x.Nazwisko.Contains(lekarzeFilter.searchString))
                    .ToList();
                    return _mapper.Map<List<LekarzeDto>>(lekarze);
                }
                else
                {
                    var lekarze = _context.Uzytkownicy
                    .Include(m => m.Rola)
                    .Include(d => d.Specjalizacje)
                    .Where(x => x.Imie.Contains(lekarzeFilter.searchString) || x.Nazwisko.Contains(lekarzeFilter.searchString) && x.SpecjalizacjeId == lekarzeFilter.Specjalizacje)
                    .ToList();
                    return _mapper.Map<List<LekarzeDto>>(lekarze);
                }
            } else
            {
                if (lekarzeFilter.Specjalizacje == 0)
                {
                    var lekarze = _context.Uzytkownicy
                    .Include(m => m.Rola)
                    .Include(d => d.Specjalizacje)
                    .ToList();
                    return _mapper.Map<List<LekarzeDto>>(lekarze);
                }
                else
                {
                    var lekarze = _context.Uzytkownicy
                    .Include(m => m.Rola)
                    .Include(d => d.Specjalizacje)
                    .Where(x => x.SpecjalizacjeId == lekarzeFilter.Specjalizacje)
                    .ToList();
                    return _mapper.Map<List<LekarzeDto>>(lekarze);
                }
            }
            
        }

    }

}