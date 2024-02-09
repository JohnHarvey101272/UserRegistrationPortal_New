using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace UserRegistrationPortal
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int UserNo { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class UserDataAccessLayer
    {
        public static List<User> GetAllUsers()
        {
            List<User> listUsers = new List<User>();
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetUsers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    User user = new User();
                    user.UserId = Convert.ToInt32(rdr["UserID"]);
                    user.UserName = rdr["UserName"].ToString();
                    user.UserNo = Convert.ToInt32(rdr["UserNo"]);
                    user.CreateDate = Convert.ToDateTime(rdr["CreateDate"]);
                    //user.CreateDate = Convert.ToDateTime(rdr["CreateDate"]).ToString("MM/dd/yyyy hh:mm:ss tt");

                    listUsers.Add(user);
                }
            }

            return listUsers;
        }

        public static List<User> GetAllUsers(string sortColumn)
        {
            List<User> listUsers = new List<User>();
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string sqlQuery = "SELECT UserID, UserName, UserNo, " +
                    "FORMAT(CreateDate, 'MM/dd/yyyy hh:mm:ss tt') as CreateDate FROM tbUser";

                if (!string.IsNullOrEmpty(sortColumn))
                {
                    sqlQuery += " ORDER BY " + sortColumn;
                }

                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    User user = new User();
                    user.UserId = Convert.ToInt32(rdr["UserID"]);
                    user.UserName = rdr["UserName"].ToString();
                    user.UserNo = Convert.ToInt32(rdr["UserNo"]);
                    user.CreateDate = Convert.ToDateTime(rdr["CreateDate"]);

                    listUsers.Add(user);
                }
            }
            return listUsers;
        }

        public static void DeleteUser(int original_UserId, string original_UserName, int original_UserNo) 
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spDeleteUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@original_UserId", original_UserId);
                cmd.Parameters.AddWithValue("@original_UserName", original_UserName);
                cmd.Parameters.AddWithValue("@original_UserNo", original_UserNo);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static void UpdateUser(int original_UserId, string UserName, int UserNo, DateTime CreateDate)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spUpdateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@original_UserId", original_UserId);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@UserNo", UserNo);
                cmd.Parameters.AddWithValue("@CreateDate", CreateDate.ToString("G",
                  CultureInfo.CreateSpecificCulture("en-us")));
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static int AddUser(string UserName, int UserNo, DateTime CreateDate)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spAddUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@UserNo", UserNo);
                cmd.Parameters.AddWithValue("@CreateDate", CreateDate);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
