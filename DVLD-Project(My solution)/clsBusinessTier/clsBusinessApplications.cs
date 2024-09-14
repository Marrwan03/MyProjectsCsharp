using clsDataAccessTier;
using System;
using System.Data;

namespace clsBusinessTier
{
    public class clsBusinessApplications
    {
        enMode Mode;
        enum enMode
        {
            Add, Update
        }


        public int AppID { get; set; }
        public int PersonID { get; set; }
        public DateTime AppDate {  get; set; }
        public int AppTypeID { get; set; }
        public byte AppStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int UserID { get; set; }

        bool _AddNewApplication()
        {
            this.AppID = clsDataAccessApplications.AddNewApplication(PersonID, DateTime.Now, AppTypeID, AppStatus, DateTime.Now, PaidFees, UserID);
            return this.AppID != -1;
        }

        bool _UpdateApplication()
        {
            return clsDataAccessApplications.UpdateApplication(AppID, AppStatus, DateTime.Now);
        }

        public clsBusinessApplications()
        {
            AppID = -1;
            PersonID = -1;
            AppDate = DateTime.MinValue;
            AppTypeID = -1;
            AppStatus = 0;
            LastStatusDate = DateTime.MinValue;
            PaidFees = -1;
            UserID = -1;
            Mode = enMode.Add;
        }
         clsBusinessApplications(int appiD, int personID, DateTime date, int appTypeID, byte appStatus, DateTime lastStatusDate, decimal paidFees, int userID)
        {
            AppID = appiD;
            PersonID = personID;
            AppDate = date;
            AppTypeID = appTypeID;
            AppStatus = appStatus;
            LastStatusDate = lastStatusDate;
            PaidFees = paidFees;
            UserID = userID;
            Mode = enMode.Update;
        }

        public static clsBusinessApplications Find(int AppID )
        {
            int PersonID = -1, UserID = -1, AppTypeID=-1;
            byte AppStatus = 0;
            DateTime AppDate = DateTime.MinValue, LastStatusDate = DateTime.MinValue;
            decimal PaidFees = -1;
            if (clsDataAccessApplications.Find( AppID,ref PersonID, ref AppDate,ref AppTypeID, ref AppStatus, ref LastStatusDate, ref PaidFees, ref UserID))
            {
                return new clsBusinessApplications(AppID, PersonID, AppDate, AppTypeID, AppStatus, LastStatusDate, PaidFees, UserID);
            }
            return null;
        }

      

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    {
                        if(_AddNewApplication())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                       
                        break;
                    }
                    case enMode.Update:
                    {
                        return _UpdateApplication();

                    }
            }
            return false;
        }

      public static bool Delete(int ApplicantID)
        {
            return clsDataAccessApplications.DeleteApplication(ApplicantID);
        }

    }
}
