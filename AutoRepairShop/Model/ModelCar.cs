namespace AutoRepairShop.Model
{
    public class ModelCar : EFModel
    {
        public List<Car> Cars { get; set; } = new List<Car>();
    }
}
