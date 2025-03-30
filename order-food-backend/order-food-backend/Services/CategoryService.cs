using order_food_backend.Repositories.Interfaces;
using order_food_backend.Services.Interfaces;
using OrderFoodLibrary.Entities;

namespace order_food_backend.Services {
    public class CategoryService : ICategoryService 
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository) {
            _categoryRepository = categoryRepository;
        }

        public Task AddCategory(Category category) {
            throw new NotImplementedException();
        }

        public Task DeleteCategory(int id) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetCategories() {
            throw new NotImplementedException();
        }

        public Task<Category> GetCategoryById(int id) {
            throw new NotImplementedException();
        }

        public Task UpdateCategory(Category category) {
            throw new NotImplementedException();
        }
    }
}
