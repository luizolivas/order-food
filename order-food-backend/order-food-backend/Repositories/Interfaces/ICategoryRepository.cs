using OrderFoodLibrary.Entities;

namespace order_food_backend.Repositories.Interfaces {
    public interface ICategoryRepository {

        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task DeleteCategory(int id);
        Task UpdateCategory(Category category);
        Task CreateCategory(Category category);
    }
}
