using Microsoft.AspNetCore.Mvc;
using Przychodnia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Przychodnia.App.ViewComponents
{
    public class Parametry : ViewComponent
    {
        private readonly PrzychodniaDbContext _context;

        public Parametry(PrzychodniaDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = 
                (from Parametry in _context.Parametry
                orderby Parametry.Pozycja, Parametry.Nazwa
                select Parametry
                ).ToList();

            return View("Parametry", items);
        }
    }
}
