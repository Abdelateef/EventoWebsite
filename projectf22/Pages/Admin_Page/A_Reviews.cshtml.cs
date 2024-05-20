using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using projectf22.Models;
using System.Collections.Generic;
using System.Data;
using System.Net.Sockets;

namespace projectf22.Pages.Admin_Page
{
    public class A_ReviewsModel : PageModel
    {
        private readonly ILogger<A_ReviewsModel> _logger;

        private DB db { get; set; }

        public DataTable dt { get; set; }

        public List<Review> ReviewsList { get; set; } = new List<Review>();

        public A_ReviewsModel(ILogger<A_ReviewsModel> logger, DB db)
        {
            _logger = logger;
            this.db = db;
        }

        public void OnGet()
        {


            dt = db.ReadTable("REVIEWS");

            for (int i = 0; i < dt.Rows.Count; i++)

            {
                Review review = new Review();
                review.ReviewID = (int)dt.Rows[i]["ReviewID"] ;
                review.Rating = (int)dt.Rows[i]["Rating"];
                review.Comment = (string)dt.Rows[i]["Comment"];
                review.ReviewDate = (DateTime)dt.Rows[i]["ReviewDate"];
                review.UserID =dt.Rows[i]["UserID"] == DBNull.Value ? 0 : (int)dt.Rows[i]["UserID"];



                review.EventID = dt.Rows[i]["EventID"] == DBNull.Value ? 0 : (int)dt.Rows[i]["EventID"];
                if (review.EventID != 0)
                {
                    ReviewsList.Add(review);
                }

                
            }
        }
    }
}