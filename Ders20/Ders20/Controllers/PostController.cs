using Ders20.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ders20.Controllers
{
    public class PostController : Controller
    {
        private readonly AppDbContext _dbContext;

        public PostController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var posts = _dbContext.Posts.ToList();
            return View(posts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm]Posts posts)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Invalid Data!";
            }

            _dbContext.Posts.Add(posts);
            _dbContext.SaveChanges();
            ViewBag.Message = $"Product Created Successfully!{posts.Id}";
            return RedirectToAction("Index");
        }
    }
}
