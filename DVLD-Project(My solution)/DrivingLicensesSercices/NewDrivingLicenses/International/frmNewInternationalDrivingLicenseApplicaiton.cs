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
    public partial class frmNewInternationalDrivingLicenseApplicaiton : Form
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


        public frmNewInternationalDrivingLicenseApplicaiton()
        {
            InitializeComponent();
        }

        clsBusinessInternationalLicense _clsinternationalLicense;
        clsBusinessApplications _clsbusinessApplications;
        clsBusinessLicenses _clsbusinessLicenses;
       

        void EnableButton(bool Issue, bool ShowLicenseHistory, bool ShowLicensesInfo)
        {
            btnIssue.Enabled = Issue;
            llblShowLicensesHistory.Enabled = ShowLicenseHistory;
            llblShowLicensesInfo.Enabled = ShowLicensesInfo;
        }

        private void ctrlFilterLicense1_onSearchLicense(clsBusinessTier.clsBusinessLicenses obj)
        {
            
            _clsbusinessLicenses = obj;
            if (obj == null)
            {
                if(MessageBox.Show("License ID is not here, please set right ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)== DialogResult.OK)
                {
                    ctrlApplicationInfo1.LoadApplicationInfo(-1);
                    EnableButton(false, false, false);
                    return;
                }
                
            }
            EnableButton(false, true, false);
            ctrlApplicationInfo1.LoadApplicationInfo(obj.LicenseID);
            _clsinternationalLicense = clsBusinessInternationalLicense.Find(obj.LicenseID);

            ctrlFilterLicense1.ctrlDriverLicenseInformation1.LoadDriverLicenseInfo(obj.ApplicationID);

            if (!clsBusinessLicenses.IsLicenseActive(obj.LicenseID, true))
            {
                if (MessageBox.Show("Your License is not active,\nOr Your license is finish,\nOr Your license must be in LicenseClass [3].", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    EnableButton(false, true, false);
                    return;
                }
            }
            else
            {
                if(_clsinternationalLicense != null) 
                {
                    if (MessageBox.Show($"Person already have international License with ID={_clsinternationalLicense.IssuedUsingLocalLicenseID}.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                    {
                        EnableButton(false, true, true);
                        return;
                    }
                }
              
               EnableButton(true, true, false);
            }
            
        }

        private void frmNewInternationalDrivingLicenseApplicaiton_Load(object sender, EventArgs e)
        {
            EnableButton(false, false, false);
            ctrlApplicationInfo1.LoadApplicationInfo();
        }

        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory2 licenseHistory = new frmLicenseHistory2(clsBusinessLicenses.Find(_clsbusinessLicenses.LicenseID, true).ApplicationID);
            licenseHistory.ShowDialog();
            ctrlFilterLicense1.ctrlDriverLicenseInformation1.LoadDriverLicenseInfo(clsBusinessLicenses.Find(_clsbusinessLicenses.LicenseID, true).ApplicationID);
        }

        bool _AddNewApplication()
        {
            _clsbusinessApplications = new clsBusinessApplications();
            _clsbusinessApplications.PersonID = clsBusinessDrivers.Find(_clsbusinessLicenses.DriverID).PersonID;
            _clsbusinessApplications.AppDate = DateTime.Now;
            _clsbusinessApplications.AppTypeID = 6;
            _clsbusinessApplications.AppStatus = 3;
            _clsbusinessApplications.LastStatusDate = DateTime.Now;
            _clsbusinessApplications.PaidFees = clsBusinessApplicationTypes.Find(_clsbusinessApplications.AppTypeID).ApplicationFees;
            _clsbusinessApplications.UserID = clsGlobalSettings.CurrentUser.UserID;
            return _clsbusinessApplications.Save();
        }

        bool _AddNewInternationalLicense()
        {
            _clsinternationalLicense = new clsBusinessInternationalLicense();
            _clsinternationalLicense.ApplicationID = _clsbusinessApplications.AppID;
            _clsinternationalLicense.DriverID = _clsbusinessLicenses.DriverID;
            _clsinternationalLicense.IssuedUsingLocalLicenseID = _clsbusinessLicenses.LicenseID;
            _clsinternationalLicense.IssueDate = DateTime.Now;
            _clsinternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            _clsinternationalLicense.IsActive = _clsbusinessLicenses.IsActive;
            _clsinternationalLicense.CreatedByUserID = _clsbusinessApplications.UserID;
            return _clsinternationalLicense.Save();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if(_clsinternationalLicense != null)
            {
                if (clsBusinessInternationalLicense.IsExists(_clsinternationalLicense.InternationalLicenseID))
                {
                    if (MessageBox.Show("This License alreadey has an Active International License", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                    {
                        EnableButton(false, true, true);
                        return;
                    }
                }
            }
           
            if(_AddNewApplication() && _AddNewInternationalLicense())
            {
                if(MessageBox.Show("International added succeefully", "Succeefully :-)",MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    ctrlApplicationInfo1.LoadApplicationInfo(_clsbusinessApplications.AppID, _clsinternationalLicense.InternationalLicenseID);
                    EnableButton(true, true, true);
                }
               
            }
        }

        private void llblShowLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInternationalDriverLicenseInfo internationalDriverLicenseInfo = new frmInternationalDriverLicenseInfo(_clsinternationalLicense.InternationalLicenseID);
            internationalDriverLicenseInfo.ShowDialog();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
