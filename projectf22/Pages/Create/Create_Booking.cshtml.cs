using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;

namespace projectf22.Pages.Create
{
    public class Create_BookingModel : PageModel
    {
        [BindProperty]
        public Booking booking { get; set; }
        private DB db { get; set; }
        public Create_BookingModel(DB db)
        {
            this.db = db;
            booking = new Booking();
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            db.AddBooking(booking);

            return RedirectToPage("/Admin_Page/A_Booking");
        }
    }
}