using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using projectf22.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace projectf22.Pages.Admin_Page
{
    public class A_EventsModel : PageModel
    {
        private readonly ILogger<A_EventsModel> _logger;
        private DB db { get; set; }
        public DataTable dt { get; set; }
        public List<Event> EventsList { get; set; } = new List<Event>();

        public A_EventsModel(ILogger<A_EventsModel> logger, DB db)
        {
            _logger = logger;
            this.db = db;
        }

        public void OnGet()
        {
            dt = db.ReadTable("EVENT");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Event _event = new Event
                {
                    EventID = (int)dt.Rows[i]["EventID"],
                    EventDate = (DateTime)dt.Rows[i]["EventDate"],
                    EventImages = (string)dt.Rows[i]["EventImages"],
                    EventName = (string)dt.Rows[i]["EventName"],
                    //LocationID = (int)dt.Rows[i]["LocationID"],
                    //AdminID = (int)dt.Rows[i]["AdminID"],
                    //Type = (string)dt.Rows[i]["Type"]
                };

                EventsList.Add(_event);
            }
        }
    }
}
