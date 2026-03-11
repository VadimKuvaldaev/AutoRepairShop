using AutoRepairShop.Data;
using AutoRepairShop.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoRepairShop.Pages.Cars
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; }

        public IActionResult OnGet(int id)
        {
            Car = _context.Cars.Find(id);

            if (Car == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Cars.Update(Car);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
