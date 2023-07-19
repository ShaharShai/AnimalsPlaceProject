using AnimalPlaceProject.Models;
using Microsoft.AspNetCore.Mvc;
using AnimalPlaceProject.Services.BlogRepository;
using AnimalPlaceProject.Data;

namespace AnimalPlaceProject.Controllers
{
    public class BlogController : Controller
    {
        private IBlogRepository _blogRepository;
        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public IActionResult Index()
        {
            return View(_blogRepository.GetAllPosts());
        }

        public IActionResult Details(int id)
        {
            var blogPost = _blogRepository.GetPostById(id);
            return View(blogPost);
        }

    }
}
