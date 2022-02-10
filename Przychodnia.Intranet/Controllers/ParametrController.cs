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
    public class ParametrController : Controller
    {
        private readonly PrzychodniaDbContext _context;

        public ParametrController(PrzychodniaDbContext context)
        {
            _context = context;
        }

        // GET: Parametr
        public async Task<IActionResult> Index(int PageNumber = 1)
        {
            var parametr = from a in _context.Parametry orderby a.Id descending where a.Aktywny==true
                        select a;

            ViewBag.TotalPages = Math.Ceiling(parametr.Count() / 20.0);
            ViewBag.PageNumber = PageNumber;
            parametr = parametr.Skip((PageNumber - 1) * 20).Take(20);

            //return View(await _context.Parametry.ToListAsync());
            return View(parametr);
        }

        // GET: Parametr/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parametr = await _context.Parametry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parametr == null)
            {
                return NotFound();
            }

            return View(parametr);
        }

        // GET: Parametr/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parametr/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa,Pozycja,Wartosc,Opis,Aktywny")] Parametr parametr)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parametr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parametr);
        }

        // GET: Parametr/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parametr = await _context.Parametry.FindAsync(id);
            if (parametr == null)
            {
                return NotFound();
            }
            return View(parametr);
        }

        // POST: Parametr/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,Pozycja,Wartosc,Opis,Aktywny")] Parametr parametr)
        {
            if (id != parametr.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parametr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParametrExists(parametr.Id))
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
            return View(parametr);
        }

        // GET: Parametr/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parametr = await _context.Parametry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parametr == null)
            {
                return NotFound();
            }

            return View(parametr);
        }

        // POST: Parametr/Delete/5
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parametr = await _context.Parametry.FindAsync(id);
            //_context.Parametry.Remove(parametr);
            parametr.Aktywny = false;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParametrExists(int id)
        {
            return _context.Parametry.Any(e => e.Id == id);
        }
    }
}
