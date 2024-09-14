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
    public partial class frmInternationalDriverLicenseInfo : Form
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

        int _InternationalLicenseID;
        public frmInternationalDriverLicenseInfo(int InternationalLicenseID)
        {
            InitializeComponent();
            _InternationalLicenseID = InternationalLicenseID;
        }

        private void frmInternationalDriverLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlDriverInternationalLicenseInfo1.LoadDriverInternationalLicenseInfo(_InternationalLicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
