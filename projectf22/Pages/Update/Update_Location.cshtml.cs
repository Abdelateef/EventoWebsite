using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;

namespace projectf22.Pages.Update
{
    public class Update_LocationModel : PageModel
    {
        [BindProperty]
        public int id { get; set; }
        private DB db { get; set; }
        [BindProperty]
        public Location Loc { get; set; }

        public Update_LocationModel(DB dp)
        {
            this.db = dp;

        }

        public void OnGet(int id)
        {
            this.id = id;
            Loc = new Location();
            Loc = db.GetLocationinfo(id);
        }

        public IActionResult OnPost()
        {
            Loc.LocationID = id;
            db.UpdateLocationInfo(Loc);
            return RedirectToPage("/Admin_Page/A_Location");
        }
    }
}
