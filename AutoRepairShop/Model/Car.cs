namespace AutoRepairShop.Model
{
    public class Car : EFModel
    {
        public BrandCar Brand { get; set; }
        public string ModelCar { get; set; } = "";       
        public int Year { get; set; }
        public Client Client { get; set; }
    }
}
