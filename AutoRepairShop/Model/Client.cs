using System.ComponentModel.DataAnnotations;

namespace AutoRepairShop.Model
{
    public class Client : EFModel
    {
        [Required(ErrorMessage = "Поле 'ФИО' обязательно для заполнения")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "ФИО должно содержать от 3 до 100 символов")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "Введите номер телефона")]
        [Phone(ErrorMessage = "Некорректный формат номера телефона")]
        public string? NumberPhone { get; set; }
        
        [Required(ErrorMessage = "Введите Email")]
        [EmailAddress(ErrorMessage = "Некорректный адрес электронной почты")]
        public string? Email { get; set; } 
        public List<Car> Cars { get; set; } = new List<Car>();
    }
}
