using clsBusinessTier;
using clsBusinessTier.View;
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
    public partial class ctrlAppointmentTest : UserControl
    {
        public void Button_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.Button_MouseEnter(sender, e);
        }

        public void Button_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.Button_MouseLeave(sender, e);
        }
        public void Label_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.Label_MouseEnter(sender, e);
        }

        public void Label_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.Label_MouseLeave(sender, e);
        }




        public event Action<clsBusinessTestAppointments> OnSave;
        protected virtual void Save(clsBusinessTestAppointments testAppointments1)
        {
            if (OnSave != null)
                OnSave(testAppointments1);
        }

        enCasesofentry casesofentry;
        enum enCasesofentry
        {
            Fresh,
            FinishHisAppointment,
            failure,
          
        }


        public ctrlAppointmentTest()
        {
            InitializeComponent();
            dtDateOfTest.MinDate = DateTime.Now;
           
        }
        clsBusinessTestAppointments _TestAppointments;
        clsBusinessMYLocalDrivingLicenseApplications_View _clsLDLApp;
        clsBusinessRetakeTestAppointment _retakeTestAppointment;


        int _TestTypeID, _LDLAppID, _TestAppID;

        void _ChangeTopicData(string TitleGroupBox, string PathImage, string TitlePage= "Schedule Test")
        {
            gbTitle.Text = TitleGroupBox;
            picImage.Image = Image.FromFile(PathImage);
            if(casesofentry == enCasesofentry.Fresh)
            {
                lblTitle.Text = TitlePage;
            }
            else
            {
                lblTitle.Text = "Schedule Retake Test";
            }
            

        }

        void _LoadMainTopicByTestType(int TestTypeID)
        {
            switch (TestTypeID)
            {
                case 1:
                    {
                        _ChangeTopicData("Vision Test", @"C:\Users\lenovo\OneDrive\Desktop\BlackICON\Vision.png");
                        break;
                    }
                case 2:
                    {
                        _ChangeTopicData("Written Test", @"C:\Users\lenovo\OneDrive\Desktop\BlackICON\Written.png");
                        break;
                    }
                case 3:
                    {
                        _ChangeTopicData("Street Test", @"C:\Users\lenovo\OneDrive\Desktop\BlackICON\driving-test.png");
                        break;
                    }
            }
        }

        void FilltestAppointments()
        {
          
            _TestAppointments.TestTypeID = _TestTypeID;
            _TestAppointments.LDLAppID = _clsLDLApp.ID;
            _TestAppointments.AppointmentDate = dtDateOfTest.Value;
            _TestAppointments.PaidFees = clsBusinessTestTypes.Find(_TestTypeID).Fees;
            _TestAppointments.ByUserID = clsGlobalSettings.CurrentUser.UserID;
            
        }

       enCasesofentry GetCurrentCase(bool IsLocked, bool HasFailure)
        {
            if(HasFailure && !IsLocked)
            {
                return enCasesofentry.failure;
            }

            else if (IsLocked)
            {
                return enCasesofentry.FinishHisAppointment;
            }

            else
            {
                return enCasesofentry.Fresh;
            }
        }

        void _ChangeControlForm(bool VisibleHideTitle, bool EnableDateOfTest, bool EnablebtnSave, bool EnableRetakeTest)
        {
            lblHideTitle.Visible = VisibleHideTitle;
            dtDateOfTest.Enabled = EnableDateOfTest;
            btnSave.Enabled = EnablebtnSave;
            ctrlRetakeTestInfo1.Enabled = EnableRetakeTest;

        }

        void _FillRetakeTestAppointment(ref clsBusinessRetakeTestAppointment retakeTestAppointment, decimal OriginalFees, decimal FeesRetake)

        {
            retakeTestAppointment.OriginalFees = OriginalFees;
            retakeTestAppointment.FeesRetake = FeesRetake;
            retakeTestAppointment.TotalFees = OriginalFees + FeesRetake;

        }

        bool _UserHasFailure=false;

        void _LoadAppointmentData()
        {
            _LoadMainTopicByTestType(_TestTypeID);
            _clsLDLApp = clsBusinessMYLocalDrivingLicenseApplications_View.Find(_LDLAppID);
            lblDLAppID.Text = _clsLDLApp.ID.ToString();
            lblDClass.Text = _clsLDLApp.ClassName;
            lblName.Text = _clsLDLApp.FullName;
            lblTrial.Text = clsBusinessTestAppointments.CountOfTrial(_TestTypeID, _LDLAppID).ToString();
            lblFees.Text = Convert.ToInt32(clsBusinessTestTypes.Find(_TestTypeID).Fees).ToString();

        }

        public void LoadDate(int TestAppID,int TestTypeID,int LDLAppID, bool IsLocked)
        {
            _LDLAppID = LDLAppID;
            _TestTypeID = TestTypeID;
            _TestAppID = TestAppID;
            //Find way 
            _clsLDLApp = clsBusinessMYLocalDrivingLicenseApplications_View.Find(_LDLAppID);
            _TestAppointments = clsBusinessTestAppointments.FindBy(TestAppID);
            if (_TestAppointments == null)
            {
                _TestAppointments= new clsBusinessTestAppointments();
                dtDateOfTest.Value = dtDateOfTest.MinDate;
            }
            else
            {
                dtDateOfTest.MinDate = _TestAppointments.AppointmentDate;
                dtDateOfTest.Value = _TestAppointments.AppointmentDate;
                dtDateOfTest.MinDate = DateTime.Now;
               
            }
            _UserHasFailure = clsBusinessTests.DoesUserHasfailure(_LDLAppID, _TestTypeID);

            casesofentry = GetCurrentCase(IsLocked, _UserHasFailure);
            _LoadMainTopicByTestType(_TestTypeID);

            _LoadAppointmentData();

            _retakeTestAppointment = clsBusinessRetakeTestAppointment.Find(TestAppID);
            switch (casesofentry)
            {
                case enCasesofentry.Fresh:
                {
                        _ChangeControlForm(false, true, true, false);
                        ctrlRetakeTestInfo1.LoadRetakeTestInfo(lblFees.Text);
                        break;
                }


                case enCasesofentry.FinishHisAppointment:
                    {
                        _ChangeControlForm(true, false, false, true);
                        if (_retakeTestAppointment != null)
                        {
                            ctrlRetakeTestInfo1.LoadRetakeTestInfo(_retakeTestAppointment, false);
                        }
                        else
                        {
                            ctrlRetakeTestInfo1.LoadRetakeTestInfo(lblFees.Text);
                        }
                        break;
                    }
                case enCasesofentry.failure:
                    {
                        _ChangeControlForm(false, true, true, true);
                        // 1- Add New Appointment he had Failed
                        if (_retakeTestAppointment == null)
                        {
                           clsBusinessRetakeTestAppointment _retakeTestAppointmentTemporary = new clsBusinessRetakeTestAppointment();
                            _FillRetakeTestAppointment(ref _retakeTestAppointmentTemporary, clsBusinessTestTypes.Find(_TestTypeID).Fees, 5);

                            ctrlRetakeTestInfo1.LoadRetakeTestInfo(_retakeTestAppointmentTemporary, true);
                          
                        }

                        //Edit
                        else
                        {
                            ctrlRetakeTestInfo1.LoadRetakeTestInfo(_retakeTestAppointment, false);
                        }
                        break;
                    }
            }
        }


        private void gbTitle_Enter(object sender, EventArgs e)
        {

        }

        private void dtDateOfTest_ValueChanged(object sender, EventArgs e)
        {

        }

     

        private void btnSave_Click(object sender, EventArgs e)
        {
            FilltestAppointments();
           
            if (_TestAppointments.Save())
            {

                if (OnSave != null)
                    OnSave(_TestAppointments);
            }
        }

    }
}
