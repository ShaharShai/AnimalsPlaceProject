using AnimalPlaceProject.Data;
using AnimalPlaceProject.Models;
using AnimalPlaceProject.Services.AnimalRepository;
using AnimalPlaceProject.Services.BlogRepository;
using Microsoft.AspNetCore.Mvc;

namespace AnimalPlaceProject.Controllers
{
    public class HomeController : Controller
	{
	    private IAnimalRepository _animalRepository;
		private IBlogRepository _blogRepository;

		public HomeController(MyContext context, IAnimalRepository animalRepository, IBlogRepository blogRepository)
		{
			_animalRepository = animalRepository;
		    _blogRepository = blogRepository;
		}
		public IActionResult Index(LoginModel model)
		{
			if(model != null)
			{
                ViewBag.User = model;
            }
            ViewBag.Post = _blogRepository.GetLastPost();
            return View(_animalRepository.GetAllAnimals());
		}
	}
}
