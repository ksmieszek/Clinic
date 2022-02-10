using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Przychodnia.Data;
using Przychodnia.Data.Entities;
using Przychodnia.Intranet.Models.Pagination;

namespace Przychodnia.Intranet.Controllers
{
    public class AdresController : Controller
    {
        private readonly PrzychodniaDbContext _context;

        public AdresController(PrzychodniaDbContext context)
        {
            _context = context;
        }

        // GET: Adres
        public IActionResult Index(int pg = 1)
        {
            var adresy = _context.Adresy.OrderByDescending(x => x.Id).ToList();
            

            const int iloscStron = 5;
            if (pg < 1)
            {
                pg = 1;
            }
            int iliscKontaktow = adresy.Count();
            var pager = new Pager(iliscKontaktow, pg, iloscStron);
            int skok = (pg - 1) * iloscStron;
            var daneDoWidoku = adresy.Skip(skok).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(daneDoWidoku);
        }

        // GET: Adres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adres = await _context.Adresy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adres == null)
            {
                return NotFound();
            }

            return View(adres);
        }

        // GET: Adres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Miejscowosc,KodPocztowy,Ulica,NumerDomu,NumerMieszkania,Aktywny")] Adres adres)
        {
            adres.Aktywny = true;

            if (ModelState.IsValid)
            {
                _context.Add(adres);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adres);
        }

        // GET: Adres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adres = await _context.Adresy.FindAsync(id);
            if (adres == null)
            {
                return NotFound();
            }
            return View(adres);
        }

        // POST: Adres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Miejscowosc,KodPocztowy,Ulica,NumerDomu,NumerMieszkania,Aktywny")] Adres adres)
        {
            if (id != adres.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adres);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdresExists(adres.Id))
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
            return View(adres);
        }

        // GET: Adres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adres = await _context.Adresy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adres == null)
            {
                return NotFound();
            }

            return View(adres);
        }

        // POST: Adres/Delete/5
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adres = await _context.Adresy.FindAsync(id);
            adres.Aktywny = false;
            //_context.Adresy.Remove(adres);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdresExists(int id)
        {
            return _context.Adresy.Any(e => e.Id == id);
        }
    }
}
