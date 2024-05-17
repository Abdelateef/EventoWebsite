namespace projectf22.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public DateTime EventDate { get; set; }
        public string EventImages { get; set; }
        public string EventName { get; set; }
        public int LocationID { get; set; }
        public int AdminID { get; set; }
        public string Type { get; set; }
    }
}
