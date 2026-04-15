using AutoRepairShop.Data;
using AutoRepairShop.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoRepairShop.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        public SelectList ClientList { get; set; } = default!;

        public IActionResult OnGet()
        {
            ClientList = new SelectList(_context.Clients, "Id", "FullName");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ClientList = new SelectList(_context.Clients, "Id", "FullName");
                return Page();
            }

            _context.Cars.Add(Car);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
