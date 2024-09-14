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
    public partial class frmRenewLicenseApplication2 : Form
    {
        public frmRenewLicenseApplication2()
        {
            InitializeComponent();
        }

        private void frmRenewLicenseApplication2_Load(object sender, EventArgs e)
        {
            ctrlAppNewLicenseInfo11.LoadAppNewLicenseInfo();
        }
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
        public void RadioButton_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.RadioButton_MouseEnter(sender, e);
        }
        public void RadioButton_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.RadioButton_MouseLeave(sender, e);
        }
        clsBusinessLicenses _clsLicense;
        clsBusinessApplications _clsApplications;
        clsBusinessLicenses _clsNewLicense;
        clsBusinessInternationalLicense _clsInternationalLicense;
        void _EnableControl(bool Renew, bool ShowNewLicensesInfo, bool ShowLicensesHistory)
        {
            btnRenew.Enabled = Renew;
            llblShowNewLicensesInfo.Enabled = ShowNewLicensesInfo;
            llblShowLicensesHistory.Enabled = ShowLicensesHistory;
        }
        private void ctrlFilterLicense1_onSearchLicense(clsBusinessTier.clsBusinessLicenses obj)
        {
            _clsLicense = obj;
            if (_clsLicense == null)
            {
                if (MessageBox.Show("License ID is not here, please set right ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    return;
                }

            }

            ctrlFilterLicense1.ctrlDriverLicenseInformation1.LoadDriverLicenseInfo(obj.ApplicationID);
            ctrlAppNewLicenseInfo11.LoadAppNewLicenseInfo(obj.PaidFees, obj.LicenseID, DateTime.Now.AddYears(10));


            if (clsBusinessLicenses.IsLicenseActive(obj.LicenseID))
            {
                if (MessageBox.Show($"selected License is not yet expiared, it will expire On {obj.ExpirationDate.ToString("dd/MMM/yyyy")}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    _EnableControl(false, false, true);
                    return;
                }
            }
            if (clsBusinessLicenses.IsRenewLicenseExists(clsBusinessDrivers.Find(obj.DriverID).PersonID, obj.LicenseClass))//Update it[Deleted when class=3]
            {

                if (clsBusinessLicenses.IsRenewLicenseActive(clsBusinessDrivers.Find(obj.DriverID).PersonID))
                {
                    clsBusinessLicenses RenewLicense = clsBusinessLicenses.Find(obj.DriverID, true, 2);
                    string Message;
                    if (RenewLicense != null)
                    {
                        Message = $"selected Renew License is not yet expiared, it will expire On {RenewLicense.ExpirationDate.ToString("dd/MMM/yyyy")}";
                    }
                    else
                    {
                        Message = $"selected Renew License is not yet expiared, it will expire On {obj.ExpirationDate.ToString("dd/MMM/yyyy")}";
                    }
                    if (MessageBox.Show(Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                    {
                        _EnableControl(false, false, true);
                        return;
                    }
                }

            }


            _EnableControl(true, false, true);

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      
        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory2 licenseHistory = new frmLicenseHistory2(_clsLicense.ApplicationID);
            licenseHistory.ShowDialog();
            ctrlFilterLicense1.ctrlDriverLicenseInformation1.LoadDriverLicenseInfo(_clsLicense.ApplicationID);
        }
        bool AddNewApp()
        {
            _clsApplications = new clsBusinessApplications();
            _clsApplications.PersonID = clsBusinessDrivers.Find(_clsLicense.DriverID).PersonID;
            _clsApplications.AppDate = DateTime.Now;
            _clsApplications.AppTypeID = 2;
            _clsApplications.AppStatus = 3;
            _clsApplications.LastStatusDate = DateTime.Now;
            _clsApplications.PaidFees = clsBusinessApplicationTypes.Find(_clsApplications.AppTypeID).ApplicationFees;
            _clsApplications.UserID = clsGlobalSettings.CurrentUser.UserID;
            return _clsApplications.Save();
        }
        bool _AddNewLicense()
        {
            _clsNewLicense = new clsBusinessLicenses();
            _clsNewLicense.ApplicationID = _clsApplications.AppID;
            _clsNewLicense.DriverID = _clsLicense.DriverID;
            _clsNewLicense.LicenseClass = _clsLicense.LicenseClass;
            _clsNewLicense.IssueDate = DateTime.Now;
            _clsNewLicense.ExpirationDate = DateTime.Now.AddYears(10);
            if (string.IsNullOrEmpty(ctrlAppNewLicenseInfo11.txtNotes.Text))
            {
                _clsNewLicense.Notes = null;
            }
            else
            {
                _clsNewLicense.Notes = ctrlAppNewLicenseInfo11.txtNotes.Text;
            }
            _clsNewLicense.PaidFees = _clsLicense.PaidFees;
            _clsNewLicense.IsActive = true;
            _clsNewLicense.IssueReason = 2;
            _clsNewLicense.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;

            return _clsNewLicense.Save();
        }
        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure you want Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _clsLicense.IsActive = false;
                _clsInternationalLicense = clsBusinessInternationalLicense.Find(_clsLicense.LicenseID);
               
                if (_clsLicense.Save() && AddNewApp() && _AddNewLicense())
                {
                    if (_clsInternationalLicense != null)
                    {
                        _clsInternationalLicense.IssuedUsingLocalLicenseID = _clsNewLicense.LicenseID;
                        _clsInternationalLicense.Save();
                    }
                    if (MessageBox.Show("Lincese Renewed succeefully With ID [" + _clsNewLicense.LicenseID + "]", "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        ctrlAppNewLicenseInfo11.LoadAppNewLicenseInfo(_clsApplications.AppID, _clsNewLicense.LicenseID);
                        _EnableControl(false, true, true);
                        ctrlFilterLicense1.Enabled = false;
                        ctrlFilterLicense1.ctrlDriverLicenseInformation1.Enabled = true;
                    }

                }
            }
        }
        public void llblShowNewLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo2 licenseInfo2 = new frmLicenseInfo2(_clsNewLicense.ApplicationID);
            licenseInfo2.ShowDialog();
        }
    }
}
