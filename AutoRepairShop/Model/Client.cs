namespace AutoRepairShop.Model
{
    public class Client : EFModel
    {        
        public int NumberPhone {  get; set; }
        public string? Email { get; set; }
        public List<Car>? Cars { get; set; }
    }
}
