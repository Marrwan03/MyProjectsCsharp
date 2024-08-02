using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;

namespace DataAccesseTier
{
    public class clsDataAccesseMessages
    {
        //public static int FindSender(string Message, DateTime Timer, int ReceiverID)
        //{
        //    int SenderID = -1;
        //    SqlConnection connection = new SqlConnection(clsDataAccesseStringSetting.DataAccesseString);
        //    string Query = "Select SenderID from Messages where Message=@Message and Timer=@Timer and ReceiverID=@ReceiverID";
        //    SqlCommand command = new SqlCommand(Query, connection);
        //    command.Parameters.AddWithValue("@Message", Message);
        //    command.Parameters.AddWithValue("@Timer", Timer);
        //    command.Parameters.AddWithValue("@ReceiverID", ReceiverID);
          

        //    try
        //    {
        //        connection.Open();
        //        object result = command.ExecuteScalar();
        //        if (result != null && int.TryParse(result.ToString(), out int ID))
        //        {
        //            SenderID = ID;
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally { connection.Close(); }
        //    return SenderID;


        //}

        public static DataTable FindMessage(string Firstname)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccesseStringSetting.DataAccesseString);
            string Query = @"SELECT        Messages.ID, Messages.SenderID, Messages.Message, Messages.Timer, Person.Firstname as ReceiverName
                         FROM            Messages INNER JOIN
                         Person ON Messages.ReceiverID = Person.ID 
						 where Person.Firstname = @Firstname";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Firstname", Firstname);
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


        public static DataTable FindMessage(int ID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccesseStringSetting.DataAccesseString);
            string Query = @"SELECT        Messages.ID, Messages.SenderID, Messages.Message, Messages.Timer, Person.Firstname as ReceiverName
                         FROM            Messages INNER JOIN
                         Person ON Messages.ReceiverID = Person.ID 
						 where Messages.SenderID = @ID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
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

        public static bool SendMessage(int SenderID, string Message, DateTime Timer,int ReceiverID)
        {
            int RecordEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccesseStringSetting.DataAccesseString);
            //PersonID
            string Query = "insert into Messages (SenderID, Message,Timer, ReceiverID) values(@SenderID,@Message,@Timer, @ReceiverID)";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@SenderID", SenderID);
            command.Parameters.AddWithValue("@Message", Message);
            command.Parameters.AddWithValue("@Timer", Timer);
            command.Parameters.AddWithValue("@ReceiverID", ReceiverID);
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

        public static int NumberOfMessage(int ReceiverID)
        {
            int CounterMessage = 0;
            SqlConnection connection = new SqlConnection(clsDataAccesseStringSetting.DataAccesseString);

            string Query = "select count(*) from Messages where ReceiverID = @ReceiverID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ReceiverID", ReceiverID);
           
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if(result != null && int.TryParse(result.ToString(), out int Counter))
                {
                    CounterMessage = Counter;
                }


            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return CounterMessage;
        }

        public static int NumberOfYourMessage(int SenderID)
        {
            int CounterMessage = 0;
            SqlConnection connection = new SqlConnection(clsDataAccesseStringSetting.DataAccesseString);

            string Query = "select count(*) from Messages where SenderID = @SenderID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@SenderID", SenderID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int Counter))
                {
                    CounterMessage = Counter;
                }


            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return CounterMessage;
        }

        public static bool DeleteMessage(string Message, DateTime Timer, int ReceiverID)
        {
            int RecordEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccesseStringSetting.DataAccesseString);
            //PersonID
            string Query = "delete from Messages where Message = @Message and Timer = @Timer and ReceiverID = @ReceiverID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Message", Message);
            command.Parameters.AddWithValue("@Timer", Timer);
            command.Parameters.AddWithValue("@ReceiverID", ReceiverID);

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

        public static int GetReceiverID(string FirstName)
        {
            int PersonID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccesseStringSetting.DataAccesseString);
            string Query = @"SELECT  Person.ID 
                FROM            Messages INNER JOIN Person ON Messages.ReceiverID = Person.ID
                where Person.Firstname = @FirstName";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@FirstName", FirstName);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if(Result != null && int.TryParse(Result.ToString(), out int ID))
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

        public static bool UpdateMessage(int SenderID,string Message, DateTime Timer, int ReceiverID, string NewMessage, DateTime NewTimer)
        {
            int RecordEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccesseStringSetting.DataAccesseString);
            //PersonID
            string Query = @"update Messages 
                           set Message = @NewMessage, 
                               Timer = @NewTimer
                           where SenderID = @SenderID and Message = @Message and Timer = @Timer and ReceiverID = @ReceiverID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@SenderID", SenderID);
            command.Parameters.AddWithValue("@Message", Message);
            command.Parameters.AddWithValue("@Timer", Timer);
            command.Parameters.AddWithValue("@ReceiverID", ReceiverID);

            command.Parameters.AddWithValue("@NewMessage", NewMessage);
            command.Parameters.AddWithValue("@NewTimer", NewTimer);

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
