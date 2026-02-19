namespace AutoRepairShop.Model
{
    public class Car : EFModel
    {
        public string? Brand { get; set; }
        public ModelCar? Model { get; set; }
        public int ModelID { get; set; }
        public int Year { get; set; }
        public string? Owner { get; set; }
    }
}
