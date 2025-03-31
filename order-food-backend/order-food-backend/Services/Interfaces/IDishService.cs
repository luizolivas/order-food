using OrderFoodLibrary.Entities;

namespace order_food_backend.Services.Interfaces {
    public interface IDishService 
    {
        Task<IEnumerable<Dish>> GetDishes();
        Task<Dish> GetDishById(int id);
        Task UpdateDish(Dish Dish);
        Task DeleteDish(int id);
        Task AddDish(Dish Dish);
    }
}
