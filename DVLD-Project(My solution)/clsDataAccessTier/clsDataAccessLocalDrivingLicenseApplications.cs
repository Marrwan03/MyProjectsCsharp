using System;
using System.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace clsDataAccessTier
{
    public class clsDataAccessLocalDrivingLicenseApplications
    {
      

        public static bool Find(ref int LDLAppID,  int AppID, ref int licenseClassID)
        {
            bool Isfound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select * from LocalDrivingLicenseApplications where ApplicationID = @ApplicationID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationID", AppID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    LDLAppID = (int)reader["LocalDrivingLicenseApplicationID"];
                    licenseClassID = (int)reader["LicenseClassID"];
                    Isfound = true;

                }

            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return Isfound;

        }

        public static bool Find( int LDLAppID,ref int AppID, ref int licenseClassID)
        {
            bool Isfound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select * from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID = @LDLAppID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    AppID = (int)reader["ApplicationID"];
                    licenseClassID = (int)reader["LicenseClassID"];
                    Isfound = true;

                }

            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return Isfound;

        }


        public static bool UpdateLocalDrivingLicenseApplications(int AppID,  int licenseClassID)
        {
            int RecordEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"Update LocalDrivingLicenseApplications
                                    set LicenseClassID=@LicenseClassID
                                      where ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);
            command.Parameters.AddWithValue("@ApplicationID", AppID);
            try
            {
                connection.Open();
                RecordEffected = command.ExecuteNonQuery();
            }
            catch (Exception ex) { } finally {  connection.Close(); }
            return RecordEffected != 0;

        }

        public static int AddNewLocalDrivingLicenseApplications(int AppID,  int licenseClassID)
        {
            int LDLAppID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"insert into LocalDrivingLicenseApplications (ApplicationID, LicenseClassID)
                                                     values(@ApplicationID, @LicenseClassID)
                                                    select SCOPE_IDENTITY() ";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);
            command.Parameters.AddWithValue("@ApplicationID", AppID);
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if(Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    LDLAppID = ID;
                }

            }
                catch (Exception ex) { } finally { connection.Close(); }
            return LDLAppID;


        }

        public static bool DeleteLocalDrivingLicenseApplications(int LDLAppID)
        {
            int RecordEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"delete from LocalDrivingLicenseApplications
                             where LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLAppID);
            try
            {
                connection.Open();
                RecordEffected = command.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return RecordEffected > 0;
        }

        public static int CountOfLicenseWith(int LicenseClassID, int AppID)
        {
            int Count = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"select * from LocalDrivingLicenseApplications where ApplicationID in(select ApplicationID from Applications 
                            where ApplicantPersonID = @AppID and ApplicationTypeID = 1 and ApplicationStatus in (1, 3) and LicenseClassID =@LicenseClassID )";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@AppID", AppID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if(Result !=null && int.TryParse(Result.ToString(), out int Total))
                 {
                    Count = Total;

                }
            }
            catch (Exception ex) { } finally { connection.Close(); }
            return Count;
        }
    }
}
