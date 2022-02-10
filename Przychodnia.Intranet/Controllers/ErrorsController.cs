using Microsoft.AspNetCore.Mvc;

namespace Przychodnia.Intranet.Controllers
{
    public class ErrorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error404()
        {
            return View();
        }
        public IActionResult ErrorDbUpdateException()
        {
            return View();
        }
    }
}
