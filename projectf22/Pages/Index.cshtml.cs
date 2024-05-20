using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using projectf22.Models;
using System.Data;

namespace projectf22.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public DataTable tb { get; set; }
        public DataTable dt = new DataTable();
        public DataTable dt2 = new DataTable();
        public DataTable dt3 = new DataTable();
        public Event myevent { get; set; }
        public List<Event> Events { get; set; } = new List<Event>();
        private readonly DB Data;
        [BindProperty] 
        public string text1 { get; set; }
        public IndexModel(ILogger<IndexModel> logger, DB db)
        {
            _logger = logger;
            Data = db;
        }

        public void OnGet()
        {
            tb = Data.ReadTablemusic();
            dt2 = Data.Get3SoonerEventS();
            dt = Data.GetSoonerEvent();
            dt3 = Data.Get3SoonerTicketS();
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                myevent = new Event();

                myevent.EventImages = (string)tb.Rows[i]["EventImages"];

                Events.Add(myevent);

            }
        }

        public IActionResult OnPost()
        {
            dt = Data.GetSoonerEvent();
            int eventID = (int)dt.Rows[0][0];

            HttpContext.Session.SetString("EID", eventID.ToString());

            return RedirectToPage("/Ticketdetails");
        }

        public IActionResult OnPostUpcoming()
        {
            int.TryParse(Request.Form["index"], out int FinalID);
            HttpContext.Session.SetString("EID", FinalID.ToString());

            return RedirectToPage("/Ticketdetails");
        }
    }
}
