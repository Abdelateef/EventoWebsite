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
        [Required(ErrorMessage = "This field is required")]
        public int ID { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "This field is required")]
        public string pass { get; set; }

        public LoginModel(DB db)
        {
            Data = db;
        }

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
            if (ModelState.IsValid)
            {
                var adminId = Data.GetID(ID);
                var adminPass = Data.GetPassUsingID(ID);
                var adminName = Data.GetNameUsingID(ID);

                if (adminId == ID && adminPass == pass && adminName == Name)
                {
                    HttpContext.Session.SetString("UsID", ID.ToString());
                    HttpContext.Session.SetString("Name", Name);
                    HttpContext.Session.SetString("Password", pass);
                    return RedirectToPage("/Index");
                }
                else if (Data.ValidateAdmin(ID, Name, pass))
                {
                    HttpContext.Session.SetString("UsID", ID.ToString());
                    HttpContext.Session.SetString("Name", Name);
                    HttpContext.Session.SetString("Password", pass);
                    return RedirectToPage("/Admin");
                }
                else
                {
                    ErrorMessage = "Name, ID, or Password might be wrong";
                    return Page();
                }
            }

            // If ModelState is not valid, return the Page with validation errors
            return Page();
        }
    }
}
