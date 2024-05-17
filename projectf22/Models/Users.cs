using Microsoft.Extensions.Configuration.UserSecrets;

namespace projectf22.Models
{
    public class Admin
    {
        public int AdminID { get; set; }
        public string AdminName { get; set; }
        public string Role { get; set; }
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }
    }

    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public int PromotionID { get; set; }
        public int BookingID { get; set; }
        public int EventID { get; set; }
        public int TicketID { get; set; }
        public int PaymentID { get; set; }

        public int AdminID { get; set; }
    }
}
