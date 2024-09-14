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
    public partial class frmDetainLicense : Form
    {
        public frmDetainLicense()
        {
            InitializeComponent();
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



        clsBusinessLicenses _clsCurrentLicense;
        clsBusinessDetainedLicenses _clsDetainLicenses;
        clsBusinessInternationalLicense _clsInternationalLicense;

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            ctrlDetainInfo1.LoadDetainInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void _EnableControl(bool ShowLicensesHistory, bool ShowLicensesInfo, bool DetainLicense)
        {
            llblShowLicensesHistory.Enabled = ShowLicensesHistory;
            llblShowLicensesInfo.Enabled = ShowLicensesInfo;
            btnDetain.Enabled = DetainLicense;
        }


        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory2 licenseHistory = new frmLicenseHistory2(_clsCurrentLicense.ApplicationID);
            licenseHistory.ShowDialog();
            ctrlFilterLicense1.ctrlDriverLicenseInformation1.LoadDriverLicenseInfo(_clsCurrentLicense.ApplicationID);

        }

        bool _AddNewDetainLicense()
        {
            _clsDetainLicenses = new clsBusinessDetainedLicenses();
            _clsDetainLicenses.LicenseID = _clsCurrentLicense.LicenseID;
            _clsDetainLicenses.DetainDate = DateTime.Now;
            _clsDetainLicenses.FineFees = Convert.ToDecimal(ctrlDetainInfo1.txtFineFees.Text);
            _clsDetainLicenses.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
            _clsDetainLicenses.IsReleased = false;
            return _clsDetainLicenses.Save();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(ctrlDetainInfo1.txtFineFees.Text))
            {
                if(MessageBox.Show("You must set Fine Fees", "Wrong Issue", MessageBoxButtons.OK, MessageBoxIcon.Error)== DialogResult.OK)
                {
                    return;
                }
            }
            if (MessageBox.Show("Are You sure you want Detain this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _clsCurrentLicense.IsActive = false;
                if(clsBusinessInternationalLicense.IsExists2(_clsCurrentLicense.LicenseID))
                {
                    _clsInternationalLicense = clsBusinessInternationalLicense.Find(_clsCurrentLicense.LicenseID);
                    _clsInternationalLicense.IsActive = false;
                    _clsInternationalLicense.Save();
                }
               
                if (_clsCurrentLicense.Save() && _AddNewDetainLicense())
                {
                    if (MessageBox.Show("Lincese Detained succeefully With ID [" + _clsDetainLicenses.DetainID + "]", "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        ctrlFilterLicense1.ctrlDriverLicenseInformation1.LoadDriverLicenseInfo(_clsCurrentLicense.ApplicationID);
                        ctrlDetainInfo1.LoadDetainID(_clsDetainLicenses.DetainID);
                        _EnableControl(true, true, false);
                        ctrlFilterLicense1.Enabled = false;
                        ctrlFilterLicense1.gbFilter.Enabled = true;
                        ctrlDetainInfo1.txtFineFees.Enabled = false;
                    }
                }
            }
        }

        private void llblShowNewLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
            ctrlDetainInfo1.LoadDetainInfo(_clsCurrentLicense.LicenseID);


            if (clsBusinessDetainedLicenses.IsExists(_clsCurrentLicense.LicenseID))
            {
                if (MessageBox.Show("Selected License is already detained, Choose another one.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    _EnableControl(true, false, false);
                    return;
                }
            }

            if (!clsBusinessLicenses.IsLicenseActive(_clsCurrentLicense.LicenseID))
            {
                if (MessageBox.Show("This License is not Active, Please set Active License.", "disActive License", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    _EnableControl(true, false, false);
                    ctrlFilterLicense1.ctrlDriverLicenseInformation1.DefultLoadDriverLicenseInfo();
                    return;
                }
            }



            _EnableControl(true, false, true);
        }
    }
}
