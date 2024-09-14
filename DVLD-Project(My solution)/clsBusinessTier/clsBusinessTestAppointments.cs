using clsDataAccessTier;
using System;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;

namespace clsBusinessTier
{
    public class clsBusinessTestAppointments
    {
        enMode _mode;
        enum enMode
        {
            Add, Update
        }


        public int ID { get; set; }
        public int TestTypeID { get; set; }
        public int LDLAppID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int ByUserID { get; set; }
        public bool IsLocked { get; set; }


        bool _AddNewTestAppointments()
        {
            this.ID = clsDataAccessTestAppointments.AddNewtestAppointments(TestTypeID, LDLAppID, AppointmentDate, PaidFees, ByUserID, IsLocked);
            return this.ID != -1;
        }

        bool _UpdateTestAppointments()
        {
            return clsDataAccessTestAppointments.UpdatetestAppointments(ID, TestTypeID, LDLAppID, AppointmentDate,PaidFees, ByUserID, IsLocked);
        }

        public clsBusinessTestAppointments()
        {
            ID = -1;
            TestTypeID = 0;
            LDLAppID = -1;
            AppointmentDate = DateTime.Now;
            PaidFees = 0;
            ByUserID = 0;
            IsLocked = false;
            _mode = enMode.Add;
        }
        clsBusinessTestAppointments(int id, int testtypeID,int ldlAppID, DateTime appointmentDate, decimal paidFees, int userID, bool isLocked)
        {
            ID = id;
            TestTypeID = testtypeID;
            LDLAppID = ldlAppID;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            ByUserID = userID;
            IsLocked=isLocked;
            _mode = enMode.Update;
        }

        public static DataTable GetAllDateFrom(int TestTypeID, int LDLAppID)
        {
            return clsDataAccessTestAppointments.GetAllDateFrom( TestTypeID, LDLAppID);
        }

        public static clsBusinessTestAppointments FindBy(int TestTypeID, int LDLAppID)
        {
            int id = -1, userId = -1;
            DateTime AppointmentDate = DateTime.MinValue;
            decimal paidFees = 0;
            bool isLocked = false;

            if(clsDataAccessTestAppointments.FindBy(ref id, TestTypeID,LDLAppID,ref AppointmentDate, ref paidFees, ref userId, ref isLocked))
            {
                return new clsBusinessTestAppointments(id, TestTypeID, LDLAppID, AppointmentDate, paidFees, userId, isLocked);
            }
            return null;

        }

    

        public static clsBusinessTestAppointments FindBy(int TestAppointmentID)
        {
            int userId = -1, TestTypeID = -1, LDLAppID= -1;
            DateTime AppointmentDate = DateTime.MinValue;
            decimal paidFees = 0;
            bool isLocked = false;

            if (clsDataAccessTestAppointments.FindBy(TestAppointmentID, ref TestTypeID,ref LDLAppID, ref AppointmentDate, ref paidFees, ref userId, ref isLocked))
            {
                return new clsBusinessTestAppointments(TestAppointmentID, TestTypeID, LDLAppID, AppointmentDate, paidFees, userId, isLocked);
            }
            return null;

        }

        public static bool IsUserHasAppoinment(int TestTypeID, int LDLAppID)
        {
            return clsDataAccessTestAppointments.IsUserHasAppoinment(TestTypeID, LDLAppID);
        }

        public static int CountOfTrial(int TestTypeID, int LDLAppID)
        {
            return clsDataAccessTestAppointments.CountOfTrial(TestTypeID, LDLAppID);
        }

        public static bool IsSameDay(int LDLAppID,int TestTypeID, DateTime dt)
        {
            return clsDataAccessTestAppointments.IsSameDay(LDLAppID,TestTypeID, dt);
        }

        public bool Save()
        {
            switch (_mode)
            {
                case enMode.Add:
                    {
                        this._mode = enMode.Update;
                        return _AddNewTestAppointments();

                    }
                    case enMode.Update:
                    {
                        return _UpdateTestAppointments();
                    }
            }
            return false;

        }

        public static bool IsExists(int LDLAppID)
        {
            return clsDataAccessTestAppointments.IsExists(LDLAppID);
        }

        public static bool DeleteTestAppointment(int LDLAppID)
        {
            return clsDataAccessTestAppointments.DeleteTestsFor(LDLAppID);
        }


    }
}
