using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;

namespace projectf22.Pages.Update
{
    public class Update_OrganizerModel : PageModel
    {
        [BindProperty]
        public int id { get; set; }
        private DB db { get; set; }
        [BindProperty]
        public Organizer Org { get; set; }

        public Update_OrganizerModel(DB dp)
        {
            this.db = dp;

        }

        public void OnGet(int id)
        {
            this.id = id;
            Org= new Organizer();
            Org = db.GetOrganizerinfo(id);
        }

        public IActionResult OnPost()
        {
            Org.EventID = id;
            db.UpdateOranizerInfo(Org);
            return RedirectToPage("/Admin_Page/A_Organizer");
        }
    }
}