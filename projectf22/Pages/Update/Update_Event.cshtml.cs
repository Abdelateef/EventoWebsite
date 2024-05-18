using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;

namespace projectf22.Pages.Update
{
    public class Update_EventModel : PageModel
    {
        [BindProperty]
        public int id { get; set; }
        private DB db { get; set; }
        [BindProperty]
        public Event Evnt { get; set; }

        public Update_EventModel(DB dp)
        {
            this.db = dp;

        }

        public void OnGet(int id)
        {
            this.id = id;
            Evnt = new Event();
            Evnt = db.GetEventtinfo(id);
        }

        public IActionResult OnPost()
        {
            Evnt.EventID = id;
            db.UpdateEventinfo(Evnt);
            return RedirectToPage("/Admin_Page/A_Event");
        }
    }
}
