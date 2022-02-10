using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Przychodnia.App.Models.Pagination;
using Przychodnia.Data;
using Przychodnia.Data.Entities;

namespace Przychodnia.App.Controllers
{
    public class CennikPoradniaController : Controller
    {
        private readonly PrzychodniaDbContext _context;

        public CennikPoradniaController(PrzychodniaDbContext context)
        {
            _context = context;
        }

        // GET: CennikPoradnia
        public async Task<IActionResult> Index(string searchName, int pg = 1)
        {
            var cenniki = await _context.CennikiPoradnie
                .Where(cp => cp.Aktywny)
                .Include(cp => cp.Poradnia)
                .Include(cp => cp.Poradnia.Lekarze)
                .ToListAsync();

            ViewBag.SzukanaNazwa = string.IsNullOrWhiteSpace(searchName) ? "" : searchName;

            if (!String.IsNullOrEmpty(searchName))
            {
                cenniki = cenniki.Where(cp => cp.Nazwa.Contains(searchName)) .ToList();
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

        public async Task<IActionResult> Refresh(int pg = 1)
        {
            return RedirectToAction(nameof(Index));
        }

        // GET: CennikPoradnia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cennikPoradnia = await _context.CennikiPoradnie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cennikPoradnia == null)
            {
                return NotFound();
            }

            return View(cennikPoradnia);
        }

        // GET: CennikPoradnia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CennikPoradnia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa,Cena")] CennikPoradnia cennikPoradnia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cennikPoradnia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cennikPoradnia);
        }

        // GET: CennikPoradnia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cennikPoradnia = await _context.CennikiPoradnie.FindAsync(id);
            if (cennikPoradnia == null)
            {
                return NotFound();
            }
            return View(cennikPoradnia);
        }

        // POST: CennikPoradnia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,Cena")] CennikPoradnia cennikPoradnia)
        {
            if (id != cennikPoradnia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cennikPoradnia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CennikPoradniaExists(cennikPoradnia.Id))
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
            return View(cennikPoradnia);
        }

        // GET: CennikPoradnia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cennikPoradnia = await _context.CennikiPoradnie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cennikPoradnia == null)
            {
                return NotFound();
            }

            return View(cennikPoradnia);
        }

        // POST: CennikPoradnia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cennikPoradnia = await _context.CennikiPoradnie.FindAsync(id);
            _context.CennikiPoradnie.Remove(cennikPoradnia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CennikPoradniaExists(int id)
        {
            return _context.CennikiPoradnie.Any(e => e.Id == id);
        }
    }
}
