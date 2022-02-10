using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Przychodnia.Data;
using Przychodnia.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Przychodnia.Intranet.Controllers
{
    public class TytulNaukowyController : Controller
    {
        private readonly PrzychodniaDbContext _context;

        public TytulNaukowyController(PrzychodniaDbContext context)
        {
            _context = context;
        }

        // GET: TytulNaukowy
        public async Task<IActionResult> Index(string sortOrder, string searchQuery, int PageNumber = 1)
        {
           
            ViewBag.NameSortParm = sortOrder == "name" ? "name_desc" : "name";

            var tytul = from a in _context.TytulyNaukowe
                        select a;
            if (!String.IsNullOrEmpty(searchQuery))
            {
                tytul = tytul.Where(a => a.Nazwa.Contains(searchQuery));
            }

            switch (sortOrder)
            {
                case "name":
                    tytul = tytul.OrderBy(a => a.Nazwa);
                    break;
                case "name_desc":
                    tytul = tytul.OrderByDescending(a => a.Nazwa);
                    break;
           
                default:
                    {
                        ViewBag.NameSortParm = "name";
                        tytul = tytul.OrderBy(a => a.Id);
                        break;
                    }
            }

            ViewBag.TotalPages = Math.Ceiling(tytul.Count() / 20.0);
            ViewBag.PageNumber = PageNumber;
            tytul = tytul.Skip((PageNumber - 1) * 20).Take(20);

            // return View(await _context.TytulyNaukowe.ToListAsync());
            return View(tytul);
        }

        // GET: TytulNaukowy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tytulNaukowy = await _context.TytulyNaukowe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tytulNaukowy == null)
            {
                return NotFound();
            }

            return View(tytulNaukowy);
        }

        // GET: TytulNaukowy/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TytulNaukowy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa,Opis,Aktywna")] TytulNaukowy tytulNaukowy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tytulNaukowy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tytulNaukowy);
        }

        // GET: TytulNaukowy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tytulNaukowy = await _context.TytulyNaukowe.FindAsync(id);
            if (tytulNaukowy == null)
            {
                return NotFound();
            }
            return View(tytulNaukowy);
        }

        // POST: TytulNaukowy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,Opis,Aktywna")] TytulNaukowy tytulNaukowy)
        {
            if (id != tytulNaukowy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tytulNaukowy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TytulNaukowyExists(tytulNaukowy.Id))
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
            return View(tytulNaukowy);
        }

        // GET: TytulNaukowy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tytulNaukowy = await _context.TytulyNaukowe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tytulNaukowy == null)
            {
                return NotFound();
            }

            return View(tytulNaukowy);
        }

        // POST: TytulNaukowy/Delete/5
        public async Task<IActionResult> Dezaktywuj(int id)
        {
            var specjalizacja = await _context.TytulyNaukowe.FindAsync(id);
            specjalizacja.Aktywna = false;
            _context.Update(specjalizacja);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool TytulNaukowyExists(int id)
        {
            return _context.TytulyNaukowe.Any(e => e.Id == id);
        }
    }
}
