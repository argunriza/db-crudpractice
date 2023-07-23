using Microsoft.AspNetCore.Mvc;

namespace Ders20.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();


        }

        public IActionResult Edit()
        {
            return View();
        }

    }
}
