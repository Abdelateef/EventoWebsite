namespace projectf22.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int UserID { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumOfTickets { get; set; }
        public decimal TotalPrice { get; set; }
    }

}
