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

        public async Task AddCategory(Category category) {
            
            if(category == null) {
                throw new ArgumentNullException(nameof(category), "Categoria não pode ser null");
            }

            await _categoryRepository.CreateCategory(category);
        }

        public async Task DeleteCategory(int id) {

            if (id == 0) {
                throw new ArgumentOutOfRangeException(nameof(id), "O ID deve ser maior que zero.");
            }
            await _categoryRepository.DeleteCategory(id);
        }

        public async Task<IEnumerable<Category>> GetCategories() 
        {            
            IEnumerable<Category> categories = await _categoryRepository.GetAllCategoriesAsync();
            return categories;
        }

        public async Task<Category> GetCategoryById(int id) {

            if (id <= 0) {
                throw new ArgumentOutOfRangeException(nameof(id), "O ID deve ser maior que zero.");
            }

            var category = await _categoryRepository.GetCategoryByIdAsync(id);

            if(category == null) {
                throw new KeyNotFoundException($"Nenhuma categoria encontrada para o ID {id}.");
            }

            return category;
        }

        public async Task UpdateCategory(Category category) {
            if (category == null) {
                throw new KeyNotFoundException($"Categoria não pode ser null");
            }

            await _categoryRepository.UpdateCategory(category);
        }
    }
}
