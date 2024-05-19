using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;

namespace projectf22.Pages.Create
{
    public class Create_TicketModel : PageModel
    {
        [BindProperty]
        public Tickets ticket { get; set; }
        private DB db { get; set; }

        public Create_TicketModel(DB db)
        {
            this.db = db;
            ticket = new Tickets();
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            db.AddTicket(ticket);
            return RedirectToPage("/Admin_Page/A_Ticket");
        }
    }
}
