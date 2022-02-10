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
    public class AktualnosciController : Controller
    {
        private readonly PrzychodniaDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IImagesService _imagesService;


        public AktualnosciController(PrzychodniaDbContext context,IImagesService imagesService)
        {
            _context = context;
            _imagesService = imagesService;
        }

        // GET: Aktualnosci
        public async Task<IActionResult> Index(string sortOrder, string searchQuery, int PageNumber = 1)
        {
            this.GetRecipients();
            ViewBag.NameSortParm = sortOrder == "name" ? "name_desc" : "name";
            ViewBag.DateSortParm = sortOrder == "date" ? "date_desc" : "date";
            var aktualnosci = from a in _context.Aktualnosci
                select a;
            if (!String.IsNullOrEmpty(searchQuery))
            {
                aktualnosci = aktualnosci.Where(a => a.Tytul.Contains(searchQuery));
            }


            switch (sortOrder)
            {
                case "name":
                    aktualnosci = aktualnosci.OrderBy(a => a.Tytul);
                    break;
                case "name_desc":
                    aktualnosci = aktualnosci.OrderByDescending(a => a.Tytul);
                    break;
                case "date":
                    aktualnosci = aktualnosci.OrderBy(a => a.DataDodania);
                    break;
                case "date_desc":
                    aktualnosci = aktualnosci.OrderByDescending(a => a.DataDodania);
                    break;
                default:
                {
                    ViewBag.NameSortParm = "name";
                    ViewBag.DateSortParm = "date";
                    aktualnosci = aktualnosci.OrderByDescending(a => a.DataDodania);
                    break;
                }
            }

            ViewBag.TotalPages = Math.Ceiling(aktualnosci.Count() / 20.0);
            ViewBag.PageNumber = PageNumber;
            aktualnosci = aktualnosci.Skip((PageNumber - 1) * 20).Take(20);

            return View(aktualnosci);
        }

        // GET: Aktualnosci/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aktualnosc = await _context.Aktualnosci
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aktualnosc == null)
            {
                return NotFound();
            }

            return View(aktualnosc);
        }

        // GET: Aktualnosci/Create
        public IActionResult Create()
        {
            this.GetRecipients();
            return View();
        }

        // POST: Aktualnosci/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AktualnosciViewModel model)
        {
            this.GetRecipients();
            if (ModelState.IsValid)
            {
                Aktualnosc aktualnosc = new Aktualnosc();
                var foto = model.Foto;
                if (foto != null)
                {
                    var uploadPath = Path.Combine(_imagesService.GetImagesPath(), "images\\aktualnosci");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + foto.FileName;
                    var filePath = Path.Combine(uploadPath, uniqueFileName);
                    var relativePath = Path.Combine("\\images\\aktualnosci", uniqueFileName);
                    foto.CopyTo(new FileStream(filePath, FileMode.Create));
                    aktualnosc.FotoUrl = relativePath;
                }

                aktualnosc.Priorytet = 1;
                aktualnosc.DataDodania = DateTime.Now;
                aktualnosc.Tytul = model.Tytul;
                aktualnosc.Tresc = model.Tresc;
                aktualnosc.Odbiorca = model.Odbiorca;

                _context.Add(aktualnosc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Aktualnosci/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aktualnosc = await _context.Aktualnosci.FindAsync(id);
            var aktualnoscViewModel = new AktualnosciViewModel();
            if (aktualnosc == null)
            {
                return NotFound();
            }
            else
            {
                aktualnoscViewModel.Id = aktualnosc.Id;
                aktualnoscViewModel.Tytul = aktualnosc.Tytul;
                aktualnoscViewModel.Odbiorca = aktualnosc.Odbiorca;
                aktualnoscViewModel.Tresc = aktualnosc.Tresc;
                aktualnoscViewModel.FotoUrl = aktualnosc.FotoUrl;
                if (aktualnoscViewModel.FotoUrl != null)
                {
                    var fotoUrl = aktualnosc.FotoUrl.Substring(1);
                    var path = Path.Combine(_imagesService.GetImagesPath(), fotoUrl);
                    using (var stream = System.IO.File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        aktualnoscViewModel.Foto =
                            new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name));
                    }
                }
                
            }

            this.GetRecipients(aktualnosc);
            return View(aktualnoscViewModel);
        }

        // POST: Aktualnosci/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,LinkTytul,Tytul,Tresc,DataDodania,Foto,Priorytet,Odbiorca")]
            AktualnosciViewModel aktualnosc)
        {
            if (id != aktualnosc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var aktualnoscDb = _context.Aktualnosci.FirstOrDefault(a => a.Id == id);
                    aktualnoscDb.Tytul = aktualnosc.Tytul;
                    aktualnoscDb.Tresc = aktualnosc.Tresc;
                    var foto = aktualnosc.Foto;
                    if (foto != null)
                    {
                        var uploadPath = Path.Combine(_imagesService.GetImagesPath(), "images\\aktualnosci");
                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + foto.FileName;
                        var filePath = Path.Combine(uploadPath, uniqueFileName);
                        var relativePath = Path.Combine("\\images\\aktualnosci", uniqueFileName);
                        foto.CopyTo(new FileStream(filePath, FileMode.Create));
                        aktualnoscDb.FotoUrl = relativePath;
                    }

                    aktualnoscDb.Odbiorca = aktualnosc.Odbiorca;

                    _context.Update(aktualnoscDb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AktualnoscExists(aktualnosc.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                this.GetRecipients();
                return RedirectToAction(nameof(Index));
            }

            this.GetRecipients();
            return View(aktualnosc);
        }

        // GET: Aktualnosci/Delete/5
        public async Task<IActionResult> UsuwaniePotwierdzone(int id)
        {
            var aktualnosc = await _context.Aktualnosci.FindAsync(id);
            _context.Aktualnosci.Remove(aktualnosc);
            //aktualnosc.Aktywna = false;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> PodbijAktualnosc(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aktualnosc = await _context.Aktualnosci
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aktualnosc == null)
            {
                return NotFound();
            }
            else
            {
                var highestPriority = await _context.Aktualnosci.MaxAsync(a => a.Priorytet);
                var priority = highestPriority + 1;
                aktualnosc.Priorytet = priority;
                _context.Update(aktualnosc);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private IActionResult GetRecipients(Aktualnosc aktualnosc = null)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem {Text = "Wszyscy", Value = "Wszyscy", Selected = true});
            items.Add(new SelectListItem {Text = "Pacjent", Value = "Pacjent"});
            items.Add(new SelectListItem {Text = "Lekarz", Value = "Lekarz"});
            if (aktualnosc != null)
            {
                items.ForEach(item => item.Selected = false);
                var selected = items.Find(item => item.Text == aktualnosc.Odbiorca);
                items[items.IndexOf(selected)].Selected = true;
            }

            ViewBag.Recipients = items;
            return View();
        }

        private bool AktualnoscExists(int id)
        {
            return _context.Aktualnosci.Any(e => e.Id == id);
        }
    }
}