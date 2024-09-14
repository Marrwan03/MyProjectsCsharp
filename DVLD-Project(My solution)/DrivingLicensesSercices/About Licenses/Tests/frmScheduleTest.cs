using clsBusinessTier;
using MyLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class frmScheduleTest : Form
    {
        public void Button_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.Button_MouseEnter(sender, e);
        }

        public void Button_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.Button_MouseLeave(sender, e);
        }

        enMode mode;
        enum enMode
        {
            add, update
        }


        clsBusinessRetakeTestAppointment _retakeTestAppointment;
        clsBusinessTestAppointments _testAppointments;

        int _DLAppID, _TestTypeID, _TestAppID;
        bool _IsLocked;

        //clsBusinessTestAppointments testAppointments;

       
        public frmScheduleTest(int TestAppID,int DLAppID, int TestTypeID, bool isLocked)
        {
            InitializeComponent();
            _TestAppID = TestAppID;
           _DLAppID = DLAppID;
            _TestTypeID = TestTypeID;
            _IsLocked = isLocked;
        }

       


        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
           
            ctrlAppointmentTest1.LoadDate(_TestAppID,_TestTypeID, _DLAppID, _IsLocked);

        }

        private void ctrlAppointmentTest1_Load(object sender, EventArgs e)
        {

        }

        void _AddNewRetakeTestAndPlusPaidFees(int ID)
        {
            _retakeTestAppointment.TestAppID = ID;
            if (_retakeTestAppointment.Save())
            {
                ctrlAppointmentTest1.ctrlRetakeTestInfo1.LoadRetakeTestInfo(_retakeTestAppointment, false);
            }
          
        }

        void _FillRetakeTestAppointment(ref clsBusinessRetakeTestAppointment retakeTestAppointment, decimal OriginalFees, decimal FeesRetake)

        {
            retakeTestAppointment.OriginalFees = OriginalFees;
            retakeTestAppointment.FeesRetake = FeesRetake;
            retakeTestAppointment.TotalFees = OriginalFees + FeesRetake;

        }

        private void ctrlAppointmentTest1_OnSave(clsBusinessTestAppointments obj)
        {
           _testAppointments = obj;
            if(_testAppointments == null)
            {
                MessageBox.Show("You must enter all Data to Complete your order.", "Wrong Appointment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(clsBusinessTestAppointments.IsSameDay(_testAppointments.LDLAppID, _testAppointments.TestTypeID, _testAppointments.AppointmentDate))
            {
              
               if( MessageBox.Show("You must enter another Data to Complete your order,\nBecause you already take this date to complete another test.", "Wrong Appointment", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    return;
                }
               
            }
           
            if(clsBusinessTests.DoesUserHasfailure(_testAppointments.LDLAppID, _testAppointments.TestTypeID))
            {
                _retakeTestAppointment = new clsBusinessRetakeTestAppointment();
                _FillRetakeTestAppointment(ref _retakeTestAppointment, clsBusinessTestTypes.Find(_TestTypeID).Fees, clsBusinessApplicationTypes.Find(8).ApplicationFees);
                _testAppointments.PaidFees = _retakeTestAppointment.TotalFees;

                if (!clsBusinessRetakeTestAppointment.IsExists(obj.ID))
                {
                    _AddNewRetakeTestAndPlusPaidFees(_testAppointments.ID);
                   
                }
                

            }

            if (_testAppointments.Save())
            {
               if( MessageBox.Show("Save is succefully", "Correct Save!", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                   this.Close();
                    
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
          
            this.Close();
        }
    }
}
