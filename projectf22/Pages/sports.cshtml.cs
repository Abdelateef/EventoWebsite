using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using projectf22.Models;
using System.Data;

namespace projectf22.Pages
{
    public class sportsModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Event> Events { get; set; } = new List<Event>();
        public int eventID;
        public DataTable eventloc { get; set; }
        public DataTable tb { get; set; }
        private DB db { get; set; }
        public Event myevent { get; set; }
        public sportsModel(DB db)
        { this.db = db; }
        public IActionResult OnGet()
        {
            eventloc = db.EventLocationsports();
            tb = db.ReadTablesports();
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                myevent = new Event();
                myevent.EventLocationID = (int)tb.Rows[i]["LocationID"];
                myevent.EventID = (int)tb.Rows[i]["EventID"];
                myevent.EventName = (string)tb.Rows[i]["EventName"];
                myevent.EventDate = (DateTime)tb.Rows[i]["EventDate"];
                myevent.Type = (string)tb.Rows[i]["Type"];
                myevent.EventImages = (string)tb.Rows[i]["EventImages"];
                myevent.Eventdescription = (string)tb.Rows[i]["event_description"];
                Events.Add(myevent);

            }
            return Page();
            //if (HttpContext.Session.GetString("Name") is not null)
            //{
            //    return Page();
            //}
            //else
            //{
            //    return RedirectToPage("/sign-up");
            //}
        }
        public IActionResult OnPostReadJuly()
        {
            eventloc = db.EventLocationsports();
            tb = db.ReadTableSportdate(7);
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                myevent = new Event();
                myevent.EventLocationID = (int)tb.Rows[i]["LocationID"];
                myevent.EventID = (int)tb.Rows[i]["EventID"];
                myevent.EventName = (string)tb.Rows[i]["EventName"];
                myevent.EventDate = (DateTime)tb.Rows[i]["EventDate"];
                myevent.Type = (string)tb.Rows[i]["Type"];
                myevent.EventImages = (string)tb.Rows[i]["EventImages"];
                myevent.Eventdescription = (string)tb.Rows[i]["event_description"];
                Events.Add(myevent);

            }
            return Page();
        }
        public IActionResult OnPostReadAugust()
        {
            eventloc = db.EventLocationsports();
            tb = db.ReadTableSportdate(8);
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                myevent = new Event();
                myevent.EventLocationID = (int)tb.Rows[i]["LocationID"];
                myevent.EventID = (int)tb.Rows[i]["EventID"];
                myevent.EventName = (string)tb.Rows[i]["EventName"];
                myevent.EventDate = (DateTime)tb.Rows[i]["EventDate"];
                myevent.Type = (string)tb.Rows[i]["Type"];
                myevent.EventImages = (string)tb.Rows[i]["EventImages"];
                myevent.Eventdescription = (string)tb.Rows[i]["event_description"];
                Events.Add(myevent);

            }
            return Page();
        }
        public IActionResult OnPostReadSeptember()
        {
            eventloc = db.EventLocationsports();
            tb = db.ReadTableSportdate(9);
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                myevent = new Event();
                myevent.EventLocationID = (int)tb.Rows[i]["LocationID"];
                myevent.EventID = (int)tb.Rows[i]["EventID"];
                myevent.EventName = (string)tb.Rows[i]["EventName"];
                myevent.EventDate = (DateTime)tb.Rows[i]["EventDate"];
                myevent.Type = (string)tb.Rows[i]["Type"];
                myevent.EventImages = (string)tb.Rows[i]["EventImages"];
                myevent.Eventdescription = (string)tb.Rows[i]["event_description"];
                Events.Add(myevent);

            }
            return Page();
        }

        public IActionResult OnPost()
        {

            string EvID = Request.Form["index"];

            int.TryParse(EvID, out eventID);

            HttpContext.Session.SetString("EID", eventID.ToString());

            return RedirectToPage("/Ticketdetails");
        }
    }
}
