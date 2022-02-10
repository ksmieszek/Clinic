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
    public class SpecjalizacjaController : Controller
    {
        private readonly PrzychodniaDbContext _context;

        public SpecjalizacjaController(PrzychodniaDbContext context)
        {
            _context = context;
        }

        // GET: Specjalizacja
        public async Task<IActionResult> Index(string sortOrder, string searchQuery, int PageNumber = 1)
        {
            ViewBag.NameSortParm = sortOrder == "name" ? "name_desc" : "name";

            var specjalizacje = from a in _context.Specjalizacje where a.Aktywna==true                                
                        select a;

            if (!String.IsNullOrEmpty(searchQuery))
            {
                specjalizacje = specjalizacje.Where(a => a.Nazwa.Contains(searchQuery));
            }

            switch (sortOrder)
            {
                case "name":
                    specjalizacje = specjalizacje.OrderBy(a => a.Nazwa);
                    break;
                case "name_desc":
                    specjalizacje = specjalizacje.OrderByDescending(a => a.Nazwa);
                    break;

                default:
                    {
                        ViewBag.NameSortParm = "name";
                        specjalizacje = specjalizacje.OrderBy(a => a.Id);
                        break;
                    }
            }

            ViewBag.TotalPages = Math.Ceiling(specjalizacje.Count() / 20.0);
            ViewBag.PageNumber = PageNumber;
            specjalizacje = specjalizacje.Skip((PageNumber - 1) * 20).Take(20);
            // return View(await _context.Specjalizacje.ToListAsync());
            return View(specjalizacje);
        }

        // GET: Specjalizacja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specjalizacja = await _context.Specjalizacje
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specjalizacja == null)
            {
                return NotFound();
            }

            return View(specjalizacja);
        }

        // GET: Specjalizacja/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Specjalizacja/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa,Opis,Aktywna")] Specjalizacja specjalizacja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specjalizacja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specjalizacja);
        }

        // GET: Specjalizacja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specjalizacja = await _context.Specjalizacje.FindAsync(id);
            if (specjalizacja == null)
            {
                return NotFound();
            }
            return View(specjalizacja);
        }

        // POST: Specjalizacja/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,Opis,Aktywna")] Specjalizacja specjalizacja)
        {
            if (id != specjalizacja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specjalizacja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecjalizacjaExists(specjalizacja.Id))
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
            return View(specjalizacja);
        }

        // GET: Specjalizacja/Delete/5
        public async Task<IActionResult> Dezaktywuj(int id)
        {
            var specjalizacja = await _context.Specjalizacje.FindAsync(id);
            specjalizacja.Aktywna = false;
            _context.Update(specjalizacja);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }       

        private bool SpecjalizacjaExists(int id)
        {
            return _context.Specjalizacje.Any(e => e.Id == id);
        }
    }
}
