using System;
using System.Data;
using System.Data.SqlClient;

namespace clsDataAccessTier
{
    public class clsDataAccessUsers
    {
        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"SELECT       
                           Users.UserID, FullName = People.FirstName+' '+ People.SecondName +' '+ People.ThirdName +' '+ People.LastName,
                           Users.UserName, Users.IsActive
                           FROM  Users INNER JOIN People ON Users.PersonID = People.PersonID";
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
        public static bool Find(ref int personID,ref int userID, string username, string password,ref bool isActive)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "Select * from Users where UserName=@Username and Password=@Password";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    userID = (int)reader["UserID"];
                    personID = (int)reader["PersonID"];
                    
                    isActive = (bool)reader["IsActive"];
                    IsFound = true;
                }

            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return IsFound;
        }


        public static bool Find(ref int personID,  int userID,ref string username, ref string password, ref bool isActive)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "Select * from Users where UserID=@UserID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserID", userID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    personID = (int)reader["PersonID"];
                    username = (string)reader["UserName"];
                    password = (string)reader["Password"];
                    isActive = (bool)reader["IsActive"];
                    IsFound = true;
                }

            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return IsFound;
        }

        public static bool Find( int personID,ref int userID, ref string username, ref string password, ref bool isActive)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "Select * from Users where PersonID=@PersonID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", personID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    userID = (int)reader["UserID"];
                    username = (string)reader["UserName"];
                    password = (string)reader["Password"];
                    isActive = (bool)reader["IsActive"];
                    IsFound = true;
                }

            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return IsFound;
        }

        public static int AddNewUser(int PersonID, string UserName, string Password, bool IsActive)
        {
            int UserID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"Insert into Users (PersonID, UserName, Password, IsActive)
                                         Values(@PersonID, @UserName, @Password, @IsActive);
                                               select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int ID))
                {
                    UserID = ID;
                }

            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return UserID;


        }

        public static bool IsExists(string username, string password)
        {
            bool IsExists = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "Select * from Users where UserName=@Username and Password=@Password";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result != null)
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

        public static bool IsExists(int PersonID)
        {
            bool IsExists = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "Select * from Users where PersonID=@PersonID";
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

        public static bool DeleteUser(int UserID)
        {
            int RecordEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "delete from Users where UserID=@UserID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
           
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

        public static bool UpdateUser(int UserID, int personID, string username, string password, bool isActive)
        {
            int RecordEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"Update Users set PersonID = @PersonID,
                                               UserName=@Username,
                                               Password=@Password,
                                               IsActive=@IsActive
                                               where UserID = @UserID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", personID);
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);
            command.Parameters.AddWithValue("@IsActive", isActive);
            command.Parameters.AddWithValue("@UserID", UserID);
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
