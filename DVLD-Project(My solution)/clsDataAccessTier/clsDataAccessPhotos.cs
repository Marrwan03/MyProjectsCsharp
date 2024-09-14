using System;
using System.Data;
using System.Data.SqlClient;

namespace clsDataAccessTier
{
    public class clsDataAccessPhotos
    {
        public static bool IsExistsPhoto(int PersonID)
        {
            bool IsExists = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select ID from Photos where PersonID = @PersonID ";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
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

        public static DataTable GetAllPhotos()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select * from Photos";
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

        public static bool Find( ref int ID,int PersonID, ref string ImagePath, ref string GuidName)
        {
            bool IsExists = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select * from Photos where PersonID = @PersonID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ID = (int)reader["ID"];
                    ImagePath = (string)reader["ImagePath"];
                    GuidName = (string)reader["GuidName"];
                    IsExists = true;
                }


            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return IsExists;
        }

        public static int AddNewPhoto(int PersonID, string ImagePath, string GuidName)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string QUery = @"insert into photos
                                              ( PersonID, ImagePath, GuidName )
                                               Values
                                               ( @PersonID, @ImagePath, @GuidName );

                                               select SCOPE_IDENTITY();";

            SqlCommand command  =new SqlCommand(QUery, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@ImagePath", ImagePath);
            command.Parameters.AddWithValue("@GuidName", GuidName);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int IDPerson))
                {
                   ID = IDPerson;
                }


            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return ID;
        }

        public static bool UpdatePhoto(int PersonID, string ImagePath, string GuidName)
        {
            int RecordEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);

            string Query = @"Update photos 
                                        Set ImagePath=@ImagePath,
                                            GuidName=@GuidName
                                            where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ImagePath", ImagePath);
            command.Parameters.AddWithValue("@GuidName", GuidName);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                RecordEffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return RecordEffected>0;
        }

        public static bool DeletePhoto(int PersonID) 
        {
            int RecordEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);

            string Query = "Delete from Photos where PersonID=@PersonID";

            SqlCommand command = new SqlCommand(Query, connection);
          
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                RecordEffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return RecordEffected > 0;
        }

        public static bool DeleteAll()
        {
            int RecordEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);

            string Query = "Delete from Photos";

            SqlCommand command = new SqlCommand(Query, connection);

          

            try
            {
                connection.Open();
                RecordEffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return RecordEffected > 0;
        }


    }
}
