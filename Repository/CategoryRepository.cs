using Ecommerce.Data;
using Ecommerce.Models;

namespace Ecommerce.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateCategory(string categoryName)
        {
            try
            {
                var cat = _context.Categories.Add(new Category
                {
                    Name = categoryName,
                });

                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public List<Category> GetCategories()
        {
            var categories = _context.Categories.ToList();
            return categories;
        }
    }
}