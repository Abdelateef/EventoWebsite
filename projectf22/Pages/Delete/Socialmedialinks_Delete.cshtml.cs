using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;

namespace projectf22.Pages.Delete
{
    public class Socialmedialinks_DeleteModel : PageModel
    {
        [BindProperty]
        public string linkURL { get; set; }

        private DB db { get; set; }

        public Socialmedialinks_DeleteModel(DB db)
        {
            this.db = db;
        }

        public void OnGet(string linkURL)
        {
            this.linkURL = linkURL;
        }

        public IActionResult OnPost()
        {
            db.DeleteSocialMediaLink(linkURL);
            return RedirectToPage("/Admin_Page/A_Socialmedialinks");
        }
    }
}
