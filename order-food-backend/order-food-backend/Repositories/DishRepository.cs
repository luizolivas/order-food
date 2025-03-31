using Microsoft.EntityFrameworkCore;
using order_food_backend.Context;
using OrderFoodLibrary.Entities;

namespace order_food_backend.Repositories {
    public class DishRepository 
    {
        private readonly ApplicationDbContext _context;

        public DishRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task CreateDish(Dish dish) {
            await _context.Dishes.AddAsync(dish);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDish(int id) {
            var dish = await _context.Dishes.FindAsync(id);
            if (dish == null) {
                throw new KeyNotFoundException("Categoria não encontrada");
            }

            _context.Dishes.Remove(dish);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Dish>> GetAllDishesAsync() {
            return await _context.Dishes.AsNoTracking().ToListAsync();
        }

        public async Task<Dish> GetDishByIdAsync(int id) {
            return await _context.Dishes.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateDish(Dish dish) {
            var existingDish = await _context.Dishes.FindAsync(dish.Id);

            if (existingDish == null) {
                throw new KeyNotFoundException("Categoria não encontrada");
            }

            if (dish == null) {
                throw new ArgumentNullException(nameof(dish), "Os dados da categoria não podem ser nulos.");
            }

            existingDish.Name = dish.Name;

            await _context.SaveChangesAsync();
        }
    }
}
