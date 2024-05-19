using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;
using System.ComponentModel.DataAnnotations;

namespace projectf22.Pages
{

    public class sign_upModel : PageModel
    {
        private readonly User Us;
        private readonly DB Data;
        public bool ShowResult { get; set; }
        public string ModalTitle { get; set; }
        public string ModalContent { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "This field is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string UsEmail { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "This field is required")]

        public string UsName { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "This field is required")]
        [MinLength(5, ErrorMessage = "Please enter minimum 5 charachters")]
        public string UsPassword { get; set; }

        public sign_upModel(DB db, User U) { Data = db; Us = U; }
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
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("Name", UsName);
                Us.UserPassword = UsPassword;
                Us.UserEmail = UsEmail;
                Us.UserName = UsName;
                Data.AddUser(Us);
                HttpContext.Session.SetString("UsID", Data.GetIDUsingInfo(Us.UserName, Us.UserEmail, Us.UserPassword).ToString());

                ShowResult = true;
                ModalTitle = "You Signed up successfully!!";
                ModalContent = "This is your ID: "+HttpContext.Session.GetString("UsID")
                    +". You will be redirect automatically after 5 seconds";


            }
            else { }


        }
    }
}
