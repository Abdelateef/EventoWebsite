using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;

namespace projectf22.Pages.Update
{
    public class Update_SocialmedialinksModel : PageModel
    {
        [BindProperty]
        public int id { get; set; }
        private DB db { get; set; }
        [BindProperty]
        public SocialMediaLink Sol { get; set; }

        public Update_SocialmedialinksModel(DB dp)
        {
            this.db = dp;

        }

        public void OnGet(int id)
        {
            this.id = id;
            Sol = new SocialMediaLink();
            Sol = db.GetSocialMediaLinkInfo(id);
        }

        public IActionResult OnPost()
        {
            Sol.ID= id;
            db.UpdateSocialMediaLink(Sol);
            return RedirectToPage("/Admin_Page/A_Socialmedialinks");
        }
    }
}