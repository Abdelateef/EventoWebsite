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
                    EventID = dt.Rows[i]["EventID"] == DBNull.Value ? 0 : (int)dt.Rows[i]["EventID"],
                    EventDate = dt.Rows[i]["EventDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[i]["EventDate"],
                    EventImages = dt.Rows[i]["EventImages"] == DBNull.Value ? "" : (string)dt.Rows[i]["EventImages"],
                    EventName = dt.Rows[i]["EventName"] == DBNull.Value ? "" : (string)dt.Rows[i]["EventName"],
                    EventLocationID = dt.Rows[i]["LocationID"] == DBNull.Value ? 0 : (int)dt.Rows[i]["LocationID"],
                    EventAdminID = dt.Rows[i]["AdminID"] == DBNull.Value ? 0 : (int)dt.Rows[i]["AdminID"],
                    Type = dt.Rows[i]["Type"] == DBNull.Value ? "" : (string)dt.Rows[i]["Type"]
                };

                EventsList.Add(_event);
            }
        }
    }
}
