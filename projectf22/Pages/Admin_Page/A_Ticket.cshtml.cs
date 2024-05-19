using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using projectf22.Models;
using System.Collections.Generic;
using System.Data;
using System.Net.Sockets;
using System.Runtime.ConstrainedExecution;

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
                
                Tickets ticket = new Tickets();
                ticket.TicketID = (int)dt.Rows[i]["TicketID"];
                ticket.TicketPrice = (decimal)dt.Rows[i]["TicketPrice"];
                ticket.Availability = (bool)dt.Rows[i]["Availability"];
                ticket.TicketType = (string)dt.Rows[i]["TicketType"];
                ticket.EventID = dt.Rows[i]["EventID"] == DBNull.Value ? 0 : (int)dt.Rows[i]["EventID"];
                if (ticket.EventID != 0) {
                    TicketsList.Add(ticket);
                }
            }

        }
    }
}
