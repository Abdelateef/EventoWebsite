using Microsoft.VisualBasic;
using System.Data;
using System.Data.SqlClient;
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
            string Q = $"UPDATE ADMIN SET AdminName = '{Adm.AdminName}', Role = '{Adm.Role}', AdminEmail = '{Adm.AdminEmail}', AdminPassword = '{Adm.AdminPassword}' WHERE AdminID = {Adm.AdminID}";

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


        public User GetUserinfo(int id)
        {
            string query = $"SELECT UserName, UserEmail, UserPassword FROM [USER] WHERE UserID = @UserID";

            DataTable dt = new DataTable();
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@UserID", id);

            dt.Load(cmd.ExecuteReader());

            if (dt.Rows.Count == 0)
            {
                con.Close();
                return null; // or throw an exception if a user with the given ID does not exist
            }

            User user = new User
            {
                UserID = id,
                UserName = dt.Rows[0]["UserName"].ToString(),
                UserEmail = dt.Rows[0]["UserEmail"].ToString(),
                UserPassword = dt.Rows[0]["UserPassword"].ToString()
            };

            con.Close();

            return user;
        }

        public void UpdateUserInfo(User user)
        {
            string query = "UPDATE [USER] SET UserName = @UserName, UserEmail = @UserEmail, UserPassword = @UserPassword WHERE UserID = @UserID";

            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@UserName", user.UserName);
            cmd.Parameters.AddWithValue("@UserEmail", user.UserEmail);
            cmd.Parameters.AddWithValue("@UserPassword", user.UserPassword);
            cmd.Parameters.AddWithValue("@UserID", user.UserID);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        /// Organizer Sub
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
            string Q = $"UPDATE ORGANIZER SET CLocation = '{Org.CLocation}', CName = '{Org.CName}', CEmail = '{Org.CEmail}', PName = '{Org.PName}' , PEmail = '{Org.PEmail} ' WHERE EventID = {Org.EventID}";

            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            cmd.ExecuteNonQuery();

            con.Close();
        }


        /// Booking Sub
        public void DeleteBooking(int ID)
        {
            string Q = $"DELETE FROM [BOOKING] WHERE BookingID= {ID}";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            cmd.ExecuteNonQuery();

            con.Close();
        }


        public Booking GetBookinginfo(int id)
        {
            string Q = $"SELECT BookingDate, NumOfTickets, TotalPrice FROM BOOKING WHERE BookingID = {id}";

            DataTable dt = new DataTable();
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            dt.Load(cmd.ExecuteReader());

            Booking booking = new Booking();

            booking.BookingID = id;
            booking.BookingDate = (DateTime)dt.Rows[0]["BookingDate"];
            booking.NumOfTickets = (int)dt.Rows[0]["NumOfTickets"];
            booking.TotalPrice = (decimal)dt.Rows[0]["TotalPrice"];

            con.Close();

            return booking;
        }

        public void UpdateBookingInfo(Booking Book)
        {
            string Q = $"UPDATE BOOKING SET BookingDate = '{Book.BookingDate}', NumOfTickets = {Book.NumOfTickets}, TotalPrice = {Book.TotalPrice} WHERE BookingID = {Book.BookingID}";

            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            cmd.ExecuteNonQuery();

            con.Close();
        }


        /// Promotion Sub
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



        /// Payment Sub
        public void DeletePayment(int ID)
        {
            string Q = $"DELETE FROM [PAYMENT] WHERE PaymentID= {ID}";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        /// Reviews Sub
        public void DeleteReviews(int ID)
        {
            string Q = $"DELETE FROM [REVIEWS] WHERE ReviewID= {ID}";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        /// Location Sub
        public void DeleteLocation(int ID)
        {
            string Q = $"DELETE FROM LOCATION WHERE LocationID = {ID}";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        /// Ticket Sub
        public void DeleteTicket(int ID)
        {
            string Q = $"DELETE FROM TICKET WHERE TicketID= {ID}";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        /// Payment Sub
        public void DeleteEvent(int ID)
        {
            string Q = $"DELETE FROM EVENT WHERE EventID= {ID}";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        /// Socialmedia Sub
        public void DeleteSocialmedia(string SocialMediaPlatforms)
        {
            string Q = $"DELETE FROM SOCIALMEDIALINKS WHERE SocialMediaPlatforms = '{SocialMediaPlatforms}'";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

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
            Tic.EventID = (int)T[4];

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
            string Q = $"INSERT INTO BOOKING( UserID, BookingDate, NumOfTickets, TotalPrice)\r\nVALUES ('{Book.UserID}','{Book.BookingDate}','{Book.NumOfTickets}','{Book.TotalPrice}');";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            cmd.ExecuteNonQuery();

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

