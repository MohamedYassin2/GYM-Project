using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_GYM_Project_
{
    public class clsUserDataAccess
    {
        public static bool GetUserInfoByID(ref int UserID, ref string UserName, ref string Password, 
            ref int Permission,ref decimal Salary,ref int PersonID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string Query = @"SELECT * FROM Users Where UserID=@UserID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    UserID = (int)reader["UserID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    Permission = (int)reader["Permission"];
                    Salary = (decimal)reader["Salary"];
                    PersonID = (int)reader["PersonID"];

                }
                else
                {
                    IsFound = false;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }

        public static bool GetUserInfoByUserNameAndPassword(ref int UserID, ref string UserName, ref string Password,
           ref int Permission, ref decimal Salary, ref int PersonID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string Query = @"SELECT * FROM Users Where UserName=@UserName AND Password=@Password";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);



            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    UserID = (int)reader["UserID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    Permission = (int)reader["Permission"];
                    Salary = (decimal)reader["Salary"];
                    PersonID = (int)reader["PersonID"];

                }
                else
                {
                    IsFound = false;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }


        public static int AddNewUser( string UserName,  string Password,
             int Permission,  decimal Salary,  int PersonID)
        {
            int UserID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string Query = @"INSERT INTO Users (UserName,Password,Permission,Salary,PersonID)
                             VALUES(@UserName,@Password,@Permission,@Salary,@PersonID)
                          SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@Permission", Permission);
            command.Parameters.AddWithValue("@Salary", Salary);
            command.Parameters.AddWithValue("@PersonID", PersonID);
    
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null)
                {
                    UserID = Convert.ToInt32(Result);
                }
                else
                {
                    UserID = -1;
                }

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                UserID = -1;
            }
            finally
            {
                connection.Close();
            }
            return UserID;
        }

        public static bool UpdateUser(int UserID,string UserName, string Password,
             int Permission, decimal Salary, int PersonID)
        {
            bool IsUpdated = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string Query = @"Update Users 
                             SET UserName = @UserName
                                ,Password = @Password
                                ,Permission=@Permission
                                ,Salary=@Salary
                                ,PersonID=@PersonID
                                where UserID=@UserID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@Permission", Permission);
            command.Parameters.AddWithValue("@Salary", Salary);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserID", UserID);
            try
            {
                connection.Open();
                int RowsAffected = command.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    IsUpdated = true;
                }
                else
                {
                    IsUpdated = false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                IsUpdated = false;
            }
            finally
            {
                connection.Close();
            }
            return IsUpdated;

        }

        public static bool DeleteUser(int UserID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string query = @"Delete Users 
                                where UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }

        public static bool IsUserExist(int UserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string query = "SELECT Found=1 FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static DataTable GetAllUsers()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string query = "SELECT * FROM UsersDetails order by UserID";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static DataTable GetUserByPhoneNumber(string PhoneNumber)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string query = "SELECT * FROM UsersDetails where Phone1=@PhoneNumber order by UserID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }






    }
}
