using AnimalPlaceProject.Data;
using AnimalPlaceProject.Models;
using AnimalPlaceProject.Services;
using AnimalPlaceProject.Services.AnimalRepository;
using AnimalPlaceProject.Services.BlogRepository;
using AnimalPlaceProject.Services.CategoryRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AnimalPlaceProject.Controllers
{
    [Authorize]
    public class Admin : Controller
    {

        IAnimalRepository _animalRepository;
        ICategoriesRepository _categoriesRepository;
        IBlogRepository _blogRepository;
        public Admin(IAnimalRepository animalRepository, ICategoriesRepository categoriesRepository, IBlogRepository blogRepository)
        {
      
            _animalRepository = animalRepository;
            _categoriesRepository = categoriesRepository;
            _blogRepository = blogRepository;
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

        public IActionResult Delete(int animalId, string categoryName)
        {
            _animalRepository.Delete(animalId);

            ViewBag.Categories = _categoriesRepository.GetAllCategories();

           return RedirectToAction("Index");
        }

        public IActionResult Edit(int animalId)
        {
            ViewBag.Categories = _categoriesRepository.GetAllCategories();
            return View(_animalRepository.GetAnimalById(animalId));
        }

        public IActionResult EditPage(int animalId, string animalName, int animalAge, string description, string categoryName, IFormFile photoFile )
        {



            _animalRepository.EditPage(animalId, animalName, animalAge, description, categoryName, photoFile!);

            ViewBag.Categories = _categoriesRepository.GetAllCategories();

           
            return RedirectToAction("Index");
        }

        public IActionResult AddNew()
        {
            ViewBag.Categories = _categoriesRepository.GetAllCategories();
            return View();
        }

        public IActionResult Add(string animalName, int animalAge, string description, int categoryId)
        {
            var photoFile = Request.Form.Files["imageName"];
            if(photoFile == null)
            {
                ViewBag.Categories = _categoriesRepository.GetAllCategories();
                return View("AddNew");
            }

            var animalCategory = _categoriesRepository.GetFirst(categoryId);

            if (ModelState.IsValid)
            {
                _animalRepository.Add(animalName, animalAge, description, categoryId, photoFile!);
                ViewBag.Categories = _categoriesRepository.GetAllCategories();
                return View("index", animalCategory!.Animals!);
            }
            ViewBag.Categories = _categoriesRepository.GetAllCategories();
            return RedirectToAction("index");

        }

        [HttpGet]
        public IActionResult CreateBlogPost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBlogPost(BlogPost model)
        {
            if(model == null)
            {
                RedirectToAction("CreateBlogPost");
            }
            if (ModelState.IsValid)
            {
                _blogRepository.CreateBlogPost(model);
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}

