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
    public partial class frmReplacementforDamagedorLostLicenses22 : Form
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

        public void RadioButton_MouseEnter(object sender, EventArgs e)
        {
           clsColorControl.RadioButton_MouseEnter(sender, e);
        }
        public void RadioButton_MouseLeave(object sender, EventArgs e)
        {
           clsColorControl.RadioButton_MouseLeave(sender, e);
        }

        public frmReplacementforDamagedorLostLicenses22()
        {
            InitializeComponent();
        }

        private void frmReplacementforDamagedorLostLicenses22_Load(object sender, EventArgs e)
        {
            rbDamageLicense.Checked = true;
            _AppType = 4;
            ctrlAppInfoForLicenseRep21.DefultLoadAppInfoForLicenseRep(_AppType);
        }

        clsBusinessLicenses _clsCurrentLicense;
        clsBusinessLicenses _clsRepLicense;
        clsBusinessApplications _clsApplications;
        clsBusinessInternationalLicense _clsInternationalLicense;
        clsBusinessDetainedLicenses _clsDetainedLicenses;
        int _AppType = 0;
        void RadioButton_CheckedChanged(object sender, EventArgs e)
        {

            if (rbDamageLicense.Checked)
            {
                lblTitlePage.Text = "Replacement for Damage License";
                _AppType = 4;
            }
            else
            {
                lblTitlePage.Text = "Replacement for Lost License";
                _AppType = 3;
            }
            this.Text = lblTitlePage.Text;
            ctrlAppInfoForLicenseRep21.DefultLoadAppInfoForLicenseRep(_AppType);
        }
        void _EnableControl(bool ShowLicensesHistory, bool ShowNewLicensesInfo, bool IssueRep)
        {
            llblShowLicensesHistory.Enabled = ShowLicensesHistory;
            llblShowNewLicensesInfo.Enabled = ShowNewLicensesInfo;
            btnIssueRep.Enabled = IssueRep;
        }
       
        private void ctrlFilterLicense1_onSearchLicense(clsBusinessTier.clsBusinessLicenses obj)
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
            ctrlAppInfoForLicenseRep21.LoadAppInfoForLicenseRep(_clsCurrentLicense.LicenseID);

            if (!clsBusinessLicenses.IsLicenseActive(_clsCurrentLicense.LicenseID))
            {
                if (MessageBox.Show("This License is not Active, Please set Active License.", "disActive License", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    _EnableControl(true, false, false);
                    return;
                }
            }


            _EnableControl(true, false, true);
        }
        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory2 licenseHistory = new frmLicenseHistory2(_clsCurrentLicense.ApplicationID);
            licenseHistory.ShowDialog();
            ctrlFilterLicense1.ctrlDriverLicenseInformation1.LoadDriverLicenseInfo(_clsCurrentLicense.ApplicationID);
        }
        private void llblShowNewLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo2 licenseInfo2 = new frmLicenseInfo2(_clsRepLicense.ApplicationID);
            licenseInfo2.ShowDialog();
        }
        bool _AddNewApp()
        {
            _clsApplications = new clsBusinessApplications();
            _clsApplications.PersonID = clsBusinessDrivers.Find(_clsCurrentLicense.DriverID).PersonID;
            _clsApplications.AppDate = DateTime.Now;
            _clsApplications.AppTypeID = _AppType;
            _clsApplications.AppStatus = 3;
            _clsApplications.LastStatusDate = DateTime.Now;
            _clsApplications.PaidFees = clsBusinessApplicationTypes.Find(_clsApplications.AppTypeID).ApplicationFees;
            _clsApplications.UserID = clsGlobalSettings.CurrentUser.UserID;
            return _clsApplications.Save();
        }
        bool _AddNewLicense()
        {
            _clsRepLicense = new clsBusinessLicenses();
            _clsRepLicense.ApplicationID = _clsApplications.AppID;
            _clsRepLicense.DriverID = _clsCurrentLicense.DriverID;
            _clsRepLicense.LicenseClass = _clsCurrentLicense.LicenseClass;
            _clsRepLicense.IssueDate = DateTime.Now;
            _clsRepLicense.ExpirationDate = DateTime.Now.AddYears(10);
            _clsRepLicense.Notes = null;
            _clsRepLicense.PaidFees = 0;
            _clsRepLicense.IsActive = true;
            _clsRepLicense.IssueReason = _AppType;
            _clsRepLicense.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;

            return _clsRepLicense.Save();
        }
        private void btnIssueRep_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure you want Replacement the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _clsCurrentLicense.IsActive = false;

                _clsInternationalLicense = clsBusinessInternationalLicense.Find(_clsCurrentLicense.LicenseID);


                if (_clsCurrentLicense.Save() && _AddNewApp() && _AddNewLicense())
                {
                    if (clsBusinessDetainedLicenses.IsExists(_clsCurrentLicense.LicenseID))
                    {
                        _clsDetainedLicenses = clsBusinessDetainedLicenses.Find(_clsCurrentLicense.LicenseID);
                        _clsDetainedLicenses.LicenseID = _clsRepLicense.LicenseID;
                    }

                    if (_clsInternationalLicense != null)
                    {
                        _clsInternationalLicense.IssuedUsingLocalLicenseID = _clsRepLicense.LicenseID;
                        _clsInternationalLicense.Save();
                    }


                    if (MessageBox.Show("Lincese Replace succeefully With ID [" + _clsRepLicense.LicenseID + "]", "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        ctrlAppInfoForLicenseRep21.LoadAppInfoForLicenseRep(_clsApplications.AppID, _clsRepLicense.LicenseID);
                        _EnableControl(true, true, false);
                        ctrlFilterLicense1.Enabled = false;
                        ctrlFilterLicense1.ctrlDriverLicenseInformation1.Enabled = true;
                        gbReplacement.Enabled = false;
                    }


                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
