using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;

namespace projectf22.Pages.Create
{
    public class Create_PromotionsModel : PageModel
    {
        [BindProperty]
        public Promotion promotion { get; set; }
        private DB db { get; set; }

        public Create_PromotionsModel(DB db)
        {
            this.db = db;
            promotion = new Promotion();
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            db.AddPromotion(promotion);
            return RedirectToPage("/Admin_Page/A_Promotions");
        }
    }
}
