using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Przychodnia.App.Models.Pagination;
using Przychodnia.Data;
using Przychodnia.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Przychodnia.App.Controllers
{
    public class PoradnieController : Controller
    {
        private readonly PrzychodniaDbContext _context;

        public PoradnieController(PrzychodniaDbContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index(string filterValue, string searchString, int pg = 1)
        {
            ViewData["GetPoradnie"] = searchString;

            var poradnia = _context.Poradnie.Where(m => m.Aktywna == true).Include(m => m.Lekarze).ToList();

            const int iloscStron = 5;
            if (pg < 1)
            {
                pg = 1;
            }
            int iliscCennikow = poradnia.Count();
            var pager = new Pager(iliscCennikow, pg, iloscStron);
            int skok = (pg - 1) * iloscStron;
            var daneDoWidoku = poradnia.Skip(skok).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;


            /*
            if (!String.IsNullOrEmpty(searchString))
            {
                poradnia = poradnia.Where(s => s.Nazwa.Contains(searchString));
            }*/

            return View(daneDoWidoku);

        }
        public async Task<IActionResult> Details(int? id, int pg = 1)        
        {
            if (id == null)
            {
                return NotFound();
            }

            var poradnia = await _context.Poradnie.Include(x => x.Lekarze)
                .FirstOrDefaultAsync(m => m.Id == id);

            
            if (poradnia == null)
            {
                return NotFound();
            }
            var specjalizacja = _context.Specjalizacje.ToList();

            foreach (var lekarzItem in poradnia.Lekarze)
            {
                foreach (var specjalizacjaItem in specjalizacja)
                {
                    if (lekarzItem.SpecjalizacjeId == specjalizacjaItem.Id)
                    {
                        lekarzItem.Specjalizacje = specjalizacjaItem;
                    }
                }
            }
            
            return View(poradnia);
        }       

    }
}

