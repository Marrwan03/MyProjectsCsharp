using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccesseTier
{
    public class clsDataAccesseCountries
    {
        public static DataTable GetAllCountries()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccesseStringSetting.DataAccesseString);
            string Query = "Select * from Countries";
            SqlCommand command = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    dataTable.Load(reader);
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return dataTable;

        }


        public static bool Find(int ID, ref string Name)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccesseStringSetting.DataAccesseString);
            string Query = "Select * from Countries where ID = @ID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    
                    Name = (string)reader["Name"];
                    IsFound = true;
                }

            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return IsFound;


        }
        public static bool Find(ref int ID,  string Name)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccesseStringSetting.DataAccesseString);
            string Query = "Select * from Countries where Name = @Name";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Name", Name);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ID = (int)reader["ID"];
                    IsFound = true;
                }

            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return IsFound;


        }

    }
}
