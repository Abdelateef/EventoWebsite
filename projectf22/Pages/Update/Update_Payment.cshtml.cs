using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;

namespace projectf22.Pages.Update
{
    public class Update_PaymentModel : PageModel
    {
        [BindProperty]
        public int id { get; set; }
        private DB db { get; set; }
        [BindProperty]
        public Payment pay { get; set; }

        public Update_PaymentModel(DB dp)
        {
            this.db = dp;

        }

        public void OnGet(int id)
        {
            this.id = id;
            pay = new Payment();
            pay = db.GetPaymentinfo(id);
        }

        public IActionResult OnPost()
        {
            pay.PaymentID = id;
            db.UpdatePaymentInfo(pay);
            return RedirectToPage("/Admin_Page/A_Payment");
        }
    }
}

