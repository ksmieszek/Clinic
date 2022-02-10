using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Przychodnia.Data;
using Przychodnia.Data.Entities;
using Przychodnia.Data.Images;
using Przychodnia.Intranet.ViewModel;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Przychodnia.Intranet.Controllers
{
    public class ZabiegController : Controller
    {
        private readonly PrzychodniaDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IImagesService _imagesService;
        public ZabiegController(PrzychodniaDbContext context, IImagesService imagesService)
        {
            _context = context;
            _imagesService = imagesService;
        }
        // GET: Zabieg
        public async Task<IActionResult> Index(string filterValue, Boolean active, int PageNumber = 1)
        {
            ViewBag.FilterValue = filterValue;
            var zabiegi = await _context.Zabiegi.ToListAsync();
            zabiegi.Reverse();
            if (filterValue != null) zabiegi = zabiegi.Where(p => ContainsString(p.Nazwa, filterValue)).ToList();

            var queryableZabiegi = zabiegi.AsQueryable();
            
            ViewBag.TotalPages = Math.Ceiling(queryableZabiegi.Count() / 4.0);
            ViewBag.PageNumber = PageNumber;
            queryableZabiegi = queryableZabiegi.Skip((PageNumber - 1) * 4).Take(4);

            return View(queryableZabiegi);

        }
        public bool ContainsString(string source, string toCheck)
        {
            return source.IndexOf(toCheck, StringComparison.OrdinalIgnoreCase) >= 0;
        }
        // GET: Zabieg/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zabieg = await _context.Zabiegi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zabieg == null)
            {
                return NotFound();
            }

            return View(zabieg);
        }
        // GET: Promocja/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zabieg/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ZabiegViewModel model)
        {
            if (ModelState.IsValid)
            {
                Zabieg zabieg = new Zabieg();
                var foto = model.Foto;
                if (foto != null)
                {
                    var uploadPath = Path.Combine(_imagesService.GetImagesPath(), "images\\zabieg");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + foto.FileName;
                    var filePath = Path.Combine(uploadPath, uniqueFileName);
                    var relativePath = Path.Combine("\\images\\zabieg", uniqueFileName);
                    foto.CopyTo(new FileStream(filePath, FileMode.Create));
                    zabieg.FotoUrl = relativePath;
                }
                zabieg.Nazwa = model.Nazwa;
                zabieg.Opis = model.Opis;
                zabieg.Przeciwwskazania = model.Przeciwwskazania;
                zabieg.Przygotowania = model.Przygotowania;
                zabieg.CzasTrwania = model.CzasTrwania;
                zabieg.CzasTrwaniaMinuty = model.CzasTrwaniaMinuty;
                zabieg.Aktywny = model.Aktywny;

                _context.Add(zabieg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
        // GET: Zabieg/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zabieg = await _context.Zabiegi.FindAsync(id);
            var zabiegViewModel = new ZabiegViewModel();
            if (zabieg == null)
            {
                return NotFound();
            }
            else
            {
                zabiegViewModel.Id = zabieg.Id;
                zabiegViewModel.Nazwa = zabieg.Nazwa;
                zabiegViewModel.Opis = zabieg.Opis;
                zabiegViewModel.Przeciwwskazania = zabieg.Przeciwwskazania;
                zabiegViewModel.Przygotowania = zabieg.Przygotowania;
                zabiegViewModel.CzasTrwania = zabieg.CzasTrwania;
                zabiegViewModel.CzasTrwaniaMinuty = zabieg.CzasTrwaniaMinuty;
                zabiegViewModel.Aktywny = zabieg.Aktywny;
                zabiegViewModel.FotoUrl = zabieg.FotoUrl;
                if (zabieg.FotoUrl != null)
                { 
                    var fotoUrl = zabieg.FotoUrl.Substring(1);
                var path = Path.Combine(_imagesService.GetImagesPath(), fotoUrl);
                using (var stream = System.IO.File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    zabiegViewModel.Foto =
                        new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name));
                }
            }

            }
            return View(zabiegViewModel);
        }

        // POST: Zabieg/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, 
            [Bind("Id,Nazwa,Opis,Przeciwwskazania,Przygotowania,CzasTrwania,CzasTrwaniaMinuty,Foto,Aktywny")]
            ZabiegViewModel zabieg)
        {
            if (id != zabieg.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var zabiegDb = _context.Zabiegi.FirstOrDefault(a => a.Id == id);
                    zabiegDb.Nazwa = zabieg.Nazwa;
                    zabiegDb.Opis = zabieg.Opis;
                    zabiegDb.Przeciwwskazania = zabieg.Przeciwwskazania;
                    zabiegDb.Przygotowania = zabieg.Przygotowania;
                    zabiegDb.CzasTrwania = zabieg.CzasTrwania;
                    zabiegDb.CzasTrwaniaMinuty = zabieg.CzasTrwaniaMinuty;
                    var foto = zabieg.Foto;
                    if (foto != null)
                    {
                        var uploadPath = Path.Combine(_imagesService.GetImagesPath(), "images\\zabieg");
                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + foto.FileName;
                        var filePath = Path.Combine(uploadPath, uniqueFileName);
                        var relativePath = Path.Combine("\\images\\zabieg", uniqueFileName);
                        foto.CopyTo(new FileStream(filePath, FileMode.Create));
                        zabiegDb.FotoUrl = relativePath;
                    }
                   

                    zabiegDb.Aktywny = zabieg.Aktywny;

                    _context.Update(zabiegDb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZabiegExists(zabieg.Id))
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
            return View(zabieg);
        }
        private bool ZabiegExists(int id)
        {
            return _context.Zabiegi.Any(e => e.Id == id);
        }
        // GET: Zabieg/Delete/5
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var UsunZabieg = await _context.Zabiegi.FindAsync(id);
            _context.Zabiegi.Remove(UsunZabieg);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }




    }
}
