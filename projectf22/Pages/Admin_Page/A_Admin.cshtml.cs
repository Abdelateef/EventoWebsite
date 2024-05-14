using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;
using System.Data;

namespace projectf22.Pages.Admin_Page
{
    public class A_AdminModel : PageModel
    {
        private readonly ILogger<A_AdminModel> _logger;
        private DB db { get; set; }
        public DataTable dt { get; set; }
        public Admin Admin { get; set; }

        public List<Admin> Adminslist { get; set; } = new List<Admin>();

        public A_AdminModel(ILogger<A_AdminModel> logger, DB db)
        {
            _logger = logger;
            this.db = db;
        }
        public void OnGet()
        {

            dt = db.ReadTable("ADMIN");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Admin = new Admin();
                Admin.AdminID = (int)dt.Rows[i]["AdminID"];
                Admin.AdminName = (string)dt.Rows[i]["AdminName"];
                Admin.Role = (string)dt.Rows[i]["Role"];
                Admin.AdminEmail = (string)dt.Rows[i]["AdminEmail"];
                Admin.AdminPassword = (string)dt.Rows[i]["AdminPassword"];

                Adminslist.Add(Admin);

            }

        }
    }
}
