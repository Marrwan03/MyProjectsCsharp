using System;
using System.Data;
using System.Data.SqlClient;
namespace clsDataAccessTier
{
    public class clsDataAccessLicenses
    {
        public static DataTable GetAllLocalLicensesFor(int PersonID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"SELECT  Licenses.LicenseID as 'Lic.ID', Licenses.ApplicationID as 'App.ID', LicenseClasses.ClassName,
                             Licenses.IssueDate, Licenses.ExpirationDate, Licenses.IsActive
                             FROM  Licenses INNER JOIN LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
                            where Licenses.ApplicationID in (select ApplicationID from Applications where ApplicantPersonID=@PersonID )
                            order by Licenses.LicenseID desc";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch(Exception ex) { }
            finally { connection.Close(); }
            return dt;
        }


        public static DataTable GetAllInternationalLicensesFor(int PersonID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"SELECT        InternationalLicenseID as 'Int.License ID',
                             ApplicationID as 'Application ID',
                             IssuedUsingLocalLicenseID as 'L.License ID',
                             IssueDate, ExpirationDate, IsActive
                             FROM            InternationalLicenses
                             where IssuedUsingLocalLicenseID in (select LicenseID from Licenses
                             where DriverID in (select DriverID from Drivers
                             where PersonID = @PersonID))";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);


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


        public static int AddNewLicenses(int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, string Notes,
             decimal PaidFees, bool IsActive, int IssueReason, int CreatedByUserID)
        {
            int _ID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"insert into Licenses (ApplicationID, DriverID, LicenseClass,IssueDate,ExpirationDate,Notes,PaidFees,IsActive, IssueReason,CreatedByUserID) 
                          values (@ApplicationID, @DriverID, @LicenseClass, @IssueDate, @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID);
                           select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            if(string.IsNullOrEmpty(Notes))
            {
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Notes", Notes);
            }
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
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
            catch (Exception ex) {  }
            finally { connection.Close(); }
            return _ID;


        }


        public static bool UpdateLicenses(int LicenseID, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, string Notes,
             decimal PaidFees, bool IsActive, int IssueReason, int CreatedByUserID)
        {
            int RecordEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            //(ApplicationID, DriverID, LicenseClass,IssueDate,ExpirationDate,Notes,PaidFees,IsActive, IssueReason,CreatedByUserID) 
            string Query = @"update Licenses 
                            set ApplicationID=@ApplicationID, DriverID=@DriverID, LicenseClass=@LicenseClass, IssueDate=@IssueDate,
                            ExpirationDate=@ExpirationDate, Notes=@Notes, PaidFees=@PaidFees, IsActive=@IsActive, IssueReason=@IssueReason, CreatedByUserID=@CreatedByUserID
                            where LicenseID=@LicenseID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            if (string.IsNullOrEmpty(Notes))
            {
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Notes", Notes);
            }
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
               RecordEffected = command.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return RecordEffected > 0;


        }

        public static bool Find(ref int IDLicenses,  int ApplicationID,ref int DriverID, ref int LicenseClass, ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes,
            ref decimal PaidFees, ref bool IsActive, ref int IssueReason, ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select * from Licenses where ApplicationID=@ApplicationID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    IDLicenses = (int)reader["LicenseID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClass = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    if (reader["Notes"] == DBNull.Value)
                    {
                        Notes = string.Empty;
                    }
                    else
                    {
                        Notes = (string)reader["Notes"];
                    }
                   
                    PaidFees = (decimal)reader["PaidFees"];
                    IsActive = (bool)reader["IsActive"];
                    IssueReason = (int)reader["IssueReason"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsFound = true;

                }
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return IsFound;

        }

        public static bool FindRenew(ref int IDLicenses,ref int ApplicationID,  int DriverID, ref int LicenseClass, ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes,
           ref decimal PaidFees,  bool IsActive,  int IssueReason, ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select * from Licenses where DriverID=@DriverID and IsActive=@IsActive and IssueReason=@IssueReason";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IDLicenses = (int)reader["LicenseID"];
                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClass = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    if (reader["Notes"] == DBNull.Value)
                    {
                        Notes = string.Empty;
                    }
                    else
                    {
                        Notes = (string)reader["Notes"];
                    }
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsFound = true;

                }
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return IsFound;

        }


        public static bool IsExists(int ApplicationID)
        {
            bool IsExists = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select Find=1 from Licenses where ApplicationID=@ApplicationID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                connection.Open();
               object result = command.ExecuteScalar();
                if (result != null)
                {
                    IsExists = true;
                }
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return IsExists;
        }

        public static bool IsLicenseActive(int LicenseID, bool WithConditionLicenseClass = true)
        {
            bool IsExists = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select Find=1 from Licenses where LicenseID=@LicenseID and IsActive=1 and ExpirationDate >= GETDATE() and LicenseClass=3";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    IsExists = true;
                }
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return IsExists;
        }

        public static bool IsLicenseActive(int LicenseID)
        {
            bool IsExists = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select Find=1 from Licenses where LicenseID=@LicenseID and IsActive=1 and ExpirationDate >= GETDATE()";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
           
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    IsExists = true;
                }
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return IsExists;
        }

        public static bool IsRenewLicenseExists(int PersonID, int LicenseClass)
        {
            bool IsExists = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"SELECT Find=1
                         FROM Licenses INNER JOIN
                         Drivers ON Licenses.DriverID = Drivers.DriverID INNER JOIN
                         People ON Drivers.PersonID = People.PersonID
						 where People.PersonID = @PersonID and IssueReason=2 and LicenseClass=@LicenseClass";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    IsExists = true;
                }
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return IsExists;
        }

        public static bool IsRenewLicenseActive(int PersonID)
        {
            bool IsActive = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"SELECT Find=1
                         FROM Licenses INNER JOIN
                         Drivers ON Licenses.DriverID = Drivers.DriverID INNER JOIN
                         People ON Drivers.PersonID = People.PersonID
						 where People.PersonID = @PersonID and IssueReason=2 and IsActive=1 and ExpirationDate >= GETDATE()";


            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    IsActive = true;
                }
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return IsActive;
        }

        public static bool Find( int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClass, ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes,
    ref decimal PaidFees, ref bool IsActive, ref int IssueReason, ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select * from Licenses where LicenseID=@LicenseID ";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClass = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];

                    if (reader["Notes"] == DBNull.Value)
                    {
                        Notes = string.Empty;
                    }
                    else
                    {
                        Notes = (string)reader["Notes"];
                    }

                    PaidFees = (decimal)reader["PaidFees"];
                    IsActive = (bool)reader["IsActive"];
                    IssueReason = (int)reader["IssueReason"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsFound = true;
                }
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return IsFound;

        }


    }
}
