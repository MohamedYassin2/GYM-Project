using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_GYM_Project_
{
    public class clsPersonDataAccess
    {
        public static bool GetPersonInfoByID( ref int PersonID, ref string Name, ref string Email, ref string Address
            , ref DateTime DateOfBirth, ref string Phone1, ref string Phone2)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string Query = @"SELECT * FROM Persons Where PersonID=@PersonID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    PersonID = (int)reader["PersonID"];
                    Name = (string)reader["Name"];
                    Email = (string)reader["Email"];
                    Address = (string)reader["Address"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Phone1 = (string)reader["Phone1"];


                    if (reader["Phone2"] == DBNull.Value)
                        Phone2 = "NULL";
                    else
                        Phone2 = (string)reader["Phone2"];



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

        public static bool GetPersonInfoByPhoneNumber(ref int PersonID, ref string Name, ref string Email, ref string Address
            , ref DateTime DateOfBirth, ref string Phone1, ref string Phone2)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string Query = @"SELECT * FROM Persons Where Phone1=@Phone1";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Phone1", Phone1);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    PersonID = (int)reader["PersonID"];
                    Name = (string)reader["Name"];
                    Email = (string)reader["Email"];
                    Address = (string)reader["Address"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Phone1 = (string)reader["Phone1"];


                    if (reader["Phone2"] == DBNull.Value)
                        Phone2 = "NULL";
                    else
                        Phone2 = (string)reader["Phone2"];



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


        public static int AddNewPerson( string Name, string Email, string Address
            , DateTime DateOfBirth, string Phone1, string Phone2)
        {
            int PersonID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string Query = @"INSERT INTO Persons (Name,Email,Address,DateOfBirth,Phone1,Phone2)
                             VALUES(@Name,@Email,@Address,@DateOfBirth,@Phone1,@Phone2)
                          SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Phone1", Phone1);



            if (Phone2 != "")
                command.Parameters.AddWithValue("@Phone2", Phone2);
            else
                command.Parameters.AddWithValue("@Phone2", DBNull.Value);


            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null)
                {
                    PersonID = Convert.ToInt32(Result);
                }
                else
                {
                    PersonID = -1;
                }

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                PersonID = -1;
            }
            finally
            {
                connection.Close();
            }
            return PersonID;
        }

        public static bool UpdatePerson(int PersonID, string Name, string Email, string Address, DateTime DateOfBirth, string Phone1, string Phone2)
        {
            bool IsUpdated = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string Query = @"Update Persons 
                             SET Name = @Name
                                ,Email = @Email
                                ,Address = @Address
                                ,DateOfBirth = @DateOfBirth
                                ,Phone1 = @Phone1
                                ,Phone2 = @Phone2
                                where PersonID=@PersonID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Phone1", Phone1);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            if (Phone2 != "")
                command.Parameters.AddWithValue("@Phone2", Phone2);
            else
                command.Parameters.AddWithValue("@Phone2", System.DBNull.Value);




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

        public static bool DeletePerson(int PersonID)
        {
            bool IsDeleted = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string Query = @"Delete from Persons 
                                where PersonID=@PersonID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

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

        public static bool IsPersonExist(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string query = "SELECT Found=1 FROM Persons WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

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

        public static bool IsPersonExistByPhoneNumber(string PhoneNumber)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string query = "SELECT Found=1 FROM Persons WHERE Phone1 = @PhoneNumber";

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


        public static DataTable GetAllPersons()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string query = "SELECT * FROM Persons order by Name";

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


        public static bool IsPersonExisByPhoneNumber(string PhoneNumber)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string query = "SELECT Found=1 FROM Persons WHERE Phone1 = @PhoneNumber";

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





    }
}
