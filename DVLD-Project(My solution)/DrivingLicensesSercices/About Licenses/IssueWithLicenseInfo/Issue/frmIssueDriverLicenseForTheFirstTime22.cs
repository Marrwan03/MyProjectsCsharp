using clsBusinessTier.View;
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
    public partial class frmIssueDriverLicenseForTheFirstTime22 : Form
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
        public void TextBox_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.TextBox_MouseEnter(sender, e);
        }
        public void TextBox_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.TextBox_MouseLeave(sender, e);
        }
    
        clsBusinessMYLocalDrivingLicenseApplications_View _clsLDLAppView;//A
        clsBusinessLocalDrivingLicenseApplications _clsLDLApp;//A
        clsBusinessApplications _clsApp;//A
        clsBusinessUsers _clsUser;
        clsBusinessDrivers _clsDrivers;//A
        clsBusinessLicenses _clsLicenses;//A

        int _LDLAppID;
        public frmIssueDriverLicenseForTheFirstTime22(int lDLAppID)
        {
            InitializeComponent();
            _LDLAppID = lDLAppID;
        }
        void _RefreshData()
        {
            _clsLDLAppView = clsBusinessMYLocalDrivingLicenseApplications_View.Find(_LDLAppID);
            _clsApp = clsBusinessApplications.Find(clsBusinessLocalDrivingLicenseApplications.FindByLDLAppID(_LDLAppID).AppID);
            ctrlAppBasicInformation1.LoadData(_clsApp);
            ctrlDriverLicenseAppInfo221.LoadData(_clsLDLAppView);
        }
        //private void frmIssueDriverLicenseForTheFirstTime_Load(object sender, EventArgs e)
        //{
        //    _RefreshData();
        //}
        private void ctrlAppBasicInformation1_OnPersonInfo()
        {
            frmPersonDetails personDetails = new frmPersonDetails(_clsApp.PersonID);
            personDetails.ShowDialog();
            _RefreshData();
        }
        bool _AddNewDriver()
        {
            _clsDrivers = new clsBusinessDrivers();
            _clsDrivers.PersonID = _clsApp.PersonID;
            _clsDrivers.CreatedByUserID = _clsApp.UserID;
            _clsDrivers.CreatedDate = DateTime.Now;
            return _clsDrivers.Save();
        }
        bool _AddNewLicense()
        {
            _clsLicenses = new clsBusinessLicenses();
            _clsLicenses.ApplicationID = _clsLDLApp.AppID;
            _clsLicenses.DriverID = _clsDrivers.DriverID;
            _clsLicenses.LicenseClass = _clsLDLApp.LicenseClassID;
            _clsLicenses.IssueDate = DateTime.Now;
            _clsLicenses.ExpirationDate = DateTime.Now.AddYears(clsBusinessLicenseClasses.Find(_clsLicenses.LicenseClass).DefaultValidityLength);
            _clsLicenses.Notes = txtNotes.Text;
            _clsLicenses.PaidFees = _clsApp.PaidFees;
            _clsLicenses.IsActive = _clsUser.IsActive;
            _clsLicenses.IssueReason = 1;
            _clsLicenses.CreatedByUserID = _clsApp.UserID;
            return _clsLicenses.Save();
        }
        private void btnIssue_Click(object sender, EventArgs e)
        {
            _clsLDLApp = clsBusinessLocalDrivingLicenseApplications.Find(_clsApp.AppID);
            _clsUser = clsBusinessUsers.Find(_clsApp.UserID);

            if (_AddNewDriver() && _AddNewLicense())
            {

                if (clsBusinessLicenses.IsExists(_clsApp.AppID))
                {
                    _clsApp.AppStatus = 3;
                    if (_clsApp.Save())
                    {
                        if (MessageBox.Show($"License issue succeefully With license ID = {_clsLicenses.LicenseID.ToString()}", "succeefully", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                          btnIssue.Enabled = false;
                            txtNotes.Enabled = false;
                        }

                    }
                }

            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIssueDriverLicenseForTheFirstTime22_Load(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void ctrlDriverLicenseAppInfo221_OnShowLicenseInfo()
        {
            frmLicenseInfo2 licenseInfo2 = new frmLicenseInfo2(_clsApp.AppID);
            licenseInfo2.ShowDialog();

        }
    }
}
