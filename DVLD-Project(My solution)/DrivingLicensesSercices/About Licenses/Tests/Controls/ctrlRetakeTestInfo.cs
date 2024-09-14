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
    public partial class ctrlRetakeTestInfo : UserControl
    {
        public void Label_MouseEnter(object sender, EventArgs e)
        {
           clsColorControl.Label_MouseEnter(sender, e);
        }

        public void Label_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.Label_MouseLeave(sender, e);
        }


        public ctrlRetakeTestInfo()
        {
            InitializeComponent();
        }

        public void LoadRetakeTestInfo(string TotalFees)
        {
            lbltotalFees.Text = TotalFees;
            lblRAppFees.Text = "0";
            lblRTestAppID.Text = "N/A";

        }

        public void LoadRetakeTestInfo(clsBusinessRetakeTestAppointment RetaketestApp, bool BeforeSave)
        {
            if (BeforeSave)
            {
                lblRTestAppID.Text = "N/A";
            }
            else
            {
                lblRTestAppID.Text = RetaketestApp.TestAppID.ToString();
            }
            lblRAppFees.Text = Convert.ToInt32(RetaketestApp.FeesRetake).ToString();
            lbltotalFees.Text = Convert.ToInt32(RetaketestApp.TotalFees).ToString();
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
