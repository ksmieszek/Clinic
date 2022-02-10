using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Przychodnia.App.Models;
using Przychodnia.Data;

namespace Przychodnia.App.Controllers
{
    public class AktualnosciController : Controller
    {
        private readonly PrzychodniaDbContext _context;

        public AktualnosciController(PrzychodniaDbContext context)
        {
            _context = context;
        }

        public ActionResult Index(int PageNumber=1)
        {
            var currentRole = ((ClaimsIdentity) HttpContext?.User?.Identity)?.FindFirst(ClaimTypes.Role)?.Value;
            var aktualnosci = from a in _context.Aktualnosci select a;
            if (currentRole == null)
            {
                aktualnosci = _context.Aktualnosci.Where(a=> a.Odbiorca == "Wszyscy").OrderByDescending(a => a.Priorytet).ThenByDescending(a => a.DataDodania);
            } else if (currentRole == "Pacjent")
            {
                aktualnosci = _context.Aktualnosci.Where(a=> a.Odbiorca == "Pacjent" || a.Odbiorca == "Wszyscy").OrderByDescending(a => a.Priorytet).ThenByDescending(a => a.DataDodania);
            }
            else
            {
                aktualnosci = _context.Aktualnosci.Where(a=> a.Odbiorca == "Lekarz" || a.Odbiorca == "Wszyscy").OrderByDescending(a => a.Priorytet).ThenByDescending(a => a.DataDodania);
            }
            ViewBag.TotalPages = Math.Ceiling(aktualnosci.Count() / 4.0);
            ViewBag.PageNumber = PageNumber;

            aktualnosci = aktualnosci.Skip((PageNumber - 1) * 4).Take(4);

            return View(aktualnosci);
            
        }
        
        public async Task<ActionResult> Szczegoly(int id)
        {
            return View(await _context.Aktualnosci.Where(t => t.Id == id).FirstOrDefaultAsync());
        }
    }
    
    
}