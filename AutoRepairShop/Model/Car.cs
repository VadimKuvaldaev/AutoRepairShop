namespace AutoRepairShop.Model
{
    public class Car : EFModel
    {
        public BrandCar? Brand { get; set; }
        public string? ModelCar { get; set; }       
        public int ModelID { get; set; }
        public int Year { get; set; }
        public string? Owner { get; set; }
    }
}
