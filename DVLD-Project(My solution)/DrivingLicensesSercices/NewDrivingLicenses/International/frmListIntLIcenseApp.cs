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
    public partial class frmListIntLIcenseApp : Form
    {
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

        public  void RadioButton_MouseEnter(object sender, EventArgs e)
        {
           clsColorControl.RadioButton_MouseEnter(sender, e);
        }
        public  void RadioButton_MouseLeave(object sender, EventArgs e)
        {
           clsColorControl.RadioButton_MouseLeave(sender, e);
        }
        public void TextBox_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.TextBox_MouseEnter(sender, e);
        }
        public void TextBox_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.TextBox_MouseLeave(sender, e);
        }

        public void ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
           clsColorControl.ToolStripMenuItem_MouseEnter(sender, e);
        }
        public void ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
           clsColorControl.ToolStripMenuItem_MouseLeave(sender, e);
        }

        public frmListIntLIcenseApp()
        {
            InitializeComponent();
        }
        DataTable _dtIntLicenseApp;
        
        DataView _dvIntLicenseApp;

        void _RefreshData()
        {
           
            _dtIntLicenseApp = clsBusinessInternationalLicense.GetAllinternationalLicenses();
            _dvIntLicenseApp = _dtIntLicenseApp.DefaultView;
            dgvIntLicenseApp.DataSource = _dtIntLicenseApp;
        }

        void _RefreshData(bool UsingFilter)
        {
            if(UsingFilter)
            {
                dgvIntLicenseApp.DataSource = _dvIntLicenseApp;
            }
            else
            {
                dgvIntLicenseApp.DataSource= _dtIntLicenseApp;
            }
            lblNumberOfRecord.Text = dgvIntLicenseApp.RowCount.ToString();
        }

        

        private void frmListIntLIcenseApp_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            _RefreshData();
            _RefreshData(false);


            dgvIntLicenseApp.EnableHeadersVisualStyles = false;
            dgvIntLicenseApp.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
        }

        void _VisibleControl(bool PanelRadioes, bool TextBox)
        {
            pIsActive.Visible = PanelRadioes;
            txtFilterName.Visible = TextBox;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterName.Text = string.Empty;
            _RefreshData();
            switch(cbFilter.SelectedItem)
            {
                case "None":
                    {
                        //_RefreshData(false);
                        _VisibleControl(false, false);
                        break;
                    }
                case "IsActive":
                    {
                        _VisibleControl(true, false);
                        break;
                    }
                default:
                    {
                        _VisibleControl(false, true);
                        break;
                    }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string _GetFilterNameBycbFilter()
        {
            switch(cbFilter.SelectedIndex)
            {
                case 1:
                    {
                        return "Int.LicenseID";
                    }
                    case 2:
                    {
                        return "ApplicationID";
                    }
                    case 3:
                    {
                        return "DriverID";
                    }
                    case 4:
                    {
                        return "L.LicenseID";
                    }
            }
            return "";
        }
        //_dtPersonFilter.RowFilter = "convert(PersonID, 'System.String') LIKE '" + FilterName + "%' ";
        string _Lasttxt =string.Empty;
        private void txtFilterName_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtFilterName.Text))
            {
                _RefreshData();
            }
            if(!clsTextProcessing.TextHasLetter(txtFilterName.Text))
            {
                _Lasttxt = txtFilterName.Text;
            }
            txtFilterName.Text = _Lasttxt;
            txtFilterName.SelectionStart = txtFilterName.Text.Length;
            // "convert(PersonID, 'System.String') LIKE '" + FilterName + "%' ";
            if(!string.IsNullOrEmpty(txtFilterName.Text))
            {
                string FilterName = _GetFilterNameBycbFilter();
                _dvIntLicenseApp.RowFilter = "convert("+ FilterName + ", 'System.String') LIKE '" + txtFilterName.Text + "%'";
                _RefreshData(true);
            }
           

        }

        void FilterRadioButton(object sender, EventArgs e)
        {
            bool IsActivce;
            if(rbYes.Checked)
            {
                IsActivce = true;
            }
            else
            {
                IsActivce= false;
            }
            _dvIntLicenseApp.RowFilter = "IsActive = " + IsActivce;
            _RefreshData(true);
        }

        private void picAddNewIntLicenseApp_Click(object sender, EventArgs e)
        {
            frmNewInternationalDrivingLicenseApplicaiton AddNewIntLicenseApp = new frmNewInternationalDrivingLicenseApplicaiton();
            AddNewIntLicenseApp.ShowDialog();
            _RefreshData();
            _RefreshData(false);
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonDetails personDetails = new frmPersonDetails(clsBusinessApplications.Find((int)dgvIntLicenseApp.CurrentRow.Cells[1].Value).PersonID);
            personDetails.ShowDialog();
            _RefreshData();
            _RefreshData(false);
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseInfo2 LicensInfo = new frmLicenseInfo2(clsBusinessLicenses.Find((int)dgvIntLicenseApp.CurrentRow.Cells[3].Value, true).ApplicationID);
            LicensInfo.ShowDialog();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseHistory2 licenseHistory = new frmLicenseHistory2((int)dgvIntLicenseApp.CurrentRow.Cells[1].Value);
            licenseHistory.ShowDialog();
            _RefreshData();
            _RefreshData(false);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
