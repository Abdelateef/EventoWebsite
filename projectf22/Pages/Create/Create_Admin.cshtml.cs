using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;
namespace projectf22.Pages.Create
{
    public class Create_AdminModel : PageModel
    {
        [BindProperty]
        public Admin Admin { get; set; }
        private DB db { get; set; }
        public Create_AdminModel(DB db)
        {
            this.db = db;
            Admin = new Admin();
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            db.AddAdmin(Admin);

            return RedirectToPage("/Admin_Page/A_Admin");
        }

    }
}
