using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Headers;

namespace clsDataAccessTier
{
    public class clsDataAccessTestAppointments
    {
        public static DataTable GetAllDateFrom(int TestTypeID, int LDLAppID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"select TestAppointmentID, AppointmentDate, PaidFees,IsLocked from TestAppointments
                             where LocalDrivingLicenseApplicationID =@LDLAppID and TestTypeID=@TestTypeID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
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

        public static bool FindBy(ref int id, int TestTypeID,int LDLAppID,ref DateTime AppointmentDate,ref decimal paidFees,ref int userID,ref bool isLocked)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"select top 1 *from TestAppointments
                            where TestTypeID =@TestTypeID  and LocalDrivingLicenseApplicationID=@LDLAppID  and IsLocked=1
                            order by TestAppointmentID desc ";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    id = (int)reader["TestAppointmentID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    paidFees = (decimal)reader["PaidFees"];
                    userID = (int)reader["CreatedByUserID"];
                    isLocked = (bool)reader["IsLocked"];
                    IsFound = true;
                }

            }
            catch (Exception ex) { } finally {  connection.Close(); }
            return IsFound;


        }

        public static bool FindBy( int id,ref int TestTypeID,ref int LDLAppID, ref DateTime AppointmentDate, ref decimal paidFees, ref int userID, ref bool isLocked)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"select * from TestAppointments
                            where TestAppointmentID=@id";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@id", id);
           
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    TestTypeID = (int)reader["TestTypeID"];
                    LDLAppID = (int)reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    paidFees = (decimal)reader["PaidFees"];
                    userID = (int)reader["CreatedByUserID"];
                    isLocked = (bool)reader["IsLocked"];
                    IsFound = true;
                }

            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return IsFound;


        }
        public static bool IsUserHasAppoinment(int TestTypeID, int LDLAppID)
        {
            bool IsHas = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"select find =1 from TestAppointments where TestTypeID = TestTypeID and LocalDrivingLicenseApplicationID=@LDLAppID and IsLocked =0";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if(Result != null)
                {
                    IsHas = true;
                }

            }
            catch (Exception ex) { } finally { connection.Close(); }
            return IsHas;


        }

        public static int CountOfTrial(int TestTypeID, int LDLAppID)
        {
            int Counter =0;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"select count(*) from TestAppointments where TestTypeID = @TestTypeID and LocalDrivingLicenseApplicationID=@LDLAppID and IsLocked = 1";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if(Result != null && int.TryParse(Result.ToString(), out int Trials))
                {
                    Counter = Trials;
                }
            }
            catch (Exception ex) { } finally { connection.Close(); }
            return Counter;

        }

        public static int AddNewtestAppointments( int TestTypeID, int LDLAppID,  DateTime AppointmentDate,  decimal paidFees,  int userID,  bool isLocked)

        {
            int _ID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"insert into TestAppointments(TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked)
                         Values(@TestTypeID,@LocalDrivingLicenseApplicationID, @AppointmentDate, @PaidFees, @CreatedByUserID, @IsLocked);
                           select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLAppID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", paidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", userID);
            command.Parameters.AddWithValue("@IsLocked", isLocked);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if(Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    _ID = ID;
                }
            }
            catch (Exception ex) { } finally { connection.Close(); }
            return _ID;

        }

        public static bool UpdatetestAppointments(int TestAppointmentID, int TestTypeID, int LDLAppID, DateTime AppointmentDate, decimal paidFees, int userID, bool isLocked)
        {
            int Recordeffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"Update TestAppointments 
                                 Set TestTypeID=@TestTypeID,
                                    LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID,
                                    AppointmentDate=@AppointmentDate,
                                    PaidFees=@PaidFees, CreatedByUserID=@CreatedByUserID, IsLocked=@IsLocked
                                     where TestAppointmentID=@TestAppointmentID";
                        
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLAppID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", paidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", userID);
            command.Parameters.AddWithValue("@IsLocked", isLocked);

            try
            {
                connection.Open();
                Recordeffected = command.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return Recordeffected > 0;
        }

        public static bool IsSameDay(int LDLAppID, int TestTypeID, DateTime dt)
        {
            bool IsSame =  false;
            //DAY(AppointmentDate)=@Day and MONTH(AppointmentDate)=@Month and YEAR(AppointmentDate)=@Year
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"select find=1 from TestAppointments
                           where LocalDrivingLicenseApplicationID = @LDLAppID and TestTypeID != @TestTypeID
                           and DAY(AppointmentDate)=@Day and MONTH(AppointmentDate)=@Month and YEAR(AppointmentDate)=@Year";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@Day", dt.Day);
            command.Parameters.AddWithValue("@Month", dt.Month);
            command.Parameters.AddWithValue("@Year", dt.Year);
            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if(Result != null)
                {
                    IsSame = true;
                }
            }
            catch (Exception ex) { } finally { connection.Close(); }
            return IsSame;


        }

        public static bool IsExists(int LDLAppID)
        {
            bool IsExists = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select find=1 from TestAppointments where LocalDrivingLicenseApplicationID=@LDLAppID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if(Result != null)
                {
                    IsExists = true;
                }
            }
            catch (Exception ex) { } finally { connection.Close(); }
            return IsExists;


        }

        public static bool DeleteTestsFor(int LDLAppID)
        {
            int RecordEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"delete from TestAppointments
                            where LocalDrivingLicenseApplicationID = @LDLAppID";
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
