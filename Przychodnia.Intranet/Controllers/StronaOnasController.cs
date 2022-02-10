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
using Przychodnia.Intranet.ViewModel;

namespace Przychodnia.Intranet.Controllers
{
    public class StronaOnasController : Controller
    {
        private readonly PrzychodniaDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IImagesService _imagesService;

        public StronaOnasController(PrzychodniaDbContext context, IImagesService imagesService)
        {
            _context = context;
            _imagesService = imagesService;
        }

        // GET: StronaOnas
        public async Task<IActionResult> Index(int PageNumber = 1)
        {
            var onas = from a in _context.StronaOnas.Where(x => x.Aktywna == true) 
                       select a;
            ViewBag.TotalPages = Math.Ceiling(onas.Count() / 20.0);
            ViewBag.PageNumber = PageNumber;
            onas = onas.Skip((PageNumber - 1) * 20).Take(20);

            //return View(await _context.StronaOnas.ToListAsync());
            return View(onas);
        }

        // GET: StronaOnas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stronaOnas = await _context.StronaOnas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stronaOnas == null)
            {
                return NotFound();
            }

            return View(stronaOnas);
        }

        // GET: StronaOnas/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: StronaOnas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StronaOnasViewModel model)
        {
            if (ModelState.IsValid)
            {
                StronaOnas stronaOnas = new StronaOnas();
                var foto = model.Foto;

                if (foto != null)
                {
                    var uploadPath = Path.Combine(_imagesService.GetImagesPath(), "images\\StronaOnas");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + foto.FileName;
                    var filePath = Path.Combine(uploadPath, uniqueFileName);
                    var relativePath = Path.Combine("\\images\\StronaOnas", uniqueFileName);
                    foto.CopyTo(new FileStream(filePath, FileMode.Create));
                    stronaOnas.FotoUrl = relativePath;
                }
                stronaOnas.Aktywna = true;
                stronaOnas.Tytul = model.Tytul;
                stronaOnas.Tresc = model.Tresc;
                stronaOnas.Pozycja = model.Pozycja;


                _context.Add(stronaOnas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: StronaOnas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stronaOnas = await _context.StronaOnas.FindAsync(id);
            var stronaOnasViewModel = new StronaOnasViewModel();
            if (stronaOnas == null)
            {
                return NotFound();
            }
            else
            {
                stronaOnasViewModel.Id = stronaOnas.Id;
                stronaOnasViewModel.Tresc = stronaOnas.Tresc;
                stronaOnasViewModel.Tytul = stronaOnas.Tytul;
                stronaOnasViewModel.Pozycja = stronaOnas.Pozycja;
                stronaOnasViewModel.FotoUrl = stronaOnas.FotoUrl;
                if (stronaOnas.FotoUrl != null)
                {
                    var fotoUrl = stronaOnas.FotoUrl.Substring(1);
                    var path = Path.Combine(_imagesService.GetImagesPath(), fotoUrl);
                    using (var stream = System.IO.File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        stronaOnasViewModel.Foto =
                            new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name));
                    }
                }
            }
            
            return View(stronaOnasViewModel);
        }

        // POST: StronaOnas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]        
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,Tytul,Tresc,Pozycja,Foto")]
            StronaOnasViewModel stronaOnas)
        {
            if (id != stronaOnas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var stronaDB = _context.StronaOnas.FirstOrDefault(a => a.Id == id);
                    stronaDB.Tresc = stronaOnas.Tresc;
                    stronaDB.Tytul = stronaOnas.Tytul;
                    stronaDB.Pozycja = stronaOnas.Pozycja;
                    var foto = stronaOnas.Foto;
                    if (foto != null)
                    {
                        var uploadPath = Path.Combine(_imagesService.GetImagesPath(), "images\\StronaOnas");
                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + foto.FileName;
                        var filePath = Path.Combine(uploadPath, uniqueFileName);
                        var relativePath = Path.Combine("\\images\\StronaOnas", uniqueFileName);
                        foto.CopyTo(new FileStream(filePath, FileMode.Create));
                        stronaDB.FotoUrl = relativePath;
                    }


                    

                    _context.Update(stronaDB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StronaOnasExists(stronaOnas.Id))
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
            return View(stronaOnas);
        }

        // GET: StronaOnas/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var stronaOnas = await _context.StronaOnas.FindAsync(id);
            _context.StronaOnas.Remove(stronaOnas);
            //stronaOnas.Aktywna = false;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StronaOnasExists(int id)
        {
            return _context.StronaOnas.Any(e => e.Id == id);
        }
    }
}
