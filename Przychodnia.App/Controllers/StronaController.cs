using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Przychodnia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Przychodnia.App.Controllers
{
    public class StronaController : Controller
    {
        private readonly PrzychodniaDbContext _context;

        public StronaController(PrzychodniaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
                ViewBag.Strona = await _context.Strony.Where(x => x.Aktywna == true).ToListAsync();
                if (id == null)
                {
                    var pierwszy = await _context.Strony.Where(x => x.Aktywna == true).FirstAsync();
                    id = pierwszy.IdStrony;
                }

                return View(await _context.Strony.Include(x => x.Ikona).Where(t => t.IdStrony == id).Where(x => x.Aktywna == true).ToListAsync());
            
            
        }
    }
}
