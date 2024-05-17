namespace projectf22.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        public int EventID { get; set; }
        public int UserID { get; set; }
    }
}
