using OrderFoodLibrary.Entities;

namespace order_food_backend.Repositories.Interfaces {
    public interface IDishRepository 
    {
        Task<IEnumerable<Dish>> GetAllDishesAsync();
        Task<Dish> GetDishByIdAsync(int id);
        Task DeleteDish(int id);
        Task UpdateDish(Dish category);
        Task CreateDish(Dish category);
    }
}
