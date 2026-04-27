using System.ComponentModel.DataAnnotations;

namespace AutoRepairShop.Model
{
    public class Car : EFModel
    {
        [Required(ErrorMessage = "Введите марку автомобиля")]
        [StringLength(50, ErrorMessage = "Марка не может превышать 50 символов")]
        public string Brand { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите модель автомобиля")]
        [StringLength(50, ErrorMessage = "Модель не может превышать 50 символов")]
        public string ModelCar { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите год выпуска автомобиля")]
        [Range(1900, 2026, ErrorMessage = "Год выпуска должен быть между 1900 и 2026")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Необходимо выбрать владельца")]
        public int? ClientId { get; set; }
        public Client? Client { get; set; } 
    }
}
