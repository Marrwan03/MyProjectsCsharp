using DataAccesseTier;
using System;
using System.Data;

namespace BusinesseTier
{
    public class clsBusnieseMessages
    {
        

        public int SenderID { get; set; }
        public string Message { get; set; }
        public DateTime Timer { get; set; }
        public int ReceiverID { get; set; }

        clsBusnieseMessages() 
        {
            Message = string.Empty;
            SenderID = -1;
            Timer = DateTime.MinValue;
            ReceiverID = -1;
         

        }


       public clsBusnieseMessages(int senderID, string message,DateTime time, int receiverID)
        {
            Message = message;
            SenderID = senderID;
            Timer = time;
            ReceiverID = receiverID;
           
        }

        public bool SendMessage()
        {
            return clsDataAccesseMessages.SendMessage(this.SenderID,this.Message, this.Timer, this.ReceiverID);
        }

     

        public static int CounterMessage(int ID)
        {
            return clsDataAccesseMessages.NumberOfMessage(ID);
        }

        public static int CounterYourMessage(int ID)
        {
            return clsDataAccesseMessages.NumberOfYourMessage(ID);
        }

        public static DataTable GetAllMessages(string ReceiverFirstname)
        {
            return clsDataAccesseMessages.FindMessage(ReceiverFirstname);
        }

        public static DataTable GetAllMessages(int ID)
        {
            return clsDataAccesseMessages.FindMessage(ID);
        }

        public static bool DeleteMessage(string Message, DateTime Timer, int ReceiverID)
        {
            return clsDataAccesseMessages.DeleteMessage(Message, Timer, ReceiverID);
        }
        public static int GetReceiverID(string FirstName)
        {
            return clsDataAccesseMessages.GetReceiverID(FirstName);
        }

        public static bool UpdateMessage(int SenderID, string Message, DateTime Timer, int ReceiverID, string NewMessage)
        {
            return clsDataAccesseMessages.UpdateMessage(SenderID,Message, Timer, ReceiverID, NewMessage, DateTime.Now);
        }


    }
}
