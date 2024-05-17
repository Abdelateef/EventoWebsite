using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;
using System.Data;

namespace projectf22.Pages.Admin_Page
{
    public class A_PromotionsModel : PageModel
    {
        private readonly ILogger<A_PromotionsModel> _logger;
        private DB db { get; set; }
        public DataTable dt { get; set; }
        public Promotion Promotion { get; set; }

        public List<Promotion> PromotionsList { get; set; } = new List<Promotion>();

        public A_PromotionsModel(ILogger<A_PromotionsModel> logger, DB db)
        {
            _logger = logger;
            this.db = db;
        }

        public void OnGet()
        {
            dt = db.ReadTable("PROMOTIONS");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Promotion = new Promotion();
                Promotion.PromotionID = (int)dt.Rows[i]["PromotionID"];
                Promotion.PromotionType = (string)dt.Rows[i]["PromotionType"];
                Promotion.DiscountAmount = (decimal)dt.Rows[i]["DiscountAmount"];

                // Check for DBNull before casting to int
                if (dt.Rows[i]["UsageLimit"] != DBNull.Value)
                {
                    Promotion.UsageLimit = (int)dt.Rows[i]["UsageLimit"];
                }

                Promotion.ExpirationDate = (DateTime)dt.Rows[i]["ExpirationDate"];

                PromotionsList.Add(Promotion);
            }
        }

    }
}
