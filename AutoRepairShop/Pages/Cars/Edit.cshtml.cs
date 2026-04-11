using AutoRepairShop.Data;
using AutoRepairShop.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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

        public SelectList ClientList { get; set; }

        public IActionResult OnGet(int id)
        {
            Car = _context.Cars
                .Include(c => c.Brand)
                .Include(c => c.Client)
                .FirstOrDefault(m => m.Id == id);

            if (Car == null)
            {
                return NotFound();
            }

            PopulateClientsList();
            return Page();
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

            _context.Attach(Car).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Cars.Any(e => e.Id == Car.Id))
                {
                    return NotFound();
                }
                else { throw; }
            }

            return RedirectToPage("./Index");
        }

        private void PopulateClientsList()
        {
            var clients = _context.Clients
                .OrderBy(c => c.FullName)
                .Select(c => new { c.Id, c.FullName })
                .ToList();

            ClientList = new SelectList(clients, "Id", "FullName", Car?.Client);
        }
    }
}
