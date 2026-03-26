namespace AutoRepairShop.Model
{
    public class Car : EFModel
    {
        public BrandCar Brand { get; set; } = new BrandCar();
        public string ModelCar { get; set; } = "";       
        public int Year { get; set; }
        public ClientCar Client { get; set; } = new ClientCar();
    }
}
