using clsDataAccessTier;
using System;
using System.Data;

namespace clsBusinessTier
{
    public class clsBusinessTests
    {


        public int ID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int UserID { get; set; }

        bool _AddNewTest()
        {
            this.ID = clsDataAccessTests.AddNewTest(TestAppointmentID,TestResult, Notes, UserID);
            return ID != -1;
        }

        clsBusinessTests(int iD, int testAppointmentID, bool testResult, string notes, int userID)
        {
            ID = iD;
            TestAppointmentID = testAppointmentID;
            TestResult = testResult;
            Notes = notes;
            UserID = userID;

        }
        public clsBusinessTests()
        {
            ID = -1;
            TestAppointmentID = -1;
            TestResult = false;
            Notes = string.Empty; 
            UserID = -1;
        }

        public static clsBusinessTests Find(int TestAppointmentID)
        {
            int id = -1, UserID = -1;
            bool TestResult = false;
            string Notes = string.Empty;
            if(clsDataAccessTests.Find(ref id, TestAppointmentID, ref TestResult,ref Notes,ref UserID))
            {
                return new clsBusinessTests(id, TestAppointmentID, TestResult, Notes, UserID);
            }
            return null;
        }

        public bool Save()
        {
            return _AddNewTest();
        }

        public static bool DoesUserHasfailure(int LDLAppID, int TestTypeID)
        {
            return clsDataAccessTests.DoesUserHasfailure(LDLAppID, TestTypeID);
        }

        public static bool DoesUserHasfailure(int TestAppID)
        {
            return clsDataAccessTests.DoesUserHasfailure(TestAppID);
        }

        public static bool DeleteTestsBy(int LDLAppID)
        {
            return clsDataAccessTests.DeleteTestsFor(LDLAppID);
        }

    }
}
