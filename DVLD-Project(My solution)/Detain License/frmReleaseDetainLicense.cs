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
    public partial class frmReleaseDetainLicense : Form
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



        int _LicenseID;

        public frmReleaseDetainLicense(int LicenseID)
        {
            InitializeComponent();
           
            _LicenseID = LicenseID;
        }

        clsBusinessLicenses _clsCurrentLicense;
        clsBusinessDetainedLicenses _clsDetainedLicense;
        clsBusinessApplications _clsApp;
        clsBusinessInternationalLicense _clsInternationalLicense;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void _EnableControl(bool ShowLicensesHistory, bool ShowLicensesInfo, bool ReleaseLicense)
        {
            llblShowLicensesHistory.Enabled = ShowLicensesHistory;
            llblShowLicensesInfo.Enabled = ShowLicensesInfo;
            btnRelease.Enabled = ReleaseLicense;
        }

        private void frmReleaseDetainLicense_Load(object sender, EventArgs e)
        {
            if(_LicenseID != -1)
            {
                _clsCurrentLicense = clsBusinessLicenses.Find(_LicenseID, true);
                _clsDetainedLicense = clsBusinessDetainedLicenses.Find(_clsCurrentLicense.LicenseID);

                ctrlFilterLicense1.txtLicenseID.Text = _clsCurrentLicense.LicenseID.ToString();
                ctrlFilterLicense1.ctrlDriverLicenseInformation1.LoadDriverLicenseInfo(_clsCurrentLicense.ApplicationID);
                ctrlReleaseInfo1.LoadReleaseInfo();
                ctrlReleaseInfo1.LoadReleaseInfo(_clsCurrentLicense.LicenseID, true);
                ctrlReleaseInfo1.LoadReleaseInfo(clsBusinessDetainedLicenses.Find(_clsCurrentLicense.LicenseID));
                ctrlFilterLicense1.gbFilter.Enabled = false;
                _EnableControl(true, false, true);
            }
            else
            {
                ctrlReleaseInfo1.LoadReleaseInfo();
            }
           
        }

    

        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory2 licenseHistory = new frmLicenseHistory2(_clsCurrentLicense.ApplicationID);
            licenseHistory.ShowDialog();

        }

        bool _NewApplication()
        {
            _clsApp = new clsBusinessApplications();
            _clsApp.PersonID = clsBusinessDrivers.Find(_clsCurrentLicense.DriverID).PersonID;
            _clsApp.AppDate = DateTime.Now;
            _clsApp.AppTypeID = 5;
            _clsApp.AppStatus = 3;
            _clsApp.LastStatusDate = DateTime.Now;
            _clsApp.PaidFees = clsBusinessApplicationTypes.Find(_clsApp.AppTypeID).ApplicationFees;
            _clsApp.UserID = clsGlobalSettings.CurrentUser.UserID;
            return _clsApp.Save();
        }

        bool _ReleaseDetain()
        {
            
            _clsDetainedLicense.IsReleased = true;
            _clsDetainedLicense.ReleasedDate = DateTime.Now;
            _clsDetainedLicense.ReleasedByUserID = clsGlobalSettings.CurrentUser.UserID;
            _clsDetainedLicense.ReleasedByAppID = _clsApp.AppID;
            return _clsDetainedLicense.Save();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            ctrlFilterLicense1.ctrlDriverLicenseInformation1.LoadDriverLicenseInfo(_clsCurrentLicense.ApplicationID);
            if (MessageBox.Show("Are You sure you want Replease this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               _clsCurrentLicense.IsActive = true;

                if (clsBusinessInternationalLicense.IsExists2(_clsCurrentLicense.LicenseID))
                {
                    _clsInternationalLicense = clsBusinessInternationalLicense.Find(_clsCurrentLicense.LicenseID);
                    _clsInternationalLicense.IsActive = true;
                    _clsInternationalLicense.Save();
                }


                if (_clsCurrentLicense.Save() && _NewApplication() && _ReleaseDetain())
                {
                    if(MessageBox.Show("Detained License released successfully.", "Detained License Released", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        ctrlFilterLicense1.ctrlDriverLicenseInformation1.LoadDriverLicenseInfo(_clsCurrentLicense.ApplicationID);
                        ctrlReleaseInfo1.LoadReleaseInfo(_clsApp.AppID);
                        _EnableControl(true, true, false);
                        ctrlFilterLicense1.gbFilter.Enabled = false;
                    }
                }

            }
        }

        private void llblShowLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo2 licenseInfo2 = new frmLicenseInfo2(_clsCurrentLicense.ApplicationID);
            licenseInfo2.ShowDialog();

        }

        private void ctrlFilterLicense1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlFilterLicense1_onSearchLicense_1(clsBusinessLicenses obj)
        {
            _clsCurrentLicense = obj;


            if (_clsCurrentLicense == null)
            {
                if (MessageBox.Show("This License ID is not Found, Please set another ID.", "Wrong License ID", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    _EnableControl(false, false, false);
                    ctrlFilterLicense1.ctrlDriverLicenseInformation1.DefultLoadDriverLicenseInfo();
                    return;
                }

            }

            ctrlFilterLicense1.ctrlDriverLicenseInformation1.LoadDriverLicenseInfo(_clsCurrentLicense.ApplicationID);
            ctrlReleaseInfo1.LoadReleaseInfo(_clsCurrentLicense.LicenseID, true);


            if (!clsBusinessDetainedLicenses.IsExists(_clsCurrentLicense.LicenseID))
            {
                if (MessageBox.Show("Selected License is not detained, Choose another one.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    ctrlReleaseInfo1.LoadReleaseInfo();
                    _EnableControl(true, false, false);
                    return;
                }
            }
            _clsDetainedLicense = clsBusinessDetainedLicenses.Find(_clsCurrentLicense.LicenseID);
            ctrlReleaseInfo1.LoadReleaseInfo(_clsDetainedLicense);

            _EnableControl(true, false, true);
        }
    }
}
