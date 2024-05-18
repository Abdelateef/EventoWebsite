using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;
using System.Data;

namespace projectf22.Pages
{
    public class shows_eventsModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Event> Events { get; set; }=new List<Event>();
        public DataTable tb { get; set; }
        private DB db { get; set; }
        public Event myevent { get; set; }
        public shows_eventsModel(DB db)
        { this.db = db; }
        public IActionResult OnGet()
        {
            tb = db.ReadTable("EVENT");
            for (int i = 0;i<tb.Rows.Count;i++)
            {
                myevent=new Event();
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
    }
}
