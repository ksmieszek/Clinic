using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Przychodnia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Przychodnia.Data.Entities;
using Przychodnia.Intranet.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace Przychodnia.Intranet.Controllers
{
    public class Pracownicy : Controller
    {
        private readonly PrzychodniaDbContext _context;

        public Pracownicy(PrzychodniaDbContext context)
        {
            _context = context;
        }

        // GET: Pracownicy
        public async Task<IActionResult> Index(string filterValue, int Role, int PageNumber = 1)
        {
            ViewBag.Role = new SelectList(_context.Role, "Id", "Nazwa", Role);
            ViewBag.FilterValue = filterValue;
            ViewBag.RolaValue = Role;
            var uzytkownicy = _context.Uzytkownicy.Include(u => u.Rola).Include(p => p.Specjalizacje).Include(p => p.TytulNaukowy).ToList();
            if (filterValue != null) uzytkownicy = uzytkownicy.Where(p => ContainsString(p.Imie, filterValue) || ContainsString(p.Nazwisko, filterValue) || ContainsString(p.Email, filterValue)).ToList();
            if (Role > 0) uzytkownicy = uzytkownicy.Where(p => p.RolaId == Role).ToList();

            ViewBag.TotalPages = Math.Ceiling(uzytkownicy.Count() / 10.0);
            ViewBag.PageNumber = PageNumber;
            var queryableUzytkownicy = uzytkownicy.AsQueryable();
            queryableUzytkownicy = queryableUzytkownicy.Skip((PageNumber - 1) * 10).Take(10);

            return View(queryableUzytkownicy);
        }

        public bool ContainsString(string source, string toCheck)
        {
            return source.IndexOf(toCheck, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        // GET: Pracownicy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var pracownik = await _context.Uzytkownicy.FirstOrDefaultAsync(m => m.Id == id); //
            if (pracownik == null) return NotFound();
            ViewBag.Rola = await _context.Role.FirstOrDefaultAsync(r => r.Id == pracownik.RolaId);
            ViewBag.Poradnia = await _context.Poradnie.FirstOrDefaultAsync(p => p.Id == pracownik.PoradnieId);
            return View(pracownik);
        }

        // GET: Pracownicy/Create
        public ActionResult Create()
        {
            ViewBag.Poradnie = new SelectList(_context.Poradnie, "Id", "Nazwa");
            ViewBag.Tytuly = new SelectList(_context.TytulyNaukowe, "Id", "Nazwa");
            ViewBag.Specjalizacje = new SelectList(_context.Specjalizacje, "Id", "Nazwa");
            return View();
        }
        public ActionResult DodajPacjenta()
        {
            return View();
        }

        // POST: Pracownicy/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Uzytkownik pracownik)
        {
            ViewBag.Poradnie = new SelectList(_context.Poradnie, "Id", "Nazwa");
            ViewBag.Tytuly = new SelectList(_context.TytulyNaukowe, "Id", "Nazwa");
            ViewBag.Specjalizacje = new SelectList(_context.Specjalizacje, "Id", "Nazwa");

            var user = await _context.Uzytkownicy.FirstOrDefaultAsync(x => x.Email == pracownik.Email);
            if (user != null)
            {
                ViewBag.DuplicatedEmailError = "Podany adres email jest już w użyciu";
                return View(pracownik);
            }

            if (ModelState.IsValid)
            {
                byte[] hash, salt;
                GenerateHash(pracownik.Haslo, out hash, out salt);
                pracownik.Haslo = Convert.ToBase64String(hash);//hash.ToString();
                pracownik.HasloSalt = Convert.ToBase64String(salt); //salt.ToString();
                pracownik.RolaId = 2;
                pracownik.CzyAktywny = true;
                _context.Add(pracownik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Lekarz));
            }
            return View(pracownik);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DodajPacjenta(Uzytkownik pracownik)
        {
            var user = await _context.Uzytkownicy.FirstOrDefaultAsync(x => x.Email == pracownik.Email);
            if (user != null)
            {
                ViewBag.DuplicatedEmailError = "Podany adres email jest już w użyciu";
                return View(pracownik);
            }

            if (ModelState.IsValid)
            {
                byte[] hash, salt;
                GenerateHash(pracownik.Haslo, out hash, out salt);
                pracownik.Haslo = Convert.ToBase64String(hash);//hash.ToString();
                pracownik.HasloSalt = Convert.ToBase64String(salt); //salt.ToString();
                pracownik.RolaId = 1;
                pracownik.CzyAktywny = true;
                _context.Add(pracownik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Pacjent));
            }
            return View(pracownik);
        }

        // GET: Pracownicy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Poradnie = new SelectList(_context.Poradnie, "Id", "Nazwa");
            ViewBag.Tytuly = new SelectList(_context.TytulyNaukowe, "Id", "Nazwa");
            ViewBag.Specjalizacje = new SelectList(_context.Specjalizacje, "Id", "Nazwa");
            ViewBag.Wizyty = _context.Wizyty.Where(w => w.Harmonogram.Lekarz.Id == id).ToList();
            if (id == null) return NotFound();
            var pracownik = await _context.Uzytkownicy.FindAsync(id);
            if (pracownik == null) return NotFound();
            return View(pracownik);
        }

        public async Task<IActionResult> EdycjaPacjenta(int? id)
        {
            if (id == null) return NotFound();
            var pracownik = await _context.Uzytkownicy.FindAsync(id);
            if (pracownik == null) return NotFound();
            return View(pracownik);
        }

        // POST: Pracownicy/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Uzytkownik pracownik)
        {
            ViewBag.Poradnie = new SelectList(_context.Poradnie, "Id", "Nazwa");
            ViewBag.Tytuly = new SelectList(_context.TytulyNaukowe, "Id", "Nazwa");
            ViewBag.Specjalizacje = new SelectList(_context.Specjalizacje, "Id", "Nazwa");
            if (id != pracownik.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var user = await _context.Uzytkownicy.FirstOrDefaultAsync(x => x.Id != id && x.Email == pracownik.Email);
                if (user != null)
                {
                    ViewBag.DuplicatedEmailError = "Podany adres email jest już w użyciu";
                    return View(pracownik);
                }

                try
                {
                    var uzytkownikDb = _context.Uzytkownicy.FirstOrDefault(u => u.Id == id);
                    uzytkownikDb.RolaId = 2;
                    uzytkownikDb.SpecjalizacjeId = pracownik.SpecjalizacjeId;
                    uzytkownikDb.TytulNaukowyId = pracownik.TytulNaukowyId;
                    uzytkownikDb.PoradnieId = pracownik.PoradnieId;
                    uzytkownikDb.Imie = pracownik.Imie;
                    uzytkownikDb.Nazwisko = pracownik.Nazwisko;
                    uzytkownikDb.Email = pracownik.Email;
                    uzytkownikDb.Pesel = pracownik.Pesel;
                    uzytkownikDb.Telefon = pracownik.Telefon;
                    uzytkownikDb.Promowany = pracownik.Promowany;
                    _context.Update(uzytkownikDb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PracownikExists(pracownik.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Lekarz));
            }
            return View(pracownik);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EdycjaPacjenta(int id, Uzytkownik pracownik)
        {
            if (id != pracownik.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var user = await _context.Uzytkownicy.FirstOrDefaultAsync(x => x.Id != id && x.Email == pracownik.Email);
                if (user != null)
                {
                    ViewBag.DuplicatedEmailError = "Podany adres email jest już w użyciu";
                    return View(pracownik);
                }

                try
                {
                    var uzytkownikDb = _context.Uzytkownicy.FirstOrDefault(u => u.Id == id);
                    uzytkownikDb.RolaId = 1;
                    uzytkownikDb.Imie = pracownik.Imie;
                    uzytkownikDb.Nazwisko = pracownik.Nazwisko;
                    uzytkownikDb.Pesel = pracownik.Pesel;
                    uzytkownikDb.Telefon = pracownik.Telefon;
                    uzytkownikDb.Email = pracownik.Email;
                    _context.Update(uzytkownikDb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PracownikExists(pracownik.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Pacjent));
            }
            else
            {
                return View(pracownik);
            }
        }

        // GET: Pracownicy/Delete/5
        public async Task<IActionResult> Dezaktywuj(int id)
        {
            var uzytkownik = await _context.Uzytkownicy.FindAsync(id);
            uzytkownik.CzyAktywny = false;
            _context.Update(uzytkownik);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        private bool PracownikExists(int id)
        {
            return _context.Uzytkownicy.Any(e => e.Id == id);
        }
        [HttpGet]
        public async Task<IActionResult> Pacjent(string filterValue, int PageNumber = 1)
        {
            ViewBag.FilterValue = filterValue;
            var uzytkownicy = _context.Uzytkownicy.Where(p => p.RolaId == 1).ToList();
            if (filterValue != null) uzytkownicy = uzytkownicy.Where(p => ContainsString(p.Imie, filterValue) || ContainsString(p.Nazwisko, filterValue) || ContainsString(p.Email, filterValue)).ToList();

            ViewBag.TotalPages = Math.Ceiling(uzytkownicy.Count() / 10.0);
            ViewBag.PageNumber = PageNumber;
            var queryableUzytkownicy = uzytkownicy.AsQueryable();
            queryableUzytkownicy = queryableUzytkownicy.Skip((PageNumber - 1) * 10).Take(10);

            return View(queryableUzytkownicy);
        }
        public async Task<IActionResult> Lekarz(string filterValue, int Specjalizacje, int TytulNaukowy, int Poradnia, int PageNumber = 1)
        {
            ViewBag.Specjalizacje = new SelectList(_context.Specjalizacje, "Id", "Nazwa", Specjalizacje);
            ViewBag.TytulNaukowy = new SelectList(_context.TytulyNaukowe, "Id", "Nazwa", TytulNaukowy);
            ViewBag.Poradnia = new SelectList(_context.Poradnie, "Id", "Nazwa", Poradnia);
            ViewBag.FilterValue = filterValue;
            ViewBag.PoradniaValue = Poradnia;
            ViewBag.SpecjalizacjaValue = Specjalizacje;
            ViewBag.TytulNaukowyValue = TytulNaukowy;
            var uzytkownicy = _context.Uzytkownicy.Include(u => u.Rola).Include(p => p.Specjalizacje).Include(p => p.TytulNaukowy).Where(p => p.RolaId != 1).ToList();
            if (filterValue != null) uzytkownicy = uzytkownicy.Where(p => ContainsString(p.Imie, filterValue) || ContainsString(p.Nazwisko, filterValue) || ContainsString(p.Email, filterValue)).ToList();
            if (Specjalizacje > 0) uzytkownicy = uzytkownicy.Where(p => p.SpecjalizacjeId == Specjalizacje).ToList();
            if (TytulNaukowy > 0) uzytkownicy = uzytkownicy.Where(p => p.TytulNaukowyId == TytulNaukowy).ToList();
            if (Poradnia > 0) uzytkownicy = uzytkownicy.Where(p => p.PoradnieId == Poradnia).ToList();

            ViewBag.TotalPages = Math.Ceiling(uzytkownicy.Count() / 10.0);
            ViewBag.PageNumber = PageNumber;
            var queryableUzytkownicy = uzytkownicy.AsQueryable();
            queryableUzytkownicy = queryableUzytkownicy.Skip((PageNumber - 1) * 10).Take(10);

            return View(queryableUzytkownicy);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeAccountState(int id, bool newState)
        {
            var pracownik = await _context.Uzytkownicy.FindAsync(id);
            pracownik.CzyAktywny = newState;
            _context.Uzytkownicy.Update(pracownik);
            await _context.SaveChangesAsync();
            return Redirect(Request.Headers["Referer"].ToString());
        }
        //get
        public async Task<IActionResult> ChangePassword(int? id)
        {
            if (id == null) return NotFound();
            var pracownik = await _context.Uzytkownicy.FindAsync(id);
            if (pracownik == null) return NotFound();
            ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            return View();
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel user, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var pracownik = await _context.Uzytkownicy.FindAsync(user.Id);

                byte[] hash, salt;
                GenerateHash(user.Password, out hash, out salt);
                pracownik.Haslo = Convert.ToBase64String(hash);//hash.ToString();
                pracownik.HasloSalt = Convert.ToBase64String(salt); //salt.ToString();

                _context.Uzytkownicy.Update(pracownik);
                await _context.SaveChangesAsync();
                return Redirect(returnUrl);
            }
            else
            {
                return View(user);
            }
        }

        public void GenerateHash(string Password, out byte[] PasswordHash, out byte[] PasswordSalt)
        {
            using (var hash = new System.Security.Cryptography.HMACSHA512())
            {
                PasswordHash = hash.ComputeHash(Encoding.UTF8.GetBytes(Password));
                PasswordSalt = hash.Key;
            }
        }

        public async Task<IActionResult> DodajUzytkownika()
        {
            return View();
        }
    }
}

