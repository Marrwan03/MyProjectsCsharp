using System;
using System.Data;
using System.Data.SqlClient;

namespace clsDataAccessTier
{
    public class clsDataAccessInternationalLicense
    {
        public static bool Find(ref int InternationalLicenseID,ref int ApplicationID, ref int DriverID, int IssuedUsingLocalLicenseID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select * from InternationalLicenses where IssuedUsingLocalLicenseID=@IssuedUsingLocalLicenseID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    InternationalLicenseID = (int)reader["InternationalLicenseID"];
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsFound = true;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return IsFound;
        }

        public static bool Find( int InternationalLicenseID, ref int ApplicationID, ref int DriverID,ref int IssuedUsingLocalLicenseID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select * from InternationalLicenses where InternationalLicenseID=@InternationalLicenseID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsFound = true;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return IsFound;

        }


        public static int AddNewInternationalLicense(  int ApplicationID,  int DriverID, int IssuedUsingLocalLicenseID,  DateTime IssueDate,  DateTime ExpirationDate,  bool IsActive,  int CreatedByUserID)
        {
            int _ID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"insert into InternationalLicenses (ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID)
                             values(@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID, @IssueDate, @ExpirationDate, @IsActive, @CreatedByUserID);
                             select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int ID))
                {
                    _ID = ID;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return _ID;
        }

        public static DataTable GetAllInternationalLicenses()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"SELECT        InternationalLicenseID as 'Int.LicenseID',
                            ApplicationID,
                            DriverID, IssuedUsingLocalLicenseID as 'L.LicenseID',
                            IssueDate, ExpirationDate, IsActive
                            FROM InternationalLicenses";
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

        public static bool IsExists(int InternationalLicenseID)
        {
            bool IsExists=false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString) ;
            string Query = "select find=1 from InternationalLicenses where InternationalLicenseID=@InternationalLicenseID";
            SqlCommand command= new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result != null)
                {
                    IsExists = true;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return IsExists;

        }

        public static bool IsExists2(int IssuedUsingLocalLicenseID)
        {
            bool IsExists = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select find=1 from InternationalLicenses where IssuedUsingLocalLicenseID=@IssuedUsingLocalLicenseID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    IsExists = true;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return IsExists;

        }

        public static bool UpdateInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            int RecordEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"update InternationalLicenses
                            set ApplicationID=@ApplicationID, DriverID=@DriverID, IssuedUsingLocalLicenseID=@IssuedUsingLocalLicenseID, 
                                IssueDate=@IssueDate, ExpirationDate=@ExpirationDate, IsActive=@IsActive, CreatedByUserID=@CreatedByUserID
                                where InternationalLicenseID=@InternationalLicenseID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
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
