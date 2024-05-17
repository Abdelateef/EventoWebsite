using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;

namespace projectf22.Pages.Create
{
    public class Create_UserModel : PageModel
    {

        [BindProperty]
        public User User { get; set; }
        private DB db { get; set; }
        public Create_UserModel(DB db)
        {
            this.db = db;
            User = new User();
        }
        public void OnGet()
        {
        }   
        public IActionResult OnPost()
        {
            db.AddUser(User);

            return RedirectToPage("/Admin_Page/A_User");
        }
    }
}

