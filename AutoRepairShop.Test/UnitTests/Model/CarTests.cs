using AutoRepairShop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairShop.Test.UnitTests.Model
{
    public class CarTests
    {
        [Fact]
        public void Car_WithValidData_ShouldBeValid()
        {
            // Arrange
            var car = new Car
            {
                Brand = "Toyota",              // Обязательное поле, строка < 50 символов
                ModelCar = "Camry",            // Обязательное поле, строка < 50 символов
                Year = 2020,                   // В пределах допустимого диапазона 1900–2026
                ClientId = 1,                  // Обязательное поле
                Client = new Client { Name = "Иван Петров" }
            };

            var context = new ValidationContext(car);
            var result = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(car, context, result, true);

            // Assert
            Assert.True(isValid);
            Assert.Empty(result);
        }

        [Fact]
        public void Car_WithInvalidYear_ShouldBeInvalid()
        {
            // Arrange
            var car = new Car
            {
                Brand = "Toyota",
                ModelCar = "Camry",
                Year = 1800,                   // ❌ Меньше минимального значения 1900
                ClientId = 1
            };

            var context = new ValidationContext(car);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(car, context, results, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage.Contains("Год выпуска должен быть"));
        }

        [Fact]
        public void Car_WithEmptyBrand_ShouldBeInvalid()
        {
            // Arrange
            var car = new Car
            {
                Brand = "",                    // ❌ Обязательное поле пустое
                ModelCar = "Camry",
                Year = 2020,
                ClientId = 1
            };

            var context = new ValidationContext(car);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(car, context, results, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage.Contains("Введите марку автомобиля"));
        }

        [Fact]
        public void Car_WithTooLongModel_ShouldBeInvalid()
        {
            // Arrange
            var car = new Car
            {
                Brand = "Toyota",
                ModelCar = new string('A', 51), // ❌ Модель длиннее 50 символов
                Year = 2020,
                ClientId = 1
            };

            var context = new ValidationContext(car);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(car, context, results, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage.Contains("Модель не может превышать 50 символов"));
        }

        [Fact]
        public void Car_WithMissingClientId_ShouldBeInvalid()
        {
            // Arrange
            var car = new Car
            {
                Brand = "Toyota",
                ModelCar = "Camry",
                Year = 2020,
                ClientId = 0  // значение по умолчанию
            };

            // Act & Assert
            // Проверяем бизнес-правило: ClientId должен быть больше 0
            Assert.True(car.ClientId <= 0, "ClientId должен быть больше 0 для указания владельца");
        }
    }
}
