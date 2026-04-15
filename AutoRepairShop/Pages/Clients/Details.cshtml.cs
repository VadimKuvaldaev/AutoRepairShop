using AutoRepairShop.Data;
using AutoRepairShop.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AutoRepairShop.Pages.Clients
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public DetailsModel(ApplicationDbContext context) 
        {
            _context = context;
        }
        public Client Client { get; set; } 
        public IActionResult OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Client = _context.Clients
                .Include(c => c.Cars)
                .FirstOrDefault(m => m.Id == id);

            if (Client == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
