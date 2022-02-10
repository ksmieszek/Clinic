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
    public class CennikPoradniaController : Controller
    {
        private readonly PrzychodniaDbContext _context;

        public CennikPoradniaController(PrzychodniaDbContext context)
        {
            _context = context;
        }

        // GET: CennikPoradnia
        public async Task<IActionResult> Index(int pg = 1)
        {
            var cenniki = await _context.CennikiPoradnie.Include(cz => cz.Poradnia).OrderByDescending(x => x.Id).ToListAsync();

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

            //return View(await _context.CennikiPoradnie.Include(cz => cz.Poradnia).ToListAsync());

        }

        public IActionResult PoradnieMainView()
        {
            return View();
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
            ViewBag.Poradnie = _context.Poradnie.Where(p => p.Aktywna).ToList();
            return View();
        }

        // POST: CennikPoradnia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection form, bool Aktywny)
        {
            var Nazwa = form["Nazwa"].ToString();
            double Cena = 0;
            double.TryParse(form["Cena"].ToString(), out Cena);
            int PoradniaId = int.Parse(form["Poradnia"].ToString());

            Poradnia poradnia= _context.Poradnie.FirstOrDefault(z => z.Id == PoradniaId);
            if (poradnia != null)
            {
                CennikPoradnia cennik = new CennikPoradnia()
                {
                    //Aktywny = true,
                    Nazwa = Nazwa,
                    Cena = Cena,
                    Poradnia = poradnia,
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

        // GET: CennikPoradnia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Poradnie = _context.Poradnie.ToList();
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
        public async Task<IActionResult> Edit(int id, IFormCollection form, bool Aktywny)
        {
            var Nazwa = form["Nazwa"].ToString();
            double Cena = 0;
            double.TryParse(form["Cena"].ToString(), out Cena);
            int PoradniaId = int.Parse(form["Poradnia"].ToString());

            Poradnia poradnia = _context.Poradnie.FirstOrDefault(z => z.Id == PoradniaId);

            CennikPoradnia cennikPoradnia = new CennikPoradnia()
            {
                Id = id,
                Nazwa = Nazwa,
                Cena = Cena,
                Poradnia = poradnia,
                Aktywny = Aktywny
            };

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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cennik = await _context.CennikiPoradnie.FindAsync(id);
            //_context.CennikiPoradnie.Remove(cennik);
            cennik.Aktywny = false;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CennikExists(int id)
        {
            return _context.CennikiLekarze.Any(e => e.Id == id);
        }

        private bool CennikPoradniaExists(int id)
        {
            return _context.CennikiPoradnie.Any(e => e.Id == id);
        }
    }
}
