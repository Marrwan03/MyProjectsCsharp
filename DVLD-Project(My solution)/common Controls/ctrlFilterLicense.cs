using clsBusinessTier;
using MyLibrary;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class ctrlFilterLicense : UserControl
    {
        public event Action<clsBusinessLicenses> onSearchLicense;
        protected virtual void SearchLicense(clsBusinessLicenses clsLicense)
        {
            if(onSearchLicense != null)
                onSearchLicense(clsLicense);
        }

        public void Label_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.Label_MouseEnter(sender, e);
        }

        public void Label_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.Label_MouseLeave(sender, e);
        }
        public void TextBox_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.TextBox_MouseEnter(sender, e);
        }
        public void TextBox_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.TextBox_MouseLeave(sender, e);
        }


        public ctrlFilterLicense()
        {
            InitializeComponent();
        }
        clsBusinessLicenses _clsLicense;
        string _LastString;
        private void txtLicenseID_TextChanged(object sender, EventArgs e)
        {
            if(!clsTextProcessing.TextHasLetter(txtLicenseID.Text))
            {
                _LastString = txtLicenseID.Text;
            }
            txtLicenseID.Text = _LastString;
            txtLicenseID.SelectionStart = txtLicenseID.Text.Length;
        }

        private void picFilter_Click(object sender, EventArgs e)
        {
            _clsLicense = clsBusinessLicenses.Find(int.Parse(txtLicenseID.Text), true);
            if(onSearchLicense!=null)
            {
                SearchLicense(_clsLicense);
            }

        }

        private void ctrlDriverLicenseInfo1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlFilterLicense_Load(object sender, EventArgs e)
        {

        }
    }
}
