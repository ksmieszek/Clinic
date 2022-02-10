using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Przychodnia.Data;
using Przychodnia.Data.Entities;
using Przychodnia.App.Models.Pagination;

namespace Przychodnia.App.Controllers
{
    public class CennikLekarzController : Controller
    {
        private readonly PrzychodniaDbContext _context;

        public CennikLekarzController(PrzychodniaDbContext context)
        {
            _context = context;
        }

        // GET: CennikLekarz
        public async Task<IActionResult> Index(string sortPrice ,string searchName, string searchLastName, string searchSpecialization, int pg = 1)
        {
            var cenniki  = await _context.CennikiLekarze
                .Where(cl => cl.Aktywny)
                .Include(cl => cl.Lekarz)
                .Include(cl => cl.Lekarz.Rola)
                .Include(cl => cl.Lekarz.TytulNaukowy)
                .Include(cl => cl.Lekarz.Specjalizacje)
                .ToListAsync();

            ViewBag.Lakarze = await _context.Uzytkownicy.Where(u => u.RolaId != 1).ToListAsync();
            ViewBag.Specjalizacje = await _context.Specjalizacje.ToListAsync();
            ViewBag.SzukaneNazwisko = string.IsNullOrWhiteSpace(searchLastName) ? "" : searchLastName;
            ViewBag.SzukanaNazwa = string.IsNullOrWhiteSpace(searchName) ? "" : searchName;
            ViewBag.SzukanaSpecjalizacja = string.IsNullOrWhiteSpace(searchSpecialization) ? "" : searchSpecialization;
            ViewBag.sortPriceParam = string.IsNullOrWhiteSpace(sortPrice) ? "price_desc" : "";

            if (!String.IsNullOrEmpty(searchName))
            {
                cenniki = cenniki.Where(c => c.Nazwa.Contains(searchName)).ToList();
            }
            if (!String.IsNullOrEmpty(searchLastName))
            {
                cenniki = cenniki.Where(c => c.Lekarz.Nazwisko.Contains(searchLastName)).ToList();
            }
            if (!String.IsNullOrEmpty(searchSpecialization))
            {
                cenniki = cenniki.Where(c => c.Lekarz.Specjalizacje.Nazwa == searchSpecialization).ToList();
            }

            switch (sortPrice)
            {
                case "price_desc":
                    cenniki = cenniki.OrderByDescending(dDw => dDw.Cena).ToList();
                    break;
                default:
                    cenniki = cenniki.OrderBy(dDw => dDw.Cena).ToList();
                    break;
            }

            const int iloscStron = 5;
            if (pg < 1)
            {
                pg = 1;
            }
            int iliscCennikow = cenniki.Count();
            var pager = new Pager(iliscCennikow, pg, iloscStron);
            int skok = (pg - 1) * iloscStron;
            var daneDoWidoku = cenniki.Skip(skok).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(daneDoWidoku);
        }
        // GET: CennikLekarz
        public async Task<IActionResult> Refresh(int pg = 1)
        {
            return RedirectToAction(nameof(Index));
        }

        // GET: CennikLekarz/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cennikLekarz = await _context.CennikiLekarze
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cennikLekarz == null)
            {
                return NotFound();
            }

            return View(cennikLekarz);
        }

        // GET: CennikLekarz/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CennikLekarz/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa,Cena")] CennikLekarz cennikLekarz)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cennikLekarz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cennikLekarz);
        }

        // GET: CennikLekarz/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
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

        // POST: CennikLekarz/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,Cena")] CennikLekarz cennikLekarz)
        {
            if (id != cennikLekarz.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cennikLekarz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CennikLekarzExists(cennikLekarz.Id))
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

        // GET: CennikLekarz/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cennikLekarz = await _context.CennikiLekarze
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cennikLekarz == null)
            {
                return NotFound();
            }

            return View(cennikLekarz);
        }

        // POST: CennikLekarz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cennikLekarz = await _context.CennikiLekarze.FindAsync(id);
            _context.CennikiLekarze.Remove(cennikLekarz);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CennikLekarzExists(int id)
        {
            return _context.CennikiLekarze.Any(e => e.Id == id);
        }
    }
}
