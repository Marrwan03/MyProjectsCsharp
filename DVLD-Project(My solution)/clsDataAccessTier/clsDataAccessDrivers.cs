using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsDataAccessTier
{
    public class clsDataAccessDrivers
    {
        public static DataTable GetAllDrivers()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select * from MyDrivers_View";
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
            catch (Exception ex) { }
            finally { connection.Close(); }
            return dt;
        }

        public static int AddNewDriver(int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"insert into Drivers (PersonID, CreatedByUserID, CreatedDate)
                                   values(@PersonID, @CreatedByUserID, @CreatedDate);
                                    select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result != null && int.TryParse(result.ToString(), out int _id))
                {
                    ID = _id;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return ID;
        }

        public static bool Find(int DriverID,ref int PersonID,ref int CreatedByUserID,ref DateTime CreatedDate)
        {
            bool IsFound = false;
            SqlConnection connection=new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select * from Drivers where DriverID=@DriverID";
            SqlCommand command= new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    PersonID = (int)reader["PersonID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
                    IsFound = true;
                }

            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return IsFound;

        }
    }
}
