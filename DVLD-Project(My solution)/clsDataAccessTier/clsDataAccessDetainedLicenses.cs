using System;
using System.Data;
using System.Data.SqlClient;

namespace clsDataAccessTier
{
    public class clsDataAccessDetainedLicenses
    {

        public static DataTable GetAllDetainLicense()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"SELECT        DetainedLicenses.DetainID as 'D.ID', DetainedLicenses.LicenseID as 'L.ID', DetainedLicenses.DetainDate as 'D.Date',DetainedLicenses.IsReleased,
                           DetainedLicenses.FineFees, DetainedLicenses.ReleaseDate, People.NationalNo as 'N.No',
                           FullName =(People.FirstName + ' '+People.SecondName+ ' '+ People.ThirdName+ ' '+ People.LastName), DetainedLicenses.ReleaseApplicationID as 'ReleaseAppID'
                           FROM            DetainedLicenses INNER JOIN
                           Licenses ON DetainedLicenses.LicenseID = Licenses.LicenseID INNER JOIN
                           Drivers ON Licenses.DriverID = Drivers.DriverID INNER JOIN
                           People ON Drivers.PersonID = People.PersonID
                           order by DetainedLicenses.DetainID desc";

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
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return dt;
        }

        public static bool IsExists(int LicenseID)
        {
            bool IsExists=false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select find=1 from DetainedLicenses where LicenseID=@LicenseID and IsReleased = 0";
            SqlCommand command =new SqlCommand(Query, connection);
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
            catch (Exception ex) { }
            finally { connection.Close(); }
            return IsExists;

        }

        public static int AddNewDetainLicense(int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID, bool IsReleased, DateTime ReleasedDate, int ReleasedByUserID, int ReleasedByAppID)
        {
            int _ID=-1;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"insert into DetainedLicenses (LicenseID,DetainDate,FineFees,CreatedByUserID,IsReleased,ReleaseDate,ReleasedByUserID,ReleaseApplicationID) 
                                               values(@LicenseID,@DetainDate,@FineFees,@CreatedByUserID,@IsReleased,@ReleasedDate,@ReleasedByUserID,@ReleasedByAppID);
                                               select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);
            if(ReleasedDate == DateTime.MinValue)
            {
                command.Parameters.AddWithValue("@ReleasedDate", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleasedDate", ReleasedDate);
            }
            if(ReleasedByUserID == -1)
            {
                command.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            }
            if(ReleasedByAppID == -1)
            {
                command.Parameters.AddWithValue("@ReleasedByAppID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleasedByAppID", ReleasedByAppID);
            }
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result != null && int.TryParse(result.ToString(), out int ID))
                {
                    _ID = ID;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return _ID;

        }

        public static bool UpdateDetainLicense(int DetainID, bool IsReleased, DateTime ReleasedDate, int ReleasedByUserID, int ReleasedByAppID)
        {
            int RecordEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"update DetainedLicenses
                             set IsReleased=@IsReleased, ReleaseDate=@ReleasedDate,
                                 ReleasedByUserID=@ReleasedByUserID, ReleaseApplicationID=@ReleasedByAppID
                                 where DetainID=@DetainID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);
            command.Parameters.AddWithValue("@ReleasedDate", ReleasedDate);
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            command.Parameters.AddWithValue("@ReleasedByAppID", ReleasedByAppID);
            command.Parameters.AddWithValue("@DetainID", DetainID);
            try
            {
                connection.Open();
                RecordEffected = command.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return RecordEffected > 0;
        }


        public static bool Find(ref int DetainID,  int LicenseID,ref DateTime DetainDate,ref decimal FineFees,ref int CreatedByUserID,ref bool IsReleased,ref DateTime ReleasedDate,ref int ReleasedByUserID,ref int ReleasedByAppID)
        {
            bool IsFound = false;
           
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select * from DetainedLicenses where LicenseID=@LicenseID and IsReleased = 0";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    DetainID = (int)reader["DetainID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = (decimal)reader["FineFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];

                    if(reader["ReleaseDate"] == DBNull.Value)
                    {
                        ReleasedDate = DateTime.MinValue;
                    }
                    else
                    {
                        ReleasedDate = (DateTime)reader["ReleaseDate"];
                    }

                    if (reader["ReleasedByUserID"] == DBNull.Value)
                    {
                        ReleasedByUserID = -1;
                    }
                    else
                    {
                        ReleasedByUserID = (int)reader["ReleasedByUserID"];
                    }

                    if(reader["ReleaseApplicationID"] == DBNull.Value)
                    {
                        ReleasedByAppID = -1;
                    }
                    else
                    {
                        ReleasedByAppID = (int)reader["ReleaseApplicationID"];
                    }
                    IsFound = true;
                }


            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return IsFound;

        }

    }
}
