using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Przychodnia.Data;
using Przychodnia.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Przychodnia.App.Controllers
{
    public class KontaktController : Controller
    {
        private readonly PrzychodniaDbContext _context;

        public KontaktController(PrzychodniaDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            var kontakty = _context.Kontakty.Include(k => k.Uzytkownik).Include(k => k.Adres).Where(k => k.Aktywny == true);
            return View(kontakty);
        }

        public async Task<ActionResult> Szczegoly(int id)
        {
            Kontakt kontakt = await _context.Kontakty.Include(k => k.Uzytkownik).Include(k => k.Adres).FirstOrDefaultAsync(k => k.Id == id);
            if(kontakt.Opis != null) kontakt.Opis = kontakt.Opis.Replace("<p>", "");
            if(kontakt.Opis != null) kontakt.Opis = kontakt.Opis.Replace("</p>", "");
            if (kontakt == null)
            {
                return NotFound();
            }
            else
            {
                return View(kontakt);
            }
        }
    }
}
