namespace AutoRepairShop.Model
{
    public class ClientCar : EFModel
    {
        public List<Client> Clients { get; set; } = new List<Client>();
    }
}
