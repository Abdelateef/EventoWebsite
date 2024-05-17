using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;
using System.Data;

namespace projectf22.Pages
{
    public class TicketdetailsModel : PageModel
    {
        public int ID { get; set; }
        public Event E { get; set; }
        public DataTable dt { get; set; }
        private readonly DB Data;

        public TicketdetailsModel(DB db) { Data = db; }
        public void OnGet()
        {
            //ID = HttpContext.Session.GetString("EventId");
/*            dt=Data.GetEventInfo(ID);
            E.EventID = (int)dt.Rows[0][0];
            E.EventDate = (DateOnly)dt.Rows[0][1];
            E.EventImages = (string)dt.Rows[0][2];
            E.EventName = (string)dt.Rows[0][3];
            E.EventLocation = (string)dt.Rows[0][4];
            E.EventAdminID = (int)dt.Rows[0][5];*/

        }
    }
}
