using clsDataAccessTier;
using System;
using System.Data;

namespace clsBusinessTier
{
    public class clsBusinessLicenses
    {
        enMode Mode;
        enum enMode
        {
            Add, Update
        }

        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public int IssueReason { get; set; }
        public int CreatedByUserID { get; set; }

        bool _UpdateLicenses()
        {
            return clsDataAccessLicenses.UpdateLicenses(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);

        }

        bool _AddNewLicenses()
        {
            this.LicenseID = clsDataAccessLicenses.AddNewLicenses(ApplicationID, DriverID,LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            return this.LicenseID != -1;
        }

       public clsBusinessLicenses()
        {
            LicenseID = 0;
            ApplicationID = 0;
            DriverID = 0;
            LicenseClass = 0;
                IssueDate = DateTime.MinValue;
            ExpirationDate = DateTime.MinValue;
            Notes = string.Empty;  
            PaidFees = 0;
            IsActive = false;
            IssueReason = 0;
            CreatedByUserID = 0;
            Mode = enMode.Add;
        }

        clsBusinessLicenses(int licenseID, int AppID, int driverID, int licenseClass, DateTime issueDate, DateTime expirationDate, string notes, decimal paidfees, bool isACtive, int issueReason, int UserId)
        {
            LicenseID = licenseID;
            ApplicationID = AppID;
            DriverID = driverID;
            LicenseClass = licenseClass;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Notes = notes;
            PaidFees = paidfees;
            IsActive = isACtive;
            IssueReason = issueReason;
            CreatedByUserID = UserId;
            Mode = enMode.Update;
        }
      
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    {
                        this.Mode = enMode.Update;
                        return _AddNewLicenses();
                    }
                case enMode.Update:
                    {
                        return _UpdateLicenses();
                    }
            }

            return false;
        }

        public static clsBusinessLicenses Find(int AppID)
        {
            int licenseID=0, driverID = 0, licenseClass=0, issueReason=0, UserId=0;
            DateTime issueDate=DateTime.MinValue, expirationDate = DateTime.MinValue;
            string notes = string.Empty;
            decimal paidfees = 0;
            bool isACtive = false;
            if(clsDataAccessLicenses.Find(ref licenseID,  AppID,ref driverID, ref licenseClass, ref issueDate, ref expirationDate, ref notes, ref paidfees, ref isACtive, ref issueReason, ref UserId))
            {
                return new clsBusinessLicenses(licenseID, AppID, driverID, licenseClass, issueDate, expirationDate, notes, paidfees, isACtive, issueReason, UserId);
            }
            return null;

        }

        public static clsBusinessLicenses Find(int DriverID, bool IsActive, int IssueReason)
        {
            int licenseID = 0, AppID=0,  licenseClass = 0,  UserId = 0;
            DateTime issueDate = DateTime.MinValue, expirationDate = DateTime.MinValue;
            string notes = string.Empty;
            decimal paidfees = 0;
           
            if (clsDataAccessLicenses.FindRenew(ref licenseID,ref AppID,  DriverID, ref licenseClass, ref issueDate, ref expirationDate, ref notes, ref paidfees,  IsActive,  IssueReason, ref UserId))
            {
                return new clsBusinessLicenses(licenseID, AppID, DriverID, licenseClass, issueDate, expirationDate, notes, paidfees, IsActive, IssueReason, UserId);
            }
            return null;

        }

        public static clsBusinessLicenses Find(int licenseID, bool ByLicenseID=true)
        {
            int ApplicationID = 0, driverID = 0, licenseClass = 0, issueReason = 0, UserId = 0;
            DateTime issueDate = DateTime.MinValue, expirationDate = DateTime.MinValue;
            string notes = string.Empty;
            decimal paidfees = 0;
            bool isACtive = false;
            if (clsDataAccessLicenses.Find( licenseID, ref ApplicationID, ref driverID, ref licenseClass, ref issueDate, ref expirationDate, ref notes, ref paidfees, ref isACtive, ref issueReason, ref UserId))
            {
                return new clsBusinessLicenses(licenseID, ApplicationID, driverID, licenseClass, issueDate, expirationDate, notes, paidfees, isACtive, issueReason, UserId);
            }
            return null;

        }



        public static bool IsExists(int ApplicationID)
        {
            return clsDataAccessLicenses.IsExists(ApplicationID);
        }

        public static bool IsLicenseActive(int LicenseID, bool WithConditionLicenseClass)
        {
            return clsDataAccessLicenses.IsLicenseActive(LicenseID, WithConditionLicenseClass);
        }

        public static bool IsLicenseActive(int LicenseID)
        {
            return clsDataAccessLicenses.IsLicenseActive(LicenseID);
        }

        public static DataTable GetAllLocalLicensesFor(int PersonID)
        {
            return clsDataAccessLicenses.GetAllLocalLicensesFor(PersonID);
        }

        public static DataTable GetAllInternationalLicensesFor(int PersonID)
        {
            return clsDataAccessLicenses.GetAllInternationalLicensesFor(PersonID);
        }

        public static bool IsRenewLicenseExists(int PersonID, int LicenseClass)
        {
            return clsDataAccessLicenses.IsRenewLicenseExists(PersonID, LicenseClass);
        }

        public static bool IsRenewLicenseActive(int PersonID)
        {
            return clsDataAccessLicenses.IsRenewLicenseActive(PersonID);
        }

    }
}
