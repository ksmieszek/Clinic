using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Przychodnia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Przychodnia.App.Controllers
{

        public class ZabiegController : Controller
        {
            private readonly PrzychodniaDbContext _context;
            public ZabiegController(PrzychodniaDbContext context)
            {
                _context = context;
            }
        // GET: Zabieg
        public async Task<IActionResult> Index(string filterValue)
        {
            //var active = _context.Zabiegi.Where(b => b.Aktywny == true).ToListAsync();
            //return View(await active);
            if (filterValue != null)
                    return View(await _context.Zabiegi.Where(p => p.Nazwa.Contains(filterValue)).ToListAsync());
                else
                {
                return View(await _context.Zabiegi.Where(b => b.Aktywny == true).ToListAsync());
                 }
            
        }
        // GET: Zabieg/Details/5
        public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

            var zabieg = await _context.Zabiegi
                .FirstOrDefaultAsync(m => m.Id == id && m.Aktywny == true) ;
                if (zabieg == null)
                {
                    return NotFound();
                }

                return View(zabieg);
            }
        }
}
