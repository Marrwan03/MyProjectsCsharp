using clsDataAccessTier;
using System;
using System.Data;

namespace clsBusinessTier
{
    public class clsBusinessRetakeTestAppointment
    {
        //int ID, decimal FeesRetake, decimal TotalFees, int TestAppID
        public int ID { get; set; }
        public decimal FeesRetake { get; set; }
        public decimal OriginalFees { get; set; }
        public decimal TotalFees { get; set; }
        public int TestAppID { get; set; }

        bool _AddNewRetakeTestAppointment()
        {
            this.ID = clsDataAccessRetakeTestAppointment.AddNewRetakeTestAppointment(OriginalFees,FeesRetake, TotalFees, TestAppID);
            return this.ID != -1;
        }

         clsBusinessRetakeTestAppointment(int iD, decimal feesRetake, decimal originalFees,decimal totalFees, int testAppID)
        {
            ID = iD;
            FeesRetake = feesRetake;
            OriginalFees = originalFees;
            TotalFees = totalFees;
            TestAppID = testAppID;
        }
        public clsBusinessRetakeTestAppointment()
        {
            ID = -1;
            FeesRetake = 0;
            OriginalFees = 0;
            TotalFees = 0;
            TestAppID = -1;
        }

        public static clsBusinessRetakeTestAppointment Find(int TestAppoinmentID)
        {
            int iD=0;
            decimal originalFees=0,feesRetake=0, totalFees=0 ;

            if(clsDataAccessRetakeTestAppointment.Find(ref iD,ref originalFees,ref feesRetake ,ref totalFees , TestAppoinmentID))
            {
                return new clsBusinessRetakeTestAppointment( iD, feesRetake,originalFees, totalFees, TestAppoinmentID);
            }
            return null;

        }

        public bool Save()
        {
            return _AddNewRetakeTestAppointment();
        }

        public static bool IsExists(int TestAppID)
        {
            return clsDataAccessRetakeTestAppointment.IsExists(TestAppID);
        }

        public static bool IsExistsBy(int LDLAppID)
        {
            return clsDataAccessRetakeTestAppointment.IsExistsBy( LDLAppID);
        }

        public static bool Delete(int LDLAppID)
        {
            return clsDataAccessRetakeTestAppointment.Delete(LDLAppID);
        }

    }
}
