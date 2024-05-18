using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using projectf22.Models;
using System.Data;

namespace projectf22.Pages
{
    public class TicketdetailsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool Available { get; set; }
        [BindProperty(SupportsGet = true)]
        public decimal Price { get; set; }
        [BindProperty]
        public int quantity { get; set; }

        public Event E = new Event();
        public DataTable dt { get; set; }
        private readonly DB Data;

        public TicketdetailsModel(DB db) { Data = db; }
        public void OnGet()
        {
            if (HttpContext.Session.GetString("value") is not null)
            {
                int.TryParse(HttpContext.Session.GetString("value"), out int n);
                quantity = n;
            }
            else
            {
                quantity = 1;
            }
            dt = Data.GetEventInfo(ID);
            E.EventID = (int)dt.Rows[0][0];
            E.EventDate = (DateTime)dt.Rows[0][1];
            E.EventImages = (string)dt.Rows[0][2];
            E.EventName = (string)dt.Rows[0][3];
            E.EventLocationID = (int)dt.Rows[0][4];
            E.EventAdminID = (int)dt.Rows[0][5];

        }


        public IActionResult OnPostplus()
        {
            quantity++;
            HttpContext.Session.SetString("value", quantity.ToString());
            return RedirectToPage();

        }
        public IActionResult OnPostminus()
        {
            quantity--;
            HttpContext.Session.SetString("value", quantity.ToString());
            return RedirectToPage();

        }
    }
}
