using AutoRepairShop.Data;
using AutoRepairShop.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AutoRepairShop.Pages.Cars
{
    public class IndexModel : PageModel
    {       
        private readonly ApplicationDbContext _context;

        public IndexModel( ApplicationDbContext context)
        {            
            _context = context;
        }
        public List<Car> Cars { get; set; }

        public void OnGet()
        {
            Cars = _context.Cars
                .Include(c => c.Brand)
                .Include(c => c.Client)
                .ToList();
        }
    }
}
