using AnimalPlaceProject.Data;
using AnimalPlaceProject.Models;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AnimalPlaceProject.Services.AnimalRepository
{
    public class AnimalRepository : IAnimalRepository
    {
        private MyContext _context;
        public AnimalRepository(MyContext context)
        {
            _context = context;
        }
        public IEnumerable<Animal> GetAllAnimals()
        {
            return _context.Animals;
        }
        public Animal GetAnimalById(int id)
        {
            return _context.Animals.Where(c => c.AnimalId == id).First();
        }

        List<Animal> IAnimalRepository.GetAnimals(string category)
        {

            return _context.Animals.Where(c => c.Category!.Name == category).ToList();

        }

        public Animal GetFirst(int animalId)
        {
            return _context.Animals.FirstOrDefault(a => a.AnimalId == animalId)!;
        }


        public void Delete(int animalId)
        {
            var animal = _context.Animals!.SingleOrDefault(m => m.AnimalId == animalId);



            foreach (var comment in animal!.Comments!)
            {
                animal.Comments.Remove(comment);
            }


            _context.Remove(animal);
            _context.SaveChanges();
        }

        public void EditPage(int animalId, string animalName, int animalAge, string description, string categoryName, IFormFile photoFile)
        {
            var animal = _context.Animals!.SingleOrDefault(m => m.AnimalId == animalId);
            animal!.Name = animalName;
            animal.Age = animalAge;

            animal.Category = _context.AnimalCategories.FirstOrDefault(c => c.Name == categoryName);

          
            var fileName = photoFile?.FileName;
            if (fileName == null || photoFile == null)
            {
                fileName = animal.PictureName;
            }
            string filePath = Path.Combine("wwwroot/Pictures", fileName!);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                photoFile?.CopyTo(stream);
            }
            animal.PictureName = fileName;

            animal.Description = description;


            _context.SaveChanges();
        }

        public void Add(string animalName, int animalAge, string description, int categoryId, IFormFile photoFile)
        {
            Category animalCategory = _context.AnimalCategories.FirstOrDefault(c => c.CategoryId == categoryId)!;
            var fileName = photoFile?.FileName;
            if(fileName == null || photoFile == null)
            {
                fileName = "turtle.jpg";
            }
            string filePath = Path.Combine("wwwroot/Pictures", fileName!);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                photoFile?.CopyTo(stream);
            }
                _context.Animals.Add(new Animal
                {
                    Name = animalName,
                    Age = animalAge,
                    PictureName = fileName,
                    Description = description,
                    CategoryId = categoryId,

                });

                _context.SaveChanges();
        }

    }
}