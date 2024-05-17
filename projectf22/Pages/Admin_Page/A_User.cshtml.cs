using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;
using System.Data;

namespace projectf22.Pages.Admin_Page
{
    public class A_UserModel : PageModel
    {
        private readonly ILogger<A_UserModel> _logger;
        private DB db { get; set; }
        public DataTable dt { get; set; }
        public User User { get; set; }

        public List<User> Userlist { get; set; } = new List<User>();

        public A_UserModel(ILogger<A_UserModel> logger, DB db)
        {
            _logger = logger;
            this.db = db;
        }

        public void OnGet()
        {
            dt = db.ReadTable("[USER]");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                User = new User();
                User.UserID = (int)dt.Rows[i]["UserID"];
                User.UserName = (string)dt.Rows[i]["Username"];
                User.UserEmail = (string)dt.Rows[i]["UserEmail"];
                User.UserPassword = (string)dt.Rows[i]["UserPassword"];
                User.PromotionID = dt.Rows[i]["PromotionID"] == DBNull.Value ? 0 : (int)dt.Rows[i]["PromotionID"]; // Check for DBNull before casting
                User.BookingID = dt.Rows[i]["BookingID"] == DBNull.Value ? 0 : (int)dt.Rows[i]["BookingID"];
                User.EventID = dt.Rows[i]["EventID"] == DBNull.Value ? 0 : (int)dt.Rows[i]["EventID"];
                User.TicketID = dt.Rows[i]["TicketID"] == DBNull.Value ? 0 : (int)dt.Rows[i]["TicketID"];
                User.PaymentID = dt.Rows[i]["PaymentID"] == DBNull.Value ? 0 : (int)dt.Rows[i]["PaymentID"];
                User.AdminID = dt.Rows[i]["AdminID"] == DBNull.Value ? 0 : (int)dt.Rows[i]["AdminID"];

                Userlist.Add(User);
            }

        }
    }
}
