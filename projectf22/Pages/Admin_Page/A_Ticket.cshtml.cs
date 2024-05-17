using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using projectf22.Models;
using System.Collections.Generic;
using System.Data;
using System.Net.Sockets;

namespace projectf22.Pages.Admin_Page
{
    public class A_TicketsModel : PageModel
    {
        private readonly ILogger<A_TicketsModel> _logger;
        private DB db { get; set; }
        public DataTable dt { get; set; }
        public List<Tickets> TicketsList { get; set; } = new List<Tickets>();

        public A_TicketsModel(ILogger<A_TicketsModel> logger, DB db)
        {
            _logger = logger;
            this.db = db;
        }

        public void OnGet()
        {
            dt = db.ReadTable("TICKET");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Tickets ticket = new Tickets
                {
                    TicketID = (int)dt.Rows[i]["TicketID"],
                    TicketPrice = (decimal)dt.Rows[i]["TicketPrice"],
                    Availability = (bool)dt.Rows[i]["Availability"],
                    TicketType = (string)dt.Rows[i]["TicketType"],
                    EventID = (int)dt.Rows[i]["EventID"]
                };

                TicketsList.Add(ticket);
            }
        }
    }
}
