using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;
using System.Data;
using System.Reflection;
using System.Reflection.Metadata;

namespace projectf22.Pages
{
    public class TicketsModel : PageModel
    {

        public DataTable dt { get; set; }
        private readonly DB Data;
        [BindProperty(SupportsGet = true)]
        public int eventID { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool Av { get; set; }
        [BindProperty(SupportsGet = true)]
        public decimal Pr { get; set; }


        public List<Tickets> ListofTickets = new List<Tickets>();
        public TicketsModel(DB data)
        {

            Data = data;

        }


        public IActionResult OnGet()
        {


            //if (HttpContext.Session.GetString("Name") is not null)
            // {
            dt = Data.GetAllTicketsInfo();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Tickets T = new Tickets();
                Data.SetTicketsInfo(T, dt.Rows[i]);
                ListofTickets.Add(T);
            }
            return Page();

            // }
            // else
            /*{
                return RedirectToPage("/sign-up");
            }*/


        }
        public IActionResult OnPost()
        {
            dt = Data.GetAllTicketsInfo();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Tickets T = new Tickets();
                Data.SetTicketsInfo(T, dt.Rows[i]);
                ListofTickets.Add(T);
            }
            string index = Request.Form["index"];


            int.TryParse(index, out int selectedIndex);

            eventID = ListofTickets[selectedIndex].EventID;
            Av = ListofTickets[selectedIndex].Availability;
            Pr = ListofTickets[selectedIndex].TicketPrice;
            return RedirectToPage("/Ticketdetails", new { ID = eventID, Available = Av, Price = Pr });


        }
    }
}
