using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;

namespace projectf22.Pages.Update
{
    public class Update_PromotionsModel : PageModel
    {
        [BindProperty]
        public int id { get; set; }
        private DB db { get; set; }
        [BindProperty]
        public Promotion Prom { get; set; }

        public Update_PromotionsModel(DB dp)
        {
            this.db = dp;

        }

        public void OnGet(int id)
        {
            this.id = id;
            Prom = new Promotion();
            Prom = db.GetPromotioninfo(id);
        }

        public IActionResult OnPost()
        {
            Prom.PromotionID = id;
            db.UpdatePromotionInfo(Prom);
            return RedirectToPage("/Admin_Page/A_Promotions");
        }
    }
}

