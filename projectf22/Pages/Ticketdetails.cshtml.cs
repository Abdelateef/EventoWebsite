using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using projectf22.Models;
using System.Data;

namespace projectf22.Pages
{
    public class TicketdetailsModel : PageModel
    {
        public int ID;

        [BindProperty]
        public decimal Total { get; set; }

        [BindProperty]
        public int Quantity { get; set; }

        public int temp { get; set; }

        public Event E = new Event();
        public DataTable dt { get; set; }
        public DataTable dt2 { get; set; }
        public Booking Book=new Booking();
        public Tickets ticket { get; set; } = new Tickets();
        private readonly DB Data;

        public TicketdetailsModel(DB db) { Data = db; }
        public void OnGet()
        {

            int.TryParse(HttpContext.Session.GetString("EID"), out ID);
            dt2 = Data.GetTicketFromEventId(ID);
            Data.SetTicketsInfo(ticket, dt2.Rows[0]);
            dt = Data.GetEventInfo(ID);
            E.EventID = (int)dt.Rows[0][0];
            E.EventDate = (DateTime)dt.Rows[0][1];
            E.EventImages = (string)dt.Rows[0][2];
            E.EventName = (string)dt.Rows[0][3];
            E.EventLocationID = (int)dt.Rows[0][4];
            E.EventAdminID = (int)dt.Rows[0][5];
            Quantity = 1;
            Total = ticket.TicketPrice * Quantity;


        }



        public void OnPostPlus()
        {
            int.TryParse(HttpContext.Session.GetString("EID"), out ID);
            dt2 = Data.GetTicketFromEventId(ID);
            Data.SetTicketsInfo(ticket, dt2.Rows[0]);
            dt = Data.GetEventInfo(ID);
            E.EventID = (int)dt.Rows[0][0];
            E.EventDate = (DateTime)dt.Rows[0][1];
            E.EventImages = (string)dt.Rows[0][2];
            E.EventName = (string)dt.Rows[0][3];
            E.EventLocationID = (int)dt.Rows[0][4];
            E.EventAdminID = (int)dt.Rows[0][5];
            Quantity = Quantity + 1;
            Total = ticket.TicketPrice * Quantity;



        }
        public void OnPostMinus()
        {
            int.TryParse(HttpContext.Session.GetString("EID"), out ID);
            dt2 = Data.GetTicketFromEventId(ID);
            Data.SetTicketsInfo(ticket, dt2.Rows[0]);
            dt = Data.GetEventInfo(ID);
            E.EventID = (int)dt.Rows[0][0];
            E.EventDate = (DateTime)dt.Rows[0][1];
            E.EventImages = (string)dt.Rows[0][2];
            E.EventName = (string)dt.Rows[0][3];
            E.EventLocationID = (int)dt.Rows[0][4];
            E.EventAdminID = (int)dt.Rows[0][5];

            if (Quantity > 0)
            {
                Quantity = Quantity - 1;

            }
            Total = ticket.TicketPrice * Quantity;

        }

        public void OnPostBook()
        {

            int.TryParse(HttpContext.Session.GetString("UsID"), out int UserID);
            Book.UserID = UserID;
            Book.BookingDate = DateTime.Now;
            Book.NumOfTickets = Quantity;
            Book.TotalPrice = Total;
            Data.AddBooking(Book);
            int m = UserID;
        }
    }
}
