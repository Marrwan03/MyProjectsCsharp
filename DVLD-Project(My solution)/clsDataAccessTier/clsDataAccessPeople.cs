using Microsoft.SqlServer.Server;
using System;
using System.Data;
using System.Data.SqlClient;

namespace clsDataAccessTier
{
    public class clsDataAccessPeople
    {
        public static DataTable GetAllPeople()
        {
         DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"SELECT        People.PersonID, People.NationalNo, People.FirstName, People.SecondName,
                           People.ThirdName, People.LastName,
						   DateOfBirth = cast(DateOfBirth as date)
						   , Gendor = 
                          case when Gendor = 0 then 'Male' else 'Female' end,
                          Countries.CountryName, People.Phone, People.Email
                         FROM            People INNER JOIN
                         Countries ON People.NationalityCountryID = Countries.CountryID";
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

        public static int GetPeopleCount()
        {
            int count = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"SELECT count(*) from People";
            SqlCommand command = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result != null && int.TryParse(result.ToString(), out int Counter))
                {
                    count = Counter;
                }
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return count;
        }                                             // NationalNo
        public static bool FindPerson(int ID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
            ref byte Gendor, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString) ;
            string Query = "select * from People where PersonID=@ID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    
                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    //SecondName
                    SecondName = (string)reader["SecondName"];
                    ThirdName = (string)reader["ThirdName"];
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    if (reader["Email"] != DBNull.Value)
                    {
                        Email = (string)reader["Email"];
                    }
                    else
                    {
                        Email = string.Empty;
                    }
                   
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    if(reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = null;
                    }
                    
                    IsFound = true;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return IsFound;


        }


        public static bool FindPerson(ref int ID, string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
           ref byte Gendor, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select * from People where NationalNo=@NationalNo";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    ID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    //SecondName
                    SecondName = (string)reader["SecondName"];
                    ThirdName = (string)reader["ThirdName"];
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    if (reader["Email"] != DBNull.Value)
                    {
                        Email = (string)reader["Email"];
                    }
                    else
                    {
                        Email = string.Empty;
                    }

                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = null;
                    }

                    IsFound = true;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return IsFound;


        }


        public static bool IsNationalNoExists(string NationalNo, int PersonID)
        {
            bool IsExists = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select NationalNo from People where NationalNo = @NationalNo and PersonID!=@ID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@ID", PersonID);
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


        public static bool IsEmailExists(string Email, int PersonID)
        {
            bool IsExists = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select Email from People where Email = @Email and PersonID!=@ID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@ID", PersonID);
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

        public static bool IsPhoneExists(string Phone, int PersonID)
        {
            bool IsExists = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select Phone from People where Phone = @Phone and PersonID!=@ID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@ID", PersonID);
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



        public static int AddNewPerson( string NationalNo, string FirstName, string SecondName, string ThirdName,
            string LastName, DateTime DateOfBirth, byte Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int PersonID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"insert into People(NationalNo, FirstName, SecondName, ThirdName, LastName,DateOfBirth,Gendor,Address,
                                                Phone,Email,NationalityCountryID,ImagePath)

                                                Values
                                               (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName,@DateOfBirth,@Gendor,@Address,
                                                @Phone,@Email,@NationalityCountryID,@ImagePath);
                                                 select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            if (ImagePath == null)
            {
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }


            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if(Result != null &&  int.TryParse(Result.ToString(), out int ID))
                {
                    PersonID = ID;
                }

            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return PersonID;

        }

        public static bool UpdatePerson(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName,
            string LastName, DateTime DateOfBirth, byte Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int RecordEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"Update People
                            Set NationalNo =@NationalNo ,FirstName =@FirstName,SecondName=@SecondName,
                                ThirdName =@ThirdName,LastName=@LastName,DateOfBirth=@DateOfBirth,
                                Gendor=@Gendor,Address=@Address,Phone=@Phone,
                                Email=@Email,NationalityCountryID=@NationalityCountryID,ImagePath=@ImagePath
                              where  PersonID=@PersonID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            if (string.IsNullOrEmpty(Email))
            {
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Email", Email);
            }
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            if(string.IsNullOrEmpty(ImagePath))
            {
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
           
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

        public static bool DeletePerson(int PersonID)
        {
            int RecordEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "Delete from People where PersonID=@PersonID";
            SqlCommand command = new SqlCommand(Query, connection);
          
            command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
               RecordEffected = command.ExecuteNonQuery() ;

            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return (RecordEffected>0);
        }

        public static bool DeleteAllPeople()
        {
            int RecordEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "Delete from People";
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
            return (RecordEffected > 0);
        }


    }

   
}
