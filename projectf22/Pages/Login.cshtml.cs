using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;
using System.ComponentModel.DataAnnotations;

namespace projectf22.Pages
{
    public class LoginModel : PageModel
    {
        public string ErrorMessage { get; set; }
        private readonly DB Data;
        [BindProperty]

        public int ID { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "This field is required")]
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
            if (Data.GetID(ID) == ID && Data.GetPassUsingID(ID)==pass && Data.GetNameUsingID(ID)==Name)
            {
                HttpContext.Session.SetString("UsID", ID.ToString());
                HttpContext.Session.SetString("Name", Name);
                return RedirectToPage("/Index");
            }

            else
            {
                ErrorMessage = "Name,ID, or Password might be wrong";
                return Page();
            }
        }
    }
}
