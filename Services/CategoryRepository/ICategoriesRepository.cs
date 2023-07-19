using AnimalPlaceProject.Models;

namespace AnimalPlaceProject.Services.CategoryRepository
{
    public interface ICategoriesRepository
    {
        public IEnumerable<Category> GetAllCategories();
        public Category GetFirst(int categoryId);
    }
}
