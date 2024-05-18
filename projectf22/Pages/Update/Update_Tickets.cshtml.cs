using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;

namespace projectf22.Pages.Update
{
    public class Update_TicketsModel : PageModel
    {
        [BindProperty]
        public int id { get; set; }
        private DB db { get; set; }
        [BindProperty]
        public Tickets Tic { get; set; }

        public Update_TicketsModel(DB dp)
        {
            this.db = dp;

        }

        public void OnGet(int id)
        {
            this.id = id;
            Tic = new Tickets();
            Tic = db.GetTicketinfo(id);
        }

        public IActionResult OnPost()
        {
            Tic.TicketID= id;
            db.UpdateTicketinfo(Tic);
            return RedirectToPage("/Admin_Page/A_Ticket");
        }
    }
}

