using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Przychodnia.Data;
using Przychodnia.Data.Entities;



namespace Przychodnia.Intranet.Controllers
{
    public class StronaController : Controller
    {
        private readonly PrzychodniaDbContext _context;

        public StronaController(PrzychodniaDbContext context)
        {
            _context = context;
        }

        // GET: Strona
        public async Task<IActionResult> Index()
        {
            return View(await _context.Strony.ToListAsync());
        }

        // GET: Strona/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var strona = await _context.Strony
                .FirstOrDefaultAsync(m => m.IdStrony == id);
            if (strona == null)
            {
                return NotFound();
            }

            return View(strona);
        }

        // GET: Strona/Create
        public IActionResult Create()
        {
            ViewBag.Ikony = new SelectList(_context.Ikony.ToList(), "Id", "Nazwa");
            Strona strona = new Strona();
            strona.CzyWOknie = true;
            return View(strona);
        }

        // POST: Strona/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStrony,LinkTytul,Tytul,Tresc,Pozycja,CzyWOknie,CzyIkona,Ikona,IkonaNazwa, IkonaId")] Strona strona)
        {
            strona.CzyWOknie = true;
            strona.Aktywna = true;

            if (ModelState.IsValid)
            {
                _context.Add(strona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(strona);
        }

        // GET: Strona/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var strona = await _context.Strony.FindAsync(id);
            ViewBag.Ikony = new SelectList(_context.Ikony.ToList(), "Id", "Nazwa");
            if (strona == null)
            {
                return NotFound();
            }
            return View(strona);
        }
        public async Task<IActionResult> DeletePP(int id)
        {
            var strona = await _context.Strony.FindAsync(id);
            //_context.Strony.Remove(strona);
            strona.Aktywna = false;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Strona/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStrony,LinkTytul,Tytul,Tresc,Pozycja,CzyWOknie,CzyIkona,Ikona,IkonaNazwa, IkonaId")] Strona strona)
        {
            if (id != strona.IdStrony)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(strona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StronaExists(strona.IdStrony))
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
            return View(strona);
        }

        // GET: Strona/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var strona = await _context.Strony
                .FirstOrDefaultAsync(m => m.IdStrony == id);
            if (strona == null)
            {
                return NotFound();
            }

            return View(strona);
        }

        // POST: Strona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var strona = await _context.Strony.FindAsync(id);
            //_context.Strony.Remove(strona);
            strona.Aktywna = false;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StronaExists(int id)
        {
            return _context.Strony.Any(e => e.IdStrony == id);
        }
    }
}
