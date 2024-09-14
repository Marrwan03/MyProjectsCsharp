using clsDataAccessTier.View;
using System;
using System.Data;
using System.Data.SqlClient;

namespace clsBusinessTier.View
{
    public class clsBusinessMYLocalDrivingLicenseApplications_View
    {
        public int ID { get; set; }
        public string ClassName { get; set; }
        public string NationalNo { get; set; }
        public string FullName { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int PastedTests { get; set; }
        public string StatusName { get; set; }

        clsBusinessMYLocalDrivingLicenseApplications_View(int id, string className, string nationalNo, string fullName, DateTime applicationDate, int pastedTests, string statusName)
        {
            ID = id;
            ClassName = className;
            NationalNo = nationalNo;
            FullName = fullName;
            ApplicationDate = applicationDate;
            PastedTests = pastedTests;
            StatusName = statusName;
        }
        public clsBusinessMYLocalDrivingLicenseApplications_View()
        {
            ID = -1;
            ClassName = "";
            NationalNo = "";
            FullName = "";
            ApplicationDate = DateTime.MinValue;
            PastedTests = -1;
            StatusName = "";
        }

        public static DataTable GetAllData()
        {
            return clsDataAccessMYLocalDrivingLicenseApplications_View.GetAllData();
        }

        public static clsBusinessMYLocalDrivingLicenseApplications_View Find(int LDLAppID)
        {
            string ClassName = "", NationalNo = "", FullName = " ", StatusName = " ";
            int PastedTests = -1;
            DateTime ApplicationDate = DateTime.MinValue;
            if(clsDataAccessMYLocalDrivingLicenseApplications_View.Find(LDLAppID, ref ClassName, ref  NationalNo, ref FullName,ref ApplicationDate, ref PastedTests, ref StatusName))
            {
                return new clsBusinessMYLocalDrivingLicenseApplications_View(LDLAppID, ClassName, NationalNo, FullName, ApplicationDate, PastedTests, StatusName);
            }
            return null;
        }


    }
}
