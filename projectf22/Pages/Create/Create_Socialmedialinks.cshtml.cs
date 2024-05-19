using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;

namespace projectf22.Pages.Create
{
    public class Create_SocialmedialinksModel : PageModel
    {
        [BindProperty]
        public SocialMediaLink socialMediaLink { get; set; }
        private DB db { get; set; }

        public Create_SocialmedialinksModel(DB db)
        {
            this.db = db;
            socialMediaLink = new SocialMediaLink();
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            db.AddSocialMediaLink(socialMediaLink);
            return RedirectToPage("/Admin_Page/A_Socialmedialinks");
        }
    }
}
