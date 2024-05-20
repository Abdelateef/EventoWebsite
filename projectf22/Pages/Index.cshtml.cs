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
        public DataTable dt = new DataTable();
        public DataTable dt2 = new DataTable();
        public DataTable dt3 = new DataTable();
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
            dt2 = Data.Get3SoonerEventS();
            dt = Data.GetSoonerEvent();
            dt3 = Data.Get3SoonerTicketS();
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
            dt2 = Data.Get3SoonerEventS();
            


            int.TryParse(Request.Form["index"], out int FinalID);
            int eventID = (int)dt.Rows[FinalID][0];

            HttpContext.Session.SetString("EID", eventID.ToString());

            return RedirectToPage("/Ticketdetails");
        }
    }
}
