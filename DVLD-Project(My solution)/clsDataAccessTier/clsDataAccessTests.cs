using System;
using System.Data;
using System.Data.SqlClient;

namespace clsDataAccessTier
{
    public class clsDataAccessTests
    {
        public static bool Find(ref int ID, int TestAppointmentID, ref bool TestResult, ref string Notes, ref int UserID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"select * from Tests where TestAppointmentID =@TestAppointmentID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    ID = (int)reader["TestID"];
                    TestResult = (bool)reader["TestResult"];
                    if(reader["Notes"] == DBNull.Value)
                    {
                        Notes = string.Empty;
                    }
                    else
                    {

                        Notes = (string)reader["Notes"];
                    }
                   
                    UserID = (int)reader["CreatedByUserID"];
                    IsFound = true;
                }

            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return IsFound;


        }

        public static int AddNewTest(int TestAppointmentID, bool TestResult, string Notes, int UserID)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"insert into Tests (TestAppointmentID, TestResult, Notes, CreatedByUserID)
                                         VALUES(@TestAppointmentID, @TestResult,@Notes, @CreatedByUserID);
                                         select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            if(string.IsNullOrEmpty(Notes) || string.IsNullOrWhiteSpace(Notes))
            {
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Notes", Notes);
            }
          
            command.Parameters.AddWithValue("@CreatedByUserID", UserID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result != null && int.TryParse(result.ToString(), out int _ID))
                {
                    ID = _ID;
                }
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return ID;
        }

        public static bool DoesUserHasfailure(int LDLAppID, int TestTypeID)
        {
            bool IsHas = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"select Find=1 from Tests
                            where TestAppointmentID in (select TestAppointmentID from TestAppointments
                            where TestTypeID=@TestTypeID and LocalDrivingLicenseApplicationID = @LDLAppID and IsLocked=1) and TestResult=0";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result != null)
                {
                    IsHas = true;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return IsHas;

        }

        public static bool DoesUserHasfailure(int TestAppID)
        {
            bool IsHas = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"select top 1 TestResult from Tests
                           where TestAppointmentID =@TestAppID and TestResult =0
                           order by TestAppointmentID desc";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestAppID", TestAppID);
           try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    IsHas = true;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return IsHas;

        }



        public static bool DeleteTestsFor(int LDLAppID)
        {
            int RecordEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"delete from Tests
                            where TestAppointmentID in (select TestAppointmentID from TestAppointments
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
