using order_food_backend.Repositories.Interfaces;
using OrderFoodLibrary.Entities;

namespace order_food_backend.Services {
    public class DishService {

        private readonly IDishRepository _dishRepository;

        public DishService(IDishRepository dishRepository) {
            _dishRepository = dishRepository;
        }

        public async Task AddDish(Dish dish) {

            if (dish == null) {
                throw new ArgumentNullException(nameof(dish), "Categoria não pode ser null");
            }

            await _dishRepository.CreateDish(dish);
        }

        public async Task DeleteDish(int id) {

            if (id == 0) {
                throw new ArgumentOutOfRangeException(nameof(id), "O ID deve ser maior que zero.");
            }
            await _dishRepository.DeleteDish(id);
        }

        public async Task<IEnumerable<Dish>> GetDishes() {
            IEnumerable<Dish> dishes = await _dishRepository.GetAllDishesAsync();
            return dishes;
        }

        public async Task<Dish> GetDishById(int id) {

            if (id <= 0) {
                throw new ArgumentOutOfRangeException(nameof(id), "O ID deve ser maior que zero.");
            }

            var dish = await _dishRepository.GetDishByIdAsync(id);

            if (dish == null) {
                throw new KeyNotFoundException($"Nenhuma categoria encontrada para o ID {id}.");
            }

            return dish;
        }

        public async Task UpdateDish(Dish dish) {
            if (dish == null) {
                throw new KeyNotFoundException($"Categoria não pode ser null");
            }

            await _dishRepository.UpdateDish(dish);
        }
    }
}
