using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;
using System.Data;

namespace projectf22.Pages.Admin_Page
{
    public class A_BookingModel : PageModel
    {
        private readonly ILogger<A_BookingModel> _logger;
        private DB db { get; set; }
        public DataTable dt { get; set; }
        public Booking Booking { get; set; }

        public List<Booking> BookingsList { get; set; } = new List<Booking>();

        public A_BookingModel(ILogger<A_BookingModel> logger, DB db)
        {
            _logger = logger;
            this.db = db;
        }

        public void OnGet()
        {
            dt = db.ReadTable("BOOKING");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Booking = new Booking();
                Booking.BookingID = (int)dt.Rows[i]["BookingID"];
                Booking.UserID = (int)dt.Rows[i]["UserID"];
                Booking.BookingDate = (DateTime)dt.Rows[i]["BookingDate"];
                Booking.NumOfTickets = (int)dt.Rows[i]["NumOfTickets"];
                Booking.TotalPrice = (decimal)dt.Rows[i]["TotalPrice"];

                BookingsList.Add(Booking);
            }
        }
    }
}
