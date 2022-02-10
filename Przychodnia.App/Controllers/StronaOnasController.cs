using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Przychodnia.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Przychodnia.App.Controllers
{
    public class StronaOnasController : Controller
    {
        private readonly PrzychodniaDbContext _context;

        public StronaOnasController(PrzychodniaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.ModelOnas =
               (
               from StronaOnas in _context.StronaOnas
               where StronaOnas.Aktywna == true
               orderby StronaOnas.Pozycja ascending
               select StronaOnas
               ).ToList();
            ViewBag.ModelStrona =
                (
                from Strona in _context.Strony
                where Strona.Aktywna == true
                orderby Strona.IdStrony descending
                select Strona
                ).ToList();
            ViewBag.Strona = await _context.Strony.ToListAsync();
            if (id == null)
            {
                var pierwszy = await _context.Strony.FirstAsync();
                id = pierwszy.IdStrony;
            }
            return View(await _context.StronaOnas.ToListAsync());
        }
    }
}
