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
    public partial class ctrlTakeTest : UserControl
    {
        public void Label_MouseEnter(object sender, EventArgs e)
        {
           clsColorControl.Label_MouseEnter(sender, e);
        }

        public void Label_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.Label_MouseLeave(sender, e);
        }




        clsBusinessTestAppointments _TestAppointments;
        clsBusinessMYLocalDrivingLicenseApplications_View _LocalDrivingLicenseApplications_View;
        clsBusinessTests _Test;

        public ctrlTakeTest()
        {
            InitializeComponent();
            
        }

        void _ChangeTopicData(string TitleGroupBox, string PathImage )
        {
            gbTitle.Text = TitleGroupBox;
            picTest.Image = Image.FromFile(PathImage);
        }

        void _ChangeByTestType(int TestType)
        {
            switch(TestType)
            {
                case 1:
                    {
                        _ChangeTopicData("Vision test", @"C:\Users\lenovo\OneDrive\Desktop\BlackICON\Vision.png");
                        break;

                    }
                    case 2:
                    {
                        _ChangeTopicData("Written test", @"C:\Users\lenovo\OneDrive\Desktop\BlackICON\Written.png");
                        break;
                    }
                    case 3:
                    {
                        //C:\Users\lenovo\OneDrive\Desktop\BlackICON\driving-test.png
                        _ChangeTopicData("Streat test", @"C:\Users\lenovo\OneDrive\Desktop\BlackICON\driving-test.png");
                        break;
                    }
            }
        }

       public void LoadTakeTest(int TestAppointmentID)
        {
            _TestAppointments = clsBusinessTestAppointments.FindBy(TestAppointmentID);
            _LocalDrivingLicenseApplications_View = clsBusinessMYLocalDrivingLicenseApplications_View.Find(_TestAppointments.LDLAppID);

            _ChangeByTestType(_TestAppointments.TestTypeID);
            lblDLAppID.Text = _LocalDrivingLicenseApplications_View.ID.ToString();
            lblDClass.Text = _LocalDrivingLicenseApplications_View.ClassName;
            lblName.Text = _LocalDrivingLicenseApplications_View.FullName;
            lblTrial.Text = clsBusinessTestAppointments.CountOfTrial(_TestAppointments.TestTypeID, _TestAppointments.LDLAppID).ToString();//Change [2] Index
            lblDate.Text = _TestAppointments.AppointmentDate.ToString("dd/MMM/yyyy");
            lblFees.Text = Convert.ToInt32(_TestAppointments.PaidFees).ToString();

            _Test = clsBusinessTests.Find(TestAppointmentID);
            if(_Test == null)
            {
                lblTestID.Text = "Not Taken Yet";
            }
            else
            {
                lblTestID.Text = _Test.ID.ToString();
            }
            

        }

        private void gbTitle_Enter(object sender, EventArgs e)
        {

        }
    }
}
