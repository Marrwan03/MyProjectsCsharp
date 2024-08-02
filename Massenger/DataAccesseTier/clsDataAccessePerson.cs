using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesseTier
{
    public class clsDataAccessePerson
    {
        public static DataTable GetAllPersons(int PersonID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccesseStringSetting.DataAccesseString);
            string Query = "Select ID, Firstname,lastname,Gender,Phone  from Person where ID != @PersonID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return dt;

        }
        public static int AddNewPerson(string FirstName, string LastName, string Gender, string Phone, int CountryID, DateTime DateOfBirth, string ImagePath)
        {
            int IDPerson = -1;
            SqlConnection connection = new SqlConnection(clsDataAccesseStringSetting.DataAccesseString);
            string Query = @"insert into Person(FirstName, lastname, Gender, Phone, CountryID, DateOfBirth, ImagePath)
                            Values (@FirstName, @Lastname, @Gender, @Phone, @CountryID, @DateOfBirth, @ImagePath);
                             select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@ImagePath", ImagePath);


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result != null && int.TryParse(result.ToString(), out int ID))
                 {
                    IDPerson = ID;
                }

            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return IDPerson;


        }

        public static bool Find(int ID,ref string FirstName, ref string LastName, ref string Gender, ref string Phone, ref int CountryID,ref DateTime DateOfBirth,ref string ImagePath)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccesseStringSetting.DataAccesseString);
            string Query = "Select * from Person where ID = @ID";
            
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    FirstName = (string)reader["Firstname"];
                    LastName = (string)reader["lastname"];
                    Gender = (string)reader["Gender"];
                    Phone = (string)reader["Phone"];
                    CountryID = (int)reader["CountryID"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

                }


            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return IsFound;


        }

        public static bool UpdatePerson(int ID, string FirstName, string LastName, string Gender, string Phone, int CountryID, DateTime DateOfBirth, string ImagePath)
        {
            int EffectRecord = 0;
            SqlConnection connection = new SqlConnection(clsDataAccesseStringSetting.DataAccesseString);                                                          //ImagePath
            string Query = @"Update Person 
                                SET Firstname=@FirstName, lastname=@LastName, Gender=@Gender, Phone=@Phone, CountryID=@CountryID,
                                DateOfBirth=@DateOfBirth, ImagePath=@ImagePath where ID=@ID";

            SqlCommand command = new SqlCommand(Query,connection);
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            if (ImagePath != "")
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }
            try
            {
                connection.Open();
                EffectRecord = command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return EffectRecord > 0;

        }
        public static bool IsFirstnameExists(int ID, string Firstname)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccesseStringSetting.DataAccesseString);
            string Query = "Select * from Person where Firstname= @Firstname and ID != @ID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Firstname", Firstname);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFound = reader.HasRows;
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return IsFound;
        }
        public static bool IsPhoneExists(int ID,string Phone)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccesseStringSetting.DataAccesseString);
            string Query = "Select * from Person where Phone= @Phone and ID != @ID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFound = reader.HasRows;


            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return IsFound;
        }

        public static bool IsExists(int ID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccesseStringSetting.DataAccesseString);
            string Query = "Select * from Person where ID= @ID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFound = reader.HasRows;


            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return IsFound;
        }

        public static bool DeletePerson(int ID)
        {
            int RecordEffect = 0;
            SqlConnection connection = new SqlConnection(clsDataAccesseStringSetting.DataAccesseString);
            string Query = "delete from Person where ID=@ID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                RecordEffect = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return RecordEffect > 0;
        }

        public static bool FindByPhone( string Phone, ref int ID, ref string FirstName, ref string LastName, ref string Gender, ref int CountryID, ref DateTime DateOfBirth,ref string ImagePath)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccesseStringSetting.DataAccesseString);
            string Query = "Select * from Person where Phone = @Phone";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Phone", Phone);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    ID = (int)reader["ID"];
                    FirstName = (string)reader["Firstname"];
                    LastName = (string)reader["lastname"];
                    Gender = (string)reader["Gender"];
                   
                    CountryID = (int)reader["CountryID"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                     ImagePath = (string)reader["ImagePath"];

                }


            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return IsFound;


        }

        public static int NumberOfPerson()
        {
            int Counter = 0;
            SqlConnection connection = new SqlConnection(clsDataAccesseStringSetting.DataAccesseString);
            string Query = "select count(*) from Person";
            SqlCommand command = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result != null && int.TryParse(result.ToString(), out int CounterPerson))
                {
                    Counter = CounterPerson;

                }
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return Counter;

        }

        public static int GetPersonID(string FirstName)
        {
            int ID = 0;
            SqlConnection connection = new SqlConnection(clsDataAccesseStringSetting.DataAccesseString);
            string Query = "select ID from Person where Firstname=@FirstName";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int CounterPerson))
                {
                    ID = CounterPerson;

                }
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return ID;

        }

    }
}
