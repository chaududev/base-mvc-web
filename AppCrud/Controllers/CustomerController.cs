using Microsoft.AspNetCore.Mvc;

namespace AppCrud.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
