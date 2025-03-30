using OrderFoodLibrary.Entities;

namespace order_food_backend.Services.Interfaces {
    public interface ICategoryService {

        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategoryById(int id);
        Task UpdateCategory(Category category);
        Task DeleteCategory(int id);
        Task AddCategory(Category category);
    }
}
