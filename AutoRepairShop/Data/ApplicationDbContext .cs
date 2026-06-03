using AutoRepairShop.Model;
using Microsoft.EntityFrameworkCore;
using AutoRepairShop.Model.AuthApp;


namespace AutoRepairShop.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }       
        public DbSet<ClientCar> ClientCars { get; set; }
        public DbSet<AuthUser> AuthUsers { get; set; }
    }
}
