using System;
using System.ComponentModel.Design;
using System.Data.SqlClient;
namespace clsDataAccessTier
{
    public class clsDataAccessRetakeTestAppointment
    {

        public static bool Find(ref int ID, ref decimal OriginalFees, ref decimal FeesRetake,ref decimal TotalFees, int TestAppID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select * from RetakeTestAppointment where TestAppID =@TestAppID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestAppID", TestAppID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    ID = (int)reader["ID"];
                    OriginalFees = (decimal)reader["OriginalFees"];
                    FeesRetake = (decimal)reader["FeesRetake"];
                    TotalFees = (decimal)reader["TotalFees"];
                    IsFound = true;
                }

            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return IsFound;
        }
        public static int AddNewRetakeTestAppointment( decimal OriginalFees,decimal FeesRetake, decimal TotalFees, int TestAppID)
        {
            int _ID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"insert into RetakeTestAppointment ( OriginalFees,FeesRetake, TotalFees, TestAppID)
                             values(@OriginalFees,@FeesRetake, @TotalFees, @TestAppID);
                               select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@FeesRetake", FeesRetake);
            command.Parameters.AddWithValue("@OriginalFees", OriginalFees);
            command.Parameters.AddWithValue("@TotalFees", TotalFees);
            command.Parameters.AddWithValue("@TestAppID", TestAppID);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    _ID = ID;
                }


            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return _ID;

        }

        public static bool IsExists(int TestAppID)
        {
            bool IsExists = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"select find=1 from RetakeTestAppointment 
                            where TestAppID =@TestAppID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestAppID", TestAppID);
            

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if(Result != null)
                {
                    IsExists = true;
                }
                
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return IsExists;


        }

        public static bool IsExistsBy(int LDLAppID)
        {
            bool IsExists = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"select find=1 from RetakeTestAppointment
                             where TestAppID in (select TestAppointmentID from TestAppointments
                             where LocalDrivingLicenseApplicationID = @LDLAppID)";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);


            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null)
                {
                    IsExists = true;
                }

            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return IsExists;


        }



        public static bool Delete(int LDLAppID)
        {
            int RecordEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"delete from RetakeTestAppointment
                             where TestAppID in (select TestAppointmentID from TestAppointments
                             where LocalDrivingLicenseApplicationID = @LDLAppID)";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);
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
