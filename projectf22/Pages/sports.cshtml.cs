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
        public DataTable tb { get; set; }
        private DB db { get; set; }
        public Event myevent { get; set; }
        public sportsModel(DB db)
        { this.db = db; }
        public IActionResult OnGet()
        {
            tb = db.ReadTablesports();
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                myevent = new Event();
                myevent.EventLocationID = (int)tb.Rows[i]["LocationID"];
                myevent.EventID = (int)tb.Rows[i]["EventID"];
                myevent.EventName = (string)tb.Rows[i]["EventName"];
                myevent.EventDate = (DateTime)tb.Rows[i]["EventDate"];
                myevent.Type = (string)tb.Rows[i]["Type"];
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
            tb = db.ReadTableSportdate(7);
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                myevent = new Event();
                myevent.EventLocationID = (int)tb.Rows[i]["LocationID"];
                myevent.EventID = (int)tb.Rows[i]["EventID"];
                myevent.EventName = (string)tb.Rows[i]["EventName"];
                myevent.EventDate = (DateTime)tb.Rows[i]["EventDate"];
                myevent.Type = (string)tb.Rows[i]["Type"];
                Events.Add(myevent);

            }
            return Page();
        }
        public IActionResult OnPostReadAugust()
        {
            tb = db.ReadTableSportdate(8);
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                myevent = new Event();
                myevent.EventLocationID = (int)tb.Rows[i]["LocationID"];
                myevent.EventID = (int)tb.Rows[i]["EventID"];
                myevent.EventName = (string)tb.Rows[i]["EventName"];
                myevent.EventDate = (DateTime)tb.Rows[i]["EventDate"];
                myevent.Type = (string)tb.Rows[i]["Type"];
                Events.Add(myevent);

            }
            return Page();
        }
        public IActionResult OnPostReadSeptember()
        {
            tb = db.ReadTableSportdate(9);
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                myevent = new Event();
                myevent.EventLocationID = (int)tb.Rows[i]["LocationID"];
                myevent.EventID = (int)tb.Rows[i]["EventID"];
                myevent.EventName = (string)tb.Rows[i]["EventName"];
                myevent.EventDate = (DateTime)tb.Rows[i]["EventDate"];
                myevent.Type = (string)tb.Rows[i]["Type"];
                Events.Add(myevent);

            }
            return Page();
        }

        public IActionResult OnPost()
        {
            tb = db.ReadTablesports();
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                myevent = new Event();
                myevent.EventLocationID = (int)tb.Rows[i]["LocationID"];
                myevent.EventID = (int)tb.Rows[i]["EventID"];
                myevent.EventName = (string)tb.Rows[i]["EventName"];
                myevent.EventDate = (DateTime)tb.Rows[i]["EventDate"];
                myevent.Type = (string)tb.Rows[i]["Type"];
                Events.Add(myevent);

            }
            string index = Request.Form["index"];

            int.TryParse(index, out int selectedIndex);

            eventID = Events[selectedIndex].EventID;
            HttpContext.Session.SetString("EID", eventID.ToString());

            return RedirectToPage("/Ticketdetails");
        }
    }
}
