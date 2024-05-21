using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using projectf22.Models;

namespace projectf22.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly DB _database;

        public ProfileModel(DB database)
        {
            _database = database;
        }

        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string Bio { get; set; }
        [BindProperty]
        public IFormFile ProfilePhoto { get; set; }
        public string ProfileImageUrl { get; set; } = "/images/default.jpg"; // Default image path
        public List<Tickets> UserTickets { get; set; }

        public IActionResult OnGet()
        {
            var userIdValue = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userIdValue) || !int.TryParse(userIdValue, out int userId))
            {
                return RedirectToPage("/Login");
            }

            LoadProfile(userId);
            UserTickets = _database.GetUserTickets(userId);  // Load user tickets
            return Page();
        }



        private void LoadProfile(int userId)
        {
            var user = _database.GetUserInfo(userId);
            if (user != null)
            {
                UserName = user.UserName;
                Bio = user.Bio; // Assuming Bio is managed by GetUserinfo
                ProfileImageUrl = user.ProfileImageUrl; // Assuming ProfileImageUrl is managed by GetUserinfo
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userIdValue = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userIdValue) || !int.TryParse(userIdValue, out int userId))
            {
                return RedirectToPage("/Login");
            }

            User currentUser = _database.GetUserInfo(userId); // Fetch current user data
            if (currentUser == null)
            {
                return NotFound(); // Handle the case where the user does not exist
            }

            // Check if a new profile photo is uploaded
            if (ProfilePhoto != null)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", ProfilePhoto.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ProfilePhoto.CopyToAsync(stream);
                }
                currentUser.ProfileImageUrl = $"/images/{ProfilePhoto.FileName}"; // Update image URL only if a new image is uploaded
            }
            else
            {
                // Do not update the image URL if no new image is uploaded
                currentUser.ProfileImageUrl = currentUser.ProfileImageUrl;
            }

            currentUser.UserName = UserName ?? currentUser.UserName; // Update the username if new data provided
            currentUser.Bio = Bio ?? currentUser.Bio; // Update the bio if new data provided

            _database.UpdateUserInfo4(currentUser); // Update user data in the database

            return RedirectToPage(); ///// Refresh or redirect to ensure the updated data is shown
        }


    }
}
