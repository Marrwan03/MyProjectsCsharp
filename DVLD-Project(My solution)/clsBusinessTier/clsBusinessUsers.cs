using clsDataAccessTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsBusinessTier
{
    public class clsBusinessUsers
    {
        enMode mode;
        enum enMode
        {
            Add, Update
        }

        public int PersonID {  get; set; }
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        bool _AddNewUser()
        {
            this.UserID = clsDataAccessUsers.AddNewUser(PersonID, Username, Password, IsActive);
            return this.UserID != -1;
        }

        bool _UpdateUser()
        {
            return clsDataAccessUsers.UpdateUser(UserID, PersonID,Username, Password, IsActive);
        }

        clsBusinessUsers(int personID, int userID, string username, string password, bool isActive)
        {
            PersonID = personID;
            UserID = userID;
            Username = username;
            Password = password;
            IsActive = isActive;
            mode = enMode.Update;
        }
      public clsBusinessUsers()
        {
            PersonID = -1;
            UserID = -1;
            Username = string.Empty;
            Password = string.Empty;
            IsActive = false;
            mode = enMode.Add;
        }

        public static clsBusinessUsers Find(string Username, string Password)
        {
            int PersonID = -1, UserID = -1;
            bool IsActive = false;
            if(clsDataAccessUsers.Find(ref PersonID, ref UserID,Username, Password, ref IsActive))
            {
                return new clsBusinessUsers(PersonID, UserID, Username, Password, IsActive);
            }
            return null;

        }

        public static clsBusinessUsers Find(int UserID)
        {
            int PersonID = -1;
            string Username = string.Empty, Password = string.Empty;
            bool IsActive = false;
            if (clsDataAccessUsers.Find(ref PersonID,  UserID,ref Username,ref Password, ref IsActive))
            {
                return new clsBusinessUsers(PersonID, UserID, Username, Password, IsActive);
            }
            return null;

        }

        public static clsBusinessUsers FindByPersonID(int PersonID)
        {
            int UserID = -1;
            string Username = string.Empty, Password = string.Empty;
            bool IsActive = false;
            if (clsDataAccessUsers.Find( PersonID,ref UserID, ref Username, ref Password, ref IsActive))
            {
                return new clsBusinessUsers(PersonID, UserID, Username, Password, IsActive);
            }
            return null;

        }

        public bool Save()
        {
            switch(mode)
            {
                case enMode.Add:
                    {
                        mode = enMode.Update;
                        return _AddNewUser();
                    }
                    case enMode.Update:
                    {
                        return _UpdateUser();
                    }
            }
            return false;
        }

        public static DataTable GetAllUsers()
        {
            return clsDataAccessUsers.GetAllUsers();
        }

        public static bool DeleteUser(int UserID)
        {
           return clsDataAccessUsers.DeleteUser(UserID);
        }

        public static bool IsExists(int PersonID)
        {
            return clsDataAccessUsers.IsExists(PersonID);
        }

    }
}
