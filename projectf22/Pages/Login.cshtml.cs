using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;

namespace projectf22.Pages
{
    public class LoginModel : PageModel
    {
        private readonly DB Data;
        [BindProperty]
        public int ID { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string pass { get; set; }

        public LoginModel(DB db) { Data = db; }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Name") is not null)
            {
                return RedirectToPage("/Index");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            if (Data.GetID(ID)==ID)
            {
                HttpContext.Session.SetString("Name", Name);
                return RedirectToPage("/Index");
            }

            else
            {
                return Page();
            }
        }
    }
}
