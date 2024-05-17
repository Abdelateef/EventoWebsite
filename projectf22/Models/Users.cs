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
        public string PromotionID { get; set; }
        public string BookingID { get; set; }
        public string EventID { get; set; }
        public string TicketID { get; set; }
        public string PaymentID { get; set; }
        
    }
}
