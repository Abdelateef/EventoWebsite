using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;
using System.Collections.Generic;
using System.Data;

namespace projectf22.Pages.Admin_Page
{
    public class A_LocationsModel : PageModel
    {
        private readonly ILogger<A_LocationsModel> _logger;
        private DB db { get; set; }
        public DataTable dt { get; set; }
        public List<Location> LocationsList { get; set; } = new List<Location>();

        public A_LocationsModel(ILogger<A_LocationsModel> logger, DB db)
        {
            _logger = logger;
            this.db = db;
        }

        public void OnGet()
        {
            dt = db.ReadTable("LOCATION");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Location location = new Location();
                location.LocationID = (int)dt.Rows[i]["LocationID"];
                location.LocationName = (string)dt.Rows[i]["LocationName"];
                location.LocationCapacity = (int)dt.Rows[i]["LocationCapacity"];
                location.LocationFacilities = (string)dt.Rows[i]["LocationFacilities"];

                LocationsList.Add(location);
            }
        }
    }
}
