namespace AutoRepairShop.Model
{
    public class Car : EFModel
    {
        public string Brand { get; set; } = string.Empty;
        public string ModelCar { get; set; } = string.Empty;
        public int Year { get; set; }
        public int ClientId { get; set; }
        public Client? Client { get; set; } 
    }
}
