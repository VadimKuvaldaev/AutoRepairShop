using AutoRepairShop.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AutoRepairShop.Pages.Account
{
    [Authorize]
    public class ProfileModel(ApplicationDbContext context) : PageModel
    {
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await context.AuthUsers.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await context.AuthUsers.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
            if (user == null) return NotFound();

            return RedirectToPage();
        }
    }
}
