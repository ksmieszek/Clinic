using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Przychodnia.App.Controllers
{
    public class ThankYouPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
