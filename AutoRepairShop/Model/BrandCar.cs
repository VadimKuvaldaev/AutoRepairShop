namespace AutoRepairShop.Model
{
    public class BrandCar : EFModel
    {
        public List<Car> Cars { get; set; } = new List<Car>();
    }
}
