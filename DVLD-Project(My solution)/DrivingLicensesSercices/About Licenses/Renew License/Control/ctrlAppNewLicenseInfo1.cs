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
    public partial class ctrlAppNewLicenseInfo1 : UserControl
    {
        public void Label_MouseEnter(object sender, EventArgs e)
        {
           clsColorControl.Label_MouseEnter(sender, e);
        }

        public void Label_MouseLeave(object sender, EventArgs e)
        {
           clsColorControl.Label_MouseLeave(sender, e);
        }

        public ctrlAppNewLicenseInfo1()
        {
            InitializeComponent();
        }

        private void ctrlAppNewLicenseInfo1_Load(object sender, EventArgs e)
        {



        }



        decimal _AppFees;
        public void LoadAppNewLicenseInfo()
        {
            lblAppDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblIssueDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");

            _AppFees = clsBusinessApplicationTypes.Find(2).ApplicationFees;
            lblAppFees.Text = Convert.ToInt32(clsBusinessApplicationTypes.Find(2).ApplicationFees).ToString();
            lblCreatedBy.Text = clsGlobalSettings.CurrentUser.Username;
        }
        public void LoadAppNewLicenseInfo(decimal LicenseFees, int OldLicenseID, DateTime ExpDate)
        {
            lblLicenseFees.Text = Convert.ToInt32(LicenseFees).ToString();
            lblOldLicenseID.Text = OldLicenseID.ToString();
            lblExpDate.Text = ExpDate.ToString("dd/MMM/yyyy");
            lblTotalFees.Text = Convert.ToInt32(clsBusinessApplicationTypes.Find(2).ApplicationFees + LicenseFees).ToString();

        }
        public void LoadAppNewLicenseInfo(int RLAppID, int RenewLicenseID)
        {
            lblRLApplicationID.Text = RLAppID.ToString();
            lblRLicenseID.Text = RenewLicenseID.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
