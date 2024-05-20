using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using projectf22.Models;
using System.Collections.Generic;
using System.Data;

namespace projectf22.Pages.Admin_Page
{
    public class A_SocialMediaLinksModel : PageModel
    {
        private readonly ILogger<A_SocialMediaLinksModel> _logger;
        private DB db { get; set; }

        public DataTable dt { get; set; }

        public SocialMediaLink socialMediaLink { get; set; }
       
        public List<SocialMediaLink> SocialMediaLinksList { get; set; } = new List<SocialMediaLink>();

        public A_SocialMediaLinksModel(ILogger<A_SocialMediaLinksModel> logger, DB db)
        {
            _logger = logger;
            this.db = db;
        }

        public void OnGet()
        {
            dt = db.ReadTable("SOCIALMEDIALINKS");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                socialMediaLink = new SocialMediaLink();
                socialMediaLink.ID = (int)dt.Rows[i]["SocialMediaID"]; 
                socialMediaLink.SocialMediaPlatforms = (string)dt.Rows[i]["SocialMediaPlatforms"];
                socialMediaLink. LinkURL = (string)dt.Rows[i]["LinkURL"];

                SocialMediaLinksList.Add(socialMediaLink);
            }
        }
    }
}
