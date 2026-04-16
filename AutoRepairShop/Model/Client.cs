namespace AutoRepairShop.Model
{
    public class Client : EFModel
    {     
        public string? FullName { get; set; }
        public string? NumberPhone { get; set; } 
        public string? Email { get; set; } 
        public List<Car> Cars { get; set; } = new List<Car>();
    }
}
