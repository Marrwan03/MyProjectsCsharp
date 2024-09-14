using System;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace clsDataAccessTier
{
    public class clsDataAccessApplications
    {
      
        public static bool Find( int ApplicationID, ref int ApplicationPersonID, ref DateTime ApplicationDate,ref int ApplicationTypeID, ref byte ApplicationStatusID, ref DateTime LastStatusDate, ref decimal PaidFees, ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select * from Applications where ApplicationID = @AppID ";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@AppID", ApplicationID);
          
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ApplicationPersonID = (int)reader["ApplicantPersonID"];
                   
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationStatusID = (byte)reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsFound = true;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return IsFound;


        }
        public static bool UpdateApplication(int ApplicationID, int ApplicationStatusID, DateTime LastStatusDate)
        {
            int RecordEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            //Applications
            string Query = @"Update Applications
                             Set     LastStatusDate=@LastStatusDate,  ApplicationStatus=@ApplicationStatusID
                                  where ApplicationID=@ApplicationID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@ApplicationStatusID", ApplicationStatusID);
            try
            {
                connection.Open();
                RecordEffected = command.ExecuteNonQuery();
            }
            catch (Exception ex) {}
            finally { connection.Close(); }
            return RecordEffected > 0;

        }

        public static int AddNewApplication( int ApplicationPersonID, DateTime ApplicationDate, int ApplicationTypeID, int ApplicationStatusID, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            int AppID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"insert into Applications( ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
                                 values( @ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedByUserID);
                                        select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, connection);
       
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicationPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatusID);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if(Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    AppID = ID;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return AppID;


        }

        public static bool DeleteApplication(int ApplicantID)
        {
            int RecordEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "delete from Applications where ApplicationID=@ApplicationID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicantID);
            try
            {
                connection.Open();
                RecordEffected = command.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return RecordEffected > 0;

        }


       

    }
}
