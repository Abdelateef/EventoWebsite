using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;

namespace projectf22.Pages.Create
{
    public class Create_ReviewsModel : PageModel
    {
        [BindProperty]
        public Review review { get; set; }
        private DB db { get; set; }

        public Create_ReviewsModel(DB db)
        {
            this.db = db;
            review = new Review();
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            db.AddReview(review);
            return RedirectToPage("/Admin_Page/A_Reviews");
        }
    }
}
