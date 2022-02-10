using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Przychodnia.Data;
using Przychodnia.Data.Entities;
using Przychodnia.Intranet.Models.Pagination;
using Przychodnia.Intranet.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Przychodnia.Intranet.Controllers
{
    public class KontaktController : Controller
    {
        private readonly PrzychodniaDbContext _context;

        public KontaktController(PrzychodniaDbContext context)
        {
            _context = context;
        }

        public ActionResult Index(int pg = 1)
        {
            var kontakty = _context.Kontakty.Include(k => k.Uzytkownik).Include(k => k.Adres).OrderBy(k => k.PozycjaWyswietlania);

            const int iloscStron = 20;
            if(pg < 1)
            {
                pg = 1;
            }
            int iliscKontaktow = kontakty.Count();
            var pager = new Pager(iliscKontaktow, pg, iloscStron);
            int skok = (pg - 1) * iloscStron;
            var daneDoWidoku = kontakty.Skip(skok).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(daneDoWidoku);
        }

        public async Task<ActionResult> Szczegoly(int id)
        {
            Kontakt kontakt = await _context.Kontakty.Include(k => k.Uzytkownik).Include(k => k.Adres).FirstOrDefaultAsync(k => k.Id == id);
            if (kontakt == null)
            {
                return NotFound();
            }
            else
            {
                return View(kontakt);
            }
        }

        public ActionResult Dodaj()
        {
            //ViewBag.Uzytkownik = new SelectList(_context.Uzytkownicy); 
            //ViewBag.Adres = new SelectList(_context.Adresy);
            List<Uzytkownik> uzytkownicy = new List<Uzytkownik>(_context.Uzytkownicy.Where(u => u.CzyAktywny));
            List <Adres> adresy = new List<Adres>(_context.Adresy.Where(a => a.Aktywny));
            //List<Rola> role = new List<Rola>(_context.Role);
            //List<Poradnia> poradnie = new List<Poradnia>(_context.Poradnie);

            KontaktViewModel viewModel = new KontaktViewModel(uzytkownicy, adresy)
            {
                PozycjaWyswietlania = 1
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Dodaj([Bind("UzytkownikId,AdresId,Telefon,Email,Opis,Aktywny,PozycjaWyswietlania")] Kontakt NowyKontakt)
        {
            //ViewBag.Uzytkownik = new List<Uzytkownik>(_context.Uzytkownicy);
            //ViewBag.Adres = new List<Adres>(_context.Adresy);
            try
            {
                if(ModelState.IsValid)
                {
                    if (NowyKontakt.AdresId == 0) NowyKontakt.AdresId = null;
                    if (NowyKontakt.UzytkownikId == 0) NowyKontakt.UzytkownikId = null;
                    NowyKontakt.Aktywny = true;
                    _context.Kontakty.Add(NowyKontakt);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var uzytkownicy = new List<Uzytkownik>(_context.Uzytkownicy);
                    var adresy = new List<Adres>(_context.Adresy);
                    return View(new KontaktViewModel(uzytkownicy, adresy));
                }
            }
            catch
            {
                ViewBag.Uzytkownik = new List<Uzytkownik>(_context.Uzytkownicy);
                ViewBag.Adres = new List<Adres>(_context.Adresy);
                return View();
            }
        }

        public async Task<ActionResult> Edycja(int id)
        {
            List<Uzytkownik> uzytkownicy = new List<Uzytkownik>(_context.Uzytkownicy);
            List<Adres> adresy = new List<Adres>(_context.Adresy);
            //List<Rola> role = new List<Rola>(_context.Role);
            //List<Poradnia> poradnie = new List<Poradnia>(_context.Poradnie);

            //ViewBag.Uzytkownik = new List<Uzytkownik>(_context.Uzytkownicy);
            //ViewBag.Adres = new List<Adres>(_context.Adresy);
            
            if (id == 0)
            {
                return NotFound();
            }
            var kontakt = await _context.Kontakty.FindAsync(id);

            KontaktViewModel kontaktViewModel = new KontaktViewModel(uzytkownicy, adresy, kontakt.Id, kontakt.UzytkownikId, kontakt.Uzytkownik, kontakt.AdresId, kontakt.Adres, kontakt.Telefon, kontakt.Email, kontakt.Opis, kontakt.Aktywny, kontakt.PozycjaWyswietlania);

            if (kontakt == null)
            {
                return NotFound();
            }
            return View(kontaktViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edycja(int id, [Bind("Id,UzytkownikId,AdresId,Telefon,Email,Opis,Aktywny,PozycjaWyswietlania")] Kontakt EdytowanyKontakt)
        {
            //ViewBag.Uzytkownik = new List<Uzytkownik>(_context.Uzytkownicy);
            //ViewBag.Adres = new List<Adres>(_context.Adresy);
            try
            {
                if (id != EdytowanyKontakt.Id)
                {
                    return NotFound();
                }

                if (EdytowanyKontakt.AdresId == 0) EdytowanyKontakt.AdresId = null;
                if (EdytowanyKontakt.UzytkownikId == 0) EdytowanyKontakt.UzytkownikId = null;

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(EdytowanyKontakt);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!KontaktExists(EdytowanyKontakt.Id))
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
                List<Uzytkownik> uzytkownicy = new List<Uzytkownik>(_context.Uzytkownicy);
                List<Adres> adresy = new List<Adres>(_context.Adresy);
                //List<Rola> role = new List<Rola>(_context.Role);
                //List<Poradnia> poradnie = new List<Poradnia>(_context.Poradnie);
                KontaktViewModel kontaktViewModel = new KontaktViewModel(uzytkownicy, adresy);
                return View(kontaktViewModel);
            }
            catch
            {
                return View();
            }
        }

        //public async Task<IActionResult> Usuwanie(int id)
        //{
        //    Kontakt kontakt = await _context.Kontakty.Include(k => k.Uzytkownik).Include(k => k.Adres).FirstOrDefaultAsync(k => k.Id == id);
        //    if (kontakt == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        //return View(kontakt);
        //        return PartialView("Usuwanie", kontakt);
        //    }
        //}

        //public async Task<IActionResult> UsuwaniePotwierdzone(int id)
        //{
        //    try
        //    {
        //        var kontakt = await _context.Kontakty.FindAsync(id);
        //        _context.Kontakty.Remove(kontakt);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        public async Task<IActionResult> UsuwaniePotwierdzone(int id)
        {
            var kontakt = await _context.Kontakty.FindAsync(id);
            kontakt.Aktywny = false;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Pracownicy/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DodajUzytkownika(IFormCollection form)
        //{
        //    var RolaId = int.Parse(form["nowyUzytkownik.RolaId"]);
        //    var PoradniaId = int.Parse(form["nowyUzytkownik.PoradnieId"]);
        //    var Email = form["nowyUzytkownik.Email"].ToString();
        //    var Haslo = form["nowyUzytkownik.Haslo"].ToString();
        //    var Imie = form["nowyUzytkownik.Imie"].ToString();
        //    var Nazwisko = form["nowyUzytkownik.Nazwisko"].ToString();
        //    var Pesel = form["nowyUzytkownik.Pesel"].ToString();

        //    var Telefon = form["Telefon"].ToString();
        //    var UzytkownikEmail = form["Email"].ToString();
        //    var Opis = form["Opis"].ToString();
        //    var Aktywny = bool.Parse(form["Aktywny"].ToString());
        //    int Pozycja = 0;
        //    int.TryParse(form["PozycjaWyswietlania"].ToString(), out Pozycja);

        //    if (ModelState.IsValid)
        //    {
        //        var nowyUzytkownik = new Uzytkownik();
        //        nowyUzytkownik.RolaId = RolaId;
        //        nowyUzytkownik.PoradnieId = PoradniaId;
        //        nowyUzytkownik.Email = Email;
        //        nowyUzytkownik.Haslo = Haslo;
        //        nowyUzytkownik.Imie = Imie;
        //        nowyUzytkownik.Nazwisko = Nazwisko;
        //        nowyUzytkownik.Pesel = Pesel;

        //        _context.Add(nowyUzytkownik);
        //        await _context.SaveChangesAsync();

        //        List<Uzytkownik> uzytkownicy = new List<Uzytkownik>(_context.Uzytkownicy);
        //        List<Adres> adresy = new List<Adres>(_context.Adresy);
        //        List<Rola> role = new List<Rola>(_context.Role);
        //        List<Poradnia> poradnie = new List<Poradnia>(_context.Poradnie);
        //        KontaktViewModel kontaktViewModel = new KontaktViewModel()
        //        {
        //            uzytkownicy = uzytkownicy,
        //            adresy = adresy,
        //            role = role,
        //            poradnie = poradnie,
        //            Telefon = Telefon,
        //            Email = UzytkownikEmail,
        //            Opis = Opis,
        //            Aktywny = Aktywny,
        //            PozycjaWyswietlania = Pozycja
        //        };

        //        return View("Dodaj", kontaktViewModel);
        //        //return RedirectToAction("Dodaj", "Kontakt"); 
        //    }
        //    return View();
        //}

        //// POST: Pracownicy/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DodajAdres(IFormCollection form)
        //{
        //    var Miejscowosc = form["nowyAdres.Miejscowosc"].ToString();
        //    var KodPocztowy = form["nowyAdres.KodPocztowy"].ToString();
        //    var Ulica = form["nowyAdres.Ulica"].ToString();
        //    var NumerDomu = form["nowyAdres.NumerDomu"].ToString();
        //    var NumerMieszkania = form["nowyAdres.NumerMieszkania"].ToString();

        //    var Telefon = form["Telefon"].ToString();
        //    var Email = form["Email"].ToString();
        //    var Opis = form["Opis"].ToString();
        //    var Aktywny = bool.Parse(form["Aktywny"].ToString());
        //    int Pozycja = 0;
        //    int.TryParse(form["PozycjaWyswietlania"].ToString(), out Pozycja);

        //    if (ModelState.IsValid)
        //    {
        //        var nowyAdres = new Adres();
        //        nowyAdres.Miejscowosc = Miejscowosc;
        //        nowyAdres.KodPocztowy = KodPocztowy;
        //        nowyAdres.Ulica = Ulica;
        //        nowyAdres.NumerDomu = NumerDomu;
        //        nowyAdres.NumerMieszkania = NumerMieszkania;

        //        _context.Add(nowyAdres);
        //        await _context.SaveChangesAsync();

        //        List<Uzytkownik> uzytkownicy = new List<Uzytkownik>(_context.Uzytkownicy);
        //        List<Adres> adresy = new List<Adres>(_context.Adresy);
        //        List<Rola> role = new List<Rola>(_context.Role);
        //        List<Poradnia> poradnie = new List<Poradnia>(_context.Poradnie);
        //        KontaktViewModel kontaktViewModel = new KontaktViewModel()
        //        {
        //            uzytkownicy = uzytkownicy,
        //            adresy = adresy,
        //            role = role,
        //            poradnie = poradnie,
        //            Telefon = Telefon,
        //            Email = Email,
        //            Opis = Opis,
        //            Aktywny = Aktywny,
        //            PozycjaWyswietlania = Pozycja
        //        };

        //        //return RedirectToAction("Dodaj", "Kontakt");
        //        return View("Dodaj", kontaktViewModel);
        //    }
        //    return View();
        //}

        private bool KontaktExists(int id)
        {
            return _context.Kontakty.Any(e => e.Id == id);
        }

        string LocalReplaceMatchCase(System.Text.RegularExpressions.Match matchExpression, string replaceWith)
        {
            // Test whether the match is capitalized
            if (Char.IsUpper(matchExpression.Value[0]))
            {
                // Capitalize the replacement string
                System.Text.StringBuilder replacementBuilder = new System.Text.StringBuilder(replaceWith);
                replacementBuilder[0] = Char.ToUpper(replacementBuilder[0]);
                return replacementBuilder.ToString();
            }
            else
            {
                return replaceWith;
            }
        }
    }
}
