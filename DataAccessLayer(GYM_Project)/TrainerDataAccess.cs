using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_GYM_Project_
{
    public class clsTrainerDataAccess
    {
        public static bool GetTrainerInfoByID(ref int TrainerID , ref string Qualification, ref decimal Salary,ref int PersonID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string Query = @"SELECT * FROM Trainers Where TrainerID=@TrainerID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TrainerID", TrainerID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    TrainerID = (int)reader["TrainerID"];
                    Salary = (decimal)reader["Salary"];
                    PersonID = (int)reader["PersonID"];

                    if (reader["Qualification"] == DBNull.Value)
                        Qualification = "NULL";
                    else
                        Qualification = (string)reader["Qualification"];

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


        public static int AddNewTrainer(string Qualification, decimal Salary, int PersonID)
        {
            int TrainerID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string Query = @"INSERT INTO Trainers (Qualification,Salary,PersonID)
                             VALUES(@Qualification,@Salary,@PersonID)
                          SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Salary", Salary);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            if (Qualification != "")
                command.Parameters.AddWithValue("@Qualification", Qualification);
            else
                command.Parameters.AddWithValue("@Qualification", DBNull.Value);





            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null)
                {
                    TrainerID = Convert.ToInt32(Result);
                }
                else
                {
                    TrainerID = -1;
                }

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                TrainerID = -1;
            }
            finally
            {
                connection.Close();
            }
            return TrainerID;
        }


        public static bool UpdateTrainer(int TrainerID, string Qualification, decimal Salary, int PersonID)
        {
            bool IsUpdated = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string Query = @"Update Trainers 
                             SET Qualification = @Qualification
                                ,Salary = @Salary
                                ,PersonID=@PersonID
                                where TrainerID=@TrainerID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@Salary", Salary);
            command.Parameters.AddWithValue("@TrainerID", TrainerID);


            if (Qualification != "")
                command.Parameters.AddWithValue("@Qualification", Qualification);
            else
                command.Parameters.AddWithValue("@Qualification", DBNull.Value);


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

        public static bool DeleteTrainer(int TrainerID)
        {
            bool IsDeleted = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string Query = @"Delete from Trainers 
                                where TrainerID=@TrainerID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TrainerID", TrainerID);

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
                Console.WriteLine(ex.Message);
                IsDeleted = false;
            }
            finally
            {
                connection.Close();
            }
            return IsDeleted;

        }

        public static bool IsTrainerExist(int TrainerID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string query = "SELECT Found=1 FROM Trainers WHERE TrainerID = @TrainerID";

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

        public static bool IsTrainerExistByPhoneNumber(string PhoneNumber)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string query = "SELECT Found=1 FROM TrainersDetails WHERE Phone1 = @PhoneNumber";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);

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

        public static DataTable GetAllTraniers()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string query = "SELECT * FROM TrainersDetails order by TrainerID";

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

        public static DataTable GetTranierByPhoneNumber(string PhoneNumber)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string query = "SELECT * FROM TrainersDetails where Phone1=@PhoneNumber order by TrainerID";

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
