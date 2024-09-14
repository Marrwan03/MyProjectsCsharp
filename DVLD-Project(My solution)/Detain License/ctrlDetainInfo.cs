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
    public partial class ctrlDetainInfo : UserControl
    {
        public  void Label_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.Label_MouseEnter(sender, e);
        }

        public  void Label_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.Label_MouseLeave(sender, e);
        }
        public  void TextBox_MouseEnter(object sender, EventArgs e)
        {
          clsColorControl.TextBox_MouseEnter(sender, e);
        }
        public  void TextBox_MouseLeave(object sender, EventArgs e)
        {
          clsColorControl.TextBox_MouseLeave(sender, e);
        }


        public ctrlDetainInfo()
        {
            InitializeComponent();
        }

        string _Lasttxt=string.Empty;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(!clsTextProcessing.TextHasLetter(txtFineFees.Text))
            {
                _Lasttxt=txtFineFees.Text;
            }
            txtFineFees.Text = _Lasttxt;
            txtFineFees.SelectionStart = txtFineFees.Text.Length;

        }

        public void LoadDetainInfo()
        {

            lblDetainDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblCreatedBy.Text = clsGlobalSettings.CurrentUser.Username;

        }

        public void LoadDetainInfo(int LicenseID)
        {
            lblLicenseID.Text = LicenseID.ToString();
        }

        public void LoadDetainID(int DetainID)
        {
            lblDetainID.Text = DetainID.ToString();
        }

        private void ctrlDetainInfo_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
