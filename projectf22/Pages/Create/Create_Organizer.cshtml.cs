using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;

namespace projectf22.Pages.Create
{
    public class Create_OrganizerModel : PageModel
    {
        [BindProperty]
        public Organizer organizer { get; set; }
        private DB db { get; set; }

        public Create_OrganizerModel(DB db)
        {
            this.db = db;
            organizer = new Organizer();
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            db.AddOrganizer(organizer);
            return RedirectToPage("/Admin_Page/A_Organizer");
        }
    }
}
