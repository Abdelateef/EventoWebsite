using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.Runtime.Intrinsics.Arm;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace projectf22.Models
{
    public class DB
    {
        public SqlConnection con { get; set; }

        public DB()
        {
            string conStr = "Data Source=SQL6032.site4now.net;Initial Catalog=db_aa8a69_courseprojectdb;User ID=db_aa8a69_courseprojectdb_admin;Password=cie206206";
            con = new SqlConnection(conStr);

        }

        public DataTable ReadTable(string Tablename)
        {
            DataTable dt = new DataTable();
            string Q = $"select * from {Tablename}";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;

        }

        ////////////////Admin
        ///// Admin sub page 
        public void AddAdmin(Admin Adm)
        {
            string Q = "INSERT INTO ADMIN (AdminName, Role, AdminEmail, AdminPassword) VALUES (@AdminName, @Role, @AdminEmail, @AdminPassword)";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);
            cmd.Parameters.AddWithValue("@AdminName", Adm.AdminName);
            cmd.Parameters.AddWithValue("@Role", Adm.Role);
            cmd.Parameters.AddWithValue("@AdminEmail", Adm.AdminEmail);
            cmd.Parameters.AddWithValue("@AdminPassword", Adm.AdminPassword);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void DeleteAdmin(int ID)
        {
            string Q = $"DELETE FROM ADMIN WHERE AdminID = {ID}";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public Admin GetAdmininfo(int id)
        {
            string Q = $"SELECT AdminName, Role, AdminEmail, AdminPassword FROM ADMIN WHERE AdminID = {id}";

            DataTable dt = new DataTable();
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            dt.Load(cmd.ExecuteReader());

            Admin admin = new Admin();

            admin.AdminID = id;
            admin.AdminName = (string)dt.Rows[0]["AdminName"];
            admin.Role = (string)dt.Rows[0]["Role"];
            admin.AdminEmail = (string)dt.Rows[0]["AdminEmail"];
            admin.AdminPassword = (string)dt.Rows[0]["AdminPassword"];

            con.Close();

            return admin;
        }

        public void UpdateAdminInfo(Admin Adm)
        {
            string Q = $"UPDATE ADMIN SET AdminName = '{Adm.AdminName}', Role = '{Adm.Role}', AdminEmail = '{Adm.AdminEmail}', AdminPassword = '{Adm.AdminPassword}', WHERE AdminID = {Adm.AdminID}";

            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        /// User Sub page
        public void DeleteUser(int ID)
        {
            string Q = $"DELETE FROM [USER] WHERE UserID= {ID}";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public User GetUserInfo(int id)
        {
            string query = "SELECT UserName, UserEmail, UserPassword, PromotionID, BookingID, EventID, TicketID, PaymentID, AdminID FROM [USER] WHERE UserID = @UserID";

            DataTable dt = new DataTable();
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@UserID", id);

            dt.Load(cmd.ExecuteReader());

            User user = new User();

            user.UserID = id;
            user.UserName = (string)dt.Rows[0]["UserName"];
            user.UserEmail = (string)dt.Rows[0]["UserEmail"];
            user.UserPassword = (string)dt.Rows[0]["UserPassword"];
            //user.PromotionID = (int)dt.Rows[0]["PromotionID"];
            //user.BookingID = (int)dt.Rows[0]["BookingID"];
            //user.EventID = (int)dt.Rows[0]["EventID"];
            //user.TicketID = (int)dt.Rows[0]["TicketID"];
            //user.PaymentID = (int)dt.Rows[0]["PaymentID"];
            //user.AdminID = (int)dt.Rows[0]["AdminID"];

            user.PromotionID = dt.Rows[0]["PromotionID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PromotionID"]; // Check for DBNull before casting
            user.BookingID = dt.Rows[0]["BookingID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["BookingID"];
            user.EventID = dt.Rows[0]["EventID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["EventID"];
            user.TicketID = dt.Rows[0]["TicketID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["TicketID"];
            user.PaymentID = dt.Rows[0]["PaymentID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PaymentID"];
            user.AdminID = dt.Rows[0]["AdminID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["AdminID"];


            con.Close();

            return user;
        }

        public void UpdateUserInfo(User user)
        {
            string query = "UPDATE [USER] SET UserName = @UserName, UserEmail = @UserEmail, UserPassword = @UserPassword, PromotionID = @PromotionID, BookingID = @BookingID, EventID = @EventID, TicketID = @TicketID, PaymentID = @PaymentID, AdminID = @AdminID WHERE UserID = @UserID";

            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@UserName", user.UserName);
            cmd.Parameters.AddWithValue("@UserEmail", user.UserEmail);
            cmd.Parameters.AddWithValue("@UserPassword", user.UserPassword);
            cmd.Parameters.AddWithValue("@UserID", user.UserID);

            cmd.Parameters.AddWithValue("@PromotionID", user.PromotionID == 0 ? (object)DBNull.Value : user.PromotionID);
            cmd.Parameters.AddWithValue("@BookingID", user.BookingID == 0 ? (object)DBNull.Value : user.BookingID);
            cmd.Parameters.AddWithValue("@EventID", user.EventID == 0 ? (object)DBNull.Value : user.EventID);
            cmd.Parameters.AddWithValue("@TicketID", user.TicketID == 0 ? (object)DBNull.Value : user.TicketID);
            cmd.Parameters.AddWithValue("@PaymentID", user.PaymentID == 0 ? (object)DBNull.Value : user.PaymentID);
            cmd.Parameters.AddWithValue("@AdminID", user.AdminID == 0 ? (object)DBNull.Value : user.AdminID);

            cmd.ExecuteNonQuery();

            con.Close();
        }



        /// Organizer Sub

        public void AddOrganizer(Organizer organizer)
        {
            string query = "INSERT INTO Organizer (CLocation, CName, CEmail, PName, PEmail, EventID) VALUES (@CLocation, @CName, @CEmail, @PName, @PEmail, @EventID)";
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@CLocation", organizer.CLocation);
            cmd.Parameters.AddWithValue("@CName", organizer.CName);
            cmd.Parameters.AddWithValue("@CEmail", organizer.CEmail);
            cmd.Parameters.AddWithValue("@PName", organizer.PName);
            cmd.Parameters.AddWithValue("@PEmail", organizer.PEmail);
            cmd.Parameters.AddWithValue("@EventID", organizer.EventID);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteOrganizer(int ID)
        {
            string Q = $"DELETE FROM [ORGANIZER] WHERE EventID = {ID}";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public Organizer GetOrganizerinfo(int id)
        {
            string Q = $"SELECT CLocation, CName, CEmail, PName, PEmail FROM ORGANIZER WHERE EventID = {id}";

            DataTable dt = new DataTable();
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            dt.Load(cmd.ExecuteReader());

            Organizer organizer = new Organizer();

            organizer.EventID = id;
            organizer.CLocation = (string)dt.Rows[0]["CLocation"];
            organizer.CName = (string)dt.Rows[0]["CName"];
            organizer.CEmail = (string)dt.Rows[0]["CEmail"];
            organizer.PName = (string)dt.Rows[0]["PName"];
            organizer.PEmail = (string)dt.Rows[0]["PEmail"];

            con.Close();

            return organizer;
        }

        public void UpdateOranizerInfo(Organizer Org)
        {
            string Q = $"UPDATE ORGANIZER SET CLocation ='EventID={Org.EventID}' '{Org.CLocation}', CName = '{Org.CName}', CEmail = '{Org.CEmail}', PName = '{Org.PName}' , PEmail = '{Org.PEmail} ' WHERE EventID = {Org.EventID}";

            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            cmd.ExecuteNonQuery();

            con.Close();
        }


        /// Booking Sub

        //public void AddBooking(Booking booking)
        //{
        //    string Q = "INSERT INTO BOOKING (UserID, BookingDate, NumOfTickets, TotalPrice) VALUES (@UserID, @BookingDate, @NumOfTickets, @TotalPrice)";
        //    con.Open();

        //    SqlCommand cmd = new SqlCommand(Q, con);
        //    cmd.Parameters.AddWithValue("@UserID", booking.UserID);
        //    cmd.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
        //    cmd.Parameters.AddWithValue("@NumOfTickets", booking.NumOfTickets);
        //    cmd.Parameters.AddWithValue("@TotalPrice", booking.TotalPrice);

        //    cmd.ExecuteNonQuery();

        //    con.Close();
        //}

        public void DeleteBooking(int ID)
        {
            string Q = $"DELETE FROM [BOOKING] WHERE BookingID= {ID}";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            cmd.ExecuteNonQuery();

            con.Close();
        }


        //public Booking GetBookinginfo(int id)
        //{
        //    string Q = $"SELECT BookingDate, NumOfTickets, TotalPrice FROM BOOKING WHERE BookingID = {id}";

        //    DataTable dt = new DataTable();
        //    con.Open();

        //    SqlCommand cmd = new SqlCommand(Q, con);

        //    dt.Load(cmd.ExecuteReader());

        //    Booking booking = new Booking();

        //    booking.BookingID = id;
        //    booking.BookingDate = (DateTime)dt.Rows[0]["BookingDate"];
        //    booking.NumOfTickets = (int)dt.Rows[0]["NumOfTickets"];
        //    booking.TotalPrice = (decimal)dt.Rows[0]["TotalPrice"];

        //    con.Close();

        //    return booking;
        //}

        //public void UpdateBookingInfo(Booking Book)
        //{
        //    string Q = $"UPDATE BOOKING SET BookingDate = '{Book.BookingDate}', NumOfTickets = {Book.NumOfTickets}, TotalPrice = {Book.TotalPrice} WHERE BookingID = {Book.BookingID}";

        //    con.Open();

        //    SqlCommand cmd = new SqlCommand(Q, con);

        //    cmd.ExecuteNonQuery();

        //    con.Close();
        //}


        // In your DB class
        public Booking GetBookingInfo(int bookingId)
        {
            string query = "SELECT UserID, BookingDate, NumOfTickets, TotalPrice FROM BOOKING WHERE BookingID = @BookingID";

            DataTable dt = new DataTable();
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@BookingID", bookingId);

            dt.Load(cmd.ExecuteReader());

            Booking booking = new Booking();

            booking.BookingID = bookingId;
            booking.UserID = (int)dt.Rows[0]["UserID"];
            booking.BookingDate = (DateTime)dt.Rows[0]["BookingDate"];
            booking.NumOfTickets = (int)dt.Rows[0]["NumOfTickets"];
            booking.TotalPrice = (decimal)dt.Rows[0]["TotalPrice"];

            con.Close();

            return booking;
        }

        public void UpdateBookingInfo(Booking booking)
        {
            string query = "UPDATE BOOKING SET UserID = @UserID, BookingDate = @BookingDate, NumOfTickets = @NumOfTickets, TotalPrice = @TotalPrice WHERE BookingID = @BookingID";

            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@UserID", booking.UserID);
            cmd.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
            cmd.Parameters.AddWithValue("@NumOfTickets", booking.NumOfTickets);
            cmd.Parameters.AddWithValue("@TotalPrice", booking.TotalPrice);
            cmd.Parameters.AddWithValue("@BookingID", booking.BookingID);

            cmd.ExecuteNonQuery();

            con.Close();
        }



        /// Promotion Sub

        public void AddPromotion(Promotion promotion)
        {
            string query = "INSERT INTO Promotions (PromotionType, DiscountAmount, UsageLimit, ExpirationDate) VALUES (@PromotionType, @DiscountAmount, @UsageLimit, @ExpirationDate)";
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@PromotionType", promotion.PromotionType);
            cmd.Parameters.AddWithValue("@DiscountAmount", promotion.DiscountAmount);
            cmd.Parameters.AddWithValue("@UsageLimit", promotion.UsageLimit);
            cmd.Parameters.AddWithValue("@ExpirationDate", promotion.ExpirationDate);

            cmd.ExecuteNonQuery();
            con.Close();
        }


        public void DeletePromotion(int ID)
        {
            string Q = $"DELETE FROM [PROMOTIONS] WHERE PromotionID= {ID}";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            cmd.ExecuteNonQuery();

            con.Close();
        }
        public Promotion GetPromotioninfo(int id)
        {
            string Q = $"SELECT PromotionType, DiscountAmount, UsageLimit,ExpirationDate FROM PROMOTIONS WHERE PromotionID = {id}";

            DataTable dt = new DataTable();
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            dt.Load(cmd.ExecuteReader());

            Promotion promotion = new Promotion();

            promotion.PromotionID = id;
            promotion.PromotionType = (string)dt.Rows[0]["PromotionType"];
            promotion.DiscountAmount = (decimal)dt.Rows[0]["DiscountAmount"];
            promotion.UsageLimit = (int)dt.Rows[0]["UsageLimit"];
            promotion.ExpirationDate = (DateTime)dt.Rows[0]["ExpirationDate"];

            con.Close();

            return promotion;
        }

        public void UpdatePromotionInfo(Promotion prom)
        {
            string Q = $"UPDATE PROMOTIONS SET PromotionType = '{prom.PromotionType}', DiscountAmount = {prom.DiscountAmount}, UsageLimit = {prom.UsageLimit} , ExpirationDate = '{prom.ExpirationDate}' WHERE PromotionID = {prom.PromotionID}";

            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            cmd.ExecuteNonQuery();

            con.Close();
        }


        public decimal GetDiscountAmount(string code)
        {
            string Q = $"SELECT DiscountAmount FROM PROMOTIONS WHERE PromotionType='{code}' AND DiscountAmount IN (SELECT DiscountAmount FROM PROMOTIONS)";

            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            decimal dt=(decimal)cmd.ExecuteScalar();


            con.Close();

            return dt;
        }

        public int GetProID(string code)
        {
            string Q = $"SELECT PromotionID FROM PROMOTIONS WHERE PromotionType='{code}' ";

            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            int dt = (int)cmd.ExecuteScalar();


            con.Close();

            return dt;
        }


        /// Payment Sub

        public void AddPayment(Payment payment)
        {
            string query = "INSERT INTO PAYMENT (PaymentDate, PaymentAmount, PaymentMethod, EventID) VALUES (@PaymentDate, @PaymentAmount, @PaymentMethod, @EventID)";
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
            cmd.Parameters.AddWithValue("@PaymentAmount", payment.PaymentAmount);
            cmd.Parameters.AddWithValue("@PaymentMethod", payment.PaymentMethod);
            cmd.Parameters.AddWithValue("@EventID", payment.EventID);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeletePayment(int ID)
        {
            string Q = $"DELETE FROM [PAYMENT] WHERE PaymentID= {ID}";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public Payment GetPaymentinfo(int id)
        {
            string Q = $"SELECT PaymentDate, PaymentAmount, PaymentMethod FROM PAYMENT WHERE PaymentID = {id}";

            DataTable dt = new DataTable();
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            dt.Load(cmd.ExecuteReader());

            Payment payment = new Payment();

            payment.PaymentID = id;
            payment.PaymentDate = (DateTime)dt.Rows[0]["PaymentDate"];
            payment.PaymentAmount = (decimal)dt.Rows[0]["PaymentAmount"];
            payment.PaymentMethod = (string)dt.Rows[0]["PaymentMethod"];

            con.Close();

            return payment;
        }

        public void UpdatePaymentInfo(Payment pay)
        {
            string Q = $"UPDATE PAYMENT SET PaymentDate = '{pay.PaymentDate}', PaymentAmount = {pay.PaymentAmount}, PaymentMethod = '{pay.PaymentMethod}' WHERE PaymentID = {pay.PaymentID}";

            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        /// Reviews Sub
        public void AddReview(Review review)
        {
            string query = "INSERT INTO Reviews (Rating, Comment, ReviewDate, EventID, UserID) VALUES (@Rating, @Comment, @ReviewDate, @EventID, @UserID)";
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Rating", review.Rating);
            cmd.Parameters.AddWithValue("@Comment", review.Comment);
            cmd.Parameters.AddWithValue("@ReviewDate", review.ReviewDate);
            cmd.Parameters.AddWithValue("@EventID", review.EventID);
            cmd.Parameters.AddWithValue("@UserID", review.UserID);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteReviews(int ID)
        {
            string Q = $"DELETE FROM [REVIEWS] WHERE ReviewID= {ID}";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            cmd.ExecuteNonQuery();

            con.Close();
        }


        public Review GetReviewinfo(int id)
        {
            string Q = $"SELECT * FROM REVIEWS WHERE ReviewID = {id}";

            DataTable dt = new DataTable();
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            dt.Load(cmd.ExecuteReader());

            Review review = new Review();

            review.ReviewID = id;
            review.Rating = (int)dt.Rows[0]["Rating"];
            review.Comment = (string)dt.Rows[0]["Comment"];
            review.ReviewDate = (DateTime)dt.Rows[0]["ReviewDate"];
            review.EventID = (int)(dt.Rows[0]["EventID"]);
            review.UserID = (int)(dt.Rows[0]["UserID"]);

            con.Close();

            return review;
        }



        public void UpdateReviewInfo(Review review)
        {
            string query = "UPDATE Review SET Rating = @Rating, Comment = @Comment, ReviewDate = @ReviewDate, EventID = @EventID, UserID = @UserID WHERE ReviewID = @ReviewID";

            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ReviewID", review.ReviewID);
            cmd.Parameters.AddWithValue("@Rating", review.Rating);
            cmd.Parameters.AddWithValue("@Comment", review.Comment);
            cmd.Parameters.AddWithValue("@ReviewDate", review.ReviewDate);
            cmd.Parameters.AddWithValue("@EventID", review.EventID);
            cmd.Parameters.AddWithValue("@UserID", review.UserID);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        /// Location Sub

        public void AddLocation(Location location)
        {
            string query = "INSERT INTO Location (LocationName, LocationCapacity, LocationFacilities) VALUES (@LocationName, @LocationCapacity, @LocationFacilities)";
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@LocationName", location.LocationName);
            cmd.Parameters.AddWithValue("@LocationCapacity", location.LocationCapacity);
            cmd.Parameters.AddWithValue("@LocationFacilities", location.LocationFacilities);

            cmd.ExecuteNonQuery();
            con.Close();
        }


        public void DeleteLocation(int ID)
        {
            string Q = $"DELETE FROM LOCATION WHERE LocationID = {ID}";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            cmd.ExecuteNonQuery();

            con.Close();
        }
        public Location GetLocationinfo(int id)
        {
            string Q = $"SELECT LocationName, LocationCapacity, LocationFacilities FROM LOCATION WHERE LocationID = {id}";

            DataTable dt = new DataTable();
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            dt.Load(cmd.ExecuteReader());

            Location location = new Location();

            location.LocationID = id;
            location.LocationName = (string)dt.Rows[0]["LocationName"];
            location.LocationCapacity = (int)dt.Rows[0]["LocationCapacity"];
            location.LocationFacilities = (string)dt.Rows[0]["LocationFacilities"];

            con.Close();

            return location;
        }

        public void UpdateLocationInfo(Location loc)
        {
            string Q = $"UPDATE LOCATION SET LocationName = '{loc.LocationName}', LocationCapacity = '{loc.LocationCapacity}', LocationFacilities = '{loc.LocationFacilities}' WHERE LocationID = {loc.LocationID}";

            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            cmd.ExecuteNonQuery();

            con.Close();
        }


        /// Ticket Sub

        public void AddTicket(Tickets ticket)
        {
            string query = "INSERT INTO Ticket (TicketPrice, Availability, TicketType, EventID) VALUES (@TicketPrice, @Availability, @TicketType, @EventID)";
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@TicketPrice", ticket.TicketPrice);
            cmd.Parameters.AddWithValue("@Availability", ticket.Availability);
            cmd.Parameters.AddWithValue("@TicketType", ticket.TicketType);
            cmd.Parameters.AddWithValue("@EventID", ticket.EventID);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteTicket(int ID)
        {
            string Q = $"DELETE FROM TICKET WHERE TicketID= {ID}";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public DataTable Get3SoonerTicketS()
        {
            string Q = $"SELECT TicketPrice\r\nFROM TICKET\r\nWHERE EventID IN (\r\n    SELECT TOP 3 EventID\r\n    FROM EVENT\r\n    ORDER BY EventDate DESC\r\n)";

            DataTable dt = new DataTable();
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            dt.Load(cmd.ExecuteReader());


            con.Close();

            return dt;
        }
        public Tickets GetTicketinfo(int id)
        {
            string Q = $"SELECT * FROM TICKET WHERE TicketID = {id}";

            DataTable dt = new DataTable();
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            dt.Load(cmd.ExecuteReader());

            Tickets tickets = new Tickets();

            tickets.TicketID = id;

            tickets.TicketPrice = (decimal)dt.Rows[0]["TicketPrice"];
            tickets.Availability = (bool)dt.Rows[0]["Availability"];
            tickets.TicketType = (string)dt.Rows[0]["TicketType"];
            tickets.EventID = (int)(dt.Rows[0]["EventID"]);

            con.Close();

            return tickets;
        }


        public void UpdateTicketinfo(Tickets ticket)
        {
            string query = "UPDATE TICKET SET TicketPrice = @TicketPrice, Availability = @Availability, TicketType = @TicketType, EventID = @EventID WHERE TicketID = @TicketID";

            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@TicketID", ticket.TicketID);
            cmd.Parameters.AddWithValue("@TicketPrice", ticket.TicketPrice);
            cmd.Parameters.AddWithValue("@Availability", ticket.Availability);
            cmd.Parameters.AddWithValue("@TicketType", ticket.TicketType);
            cmd.Parameters.AddWithValue("@EventID", ticket.EventID);

            cmd.ExecuteNonQuery();

            con.Close();
        }


        public DataTable SortTicketPricesAsc()
        {
            DataTable dt = new DataTable();
            string Q = $"SELECT TicketPrice FROM TICKET ORDER BY TicketPrice ASC;";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;

        }

        public DataTable Getticketimages()
        {
            DataTable dt = new DataTable();
            string Q = $"select EventImages from EVENT inner join TICKET on EVENT.EventID=TICKET.EventID";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;

        }
        public DataTable EventLocation()
        {
            DataTable dt = new DataTable();
            string Q = $"select LocationName from EVENT inner join LOCATION on EVENT.LocationID=LOCATION.LocationID where Type='Entertainment'";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;

        }
        public DataTable EventLocationsports()
        {
            DataTable dt = new DataTable();
            string Q = $"select LocationName from EVENT inner join LOCATION on EVENT.LocationID=LOCATION.LocationID where Type='Sports'";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;

        }

        /// Event Sub

        public void AddEvent(Event ev)
        {
            string query = "INSERT INTO EVENT (EventName, EventDate, EventImages, LocationID, AdminID, Type,event_description) VALUES (@EventName, @EventDate, @EventImages, @LocationID, @AdminID, @Type,@event_description)";
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@EventName", ev.EventName);
            cmd.Parameters.AddWithValue("@EventDate", ev.EventDate);
            cmd.Parameters.AddWithValue("@EventImages", ev.EventImages);
            cmd.Parameters.AddWithValue("@LocationID", ev.EventLocationID);
            cmd.Parameters.AddWithValue("@AdminID", ev.EventAdminID);
            cmd.Parameters.AddWithValue("@Type", ev.Type);
            cmd.Parameters.AddWithValue("@event_description", ev.Eventdescription);
            cmd.ExecuteNonQuery();
            con.Close();
        }

       




        public void DeleteEvent(int ID)
        {
            string Q = $"DELETE FROM EVENT WHERE EventID= {ID}";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            cmd.ExecuteNonQuery();

            con.Close();
        }
        public Event GetEventtinfo(int id)
        {
            string Q = $"SELECT * FROM EVENT WHERE EventID = {id}";

            DataTable dt = new DataTable();
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            dt.Load(cmd.ExecuteReader());

            Event eevent = new Event();

            eevent.EventID = id;
            eevent.EventDate = (DateTime)dt.Rows[0]["EventDate"];
            eevent.EventImages = (string)dt.Rows[0]["EventImages"];
            eevent.EventLocationID = (int)(dt.Rows[0]["LocationID"]);
            eevent.EventAdminID = (int)(dt.Rows[0]["AdminID"]);
            eevent.EventName = (string)dt.Rows[0]["EventName"];
            eevent.Type = (string)dt.Rows[0]["Type"];
            eevent.Eventdescription = (string)dt.Rows[0]["event_description"];


            con.Close();

            return eevent;
        }

        public DataTable GetSoonerEvent()
        {
            string Q = $"SELECT* FROM EVENT WHERE EventDate=(SELECT MAX(EventDate) from EVENT)";

            DataTable dt = new DataTable();
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            dt.Load(cmd.ExecuteReader());


            con.Close();

            return dt;
        }

        public DataTable Get3SoonerEventS()
        {
            string Q = $"SELECT *\r\nFROM EVENT\r\nWHERE EventDate IN (\r\n    SELECT TOP 3 EventDate\r\n    FROM EVENT\r\n    ORDER BY EventDate DESC\r\n)";

            DataTable dt = new DataTable();
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            dt.Load(cmd.ExecuteReader());


            con.Close();

            return dt;
        }

        public void UpdateEventinfo(Event evt)
        {
            string query = "UPDATE EVENT SET EventDate = @EventDate, EventImages = @EventImages, LocationID = @LocationID, AdminID = @AdminID, EventName = @EventName, Type = @Type, event_description = @event_description WHERE EventID = @EventID";

            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@EventID", evt.EventID);
            cmd.Parameters.AddWithValue("@EventDate", evt.EventDate);
            cmd.Parameters.AddWithValue("@EventImages", evt.EventImages);
            cmd.Parameters.AddWithValue("@LocationID", evt.EventLocationID);
            cmd.Parameters.AddWithValue("@AdminID", evt.EventAdminID);
            cmd.Parameters.AddWithValue("@EventName", evt.EventName);
            cmd.Parameters.AddWithValue("@Type", evt.Type);
            cmd.Parameters.AddWithValue("@event_description", evt.Eventdescription);

            cmd.ExecuteNonQuery();

            con.Close();
        }


        /// Socialmedia Sub
        public void AddSocialMediaLink(SocialMediaLink socialMediaLink)
        {
            string query = "INSERT INTO SOCIALMEDIALINKS (SocialMediaPlatforms, LinkURL) VALUES (@SocialMediaPlatforms, @LinkURL)";
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@SocialMediaPlatforms", socialMediaLink.SocialMediaPlatforms);
            cmd.Parameters.AddWithValue("@LinkURL", socialMediaLink.LinkURL);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteSocialMediaLink(int id)
        {
            string Q = $"DELETE FROM SOCIALMEDIALINKS WHERE SocialMediaID = {id}";
           
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public SocialMediaLink GetSocialMediaLinkInfo(int linkId)
        {
            string query = $"SELECT * FROM SOCIALMEDIALINKS WHERE SocialMediaID = {linkId}";

            DataTable dt = new DataTable();
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            dt.Load(cmd.ExecuteReader());

            SocialMediaLink link = new SocialMediaLink();

            link.ID = linkId;
            link.SocialMediaPlatforms = dt.Rows[0]["SocialMediaPlatforms"].ToString();
            link.LinkURL = dt.Rows[0]["LinkURL"].ToString();

            con.Close();

            return link;
        }


        public void UpdateSocialMediaLink(SocialMediaLink link)
        {
            string query = "UPDATE SOCIALMEDIALINKS SET SocialMediaPlatforms = @SocialMediaPlatforms, LinkURL = @LinkURL WHERE SocialMediaID = @ID";

            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", link.ID);
            cmd.Parameters.AddWithValue("@SocialMediaPlatforms", link.SocialMediaPlatforms);
            cmd.Parameters.AddWithValue("@LinkURL", link.LinkURL);

            cmd.ExecuteNonQuery();

            con.Close();
        }


        ///////////////User

        public void AddUser(User us)
        {
            string Q = $"INSERT INTO [USER] (Username, UserEmail,UserPassword)\r\nVALUES('{us.UserName}','{us.UserEmail}','{us.UserPassword}')";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public int GetID(int ID)
        {
            string Q = $"select UserID from [USER] WHERE UserID='{ID}'";

            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            int dt = (int)cmd.ExecuteScalar();


            con.Close();
            return dt;
        }

        public int GetIDUsingInfo(string name, string email, string pass)
        {
            string Q = $"select UserID from [USER] WHERE Username='{name}' AND UserEmail='{email}' AND UserPassword='{pass}'";

            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            int dt = (int)cmd.ExecuteScalar();


            con.Close();
            return dt;
        }


        public void UPdateUserBookingID(int ID, int BID)
        {
            string Q = $"UPDATE [USER]\r\nSET BookingID = '{BID}' \r\nWHERE UserID = '{ID}';";

            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            cmd.ExecuteScalar();


            con.Close();
        }

        public void UPdateUserInfo2(int ID, int TickID, int PayID)
        {
            string Q = $"UPDATE [USER]\r\nSET  TicketID ='{TickID}', PaymentID='{PayID}'\r\nWHERE UserID = '{ID}';";

            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            cmd.ExecuteScalar();


            con.Close();
        }

        public void UPdateUserInfo3(int ID, int ProID)
        {
            string Q = $"UPDATE [USER]\r\nSET  PromotionID= '{ProID}'\r\nWHERE UserID = '{ID}';";

            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            cmd.ExecuteScalar();


            con.Close();
        }
        public string GetPassUsingID(int ID)
        {
            string Q = $"select UserPassword From [USER] WHERE UserID='{ID}'";

            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            string dt = (string)cmd.ExecuteScalar();


            con.Close();
            return dt;
        }

        public string GetNameUsingID(int ID)
        {
            string Q = $"select Username From [USER] WHERE UserID='{ID}'";

            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            string dt = (string)cmd.ExecuteScalar();


            con.Close();
            return dt;
        }

        public DataTable GetAllTicketsInfo()
        {
            string Q = $"SELECT * FROM TICKET";

            DataTable dt = new DataTable();
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            dt.Load(cmd.ExecuteReader());


            con.Close();

            return dt;
        }

        public void SetTicketsInfo(Tickets Tic, DataRow T)
        {

            Tic.TicketID = (int)T[0];
            Tic.TicketPrice = (decimal)T[1];
            Tic.Availability = (bool)T[2];
            Tic.TicketType = (string)T[3];
            if (T[4] == null)
            {
                Tic.EventID = 0;
            }
            else { Tic.EventID = (int)T[4]; }

        }

        public DataTable GetEventInfo(int ID)
        {

            string Q = $"SELECT * FROM EVENT WHERE EventID='{ID}'";

            DataTable dt = new DataTable();
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            dt.Load(cmd.ExecuteReader());


            con.Close();

            return dt;

        }

        public DataTable GetTicketFromEventId(int ID)
        {

            string Q = $"SELECT * FROM TICKET WHERE EventID='{ID}'";

            DataTable dt = new DataTable();
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            dt.Load(cmd.ExecuteReader());


            con.Close();

            return dt;

        }

        //////Events
        public DataTable ReadTablesports()
        {
            DataTable dt = new DataTable();
            string Q = $"SELECT * from EVENT where Type='Sports'";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;

        }
        public DataTable ReadTablemusic()
        {
            DataTable dt = new DataTable();
            string Q = $"SELECT * from EVENT where Type='Entertainment'";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;

        }

        public DataTable ReadTableMay(int x)
        {
            DataTable dt = new DataTable();
            string Q = $"SELECT * FROM EVENT WHERE MONTH(eventdate) = {x} and Type='Entertainment';";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;

        }

        public DataTable ReadTableSportdate(int x)
        {
            DataTable dt = new DataTable();
            string Q = $"SELECT * FROM EVENT WHERE MONTH(eventdate) = {x} and Type='Sports';";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;

        }

        //////Booking
        public void AddBooking(Booking Book)

        {

            string query = "INSERT INTO BOOKING (UserID, BookingDate, NumOfTickets, TotalPrice) VALUES (@UserID, @BookingDate, @NumOfTickets, @TotalPrice);";

            using (SqlConnection con = new SqlConnection("Data Source=SQL6032.site4now.net;Initial Catalog=db_aa8a69_courseprojectdb;User ID=db_aa8a69_courseprojectdb_admin;Password=cie206206"))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", Book.UserID);
                    cmd.Parameters.AddWithValue("@BookingDate", Book.BookingDate);
                    cmd.Parameters.AddWithValue("@NumOfTickets", Book.NumOfTickets);
                    cmd.Parameters.AddWithValue("@TotalPrice", Book.TotalPrice);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            con.Close();
        }
        public int GetBookingID(Booking Book)
        {
            string Q = $"select BookingID from BOOKING WHERE UserID='{Book.UserID}' AND BookingDate='{Book.BookingDate}' AND NumOfTickets='{Book.NumOfTickets}' AND TotalPrice='{Book.TotalPrice}';";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            int BID = cmd.ExecuteNonQuery();


            con.Close();
            return BID;
        }
    }




}

