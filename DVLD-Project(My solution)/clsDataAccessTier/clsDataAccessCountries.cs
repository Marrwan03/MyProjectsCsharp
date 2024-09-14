using System;
using System.Data;
using System.Data.SqlClient;


namespace clsDataAccessTier
{
    public class clsDataAccessCountries
    {
        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select * from Countries";
            SqlCommand command = new SqlCommand(Query, connection);
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

      

        public static string GetCountryName(int CountryID)
        {
            string CountryName = string.Empty;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select CountryName from Countries where CountryID = @CountryID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result != null)
                {
                    CountryName = result.ToString();
                }
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return CountryName;

        }

        public static int GetCountryID(string CountryName)
        {
            int CountryID = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select CountryID from Countries where CountryName = @CountryName";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int CouID))
                {
                    CountryID = CouID;
                }
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return CountryID;

        }

        public static bool Find(int ID, ref string Name)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select CountryName from Countries where CountryID = @CountryID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@CountryID", ID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    Name = result.ToString();
                    isFound = true;
                }
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return isFound;
        }

        public static bool Find(ref int ID,  string Name)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select CountryID from Countries where CountryName = @CountryName";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@CountryName", Name);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int CountryID))
                {
                   ID = CountryID;
                    isFound = true;
                }
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return isFound;
        }

    }
}
