namespace AutoRepairShop.Model
{
    public class Car : EFModel
    {
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public string? Owner { get; set; }
    }
}
