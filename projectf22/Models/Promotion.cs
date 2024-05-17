namespace projectf22.Models
{
    public class Promotion
    {
        public int PromotionID { get; set; }
        public string PromotionType { get; set; }
        public decimal DiscountAmount { get; set; }
        public int UsageLimit { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
