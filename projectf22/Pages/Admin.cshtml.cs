using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace projectf22.Pages
{
    public class AdminModel : PageModel
    {
        private readonly DB Data;

        public AdminModel(DB db) { Data = db; }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Name") is not null)
            {
                int.TryParse(HttpContext.Session.GetString("UsID"), out int Id);
                string user = HttpContext.Session.GetString("Name");
                string password = HttpContext.Session.GetString("Password");
                    
                if (Data.ValidateAdmin(Id, user, password))
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
