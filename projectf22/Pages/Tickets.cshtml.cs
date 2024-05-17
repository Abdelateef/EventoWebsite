using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;
using System.Data;
using System.Reflection;

namespace projectf22.Pages
{
    public class TicketsModel : PageModel
    {
        
        public DataTable dt { get; set; }
        private readonly DB Data;

        public List<Tickets> ListofTickets = new List<Tickets>();
        public TicketsModel( DB data)
        {

            Data = data;

        }


        public IActionResult OnGet()
        {
            dt = Data.GetAllTicketsInfo();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Tickets T = new Tickets();
                Data.SetTicketsInfo(T, dt.Rows[i]);
                ListofTickets.Add(T);
            }

            if (HttpContext.Session.GetString("Name") is not null)
            {
                return Page();
            }
            else
            {
                return RedirectToPage("/sign-up");
            }


        }
        public void OnPost()
        {
            //HttpContext.Session.SetString("EventId", ListofTickets[0].EventID);
        }
    }
}
