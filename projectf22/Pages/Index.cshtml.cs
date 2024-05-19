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
            dt = Data.GetSoonerEvent();

        }

        public IActionResult OnPost()
        {
            dt = Data.GetSoonerEvent();
            int eventID = (int)dt.Rows[0][0];
            HttpContext.Session.SetString("EID", eventID.ToString());

            return RedirectToPage("/Ticketdetails");
        }
    }
}
