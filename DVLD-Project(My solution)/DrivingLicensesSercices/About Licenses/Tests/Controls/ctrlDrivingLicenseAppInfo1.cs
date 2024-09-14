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
    public partial class ctrlDrivingLicenseAppInfo : UserControl
    {
        public void Label_MouseEnter(object sender, EventArgs e)
        {
           clsColorControl.Label_MouseEnter(sender, e);
        }

        public void Label_MouseLeave(object sender, EventArgs e)
        {
           clsColorControl.Label_MouseLeave(sender, e);
        }



        public event Action OnShowLicenseInfo;
        protected virtual void ShowLicenseInfo()
        {
            if (OnShowLicenseInfo != null)
                OnShowLicenseInfo();
        }

        public ctrlDrivingLicenseAppInfo()
        {
            InitializeComponent();
        }

       public void LoadData(clsBusinessMYLocalDrivingLicenseApplications_View localDrivingLicense)
        {
            lblDLAppID.Text = localDrivingLicense.ID.ToString();
            lblLicenseClass.Text = localDrivingLicense.ClassName;
            lblPastedTests.Text = localDrivingLicense.PastedTests.ToString() + "/3";
        }

        private void ctrlDrivingLicenseAppInfo_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (OnShowLicenseInfo != null)
                OnShowLicenseInfo();
        }
    }
}
