using clsDataAccessTier;
using System;
using System.Data;

namespace clsBusinessTier
{
    public class clsBusinessInternationalLicense
    {
        enMode Mode;
        enum enMode
        {Add, Update }


        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get;  set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        bool _AddNewInternationalLicens()
        {
            this.InternationalLicenseID = clsDataAccessInternationalLicense.AddNewInternationalLicense( ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);
            return this.InternationalLicenseID != -1 ;
        }

        bool _UpdateInternationalLicense()
        {
            return clsDataAccessInternationalLicense.UpdateInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);
        }

        public clsBusinessInternationalLicense()
        {
            InternationalLicenseID = 0;
            ApplicationID = 0;
            DriverID = 0;
            IssuedUsingLocalLicenseID = 0;
            IssueDate = DateTime.MinValue;
            ExpirationDate = DateTime.MinValue;
            IsActive = false;
            CreatedByUserID = 0;
            Mode = enMode.Add;

        }
        clsBusinessInternationalLicense(int internationalLicenseID, int applicationID, int driverID, int issuedUsingLocalLicenseID, DateTime issueDate, DateTime expirationDate, bool isActive, int createdByUserID)
        {
            InternationalLicenseID = internationalLicenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            IssuedUsingLocalLicenseID = issuedUsingLocalLicenseID;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            IsActive = isActive;
            CreatedByUserID = createdByUserID;
            Mode = enMode.Update;

        }

        public static clsBusinessInternationalLicense Find(int issuedUsingLocalLicenseID)
        {
            int internationalLicenseID=0, applicationID=0, driverID=0, createdByUserID=0;
            DateTime issueDate = DateTime.MinValue, expirationDate = DateTime.MinValue;
            bool isActive = false;
            if(clsDataAccessInternationalLicense.Find(ref internationalLicenseID, ref applicationID, ref driverID, issuedUsingLocalLicenseID, ref issueDate, ref expirationDate, ref isActive,ref createdByUserID))
            {
                return new clsBusinessInternationalLicense(internationalLicenseID, applicationID, driverID, issuedUsingLocalLicenseID, issueDate, expirationDate, isActive, createdByUserID);
            }
            return null;
        }

        public static clsBusinessInternationalLicense Find2(int internationalLicenseID)
        {
            int issuedUsingLocalLicenseID = 0, applicationID = 0, driverID = 0, createdByUserID = 0;
            DateTime issueDate = DateTime.MinValue, expirationDate = DateTime.MinValue;
            bool isActive = false;
            if (clsDataAccessInternationalLicense.Find( internationalLicenseID, ref applicationID, ref driverID,ref issuedUsingLocalLicenseID, ref issueDate, ref expirationDate, ref isActive, ref createdByUserID))
            {
                return new clsBusinessInternationalLicense(internationalLicenseID, applicationID, driverID, issuedUsingLocalLicenseID, issueDate, expirationDate, isActive, createdByUserID);
            }
            return null;
        }

        public static DataTable GetAllinternationalLicenses()
        {
            return clsDataAccessInternationalLicense.GetAllInternationalLicenses();
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.Add:
                    {
                        if(_AddNewInternationalLicens())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        break;
                    }
                case enMode.Update:
                    {
                        return _UpdateInternationalLicense();
                    }

            }
            return false;
        }

        public static bool IsExists(int InternationalLicenseID)
        {
            return clsDataAccessInternationalLicense.IsExists(InternationalLicenseID);
        }
        public static bool IsExists2(int IssuedUsingLocalLicenseID)
        {
            return clsDataAccessInternationalLicense.IsExists2(IssuedUsingLocalLicenseID);
        }



    }
}
