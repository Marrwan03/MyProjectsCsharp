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
    public partial class ctrlReleaseInfo : UserControl
    {
        public ctrlReleaseInfo()
        {
            InitializeComponent();
        }
        public void Label_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.Label_MouseEnter(sender, e);
        }

        public void Label_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.Label_MouseLeave(sender, e);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


       public void LoadReleaseInfo()
        {
            lblDetainID.Text = "[???]";
            lblDetainDate.Text = "[???]";
            lblAppFees.Text = "[???]";
            lblTotalFees.Text = "[???]";
            lblReleaseDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblLicenseID.Text = "[???]";
            lblDetainBy.Text = "[???]";
            lblFineFees.Text = "[???]";
            lblAppID.Text = "[???]";
            lblReleaseBy.Text = clsGlobalSettings.CurrentUser.Username;
        }

        public void LoadReleaseInfo(clsBusinessDetainedLicenses DetainLicense)
        {
            decimal AppFees = clsBusinessApplicationTypes.Find(5).ApplicationFees;
            lblDetainID.Text = DetainLicense.DetainID.ToString();
            lblDetainDate.Text = DetainLicense.DetainDate.ToString("dd/MMM/yyyy");
            lblAppFees.Text = Convert.ToInt32(AppFees).ToString();
            lblTotalFees.Text = Convert.ToInt32(DetainLicense.FineFees + AppFees).ToString();
            lblDetainBy.Text = clsBusinessUsers.Find(DetainLicense.CreatedByUserID).Username;
            lblFineFees.Text = Convert.ToInt32(DetainLicense.FineFees).ToString();
        }

        public void LoadReleaseInfo(int ApplicationID)
        {
            lblAppID.Text = ApplicationID.ToString();
        }

        public void LoadReleaseInfo(int LicenseID, bool FillLicenseID=true)
        {
           lblLicenseID.Text = LicenseID.ToString();
        }

        private void ctrlReleaseInfo_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
