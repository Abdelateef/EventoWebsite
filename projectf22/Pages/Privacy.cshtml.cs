﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;
using System.Data;

namespace projectf22.Pages
{
    public class PrivacyModel : PageModel
    {
        public DataTable tb { get; set; }
        public DataTable eventloc { get; set; }
        public DataTable myprice { get; set; }
        public Tickets Tiepri { get; set; }
        public int eventID;
        private DB db { get; set; }
        public Event myevent { get; set; }
        public List<Event> Events { get; set; } = new List<Event>();
        public List<Tickets> alltickets { get; set; } = new List<Tickets>();
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger, DB db)
        {
            _logger = logger;
            this.db = db;
        }

        public void OnGet()
        {
            eventloc = db.EventLocation();
            tb = db.ReadTable("EVENT");
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                myevent = new Event();
                myevent.EventLocationID = tb.Rows[i]["LocationID"] == DBNull.Value ? 0 : (int)tb.Rows[i]["LocationID"];
                myevent.EventID = (int)tb.Rows[i]["EventID"];
                myevent.EventName = (string)tb.Rows[i]["EventName"];
                myevent.EventDate = (DateTime)tb.Rows[i]["EventDate"];
                myevent.Type = (string)tb.Rows[i]["Type"];
                myevent.EventImages = (string)tb.Rows[i]["EventImages"];
                myevent.Eventdescription = (string)tb.Rows[i]["event_description"];
                Events.Add(myevent);

            }
            myprice = db.SortTicketPricesAsc();
        
            

        }

        public IActionResult OnPost()
        {
            tb = db.ReadTable("EVENT");
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                myevent = new Event();
                myevent.EventLocationID = tb.Rows[i]["LocationID"] == DBNull.Value ? 0 : (int)tb.Rows[i]["LocationID"];
                myevent.EventID = (int)tb.Rows[i]["EventID"];
                myevent.EventName = (string)tb.Rows[i]["EventName"];
                myevent.EventDate = (DateTime)tb.Rows[i]["EventDate"];
                myevent.Type = (string)tb.Rows[i]["Type"];
                myevent.EventImages = (string)tb.Rows[i]["EventImages"];
                myevent.Eventdescription = (string)tb.Rows[i]["event_description"];
                Events.Add(myevent);

            }
            HttpContext.Session.SetString("EID", Events[1].EventID.ToString());
            return RedirectToPage("/Ticketdetails");
        }

        public IActionResult OnPostNext3()
        {
            tb = db.ReadTable("EVENT");
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                myevent = new Event();
                myevent.EventLocationID = tb.Rows[i]["LocationID"] == DBNull.Value ? 0 : (int)tb.Rows[i]["LocationID"];
                myevent.EventID = (int)tb.Rows[i]["EventID"];
                myevent.EventName = (string)tb.Rows[i]["EventName"];
                myevent.EventDate = (DateTime)tb.Rows[i]["EventDate"];
                myevent.Type = (string)tb.Rows[i]["Type"];
                myevent.EventImages = (string)tb.Rows[i]["EventImages"];
                myevent.Eventdescription = (string)tb.Rows[i]["event_description"];
                Events.Add(myevent);

            }
            string index = Request.Form["index"];


            int.TryParse(index, out int selectedIndex);

            int eventID = Events[selectedIndex].EventID;
            HttpContext.Session.SetString("EID", eventID.ToString());

            return RedirectToPage("/Ticketdetails");
        }
    }

}
