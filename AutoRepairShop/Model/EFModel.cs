using System.ComponentModel.DataAnnotations;

namespace AutoRepairShop.Model
{
    public class EFModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле 'Имя/Наименование обязательно для заполнения'")]
        public string Name { get; set; } = "";
    }
}
