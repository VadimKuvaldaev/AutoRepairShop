using AutoRepairShop.Model;
using Microsoft.EntityFrameworkCore;

namespace AutoRepairShop.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ModelCar> ModelsCars { get; set; }
    }
}
