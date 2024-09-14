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
    public partial class ctrlAppInfoForLicenseRep2 : UserControl
    {
        public  void Label_MouseEnter(object sender, EventArgs e)
        {
           clsColorControl.Label_MouseEnter(sender, e);
        }

        public  void Label_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.Label_MouseLeave(sender, e);
        }


        public ctrlAppInfoForLicenseRep2()
        {
            InitializeComponent();
        }

        private void ctrlAppInfoForLicenseRep2_Load(object sender, EventArgs e)
        {

        }

        public void DefultLoadAppInfoForLicenseRep(int AppType)
        {
            lblLRAppID.Text = "[???]";
            lblAppDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblAppFees.Text = Convert.ToInt32(clsBusinessApplicationTypes.Find(AppType).ApplicationFees).ToString();
            lblRepLicenseID.Text = "[???]";
            lblOldLicenseID.Text = "[???]";
            lblCreatedBy.Text = clsGlobalSettings.CurrentUser.Username;
        }
        public void LoadAppInfoForLicenseRep(int OldLicenseID)
        {
            lblOldLicenseID.Text = OldLicenseID.ToString();
        }
        public void LoadAppInfoForLicenseRep(int LRAppID, int RepLicenseID)
        {
            lblLRAppID.Text = LRAppID.ToString();
            lblRepLicenseID.Text = RepLicenseID.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
