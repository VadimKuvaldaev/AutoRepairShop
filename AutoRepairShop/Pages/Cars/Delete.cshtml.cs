using AutoRepairShop.Data;
using AutoRepairShop.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AutoRepairShop.Pages.Cars
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
                return NotFound();
            
            Car = _context.Cars
                .Include(c => c.Client)
                .FirstOrDefault(m => m.Id == id);

            if (Car == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            var carToDelete = _context.Cars.Find(Car.Id);

            if (carToDelete != null)
            {
                _context.Cars.Remove(carToDelete);
                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}
