using DataAccessLayer_GYM_Project_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_GYM_Project
{
    public class clsMembersDataAccess
    {
        public static bool GetMemberInfoByID(ref int MemberID, ref bool IsActive,ref int PersonID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string Query = @"SELECT * FROM Members Where MemberID=@MemberID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@MemberID", MemberID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    MemberID = (int)reader["MemberID"];
                    PersonID = (int)reader["PersonID"];
                    IsActive = (bool)reader["IsActive"];

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

        public static bool GetMemberInfoByPersonID(ref int MemberID, ref bool IsActive, ref int PersonID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string Query = @"SELECT * FROM Members Where PersonID=@PersonID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    MemberID = (int)reader["MemberID"];
                    PersonID = (int)reader["PersonID"];
                    IsActive = (bool)reader["IsActive"];

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



        public static int AddNewMember( bool IsActive, int PersonID)
        {
            int MemberID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string Query = @"INSERT INTO Members (IsActive,PersonID)
                             VALUES(@IsActive,@PersonID)
                          SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null)
                {
                    MemberID = Convert.ToInt32(Result);
                }
                else
                {
                    MemberID = -1;
                }

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                MemberID = -1;
            }
            finally
            {
                connection.Close();
            }
            return MemberID;
        }

        public static bool UpdateMember(int MemberID, bool IsActive, int PersonID)
        {
            bool IsUpdated = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string Query = @"Update Members 
                             SET IsActive = @IsActive
                                ,PersonID = @PersonID
                                where MemberID=@MemberID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@MemberID", MemberID);


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

        public static bool DeleteMember(int MemberID)
        {
            bool IsDeleted = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string Query = @"Delete from Members 
                                where MemberID=@MemberID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@MemberID", MemberID);

            try
            {
                connection.Open();
                int RowsAffected = command.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    IsDeleted = true;
                }
                else
                {
                    IsDeleted = false;
                }

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                IsDeleted = false;
            }
            finally
            {
                connection.Close();
            }
            return IsDeleted;

        }

        public static bool IsMemberExist(int MemberID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string query = "SELECT Found=1 FROM Members WHERE MemberID = @MemberID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@MemberID", MemberID);

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

        public static DataTable GetAllMembers()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string query = "SELECT MemberID,Name,Email,Address,DateOfBirth,Phone1,Phone2,IsActive  FROM MembersDetails order by MemberID";

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

        public static DataTable SearchByMemberID(int MemberID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string query = @"SELECT MemberID,Name,Email,Address,DateOfBirth,Phone1,Phone2,IsActive  FROM MembersDetails
                         Where MemberID = @MemberID
                        order by MemberID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("MemberID", MemberID);
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

        public static DataTable GetMemberByPhoneNumber(string PhoneNumber)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string query = @"SELECT  MemberID,Name,Email,Address,DateOfBirth,Phone1,Phone2,IsActive  FROM MembersDetails
                            where Phone1=@PhoneNumber
                                order by MemberID";

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
