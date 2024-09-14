using System;
using System.Data.SqlClient;

namespace clsDataAccessTier
{
    public class clsDataAccessStatus
    {
        public static bool Find(ref int ID,string Name)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = " select * from Status2 where Name = @Name";
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
            catch (Exception ex) { }
            finally { connection.Close(); }
            return IsFound;

        }

        public static bool Find( int ID,ref string Name)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = " select * from Status2 where ID = @ID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                   
                    Name = (string)reader["Name"];
                    IsFound = true;
                }

            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return IsFound;

        }

    }
}
