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
    public partial class ctrlApplicationInfo : UserControl
    {
        public void Label_MouseEnter(object sender, EventArgs e)
        {
           clsColorControl.Label_MouseEnter(sender, e);
        }

        public void Label_MouseLeave(object sender, EventArgs e)
        {
           clsColorControl.Label_MouseLeave(sender, e);
        }

        public ctrlApplicationInfo()
        {
            InitializeComponent();
        }

        public void LoadApplicationInfo()
        {
            lblAppDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblIsuueDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToString("dd/MMM/yyyy");
            lblFees.Text = ((int)clsBusinessApplicationTypes.Find(5).ApplicationFees).ToString();
            lblCreatedBy.Text = clsGlobalSettings.CurrentUser.Username;
        }

        public void LoadApplicationInfo(int LocalLicenseID)
        {
            if( LocalLicenseID == -1 )
            {
                lblLocalLicenseID.Text = "[???]";
            }
            else

            {
                lblLocalLicenseID.Text = LocalLicenseID.ToString();
            }
           
        }

        public void LoadApplicationInfo(int ILAppID, int ILLicenseID)
        {
            if( ILAppID == -1 && ILLicenseID == -1 )
            {
                lblILAppID.Text = "[???]";
                lblILLicenseID.Text = "[???]";
            }
            else
            {
                lblILAppID.Text = ILAppID.ToString();
                lblILLicenseID.Text = ILLicenseID.ToString();
            }
           

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
