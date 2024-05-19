using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;

namespace projectf22.Pages.Create
{
    public class Create_EventModel : PageModel
    {
        [BindProperty]
        public Event ev { get; set; }
        private DB db { get; set; }

        public Create_EventModel(DB db)
        {
            this.db = db;
            ev = new Event();
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            db.AddEvent(ev);
            return RedirectToPage("/Admin_Page/A_Event");
        }
    }
}

