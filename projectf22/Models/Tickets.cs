namespace projectf22.Models
{
    public class Tickets
    {
        public int TicketID { get; set; }
        public decimal TicketPrice { get; set; }
        public bool Availability { get; set; }
        public string TicketType { get; set; }
        public int EventID { get; set; }
    }
}
