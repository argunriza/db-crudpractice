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
        public IActionResult Create([FromForm] Posts post)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Invalid Data!";
            }

            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();
            ViewBag.Message = $"Post {post.Id} Created Successfully!";

            return View();
        }

        [HttpGet]
        public IActionResult Update([FromRoute] int id)
        {
            Posts? dbEntity = _dbContext.Posts.SingleOrDefault(post => post.Id == id);

            return View(dbEntity);
        }

        [HttpPost]
        public IActionResult Update([FromRoute] int id, [FromForm] Posts post)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Invalid data!.";

                return View();
            }

            Posts? dbEntity = this._dbContext.Posts.SingleOrDefault(post => post.Id == id);

            if (dbEntity is null)
            {
                ViewBag.Message = "Post Not Found!";

                return View();
            }

            dbEntity.Title = post.Title;
            dbEntity.Content = post.Content;
            dbEntity.CreatedAt = post.CreatedAt;
            dbEntity.CreatedBy = post.CreatedBy;

            this._dbContext.Posts.Update(dbEntity);
            this._dbContext.SaveChanges();
            ViewBag.Message = "Post Updated Succesfully.";

            return View();
        }

        [HttpGet]

        public IActionResult Delete([FromRoute] int id)
        {
            var dbEntity = _dbContext.Posts.SingleOrDefault(post => post.Id == id);
            if (dbEntity is null)
            {
                ViewBag.Message = "Post cannot found!.";

                return View();
            }

            _dbContext.Posts.Remove(dbEntity);
            _dbContext.SaveChanges();

            ViewBag.Message = "Post deleted successfully.";
            
            return View();
        }
    }
}
