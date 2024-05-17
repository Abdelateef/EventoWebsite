using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace projectf22.Pages
{
    public class AdminModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Name") is not null)
            {
                if (HttpContext.Session.GetString("Name").Contains("admin"))
                { return Page(); }
                else
                { return RedirectToPage("/Index"); }
            }
            else
            {
                return RedirectToPage("/sign-up");
            }
        }
    }
}
