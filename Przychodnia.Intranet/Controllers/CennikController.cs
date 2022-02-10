using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Przychodnia.Data;
using Przychodnia.Data.Entities;
using Przychodnia.Intranet.Models.Pagination;

namespace Przychodnia.Intranet.Controllers
{
    public class CennikController : Controller
    {
        private readonly PrzychodniaDbContext _context;

        public CennikController(PrzychodniaDbContext context)
        {
            _context = context;
        }

        // GET: Cennik
        public async Task<IActionResult> Index(int pg = 1)
        {
            var cenniki = await _context.CennikiLekarze.Include(cl => cl.Lekarz).OrderByDescending(x => x.Id).ToListAsync();

            const int iloscStron = 20;
            if (pg < 1)
            {
                pg = 1;
            }
            int iliscKontaktow = cenniki.Count();
            var pager = new Pager(iliscKontaktow, pg, iloscStron);
            int skok = (pg - 1) * iloscStron;
            var daneDoWidoku = cenniki.Skip(skok).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(daneDoWidoku);

            //return View(await _context.CennikiLekarze.ToListAsync());
        }

        // GET: Cennik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cennik = await _context.CennikiLekarze
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cennik == null)
            {
                return NotFound();
            }

            return View(cennik);
        }

        // GET: Cennik/Create
        public IActionResult Create()
        {
            ViewBag.Lekarze = _context.Uzytkownicy.Where(u => u.RolaId != 1 && u.CzyAktywny).ToList();
            return View();
        }

        // POST: Cennik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection form, bool Aktywny)
        {
            var Nazwa = form["Nazwa"].ToString();
            double Cena = 0;
            double.TryParse(form["Cena"].ToString(), out Cena);
            int LekarzId = int.Parse(form["Lekarz"].ToString());

            Uzytkownik uzytkownik = _context.Uzytkownicy.FirstOrDefault(u => u.Id == LekarzId);
            if (uzytkownik != null)
            {
                CennikLekarz cennik = new CennikLekarz()
                {
                    //Aktywny = true,
                    Nazwa = Nazwa,
                    Cena = Cena,
                    Lekarz = uzytkownik,
                    Aktywny = Aktywny
                };
                if (ModelState.IsValid)
                {
                    _context.Add(cennik);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }

        // GET: Cennik/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Lekarze = _context.Uzytkownicy.Where(u => u.RolaId != 1).ToList();
            if (id == null)
            {
                return NotFound();
            }

            var cennikLekarz = await _context.CennikiLekarze.FindAsync(id);
            if (cennikLekarz == null)
            {
                return NotFound();
            }
            return View(cennikLekarz);
        }

        // POST: Cennik/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection form, bool Aktywny)
        {
            var Nazwa = form["Nazwa"].ToString();
            double Cena = 0;
            double.TryParse(form["Cena"].ToString(), out Cena);
            int LekarzId = int.Parse(form["Lekarz"].ToString());

            Uzytkownik lekarz = _context.Uzytkownicy.FirstOrDefault(l => l.Id == LekarzId);
            CennikLekarz cennikLekarz = new CennikLekarz()
            {
                Id = id,
                Nazwa = Nazwa,
                Cena = Cena,
                Lekarz = lekarz,
                Aktywny = Aktywny
            };

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cennikLekarz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CennikExists(cennikLekarz.Id))
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
            return View(cennikLekarz);
        }

        // GET: Cennik/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cennik = await _context.CennikiLekarze
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cennik == null)
            {
                return NotFound();
            }

            return View(cennik);
        }

        // POST: Cennik/Delete/5        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cennik = await _context.CennikiLekarze.FindAsync(id);

            //_context.CennikiLekarze.Remove(cennik);
            cennik.Aktywny = false;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CennikExists(int id)
        {
            return _context.CennikiLekarze.Any(e => e.Id == id);
        }
    }
}
