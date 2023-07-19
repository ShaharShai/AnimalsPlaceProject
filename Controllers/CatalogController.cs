using AnimalPlaceProject.Data;
using AnimalPlaceProject.Models;
using AnimalPlaceProject.Services;
using AnimalPlaceProject.Services.AnimalRepository;
using AnimalPlaceProject.Services.CategoryRepository;
using AnimalPlaceProject.Services.CommentRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace AnimalPlaceProject.Controllers
{
    public class CatalogController : Controller
	{
		private IAnimalRepository _animalRepository;
		private ICategoriesRepository _categoriesRepository;
		private ICommentsRepository _commentsRepository;
		public CatalogController(IAnimalRepository animalRepository, ICategoriesRepository categoriesRepository, ICommentsRepository commentsRepository)
		{
		    _animalRepository = animalRepository;
			_categoriesRepository = categoriesRepository;
			_commentsRepository = commentsRepository;
		}

		public IActionResult Index(string categoryName = "All")
		{

			ViewBag.Categories = _categoriesRepository.GetAllCategories();

            ViewBag.CurrentCategory = categoryName;

            if (categoryName == "All")
			{
                return View(_animalRepository.GetAllAnimals());
            }
            return View(_animalRepository.GetAnimals(categoryName));
        }

		public IActionResult Details(int animalId)
		{
            return View(_animalRepository.GetAnimalById(animalId));
        }

		public IActionResult AddComment(string content, int animalId)
		{

			if(content == null)
			{
                return View("Details", _animalRepository.GetFirst(animalId));
            }

			_commentsRepository.AddComment(content, _animalRepository.GetFirst(animalId));
            return View("Details", _animalRepository.GetFirst(animalId));
		}

		public IActionResult AddLike(int commentId, int animalId, bool isLiked)
		{

			_commentsRepository.AddLike(commentId, isLiked);

            return View("Details", _animalRepository.GetFirst(animalId));
        }
    }

}

