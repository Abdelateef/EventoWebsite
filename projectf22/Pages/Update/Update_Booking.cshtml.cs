using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;

namespace projectf22.Pages.Update
{
    public class Update_BookingModel : PageModel
    {
        [BindProperty]
        public int id { get; set; }
        private DB db { get; set; }
        [BindProperty]
        public Booking Book { get; set; }

        public Update_BookingModel(DB dp)
        {
            this.db = dp;

        }

        public void OnGet(int id)
        {
            this.id = id;
            Book = new Booking();
            Book = db.GetBookingInfo(id);
        }

        public IActionResult OnPost()
        {
            Book.BookingID = id;
            db.UpdateBookingInfo(Book);
            return RedirectToPage("/Admin_Page/A_Booking");
        }
    }
}
