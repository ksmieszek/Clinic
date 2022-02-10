using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Przychodnia.Data;
using Przychodnia.Data.Entities;

namespace Przychodnia.App.Controllers
{
    public class RegulaminController : Controller
    {
        private readonly PrzychodniaDbContext _context;

        public RegulaminController(PrzychodniaDbContext context)
        {
            _context = context;
        }

        // GET: Regulamin
        public async Task<IActionResult> Index()
        {
            return View(await _context.Regulaminy.ToListAsync());
        }
    }
}

