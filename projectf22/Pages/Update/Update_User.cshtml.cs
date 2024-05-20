using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;

namespace projectf22.Pages.Update
{
    public class Update_UserModel : PageModel
    {
        [BindProperty]
        public int id { get; set; }

        private DB db { get; set; }

        [BindProperty]
        public User User { get; set; }

        public Update_UserModel(DB db)
        {
            this.db = db;
        }

        public void OnGet(int id)
        {
            this.id = id;
            User = db.GetUserInfo(id);
        }

        public IActionResult OnPost()
        {
            User.UserID = id;
            db.UpdateUserInfo(User);
            return RedirectToPage("/Admin_Page/A_User");
        }
    }
}
