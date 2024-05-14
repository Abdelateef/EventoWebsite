using System.Data;
using System.Data.SqlClient;
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
            String Q = $"select * from {Tablename}";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;

        }


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
            String Q = $"DELETE FROM ADMIN WHERE AdminID = {ID}";
            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public Admin GetAdmininfo(int id)
        {
            String Q = $"SELECT AdminName, Role, AdminEmail, AdminPassword FROM ADMIN WHERE AdminID = {id}";

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

    }

}

