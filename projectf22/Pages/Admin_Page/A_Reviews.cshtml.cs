using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;
using System.Collections.Generic;
using System.Data;

namespace projectf22.Pages.Admin_Page
{
    public class A_ReviewsModel : PageModel
    {
        private readonly DB _db;

        public List<Review> ReviewsList { get; set; } = new List<Review>();

        public A_ReviewsModel(DB db)
        {
            _db = db;
        }

        public void OnGet()
        {
            DataTable dt = _db.ReadTable("REVIEWS");

            foreach (DataRow row in dt.Rows)
            {
                Review review = new Review
                {
                    ReviewID = (int)row["ReviewID"],
                    Rating = (int)row["Rating"],
                    Comment = row["Comment"].ToString(),
                    ReviewDate = (DateTime)row["ReviewDate"],
                    EventID = (int)row["EventID"],
                    UserID = (int)row["UserID"]
                };

                ReviewsList.Add(review);
            }
        }
    }
}
