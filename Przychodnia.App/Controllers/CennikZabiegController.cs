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
    public class CennikZabiegController : Controller
    {
        private readonly PrzychodniaDbContext _context;

        public CennikZabiegController(PrzychodniaDbContext context)
        {
            _context = context;
        }

        // GET: CennikZabieg
        public async Task<IActionResult> Index(string searchName, int pg = 1)
        {
            var cenniki = await _context.CennikiZabiegi
                .Where(cz => cz.Aktywny)
                .Include(cz => cz.Zabieg)
                .ToListAsync();

            ViewBag.SzukanaNazwa = string.IsNullOrWhiteSpace(searchName) ? "" : searchName;

            if (!String.IsNullOrEmpty(searchName))
            {
                cenniki = cenniki.Where(c => c.Zabieg.Nazwa.Contains(searchName)).ToList();
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

        // GET: CennikZabieg/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cennikZabieg = await _context.CennikiZabiegi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cennikZabieg == null)
            {
                return NotFound();
            }

            return View(cennikZabieg);
        }

        // GET: CennikZabieg/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CennikZabieg/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa,Cena")] CennikZabieg cennikZabieg)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cennikZabieg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cennikZabieg);
        }

        // GET: CennikZabieg/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cennikZabieg = await _context.CennikiZabiegi.FindAsync(id);
            if (cennikZabieg == null)
            {
                return NotFound();
            }
            return View(cennikZabieg);
        }

        // POST: CennikZabieg/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,Cena")] CennikZabieg cennikZabieg)
        {
            if (id != cennikZabieg.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cennikZabieg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CennikZabiegExists(cennikZabieg.Id))
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
            return View(cennikZabieg);
        }

        // GET: CennikZabieg/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cennikZabieg = await _context.CennikiZabiegi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cennikZabieg == null)
            {
                return NotFound();
            }

            return View(cennikZabieg);
        }

        // POST: CennikZabieg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cennikZabieg = await _context.CennikiZabiegi.FindAsync(id);
            _context.CennikiZabiegi.Remove(cennikZabieg);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CennikZabiegExists(int id)
        {
            return _context.CennikiZabiegi.Any(e => e.Id == id);
        }
    }
}
