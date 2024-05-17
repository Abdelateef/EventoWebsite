using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;
using System.Data;

namespace projectf22.Pages.Admin_Page
{
    public class A_OrganizerModel : PageModel
    {
        private readonly ILogger<A_OrganizerModel> _logger;
        private DB db { get; set; }
        public DataTable dt { get; set; }
        public Organizer Organizer { get; set; }
        public List<Organizer> Organizerlist { get; set; } = new List<Organizer>();

        public A_OrganizerModel(ILogger<A_OrganizerModel> logger, DB db)
        {
            _logger = logger;
            this.db = db;
        }

        public void OnGet()
        {
            dt = db.ReadTable("ORGANIZER");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Organizer organizer = new Organizer();
                organizer.CLocation = (string)dt.Rows[i]["CLocation"];
                organizer.CName = (string)dt.Rows[i]["CName"];
                organizer.CEmail = (string)dt.Rows[i]["CEmail"];
                organizer.PName = (string)dt.Rows[i]["PName"];
                organizer.PEmail = (string)dt.Rows[i]["PEmail"];
                organizer.EventID = (int)dt.Rows[i]["EventID"];

                Organizerlist.Add(organizer);
            }
        }

    }
}
