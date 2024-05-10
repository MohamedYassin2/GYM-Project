using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_GYM_Project_
{
    public class clsSubscriptionPeriodDataAccess
    {
        public static bool GetSubscriptionPeriodInfoByID(ref int PeriodID,ref DateTime StartDate,ref DateTime EndDate,ref int Fees,ref int MemberID,ref int PaymentID,ref int SubscriptionTypeID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string Query = @"SELECT * FROM  SubscriptionPeriods Where PeriodID=@PeriodID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PeriodID", PeriodID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    PeriodID = (int)reader["PeriodID"];
                    StartDate = (DateTime)reader["StartDate"];
                    EndDate = (DateTime)reader["EndDate"];
                    Fees = (int)reader["Fees"];
                    MemberID = (int)reader["MemberID"];
                    PaymentID = (int)reader["PaymentID"];
                    SubscriptionTypeID = (int)reader["SubscriptionTypeID"];

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

        public static bool GetSubscriptionPeriodInfoByPaymentID(ref int PeriodID, ref DateTime StartDate, ref DateTime EndDate, ref int Fees, ref int MemberID, ref int PaymentID, ref int SubscriptionTypeID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string Query = @"SELECT * FROM  SubscriptionPeriods Where PaymentID=@PaymentID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PaymentID", PaymentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    PeriodID = (int)reader["PeriodID"];
                    StartDate = (DateTime)reader["StartDate"];
                    EndDate = (DateTime)reader["EndDate"];
                    Fees = (int)reader["Fees"];
                    MemberID = (int)reader["MemberID"];
                    PaymentID = (int)reader["PaymentID"];
                    SubscriptionTypeID = (int)reader["SubscriptionTypeID"];

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

        public static int AddNewSubscriptionPeriod(DateTime StartDate, DateTime EndDate,  int Fees, int MemberID,int PaymentID, int SubscriptionTypeID)
        {
            int PeriodID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string Query = @"INSERT INTO SubscriptionPeriods (StartDate,EndDate,Fees,MemberID,PaymentID,SubscriptionTypeID)
                             VALUES(@StartDate,@EndDate,@Fees,@MemberID,@PaymentID,@SubscriptionTypeID)
                          SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@StartDate", StartDate);
            command.Parameters.AddWithValue("@EndDate", EndDate);
            command.Parameters.AddWithValue("@Fees", Fees);
            command.Parameters.AddWithValue("@MemberID", MemberID);
            command.Parameters.AddWithValue("@PaymentID", PaymentID);
            command.Parameters.AddWithValue("@SubscriptionTypeID", SubscriptionTypeID);



            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null)
                {
                    PeriodID = Convert.ToInt32(Result);
                }
                else
                {
                    PeriodID = -1;
                }

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                PeriodID = -1;
            }
            finally
            {
                connection.Close();
            }
            return PeriodID;
        }

        public static bool UpdateSubscriptionPeriod(int PeriodID, DateTime StartDate, DateTime EndDate, int Fees, int MemberID, int PaymentID, int SubscriptionTypeID)
        {
            bool IsUpdated = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string Query = @"Update SubscriptionPeriods 
                             SET StartDate = @StartDate
                                ,EndDate = @EndDate
                                ,Fees=@Fees
                                ,MemberID=@MemberID
                                ,PaymentID=@PaymentID
                                ,SubscriptionTypeID=@SubscriptionTypeID
                                where PeriodID=@PeriodID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@StartDate", StartDate);
            command.Parameters.AddWithValue("@EndDate", EndDate);
            command.Parameters.AddWithValue("@Fees", Fees);
            command.Parameters.AddWithValue("@MemberID", MemberID);
            command.Parameters.AddWithValue("@PaymentID", PaymentID);
            command.Parameters.AddWithValue("@SubscriptionTypeID", SubscriptionTypeID);
            command.Parameters.AddWithValue("@PeriodID", PeriodID);


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

        public static DataTable GetAllSubscriptionPeriods()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string query = "SELECT * FROM SubscriptionDetails";

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

        public static bool DeleteSubscriptionPeriod(int PeriodID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string query = @"Delete from SubscriptionPeriods 
                                where PeriodID = @PeriodID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PeriodID", PeriodID);

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

        public static bool DeleteSubscriptionPeriodByPaymentID(int PaymentID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string query = @"Delete from SubscriptionPeriods 
                                where PaymentID = @PaymentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PaymentID", PaymentID);

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


        public static bool IsSubscriptionPeriodExist(int PeriodID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string query = "SELECT Found=1 FROM SubscriptionPeriods WHERE PeriodID = @PeriodID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PeriodID", PeriodID);

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

        public static bool IsMemberHasSubscription(int MemberID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string query = "SELECT Found=1 FROM SubscriptionPeriods WHERE MemberID = @MemberID";

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


        public static DataTable GetSubscriptionPeriodByMemberID(int MemberID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string query = "SELECT * FROM SubscriptionDetails where MemberID=@MemberID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MemberID", MemberID);
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
