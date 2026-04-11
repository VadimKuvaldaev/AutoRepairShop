using AutoRepairShop.Data;
using AutoRepairShop.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AutoRepairShop.Pages.Cars
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Car Car { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = _context.Cars
                .Include(c => c.Brand)
                .Include(c => c.Client)
                .FirstOrDefault(m => m.Id == id);

            if (Car == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
