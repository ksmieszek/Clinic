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
    public class CennikZabiegController : Controller
    {
        private readonly PrzychodniaDbContext _context;

        public CennikZabiegController(PrzychodniaDbContext context)
        {
            _context = context;
        }

        // GET: CennikZabieg
        public async Task<IActionResult> Index(int pg = 1)
        {
            var cenniki = await _context.CennikiZabiegi.Include(cz => cz.Zabieg).OrderByDescending(x => x.Id).ToListAsync();

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

            //return View(await _context.CennikiZabiegi.Include(cz => cz.Zabieg).ToListAsync());
        }

        public IActionResult CennikiMainView()
        {
            return  View();
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
            ViewBag.Zabiegi = _context.Zabiegi.Where(z => z.Aktywny).ToList();
            return View();
        }

        // POST: CennikZabieg/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection form, bool Aktywny)
        {
            var Nazwa = form["Nazwa"].ToString();
            double Cena = 0;
            double.TryParse(form["Cena"].ToString(), out Cena);
            int ZabiegId = int.Parse(form["Zabieg"].ToString());

            Zabieg zabieg = _context.Zabiegi.FirstOrDefault(z => z.Id == ZabiegId);
            if(zabieg != null)
            {
                CennikZabieg cennik = new CennikZabieg()
                {
                    Nazwa = Nazwa,
                    Cena = Cena,
                    Zabieg = zabieg,
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

        // GET: CennikZabieg/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Zabiegi = _context.Zabiegi.ToList();
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
        public async Task<IActionResult> Edit(int id, IFormCollection form, bool Aktywny)
        {

            var Nazwa = form["Nazwa"].ToString();
            double Cena = 0;
            double.TryParse(form["Cena"].ToString(), out Cena);
            int ZabiegId = int.Parse(form["Zabieg"].ToString());

            Zabieg zabieg = _context.Zabiegi.FirstOrDefault(z => z.Id == ZabiegId);
            CennikZabieg cennikZabieg = new CennikZabieg()
            {
                //Aktywny = true,
                Id = id,
                Nazwa = Nazwa,
                Cena = Cena,
                Zabieg = zabieg,
                Aktywny = Aktywny
            };

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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cennikZabieg = await _context.CennikiZabiegi.FindAsync(id);
            //_context.CennikiZabiegi.Remove(cennikZabieg);
            cennikZabieg.Aktywny = false;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CennikZabiegExists(int id)
        {
            return _context.CennikiZabiegi.Any(e => e.Id == id);
        }
    }
}
