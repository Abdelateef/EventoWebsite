using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace projectf22.Pages
{
    public class shows_eventsModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Name") is not null)
            {
                return Page();
            }
            else
            {
                return RedirectToPage("/sign-up");
            }
        }
    }
}
