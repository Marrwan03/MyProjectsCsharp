using System;
using System.Data;
using System.Data.SqlClient;

namespace clsDataAccessTier
{
    public class clsDataAccessLicenseClasses
    {
        public static bool Find(int LicenseClassesID,ref string ClassName,ref string ClassDescription,ref byte MinimumAllowedAge,ref byte DefaultValidityLength,ref decimal ClassFees)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select * from LicenseClasses where LicenseClassID=@LicenseClassesID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LicenseClassesID", LicenseClassesID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    //tinyint == byte
                    ClassName = (string)reader["ClassName"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    ClassFees = (decimal)reader["ClassFees"];
                    IsFound = true;
                }

            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return IsFound;

        }

        public static DataTable GetAllData()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string QUery = "select * from LicenseClasses";
            SqlCommand command = new SqlCommand(QUery, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch { }
            finally { connection.Close(); }
            return dt;

        }


    }
}
