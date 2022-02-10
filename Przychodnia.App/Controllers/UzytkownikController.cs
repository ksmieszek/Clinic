using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Przychodnia.App.Models;
using Przychodnia.App.ViewModel;
using Przychodnia.Data;
using Przychodnia.Data.Entities;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Przychodnia.App.Controllers
{
    [Route("[controller]/[action]")]
    public class UzytkownikController : Controller
    {
        private readonly string _sendGridApiKey = "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";
        private readonly PrzychodniaDbContext _context;

        public UzytkownikController(PrzychodniaDbContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            
            ViewBag.loginFailed = TempData["loginFailed"] as string;
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            var idt = HttpContext.User.Identity;

            HttpContext.User = null;

            return RedirectToAction("Index", "Home");
        }

        private bool MatchPasswords(string expectedPass, string passedPass, byte[] passwordSalt)
        {
            var hashedPass = GenerateHash(passedPass, passwordSalt);

            return expectedPass == hashedPass;
        }

        [HttpPost]
        public async Task<IActionResult> Logowanie(string Email, string Haslo)
        {
            var user = await _context.Uzytkownicy.Include(x => x.Rola).FirstOrDefaultAsync(x => x.Email == Email && x.CzyAktywny==true);
            var ctx = HttpContext.User;
            if (user == null)
            {
                TempData["loginFailed"] = "Nieprawidlowe dane logowania lub konto nie jest aktywne";
                return RedirectToAction("Login");
            }

            var passwordSalt = Convert.FromBase64String(user.HasloSalt);


            if (MatchPasswords(user.Haslo, Haslo, passwordSalt))
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.Role, user.Rola.Nazwa),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.Now.AddMinutes(30),
                };

                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);



                //SignInManager<Uzytkownik> sm = new SignInManager<Uzytkownik>(UserMana)
                //sm.SignInAsync();

                if (user.RolaId == 1)
                {
                    return RedirectToAction("Lekarz", "Uzytkownik");
                }
                else if (user.RolaId == 2)
                {
                    return RedirectToAction("MojeWizyty", "Uzytkownik");
                }
                else
                {
                    TempData["loginFailed"] = "Blad logowania";
                    return RedirectToAction("Login");
                }
            }
            else
            {
                TempData["loginFailed"] = "Nieprawidłowe dane logowania";
                return RedirectToAction("Login");
            }
        }

        public IActionResult Rejestracja()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Rejestruj(RejestracjaViewModel rejestracja)
        {
            var token = Guid.NewGuid().ToString().Replace("-", "");

            Uzytkownik uzytkownik = new Uzytkownik()
            { 
                Imie = rejestracja.Imie,
                Nazwisko = rejestracja.Nazwisko,
             //   Haslo = rejestracja.Password,
                Email = rejestracja.Email,
                Pesel = rejestracja.Pesel,
                Telefon = rejestracja.Telefon,
                TokenAktywacyjny = token.ToString(),
                RolaId = 1

            };
            var user = await _context.Uzytkownicy.FirstOrDefaultAsync(x => x.Email == rejestracja.Email);
            if (user != null)
            {
                TempData["loginFailed"] = "Podany adres email jest juz w uzyciu";
                return RedirectToAction("Login");
            }

            byte[] hash, salt;
            GenerateHash(rejestracja.Password, out hash, out salt);
            uzytkownik.Haslo = Convert.ToBase64String(hash);//hash.ToString();
            uzytkownik.HasloSalt = Convert.ToBase64String(salt); //salt.ToString();

            _context.Uzytkownicy.Add(uzytkownik);
            _context.SaveChanges();

            var url = $"http://{Request.Host}/Uzytkownik/AktywacjaKonta?token={token}";

            await SendConfirmationLink(rejestracja.Imie, url, uzytkownik.Email, token.ToString());

            return View("Login");
        }
        public void GenerateHash(string Password, out byte[] PasswordHash, out byte[] PasswordSalt)
        {
            using(var hash=new System.Security.Cryptography.HMACSHA512())
            {
                PasswordHash = hash.ComputeHash(Encoding.UTF8.GetBytes(Password));
                PasswordSalt = hash.Key;
            }
        }

        public string GenerateHash(string Password, byte[] PasswordSalt)
        {
            string password;
            using (var hash = new System.Security.Cryptography.HMACSHA512())
            {
                hash.Key = PasswordSalt;
                var PasswordHash = hash.ComputeHash(Encoding.UTF8.GetBytes(Password));
                password = Convert.ToBase64String(PasswordHash);
            }

            return password;
        }
        public IActionResult ResetujHaslo()
        {
            return View("ResetujHaslo");
        }

        public IActionResult Pacjent()
        {
            return View();
        }
        
        public IActionResult Lekarz()
        {
            ViewBag.ModelUzytkownicy = (
                from item in _context.Uzytkownicy
                orderby item.Id
                where item.RolaId == 2
                select item
                ).ToList();
            return View();
        }

        [HttpGet]
        public IActionResult PobierzWszystkichUzytkownikow()
        {
            var uzytkownicy = _context.Uzytkownicy.ToList();
            return View(uzytkownicy);
        }

        public IActionResult Edycja()
        {
            var user = HttpContext.User.Identity;
            var userEntity = _context.Uzytkownicy.FirstOrDefault(x => x.Email == user.Name);

            EdycjaUzytkownikaViewModel model = new()
            {
                Id = userEntity.Id,
                Imie = userEntity.Imie,
                Nazwisko = userEntity.Nazwisko,
          //      Password = userEntity.Haslo,
                Pesel = userEntity.Pesel,
                Telefon = userEntity.Telefon
            };
            byte[] hash, salt;
            GenerateHash(userEntity.Haslo, out hash, out salt);
            userEntity.Haslo = Convert.ToBase64String(hash);//hash.ToString();
            userEntity.HasloSalt = Convert.ToBase64String(salt); //salt.ToString();


            return View(model);
        }

        [HttpPost]
        public IActionResult Edycja(EdycjaUzytkownikaViewModel edycjaUzytkownikaViewModel)
        {
            var user = HttpContext.User.Identity;
            var userEntity = _context.Uzytkownicy.FirstOrDefault(x => x.Email == user.Name);

            userEntity.Imie = edycjaUzytkownikaViewModel.Imie;
            userEntity.Nazwisko = edycjaUzytkownikaViewModel.Nazwisko;
          //userEntity.Haslo = edycjaUzytkownikaViewModel.Password;
            userEntity.Pesel = edycjaUzytkownikaViewModel.Pesel;
            userEntity.Telefon = edycjaUzytkownikaViewModel.Telefon;

            byte[] hash, salt;
            GenerateHash(edycjaUzytkownikaViewModel.Password, out hash, out salt);
            userEntity.Haslo = Convert.ToBase64String(hash);//hash.ToString();
            userEntity.HasloSalt = Convert.ToBase64String(salt); //salt.ToString();
            _context.SaveChanges();


            return RedirectToAction("Index", "Home");
        }

        private async Task SendConfirmationLink(string userName, string confirmmationLink, string emailAddress, string token)
        {
            
            var client = new SendGridClient(_sendGridApiKey);
            var from = new EmailAddress("zespolwsb1@outlook.com", "Przychodnia");
            var subject = "Potwierdzenie rejestracji w serwisie Przychodnia";
            var to = new EmailAddress(emailAddress);
            var message = MailHelper.CreateSingleTemplateEmail(from, to, "d-bae3ab13545d44efb99e3a3a34dfa8d3",
                new { name = userName, confirmationLink = confirmmationLink });
            var result = await client.SendEmailAsync(message);
        }
        [HttpPost]
        public async Task<RedirectToActionResult> ResetujHaslo(string Email)
        {
            var user = await _context.Uzytkownicy.FirstOrDefaultAsync(x => x.Email == Email);
            if (user != null)
            {
                TempData["loginFailed"] = "Na podany adres email wyslano link resetujacy haslo";
            }
            var resetToken = Guid.NewGuid().ToString();
            user.TokenAktywacyjny = resetToken;
            var client = new SendGridClient(_sendGridApiKey);
            var from = new EmailAddress("zespolwsb1@outlook.com", "Przychodnia");
            var subject = "Reset hasla w serwisie przychodnia WSB";
            var url = $"http://{Request.Host}/Uzytkownik/ResetHasla?token={resetToken}";
            var to = new EmailAddress(Email);
            var message = MailHelper.CreateSingleTemplateEmail(from, to, "d-ba663c65ae86403db06c5a5b24a2816f",
                new { name = Email, resetLink = url });
            var result = await client.SendEmailAsync(message);
            await _context.SaveChangesAsync();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public async Task<IActionResult> ResetHasla([FromQuery] string token)
        {
            var user = await _context.Uzytkownicy.FirstOrDefaultAsync(x => x.TokenAktywacyjny ==  token);
            var viewModel = new PrzypomnijHasloViewModel
            {
                Email = user.Email
            };


            return View("Resetuj", viewModel);
            
        }
        [HttpPost]
        public async Task<IActionResult> Resetuj(PrzypomnijHasloViewModel  przypomnijHasloViewModel)
        {
            var user = await _context.Uzytkownicy.FirstOrDefaultAsync(x => x.Email == przypomnijHasloViewModel.Email);
            byte[] hash, salt;
            GenerateHash(przypomnijHasloViewModel.Password, out hash, out salt);
            user.Haslo = Convert.ToBase64String(hash);//hash.ToString();
            user.HasloSalt = Convert.ToBase64String(salt); //salt.ToString();
            _context.SaveChanges();

            return RedirectToAction("Login");
        }
        public async Task<IActionResult> AktywacjaKonta([FromQuery] string token)
        {
            var entity = await _context.Uzytkownicy.FirstOrDefaultAsync(x => x.TokenAktywacyjny == token);

            entity.CzyAktywny = true;
            await _context.SaveChangesAsync();

            return RedirectToAction("Login");
        }

        
        [HttpGet]
        public async Task<IActionResult> MojeWizyty()
        {
            var user = HttpContext.User.Identity;
            var userEntity = _context.Uzytkownicy.FirstOrDefault(x => x.Email == user.Name);

            var appointments = _context.Wizyty
                .Include(w => w.Harmonogram.Lekarz)
                .Include(w => w.Harmonogram.Lekarz.TytulNaukowy)
                .Where(w => w.Pacjent.Id == userEntity.Id)
                .ToList();

            var viewModel = new MojeWizytyViewModel
            {
                Appointments = appointments,
            };

            return View("MojeWizyty", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> OdwolajWizyte(int wizytaId)
        {
            var user = HttpContext.User.Identity;
            var userEntity = _context.Uzytkownicy.FirstOrDefault(x => x.Email == user.Name);

            var appointments = _context.Wizyty.Remove(new Wizyta {
                Id = wizytaId,
            });

            _context.SaveChanges();

            return RedirectToAction("MojeWizyty");
        }
    }

}
