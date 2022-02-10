using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Przychodnia.Data;
using Przychodnia.Data.Entities;
using Przychodnia.Data.Images;
using Przychodnia.Intranet.Models.Pagination;
using Przychodnia.Intranet.ViewModel;

namespace Przychodnia.Intranet.Controllers
{
    public class PoradniaController : Controller
    {
        private readonly PrzychodniaDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IImagesService _imagesService;

        public PoradniaController(PrzychodniaDbContext context, IImagesService imagesService)
        {
            _context = context;
            _imagesService = imagesService;

        }

        // GET: Poradnia
        public async Task<IActionResult> Index(int pg = 1)
        {
            var poradnia = from a in _context.Poradnie
                                select a;
           
            const int iloscStron = 20;
            if (pg < 1)
            {
                pg = 1;
            }
            int iliscKontaktow = poradnia.Count();
            var pager = new Pager(iliscKontaktow, pg, iloscStron);
            int skok = (pg - 1) * iloscStron;
            var daneDoWidoku = poradnia.Skip(skok).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;
            // return View(await _context.Poradnie.ToListAsync());
            return View(daneDoWidoku);
        }

        // GET: Poradnia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poradnia = await _context.Poradnie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (poradnia == null)
            {
                return NotFound();
            }

            return View(poradnia);
        }

        // GET: Poradnia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Poradnia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PoradniaViewModel model)
        {
            if (ModelState.IsValid)
            {
                Poradnia poradnia = new Poradnia();
                var foto = model.Foto;

                if (foto != null)
                {
                    var uploadPath = Path.Combine(_imagesService.GetImagesPath(), "images\\Poradnie");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + foto.FileName;
                    var filePath = Path.Combine(uploadPath, uniqueFileName);
                    var relativePath = Path.Combine("\\images\\Poradnie", uniqueFileName);
                    foto.CopyTo(new FileStream(filePath, FileMode.Create));
                    poradnia.FotoUrl = relativePath;
                }
                poradnia.Nazwa = model.Nazwa;
                poradnia.Opis = model.Opis;
                poradnia.Aktywna = model.Aktywna;
               

                _context.Add(poradnia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
           
       

        // GET: Poradnia/Edit/5

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poradnia = await _context.Poradnie.FindAsync(id);
            var poradniaViewModel = new PoradniaViewModel();
            if (poradnia == null)
            {
                return NotFound();
            }
            else
            {
                poradniaViewModel.Id = poradnia.Id;
                poradniaViewModel.Nazwa = poradnia.Nazwa;
                poradniaViewModel.Opis = poradnia.Opis;
                poradniaViewModel.FotoUrl = poradnia.FotoUrl;
                poradniaViewModel.Aktywna = poradnia.Aktywna;
                if (poradnia.FotoUrl != null)
                {
                    var fotoUrl = poradnia.FotoUrl.Substring(1);
                    var path = Path.Combine(_imagesService.GetImagesPath(), fotoUrl);
                    using (var stream = System.IO.File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        poradniaViewModel.Foto =
                            new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name));
                    }
                }
            }

            return View(poradniaViewModel);
        }


        // POST: Poradnia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,Opis,Foto,Aktywna")] PoradniaViewModel poradnia)
        {
            if (id != poradnia.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var poradniaDB = _context.Poradnie.FirstOrDefault(a => a.Id == id);
                    poradniaDB.Nazwa = poradnia.Nazwa;
                    poradniaDB.Opis = poradnia.Opis;
                    poradniaDB.Aktywna = poradnia.Aktywna;

                    var foto = poradnia.Foto;
                    if (foto != null)
                    {
                        var uploadPath = Path.Combine(_imagesService.GetImagesPath(), "images\\Poradnie");
                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + foto.FileName;
                        var filePath = Path.Combine(uploadPath, uniqueFileName);
                        var relativePath = Path.Combine("\\images\\Poradnie", uniqueFileName);
                        foto.CopyTo(new FileStream(filePath, FileMode.Create));
                        poradniaDB.FotoUrl = relativePath;
                    }




                    _context.Update(poradniaDB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoradniaExists(poradnia.Id))
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
            return View(poradnia);
        }

        public async Task<IActionResult> Dezaktywuj(int id)
        {
            var poradnia = await _context.Poradnie.FindAsync(id);
            poradnia.Aktywna = false;
            _context.Update(poradnia);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool PoradniaExists(int id)
        {
            return _context.Poradnie.Any(e => e.Id == id);
        }
    }
}
