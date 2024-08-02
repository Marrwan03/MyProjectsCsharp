using System;
using System.Data;
using System.Data.SqlClient;
namespace DataAccesseTier
{
    public class clsDataAccesseBlock
    {
        public static bool IsBlock(int BlockByPersonID, int BlockedID)
        {
            bool IsBlock = false;
            SqlConnection connection = new SqlConnection(clsDataAccesseStringSetting.DataAccesseString);
            string Query = "select * from Block where BlockByPersonID=@BlockByPersonID and BlockedID = @BlockedID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@BlockByPersonID", BlockByPersonID);
            command.Parameters.AddWithValue("@BlockedID", BlockedID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsBlock = reader.HasRows;
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return IsBlock;
        }

        public static DataTable GetAllPersonsBlocked(int ID)
        {
           DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccesseStringSetting.DataAccesseString);
            string Query = "select * from Block where BlockByPersonID=@BlockByPersonID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@BlockByPersonID", ID);
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

        public static int AddBlockPerson(int BlockByPersonID, int BlockedID, DateTime time)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccesseStringSetting.DataAccesseString);
            string Query = @"insert into Block (BlockedID, Time, BlockByPersonID)
                           values(@BlockedID, @Time, @BlockByPersonID); 
                           select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@BlockByPersonID", BlockByPersonID);
            command.Parameters.AddWithValue("@BlockedID", BlockedID);
            command.Parameters.AddWithValue("@Time", time);
            try
            {
                connection.Open();
               object result = command.ExecuteScalar();
               if(result != null && int.TryParse(result.ToString(), out int IDTable))
                {
                    ID = IDTable;
                }

            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return ID;
        }
        public static bool  DeleteBlock(int BlockByPersonID, int BlockedID)
        {
            int RecordEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccesseStringSetting.DataAccesseString);
            string Query = @"Delete from Block where BlockByPersonID=@BlockByPersonID and BlockedID=@BlockedID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@BlockByPersonID", BlockByPersonID);
            command.Parameters.AddWithValue("@BlockedID", BlockedID);
            try
            {
                connection.Open();
                RecordEffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return RecordEffected > 0;
        }


    }
}
