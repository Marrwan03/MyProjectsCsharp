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

   
    public partial class frmTestAppointments : Form
    {

        public void Label_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.Label_MouseEnter(sender, e);
        }

        public void Label_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.Label_MouseLeave(sender, e);
        }

        public void Button_MouseEnter(object sender, EventArgs e)
        {
           clsColorControl.Button_MouseEnter(sender, e);
        }

        public void Button_MouseLeave(object sender, EventArgs e)
        {
           clsColorControl.Button_MouseLeave(sender, e);
        }

        public void ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
           clsColorControl.ToolStripMenuItem_MouseEnter(sender, e);
        }
        public void ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.ToolStripMenuItem_MouseLeave(sender, e);
        }




        int _LDLAppID;
        int _TestTypeID;
      

        enTest TestType;
        enum enTest
        {
            Vision, 
            Written,
            Street
        }

        enTest GetTestType(int TestTypeID)
        {
            switch(TestTypeID)
            {
                case 1:
                    return enTest.Vision;
                    case 2:
                    return enTest.Written;
                    case 3:
                    return enTest.Street;
            }
            return enTest.Vision;
        }

        public frmTestAppointments(int LDLAppID, int testTypeID)
        {
            InitializeComponent();

            _LDLAppID = LDLAppID;
            _TestTypeID = testTypeID;
            TestType = GetTestType(testTypeID);


        }

        private clsBusinessPeople _clsPerson;
        private clsBusinessApplications _clsApplication;
        private clsBusinessMYLocalDrivingLicenseApplications_View _clsLocalDrivingLicenseApp;
        private clsBusinessTestAppointments _clsTestAppointments;
        private DataTable _dt;



        void _RefreshData()
        {
            _clsLocalDrivingLicenseApp = clsBusinessMYLocalDrivingLicenseApplications_View.Find(_LDLAppID);
            _clsPerson = clsBusinessPeople.Find(_clsLocalDrivingLicenseApp.NationalNo);
            _clsApplication = clsBusinessApplications.Find(clsBusinessLocalDrivingLicenseApplications.FindByLDLAppID(_LDLAppID).AppID);

            if( _clsPerson == null || _clsLocalDrivingLicenseApp == null || _clsApplication == null) 
            {
                MessageBox.Show("you have wrong in your data please check then try again");
                return;
            }

            ctrlDriverLicenseInfo221.LoadData(_clsLocalDrivingLicenseApp);
            ctrlAppBasicInformation1.LoadData(_clsApplication);
        }

        void _RefreshAppoiment()
        {
            _dt = clsBusinessTestAppointments.GetAllDateFrom(_TestTypeID, _LDLAppID);
           dgvAppointments.DataSource = _dt;
           
            lblNumberOfRecord.Text = _dt.Rows.Count.ToString();

        }

        void _ChangeTopicData(string TitleForm, string PathImage, string TitlePage)
        {
            this.Text = TitleForm;
            picTest.Image = Image.FromFile(PathImage);
            lbltitlePage.Text = TitlePage;

        }

       void _LoadMainTopicByTestType()
        {
            switch (TestType)
            {
                case enTest.Vision:
                    {
                        _ChangeTopicData("Vision Test Appointments", @"C:\Users\lenovo\OneDrive\Desktop\BlackICON\Vision.png", "Vision Test Appointments");
                        break;
                    }
                case enTest.Written:
                    {
                        _ChangeTopicData("Written Test Appointments", @"C:\Users\lenovo\OneDrive\Desktop\BlackICON\Written.png", "Written Test Appointments");
                        break;
                    }
                    default:
                    {
                        _ChangeTopicData("Street Test Appointments", @"C:\Users\lenovo\OneDrive\Desktop\BlackICON\driving-test.png", "Street Test Appointments");
                        break;
                    }
            }

        }

        private void frmTestAppointments_Load(object sender, EventArgs e)
        {
            _LoadMainTopicByTestType();
            _RefreshAppoiment();
            _RefreshData();

            dgvAppointments.EnableHeadersVisualStyles = false;
            dgvAppointments.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
        }

        private void picAddAppointment_Click(object sender, EventArgs e)
        {
            if(clsBusinessTestAppointments.IsUserHasAppoinment(_TestTypeID, _LDLAppID))
            {

                if(MessageBox.Show("You have one appointment, Please complete your Test Appointment", "Wrong appointment", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    return;
                }

            }

            _clsTestAppointments = clsBusinessTestAppointments.FindBy(_TestTypeID, _LDLAppID);
            if(_clsTestAppointments != null)
            {
                if (clsBusinessTests.Find(_clsTestAppointments.ID).TestResult)
                {
                    if (MessageBox.Show("You are complete The Test Appointment", "Complete appointment", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        return;
                    }
                }
                
            }
            else
                _clsTestAppointments = new clsBusinessTestAppointments();

            
            frmScheduleTest scheduleTest = new frmScheduleTest(-1,_LDLAppID, _TestTypeID, false);
            scheduleTest.ShowDialog();
            _RefreshAppoiment();
            _RefreshData() ;


        }

       

        private void ctrlAppBasicInformation1_OnPersonInfo()
        {
            frmPersonDetails personDetails = new frmPersonDetails(_clsPerson.ID);
            personDetails.ShowDialog();
            _RefreshData();
        }

       

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            frmScheduleTest scheduleTest = new frmScheduleTest((int)dgvAppointments.CurrentRow.Cells[0].Value, _LDLAppID, _TestTypeID, (bool)dgvAppointments.CurrentRow.Cells[3].Value);
           
            scheduleTest.ShowDialog();
            _RefreshAppoiment();
            _RefreshData();

        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTakeTest takeTest = new frmTakeTest((int)dgvAppointments.CurrentRow.Cells[0].Value);
            takeTest.ShowDialog();
            _RefreshAppoiment();
            _RefreshData();

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dgvAppointments.CurrentRow == null)
            {
                takeTestToolStripMenuItem.Enabled = false;
                editToolStripMenuItem.Enabled = false;
                return;
            }
            else
            {
                takeTestToolStripMenuItem.Enabled = true;
                editToolStripMenuItem.Enabled = true;
            }

            if (clsBusinessTests.DoesUserHasfailure((int)dgvAppointments.CurrentRow.Cells[0].Value) || (bool)dgvAppointments.CurrentRow.Cells[3].Value)
            {
                takeTestToolStripMenuItem.Enabled = false;
            }
            else
            {
                takeTestToolStripMenuItem.Enabled = true;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlDrivingLicenseAppInfo1_OnShowLicenseInfo()
        {
            
        }

        private void ctrlDriverLicenseInfo221_OnShowLicenseInfo()
        {
            frmLicenseInfo2 licenseInfo2 = new frmLicenseInfo2(_clsApplication.AppID);
            licenseInfo2.ShowDialog();
        }
    }
}
