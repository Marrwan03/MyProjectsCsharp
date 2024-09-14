using System;
using System.Data;
using System.Data.SqlClient;

namespace clsDataAccessTier.View
{
    public class clsDataAccessMYLocalDrivingLicenseApplications_View
    {
        public static DataTable GetAllData()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select * from MYLocalDrivingLicenseApplications_View";
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

        public static bool Find(int ID,ref string ClassName, ref string NationalNo, ref string FullName, ref DateTime ApplicationDate, ref int PastedTests, ref string StatusName)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"select * from MYLocalDrivingLicenseApplications_View
                            where [L.D.LAppID] = @ID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    ClassName = (string)reader["ClassName"];
                    NationalNo = (string)reader["NationalNo"];
                    FullName = (string)reader["FullName"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    PastedTests = (int)reader["PastedTests"];
                    StatusName = (string)reader["Name"];
                    IsFound = true;

                }

            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return IsFound;


        }

    }
}
