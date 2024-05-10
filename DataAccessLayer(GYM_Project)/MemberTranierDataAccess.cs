using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_GYM_Project_
{
    public class clsMemberTranierDataAccess
    {
        public static bool GetRecordFromMemberTrainersByID(ref int MemberID,ref int TrainerID,ref DateTime AssginDate)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string Query = @"SELECT * FROM MembersTrainers Where MemberID=@MemberID";

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
                    TrainerID = (int)reader["TrainerID"];
                    AssginDate = (DateTime)reader["AssignDate"];
                    
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


        public static bool AddNewRecordInMemberTranierTable( int MemberID,  int TrainerID,  DateTime AssignDate)
        {
            bool IsAdded = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string Query = @"INSERT INTO MembersTrainers (MemberID,TrainerID,AssignDate)
                             VALUES(@MemberID,@TrainerID,@AssignDate)";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@MemberID", MemberID);
            command.Parameters.AddWithValue("@TrainerID", TrainerID);
            command.Parameters.AddWithValue("@AssignDate", AssignDate);


            try
            {
                connection.Open();
                int rowsaffected = command.ExecuteNonQuery();
                if (rowsaffected > 0)
                {
                    IsAdded = true;
                }
                else
                {
                    IsAdded = false;
                }

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                IsAdded = false;
            }
            finally
            {
                connection.Close();
            }
            return IsAdded;
        }


        //not implemented yet
        public static bool UpdateRecordInMemberTranierTable(int MemberID, int TrainerID, DateTime AssignDate)
        {

            //bool IsUpdated = false;
            //SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            //string Query = @"UPDATE MembersTrainers
            //                 Set MemberID = @MemberID,
            //                     TrainerID = @TrainerID
            //                     AssignDate = @AssignDate
            //                     Where           ";

            return true;

        }

        public static bool DeleteRecordInMemberTranierTable(int MemberID,int TrainerID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string query = @"Delete MembersTrainers 
                                where MemberID = @MemberID AND TrainerID = @TrainerID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@MemberID", MemberID);
            command.Parameters.AddWithValue("@TrainerID", TrainerID);

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

        public static bool IsRecordMemberTranierExist(int MemberID,int TrainerID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string query = "SELECT Found=1 FROM MembersTrainers WHERE MemberID = @MemberID AND TrainerID =@TrainerID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@MemberID", MemberID);
            command.Parameters.AddWithValue("@TrainerID", TrainerID);

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

        public static DataTable GetAllMemberTranierRecords()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string query = "SELECT * FROM MembersTrainers order by MemberID";

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


        public static bool IsMemberHasTrainers(int MemberID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string query = "SELECT Found=1 FROM MembersTrainers WHERE MemberID = @MemberID ";

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

        public static bool IsTrainerTeachMembers(int TrainerID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string query = "SELECT Found=1 FROM MembersTrainers WHERE TrainerID = @TrainerID ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TrainerID", TrainerID);

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













    }
}
