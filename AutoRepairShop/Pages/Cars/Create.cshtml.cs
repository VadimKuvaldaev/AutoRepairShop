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
        public Car Car { get; set; }

        public SelectList ClientList { get; set; }

        public void OnGet()
        {
            PopulateClientsList();
        }

        public IActionResult OnPost()
        {
            ModelState.Remove("Car.Client");
            ModelState.Remove("Car.Brand");

            if (!ModelState.IsValid)
            {         
                PopulateClientsList();
                return Page();
            }

            _context.Cars.Add(Car);
            _context.SaveChanges();
            return RedirectToPage("./Index");
        }

        private void PopulateClientsList()
        {
            var clients = _context.Clients
                .OrderBy(c => c.FullName)
                .Select(c => new { c.Id, c.FullName })
                .ToList();

            ClientList = new SelectList(clients, "Id", "FullName");
        }
    }
}
