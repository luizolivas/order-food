using Moq;
using order_food_backend.Repositories.Interfaces;
using order_food_backend.Services;
using OrderFoodLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace order_food_tests.Application.Services.DishServices {
    public class DishServiceTest 
    {
        private readonly Mock<IDishRepository> _dishRepositoryMock;
        private readonly DishService _dishService;

        public DishServiceTest() {
            _dishRepositoryMock = new Mock<IDishRepository>();
            _dishService = new DishService(_dishRepositoryMock.Object);
        }

        [Fact]
        public async Task GetDishes_ShouldReturnDishes() {

            var cat = new Category { Id = 1, Name = "Almoço" };
            var dishes = new List<Dish> {

               new Dish { Id = 1, Name = "Arroz", Avaliable = true, Category = cat, Price = 10, Description = "Teste" },
               new Dish { Id = 2, Name = "Feijão", Avaliable = true, Category = cat, Price = 10, Description = "Teste1" }
            };
            _dishRepositoryMock.Setup(repo => repo.GetAllDishesAsync()).ReturnsAsync(dishes);

            var result = await _dishService.GetDishes();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal("Arroz", result.First().Name);
        }

        [Fact]
        public async Task GetDishById_ShouldReturnDishByID() {

            var cat = new Category { Id = 1, Name = "Almoço" };
            Dish dish = new Dish { Id = 1, Name = "Arroz", Avaliable = true, Category = cat, Price = 10, Description = "Teste" };

            _dishRepositoryMock.Setup(repo => repo.GetDishByIdAsync(1)).ReturnsAsync(dish);

            var result = await _dishService.GetDishById(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Arroz", result.Name);
        }

        [Fact]
        public async Task AddDish_ShouldCallRepository() {
            var cat = new Category { Id = 1, Name = "Almoço" };
            Dish dish = new Dish { Id = 1, Name = "Arroz", Avaliable=true, Category = cat, Price= 10, Description="Teste"  };

            await _dishService.AddDish(dish);

            _dishRepositoryMock.Verify(repo => repo.CreateDish(dish), Times.Once);

        }

        [Fact]
        public async Task UpdateDish_ShouldCallRepository() {
            var cat = new Category { Id = 1, Name = "Almoço" };
            Dish dish = new Dish { Id = 1, Name = "Arroz", Avaliable = true, Category = cat, Price = 10, Description = "Teste" };

            await _dishService.UpdateDish(dish);

            _dishRepositoryMock.Verify(repo => repo.UpdateDish(dish), Times.Once);
        }

        [Fact]
        public async Task DeleteDish_ShouldCallRepository() {

            int dishId = 1;

            await _dishService.DeleteDish(dishId);

            _dishRepositoryMock.Verify(repo => repo.DeleteDish(dishId), Times.Once);
        }
    }
}
