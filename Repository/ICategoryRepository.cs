using Ecommerce.Models;

namespace Ecommerce.Repository;
public interface ICategoryRepository
{
    bool CreateCategory(string categoryName);
    List<Category> GetCategories();
}