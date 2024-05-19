using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;

namespace projectf22.Pages.Create
{
    public class Create_LocationModel : PageModel
    {
        [BindProperty]
        public Location location { get; set; }
        private DB db { get; set; }

        public Create_LocationModel(DB db)
        {
            this.db = db;
            location = new Location();
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            db.AddLocation(location);
            return RedirectToPage("/Admin_Page/A_Location");
        }
    }
}
