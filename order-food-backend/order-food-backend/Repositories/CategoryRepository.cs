using Microsoft.EntityFrameworkCore;
using order_food_backend.Context;
using order_food_backend.Repositories.Interfaces;
using OrderFoodLibrary.Entities;

namespace order_food_backend.Repositories {
    public class CategoryRepository : ICategoryRepository {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task CreateCategory(Category category) {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategory(int id) {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) {
                throw new KeyNotFoundException("Categoria não encontrada");
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync() {
            return await _context.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id) {
            return await _context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateCategory(Category category) {
            var existingCategory = await _context.Categories.FindAsync(category.Id);

            if (existingCategory == null) {
                throw new KeyNotFoundException("Categoria não encontrada");
            }

            if (category == null) {
                throw new ArgumentNullException(nameof(category), "Os dados da categoria não podem ser nulos.");
            }

            existingCategory.Name = category.Name;

            await _context.SaveChangesAsync();
        }
    }
}
