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
    public partial class frmListDetainedLicenses : Form
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
        public void TextBox_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.TextBox_MouseEnter(sender, e);
        }
        public void TextBox_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.TextBox_MouseLeave(sender, e);
        }
        public  void ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
           clsColorControl.ToolStripMenuItem_MouseEnter(sender, e);
        }
        public  void ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.ToolStripMenuItem_MouseLeave(sender, e);
        }
        public  void RadioButton_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.RadioButton_MouseEnter(sender, e);
        }
        public  void RadioButton_MouseLeave(object sender, EventArgs e)
        {
           clsColorControl.RadioButton_MouseLeave(sender, e);
        }


        public frmListDetainedLicenses()
        {
            InitializeComponent();
        }

        DataTable _dtDetainLicense;
        DataView  _dvDetainLicense;

        void _RefreshData()
        {
            _dtDetainLicense = clsBusinessDetainedLicenses.GetAllDetainLicense();
            _dvDetainLicense = _dtDetainLicense.DefaultView;
        }

        void _RefreshData(bool UsingFilter)
        {
            if(UsingFilter)
            {
                dgvListDetainedLicenses.DataSource = _dvDetainLicense;
            }
            else
            {
                dgvListDetainedLicenses.DataSource = _dtDetainLicense;
            }
            lblNumberOfRecords.Text = dgvListDetainedLicenses.RowCount.ToString();
        }

        void _VisibleControl(bool textbox, bool panel)
        {
            txtFilter.Visible = textbox;
            pReleaseFilter.Visible = panel;
        }


        private void frmListDetainedLicenses_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            _RefreshData();
            _RefreshData(false);

            dgvListDetainedLicenses.EnableHeadersVisualStyles = false;
            dgvListDetainedLicenses.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            switch(cbFilter.SelectedIndex)
            {
                case 0:
                    {
                        _RefreshData();
                        _RefreshData(false);
                        _VisibleControl(false, false);
                        break;
                    }
                    case 2:
                    {
                        _VisibleControl(false, true);
                        break;
                    }
                    default:
                    {
                        txtFilter.Text = string.Empty;
                        _VisibleControl(true, false);
                        break;
                    }
            }
        }

        string GetFilterType()
        {
            switch(cbFilter.SelectedItem)
            {
                case "Detain ID":
                    {
                        return "D.ID";
                    }
                case "Is Release":
                    {
                        return "IsReleased";
                    }
                case "National No":
                    {
                        return "N.No";
                    }
                case "Full Name":
                    {
                        return "FullName";
                    }
                default:
                    {
                        return "ReleaseAppID";
                    }
            }
        }


        string _Lasttxt=string.Empty;
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterName = GetFilterType();
            string Filter = string.Empty;
            if(cbFilter.SelectedIndex == 1 || cbFilter.SelectedIndex == 5)
            {
                if(!clsTextProcessing.TextHasLetter(txtFilter.Text))
                {
                    _Lasttxt = txtFilter.Text;
                }
                txtFilter.Text = _Lasttxt;
                txtFilter.SelectionStart = txtFilter.Text.Length;

                Filter = "convert(" + FilterName + ", 'System.String') like '" + txtFilter.Text + "%' ";
            }
            else
            {
                Filter = FilterName + " like '" + txtFilter.Text + "%' ";
            }
            _dvDetainLicense.RowFilter = Filter;
            _RefreshData(true);
        }

        void FilterRadioButton(object sender, EventArgs e)
        {
            int Result = rbYes.Checked ? 1 : 0;
            string filter = GetFilterType();
            _dvDetainLicense.RowFilter = filter + " = " + Result.ToString();
            _RefreshData(true);
        }

        private void picDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense detainLicense = new frmDetainLicense();
            detainLicense.ShowDialog();
            _RefreshData();
            _RefreshData(false);
        }

        

        private void picReleaseLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainLicense releaseDetainLicense = new frmReleaseDetainLicense(-1);
            releaseDetainLicense.ShowDialog();
            _RefreshData();
            _RefreshData(false);
        }

        private void showPersonInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmPersonDetails personDetails = new frmPersonDetails(clsBusinessDrivers.Find(clsBusinessLicenses.Find( (int)dgvListDetainedLicenses.CurrentRow.Cells[1].Value,true ).DriverID).PersonID);
            personDetails.ShowDialog();
            _RefreshData();
            _RefreshData(false);
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseInfo2 licenseInfo2 = new frmLicenseInfo2(clsBusinessLicenses.Find((int)dgvListDetainedLicenses.CurrentRow.Cells[1].Value, true).ApplicationID);
            licenseInfo2.ShowDialog();
           
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseHistory2 licenseHistory = new frmLicenseHistory2(clsBusinessLicenses.Find((int)dgvListDetainedLicenses.CurrentRow.Cells[1].Value, true).ApplicationID);
            licenseHistory.ShowDialog();
            _RefreshData();
            _RefreshData(false);

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if(clsBusinessDetainedLicenses.IsExists((int)dgvListDetainedLicenses.CurrentRow.Cells[1].Value))
            {
                releateToolStripMenuItem.Enabled = true;
            }
            else
            {
                releateToolStripMenuItem.Enabled=false;
            }
        }

        private void releateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainLicense releaseDetainLicense = new frmReleaseDetainLicense((int)dgvListDetainedLicenses.CurrentRow.Cells[1].Value);
            releaseDetainLicense.ShowDialog();
            _RefreshData();
            _RefreshData(false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
