using clsDataAccessTier;
using clsDataAccessTier.View;
using System;
using System.Data;

namespace clsBusinessTier
{
    public class clsBusinessLocalDrivingLicenseApplications
    {
        enMode Mode;
        enum enMode
        {
            Add, Update
        }


        public int LDLAppID { get; set; }
        public int AppID {  get; set; }
        public int LicenseClassID { get; set; }

        bool _AddNewLocalDrivingLicenseApplications()
        {
            this.LDLAppID = clsDataAccessLocalDrivingLicenseApplications.AddNewLocalDrivingLicenseApplications(AppID, LicenseClassID);
            return this.LDLAppID != -1;
        }

        bool _UpdateLocalDrivingLicenseApplications()
        {
            return clsDataAccessLocalDrivingLicenseApplications.UpdateLocalDrivingLicenseApplications(AppID, LicenseClassID);
        }

        public clsBusinessLocalDrivingLicenseApplications()
        {
            LDLAppID = -1;
            AppID = -1;
            LicenseClassID = -1;
            Mode = enMode.Add;
        }
        clsBusinessLocalDrivingLicenseApplications(int lDLAppID, int AppID, int LicenseClassID)
        {
            LDLAppID = lDLAppID;
           this.AppID = AppID;
            this.LicenseClassID = LicenseClassID;
            Mode = enMode.Update;

        }

        public static DataTable GetAllViewData()
        {
            return clsDataAccessMYLocalDrivingLicenseApplications_View.GetAllData();
        }

        public static clsBusinessLocalDrivingLicenseApplications Find(int ApplicationID)
        {
            int LDLAppID = -1, licenseClassID = -1;

            if(clsDataAccessLocalDrivingLicenseApplications.Find(ref LDLAppID,  ApplicationID, ref licenseClassID))
            {
                return new clsBusinessLocalDrivingLicenseApplications(LDLAppID, ApplicationID, licenseClassID);
            }
            return null;
        }

        public static clsBusinessLocalDrivingLicenseApplications FindByLDLAppID(int LDLAppID)
        {
            int AppID = -1, licenseClassID = -1;

            if (clsDataAccessLocalDrivingLicenseApplications.Find( LDLAppID,ref AppID, ref licenseClassID))
            {
                return new clsBusinessLocalDrivingLicenseApplications(LDLAppID, AppID, licenseClassID);
            }
            return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    {
                        if(_AddNewLocalDrivingLicenseApplications())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        break;
                    }
                    case enMode.Update:
                    {
                        return _UpdateLocalDrivingLicenseApplications();
                    }

            }
            return false;
        }

        public static int CountOfLicenseWith(int LicenseClassID, int AppID)
        {
            return clsDataAccessLocalDrivingLicenseApplications.CountOfLicenseWith(LicenseClassID, AppID);
        }

        public static bool DeleteLocalDrivingLicenseApplications(int LDLAppID)
        {
            return clsDataAccessLocalDrivingLicenseApplications.DeleteLocalDrivingLicenseApplications(LDLAppID);
        }

    }
}
