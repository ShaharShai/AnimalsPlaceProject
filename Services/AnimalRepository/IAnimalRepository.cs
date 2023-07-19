using AnimalPlaceProject.Models;

namespace AnimalPlaceProject.Services.AnimalRepository
{
    public interface IAnimalRepository
    {
        public IEnumerable<Animal> GetAllAnimals();
        public List<Animal> GetAnimals(string category);
        public Animal GetAnimalById(int id);
        public Animal GetFirst(int animalId);
        public void Delete(int animalId);
        public void EditPage(int animalId, string animalName, int animalAge, string description, string categoryName, IFormFile photoFile);
        public void Add(string animalName, int animalAge, string description, int categoryId, IFormFile photoFile);

    }
}
