using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;

namespace projectf22.Pages.Delete
{
    public class Socialmedialinks_DeleteModel : PageModel
    {
        [BindProperty]
        public string Socialmediatype { get; set; }

        private readonly DB db;

        public Socialmedialinks_DeleteModel(DB db)
        {
            this.db = db;
        }

        public void OnGet(string socialmediatype)
        {
            Socialmediatype = socialmediatype;
        }

        public IActionResult OnPost()
        {
            db.DeleteSocialmedia(Socialmediatype);
            return RedirectToPage("/Admin_Page/A_Socialmedialinks");
        }
    }
}
