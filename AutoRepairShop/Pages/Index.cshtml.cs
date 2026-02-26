using AutoRepairShop.Data;
using AutoRepairShop.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace AutoRepairShop.Pages.Cars
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        public IndexModel(/*ILogger<IndexModel> logger,*/ ApplicationDbContext context)
        {
            /*_logger = logger;*/
            _context = context;
        }
        public List<Car> Cars { get; set; }
        public void OnGet()
        {            
            /*var car = new Car { Brand = new() { Name = "Mitsubishi" }, Model = "Lancer" };
            _context.Cars.Add(car);
            _context.SaveChanges();*/

            var Cars = _context.Cars.ToList();
        }
    }
}
