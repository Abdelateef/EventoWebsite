using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;

namespace projectf22.Pages.Update
{
    public class Update_ReviewsModel : PageModel
    {
        [BindProperty]
        public int id { get; set; }
        private DB db { get; set; }
        [BindProperty]
        public Review rev { get; set; }

        public Update_ReviewsModel(DB dp)
        {
            this.db = dp;

        }

        public void OnGet(int id)
        {
            this.id = id;
            rev = new Review();
            rev = db.GetReviewinfo(id);
        }

        public IActionResult OnPost()
        {
            rev.ReviewID = id;
            db.UpdateReviewInfo(rev);
            return RedirectToPage("/Admin_Page/A_Reviews");
        }
    }
}
