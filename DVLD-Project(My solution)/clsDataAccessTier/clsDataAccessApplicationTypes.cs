using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace clsDataAccessTier
{
    public class clsDataAccessApplicationTypes
    {
        public static DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select * from ApplicationTypes";
            SqlCommand command = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);

                }


            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return dt;


        }

        public static bool Find(int ApplicationTypeID,ref  string ApplicationTypeTitle,ref decimal ApplicationFees)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select * from ApplicationTypes where ApplicationTypeID=@ApplicationTypeID ";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                    ApplicationFees = (Decimal)reader["ApplicationFees"];
                    IsFound = true;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return IsFound;
        }

        public static bool UpdateApplicationTypes(int ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationFees)
        {
            int recordEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"Update ApplicationTypes 
                           set ApplicationTypeTitle =@ApplicationTypeTitle,
                                ApplicationFees=@ApplicationFees
                                 where ApplicationTypeID=@ApplicationTypeID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                connection.Open();
                recordEffected = command.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return recordEffected > 0;
        }


        public static decimal GetMinimumFees()
        {
            decimal MinFees = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select min(ApplicationFees) from ApplicationTypes";
            SqlCommand command = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result != null && decimal.TryParse(result.ToString(), out decimal Min))
                {
                    MinFees = Min;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return MinFees;


        }

        public static decimal GetMaximumFees()
        {
            decimal MaxFees = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select Max(ApplicationFees) from ApplicationTypes";
            SqlCommand command = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && decimal.TryParse(result.ToString(), out decimal Max))
                {
                    MaxFees = Max;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return MaxFees;


        }

    }
}
