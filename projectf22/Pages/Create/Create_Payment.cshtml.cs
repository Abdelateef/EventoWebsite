using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;

namespace projectf22.Pages.Create
{
    public class Create_PaymentModel : PageModel
    {
        [BindProperty]
        public Payment payment { get; set; }
        private DB db { get; set; }

        public Create_PaymentModel(DB db)
        {
            this.db = db;
            payment = new Payment();
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            db.AddPayment(payment);
            return RedirectToPage("/Admin_Page/A_Payment");
        }
    }
}
