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
    public partial class frmLocalDrivingLicenseApplications : Form
    {
        public  void ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
           clsColorControl.ToolStripMenuItem_MouseEnter(sender, e);
        }
        public  void ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
           clsColorControl.ToolStripMenuItem_MouseLeave(sender, e);
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

        public void TextBox_MouseEnter(object sender, EventArgs e)
        {
          clsColorControl.TextBox_MouseEnter(sender, e);
        }
        public void TextBox_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.TextBox_MouseLeave(sender, e);
        }


        public frmLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        DataTable _dtLocalDrivingLicenseApplications;
        DataView _dvLocalDrivingLicenseApplications;
       
        clsBusinessApplications _clsApp;

        void _RefreshData(bool UsingFilter = false)
        {
            if(UsingFilter)
            {
                dgvLocalDrivingLicenseApplications.DataSource = _dvLocalDrivingLicenseApplications;
            }
            else
            {
                _dtLocalDrivingLicenseApplications = clsBusinessLocalDrivingLicenseApplications.GetAllViewData();
                dgvLocalDrivingLicenseApplications.DataSource = _dtLocalDrivingLicenseApplications;
            }
            lblNumberOfRecord.Text = dgvLocalDrivingLicenseApplications.RowCount.ToString();
        }


        private void lblTitlePage_MouseEnter(object sender, EventArgs e)
        {
            lblTitlePage.ForeColor = Color.DarkGray;
        }

        private void lblTitlePage_MouseLeave(object sender, EventArgs e)
        {
            lblTitlePage.ForeColor = Color.Black;
        }

        void ControlVisible(bool ShowComboBox, bool ShowTextBox )
        {
            if(ShowComboBox)
            {
                txtFilter.Visible = false;
                cbFilter.Visible = true;
            }
            else if(ShowTextBox) 
            {
                txtFilter.Visible = true;
                cbFilter.Visible = false;
            }
            else
            {
                txtFilter.Visible = false;
                cbFilter.Visible = false;
            }
        }

        private void cbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _RefreshData();
            switch(cbFilterType.SelectedIndex)
            {
                case 0:
                {
                    ControlVisible(false, false);
                    break;
                }
                case 4:
                {
                    cbFilter.SelectedIndex = 0;
                    ControlVisible(true, false);
                    break;
                }
                default:
                {
                    txtFilter.Text = string.Empty;
                    ControlVisible(false, true);
                    break;
                }
            }
        }

        private void frmLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
          
            cbFilterType.SelectedIndex = 0;
           
            
            _RefreshData();
            _dvLocalDrivingLicenseApplications = _dtLocalDrivingLicenseApplications.DefaultView;

            dgvLocalDrivingLicenseApplications.EnableHeadersVisualStyles = false;
            dgvLocalDrivingLicenseApplications.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
        }

        void _FilterStringData(string FilterType, string Filter)
        {
            _dvLocalDrivingLicenseApplications.RowFilter = FilterType + " like '" + Filter + "%' ";
        }

        string _Lasttxt;
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if(cbFilterType.SelectedIndex == 1)
            {
                if(!clsTextProcessing.TextHasLetter(txtFilter.Text))
                {
                    _Lasttxt = txtFilter.Text;
                }
                txtFilter.Text = _Lasttxt;
                txtFilter.SelectionStart = txtFilter.Text.Length;
                _dvLocalDrivingLicenseApplications.RowFilter = "convert(L.D.LAppID, 'System.String') like '" + txtFilter.Text + "%' ";
            }
            else if(cbFilterType.SelectedIndex == 2)
            {
               _FilterStringData("NationalNo", txtFilter.Text);
            }
            else
            {
                _FilterStringData("FullName", txtFilter.Text);
            }
            _RefreshData(true);
            
        }


        void _FilterStatus(string Filter)
        {
            _dvLocalDrivingLicenseApplications.RowFilter = "Name = '" + Filter + "'";
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cbFilter.SelectedIndex)
            {
                case 0:
                    {
                        _RefreshData();
                        return;
                    }
                    case 1:
                    {
                        _FilterStatus("New");
                        break;
                    }
                    case 2:
                    {
                        _FilterStatus("Canceled");
                        break;
                    }
                    case 3:
                    {
                        _FilterStatus("Completed");
                        break;
                    }
            }

            _RefreshData(true);

        }

        private void caToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(_clsApp.AppStatus == 2)
            {
                MessageBox.Show("You are already cancel this License", "Canceld", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
            }
            if(MessageBox.Show("Are you sure do you want Canceled This localDrivingLicenseApplications", "Confirm Camcel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _clsApp.AppStatus = 2;
               // clsApp.LastStatusDate = DateTime.Now;
                if (_clsApp.Save())
                {
                    if(MessageBox.Show("Your order is Succeefully", "Succeefully", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        _RefreshData();
                    }
                }
            }
          


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmAdd_UpdateLocalDrivingLicensesApplication newLocalDrivingLicensesApplication = new frmAdd_UpdateLocalDrivingLicensesApplication(-1);
            newLocalDrivingLicensesApplication.ShowDialog();
            _RefreshData();

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        void _EnableSechduleTestsMenue(bool VersionTest, bool WrittenTest, bool StreetTest)
        {
            sechduleVersionTestToolStripMenuItem.Enabled = VersionTest;
            sechduleWrittenTestToolStripMenuItem.Enabled = WrittenTest;
            sechduleStreetTestToolStripMenuItem.Enabled = StreetTest;
        }

        void _EnableContexMenue(bool CancelApplication, bool SechduleTests, bool IssueDrivingLicense, bool ShowLicense, bool DeleteApp,bool ShowLicenseHistory=true)
        {
            caToolStripMenuItem.Enabled = CancelApplication;
            SechduleTestsStripMenuItem1.Enabled = SechduleTests;
            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = IssueDrivingLicense;
            showLicenseToolStripMenuItem.Enabled = ShowLicense;
            showPersonLicenseHistoryToolStripMenuItem.Enabled = ShowLicenseHistory;
            DeleteAppStripMenuItem1.Enabled= DeleteApp;
        }
        void _SechduleTestsMenue(int PastedTests)
        {
            switch (PastedTests)
            {
                case 0:
                    {

                        _EnableSechduleTestsMenue(true, false, false);
                        break;
                    }
                case 1:
                    {
                        _EnableSechduleTestsMenue(false, true, false);
                        break;
                    }
                case 2:
                    {
                        _EnableSechduleTestsMenue(false, false, true);
                        break;
                    }
                default:
                    {

                        _EnableSechduleTestsMenue(false, false, false);
                        break;
                    }
            }
        }
        void _ContexMenue(byte AppStatus, int PastedTests)
        {
            switch(AppStatus)
            {
                case 1:
                    {
                        if(PastedTests == 3)
                        {
                            if (clsBusinessLicenses.IsExists(_clsApp.AppID))
                            {
                                _EnableContexMenue(false, false, false, true, false);
                            }
                            else
                            {
                                _EnableContexMenue(true, false, true, false, true);
                            }
                           
                        }
                        else
                        {
                            _SechduleTestsMenue(PastedTests);
                            _EnableContexMenue(true, true, false, false, true);
                        }
                        
                        break;
                    }
                    case 2:
                    {
                        _EnableContexMenue(false, false, false, false, false) ;
                        break;
                    }
                    case 3:
                    {
                        _EnableContexMenue(false, false, false, true, false);
                        break;
                    }
            }
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int PastedTests = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[5].Value;
             _clsApp = clsBusinessApplications.Find(clsBusinessLocalDrivingLicenseApplications.FindByLDLAppID((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value).AppID);

            _ContexMenue(_clsApp.AppStatus, PastedTests);
        }

        frmTestAppointments testAppointments;
        private void sechduleVersionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
             testAppointments = new frmTestAppointments((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value, 1);
            testAppointments.ShowDialog();
            _RefreshData();
        }

     
        private void sechduleWrittenTestToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            testAppointments = new frmTestAppointments((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value, 2);
            testAppointments.ShowDialog();
            _RefreshData();
        }

        private void sechduleStreetTestToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            testAppointments = new frmTestAppointments((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value, 3);
            testAppointments.ShowDialog();
            _RefreshData();
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueDriverLicenseForTheFirstTime22 issueDriverLicenseForTheFirstTime = new frmIssueDriverLicenseForTheFirstTime22((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            issueDriverLicenseForTheFirstTime.ShowDialog();
            _RefreshData();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseInfo2 licenseInfo = new frmLicenseInfo2(clsBusinessLocalDrivingLicenseApplications.FindByLDLAppID((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value).AppID);
            licenseInfo.ShowDialog();
            _RefreshData();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmLicenseHistory2 licenseHistory = new frmLicenseHistory2(clsBusinessLocalDrivingLicenseApplications.FindByLDLAppID((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value).AppID);
           licenseHistory.ShowDialog();
            _RefreshData();

        }

        bool DeleteApplication()
        {
            int LDLAppID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            if (clsBusinessTestAppointments.IsExists(LDLAppID))
            {

                if(clsBusinessTests.DeleteTestsBy(LDLAppID))
                {
                    if (clsBusinessRetakeTestAppointment.IsExistsBy(LDLAppID))
                    {
                        clsBusinessRetakeTestAppointment.Delete(LDLAppID);
                    }
                }

                clsBusinessTestAppointments.DeleteTestAppointment(LDLAppID);
            }

            clsBusinessLocalDrivingLicenseApplications DeletedLDLApp = clsBusinessLocalDrivingLicenseApplications.FindByLDLAppID(LDLAppID);
            if (clsBusinessLocalDrivingLicenseApplications.DeleteLocalDrivingLicenseApplications(LDLAppID))
            {
                
                if (clsBusinessApplications.Delete(DeletedLDLApp.AppID));
                {
                    return true;
                }

            }
            return false;
        }

        private void DeleteAppStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure do you want delete this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information)== DialogResult.Yes)
            {
                if(DeleteApplication())
                {
                    if(MessageBox.Show("Application deleted succeefully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        _RefreshData();
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
