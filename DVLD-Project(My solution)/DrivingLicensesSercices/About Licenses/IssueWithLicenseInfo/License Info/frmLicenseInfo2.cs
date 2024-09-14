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
    public partial class frmLicenseInfo2 : Form
    {
        int _AppID;
        public frmLicenseInfo2(int appID)
        {
            InitializeComponent();
            this._AppID = appID;
        }

        private void frmLicenseInfo2_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInformation1.LoadDriverLicenseInfo(_AppID);
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
     
      
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
