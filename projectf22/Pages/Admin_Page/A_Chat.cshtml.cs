using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;
using System.Data;

namespace projectf22.Pages.Admin_Page
{
    public class A_ChatModel : PageModel
    {
        public List<Event> Events { get; set; } = new List<Event>();
        public DataTable tb { get; set; }
        private DB db { get; set; }
        public Event myevent { get; set; }
        public A_ChatModel(DB db) { this.db = db; }
        public Dictionary<string, int> MonthlyEventCounts { get; set; }

        Dictionary<int, int> eventCountsByMonth = new Dictionary<int, int>();

        public void OnGet()
        {
            tb = db.Getallmonthsevents();
            MonthlyEventCounts = GetMonthlyEventCounts(tb);
        }
        public static Dictionary<string, int> GetMonthlyEventCounts(DataTable tb)
        {
            var monthlyCounts = tb.AsEnumerable()
                .GroupBy(row => row.Field<int>("Month"))
                .ToDictionary(g => g.Key.ToString("0000-00"), g => g.Count());

            return monthlyCounts;
        }
    }
}
