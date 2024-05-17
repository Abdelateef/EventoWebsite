using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;
using System.Runtime.Intrinsics.Arm;

namespace projectf22.Pages.Update
{

    public class Update_UserModel : PageModel
    {
        [BindProperty]
        public int id { get; set; }
        private DB db { get; set; }
        [BindProperty]
        public User User { get; set; }

        public Update_UserModel(DB dp)
        {
            this.db = dp;

        }
        public void OnGet(int id)
        {
            this.id = id;
            User  = new User();
            User = db.GetUserinfo(id);

        }
        public IActionResult OnPost()
        {
            User.UserID = id;
            db.UpdateUserInfo(User);
            return RedirectToPage("/Admin_Page/A_User");
        }
    }
}
