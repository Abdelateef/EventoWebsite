using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;

namespace projectf22.Pages.Delete
{
    public class Payment_DeleteModel : PageModel
    {

        [BindProperty]
        public int id { get; set; }

        private DB db { get; set; }

        public Payment_DeleteModel(DB db)
        {
            this.db = db;
        }

        public void OnGet(int id)
        {
            this.id = id;
        }
        public IActionResult OnPost()
        {
            db.DeletePayment(id);

            return RedirectToPage("/Admin_Page/A_Payment");
        }
    }
}
