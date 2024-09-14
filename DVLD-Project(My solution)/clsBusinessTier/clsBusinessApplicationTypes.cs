using clsDataAccessTier;
using System;
using System.Data;

namespace clsBusinessTier
{
    public class clsBusinessApplicationTypes
    {
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationFees { get; set;}

        bool _UpdateApplicationType()
        {
            return clsDataAccessApplicationTypes.UpdateApplicationTypes(ApplicationTypeID, ApplicationTypeTitle, ApplicationFees);
        }
      public  clsBusinessApplicationTypes() 
        {
            ApplicationTypeTitle = string.Empty;
            ApplicationFees = -1;
        }

        clsBusinessApplicationTypes(int applicationTypeID, string applicationTypeTitle, decimal applicationfees)
        {
            ApplicationTypeID = applicationTypeID;
            ApplicationTypeTitle = applicationTypeTitle;
            ApplicationFees = applicationfees;
        }

        public static clsBusinessApplicationTypes Find(int ApplicationTypeID)
        {
            string TypeTitle = string.Empty;
            decimal Fees = 0;
            if (clsDataAccessApplicationTypes.Find(ApplicationTypeID, ref TypeTitle, ref Fees) )
            {
                return new clsBusinessApplicationTypes(ApplicationTypeID, TypeTitle, Fees);
            }
            return null;
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsDataAccessApplicationTypes.GetAllApplicationTypes();
        }

        public bool Save()
        {
            return _UpdateApplicationType();
        }


        public static decimal MinimumFees()
        {
            return clsDataAccessApplicationTypes.GetMinimumFees();

        }
        public static decimal MaximumFees()
        {
            return clsDataAccessApplicationTypes.GetMaximumFees();

        }

    }
}
