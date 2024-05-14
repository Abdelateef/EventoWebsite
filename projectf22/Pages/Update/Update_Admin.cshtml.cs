using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;

namespace projectf22.Pages.Update
{
    public class Update_AdminModel : PageModel
    {
        [BindProperty]
        public int id { get; set; }
        private DB db { get; set; }
        [BindProperty]
        public Admin Adm { get; set; }

        public Update_AdminModel(DB dp)
        {
            this.db = dp;

        }

        public void OnGet(int id)
        {
            this.id = id;
            Adm = new Admin();
            Adm = db.GetAdmininfo(id);
        }

        public IActionResult OnPost()
        {
            Adm.AdminID = id;
            db.UpdateAdminInfo(Adm);
            return RedirectToPage("/Admin_Page/A_Admin");
        }
    }
}
