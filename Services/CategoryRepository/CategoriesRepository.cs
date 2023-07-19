using AnimalPlaceProject.Data;
using AnimalPlaceProject.Models;

namespace AnimalPlaceProject.Services.CategoryRepository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private MyContext _context;
        public CategoriesRepository(MyContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.AnimalCategories;
        }

        public Category GetFirst(int categoryId)
        {
            return _context.AnimalCategories.FirstOrDefault(c => c.CategoryId == categoryId)!;
        }
    }
}
