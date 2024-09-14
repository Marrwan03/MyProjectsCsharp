using clsDataAccessTier;
using System;
using System.Data;

namespace clsBusinessTier
{
    public class clsBusinessDetainedLicenses
    {
        enMode _Mode;
        enum enMode
        {
            Add, Update
        }

        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleasedDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleasedByAppID { get; set; }

        private bool _AddNewDetainLicense()
        {
            this.DetainID = clsDataAccessDetainedLicenses.AddNewDetainLicense(LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleasedDate, ReleasedByUserID, ReleasedByAppID);
            return this.DetainID != -1;
        }

        private bool _UpdateDetainLicense()
        {
            return clsDataAccessDetainedLicenses.UpdateDetainLicense(DetainID, IsReleased, ReleasedDate, ReleasedByUserID, ReleasedByAppID);
        }

        public clsBusinessDetainedLicenses()
        {
            DetainID = 0;
            LicenseID = 0;
            DetainDate = DateTime.Now;
            FineFees = 0;
            CreatedByUserID = 0;
            IsReleased = false;
            ReleasedDate = DateTime.MinValue;
            ReleasedByUserID = -1;
            ReleasedByAppID = -1;
            _Mode = enMode.Add;
        }
         clsBusinessDetainedLicenses(int detainID, int licenseID, DateTime detainDate, decimal fineFees, int createdByUserID, bool isReleased, DateTime releasedDate, int releasedByUserID, int releasedByAppID)
        {
            DetainID = detainID;
            LicenseID = licenseID;
            DetainDate = detainDate;
            FineFees = fineFees;
            CreatedByUserID = createdByUserID;
            IsReleased = isReleased;
            ReleasedDate = releasedDate;
            ReleasedByUserID = releasedByUserID;
            ReleasedByAppID = releasedByAppID;
            _Mode = enMode.Update;
        }

        public static clsBusinessDetainedLicenses Find(int licenseID)
        {
            int detainID=0, createdByUserID=0, releasedByUserID=0, releasedByAppID=0;
            DateTime detainDate=DateTime.MinValue, releasedDate=DateTime.MinValue;
            decimal fineFees = 0;
            bool isReleased=false;
            if(clsDataAccessDetainedLicenses.Find(ref detainID, licenseID, ref detainDate, ref  fineFees, ref createdByUserID, ref isReleased,ref releasedDate, ref  releasedByUserID,ref releasedByAppID))
            {
                return new clsBusinessDetainedLicenses(detainID, licenseID, detainDate, fineFees, createdByUserID, isReleased, releasedDate, releasedByUserID, releasedByAppID);
            }
            return null;
        }

        public static DataTable GetAllDetainLicense()
        {
            return clsDataAccessDetainedLicenses.GetAllDetainLicense();
        }

        public static bool IsExists(int LicenseID)
        {
            return clsDataAccessDetainedLicenses.IsExists(LicenseID);
        }

       public bool Save()
        {
            switch( _Mode)
            {
               case enMode.Add:
               {
                   if(_AddNewDetainLicense())
                   {
                       _Mode = enMode.Update;
                       return true;
                   }
                   break;
               }
               case enMode.Update:
               {
                   return _UpdateDetainLicense();
               }

            }
            return false;
        }


    }
}
