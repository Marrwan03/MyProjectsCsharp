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
    public partial class ctrlDriverLincensesHistory1 : UserControl
    {
        public ctrlDriverLincensesHistory1()
        {
            InitializeComponent();
        }

        private void ctrlDriverLincensesHistory1_Load(object sender, EventArgs e)
        {

        }

        public void Label_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.Label_MouseEnter(sender, e);
        }
        public void Label_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.Label_MouseLeave(sender, e);
        }
        public void ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.ToolStripMenuItem_MouseEnter(sender, e);
        }
        public void ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.ToolStripMenuItem_MouseLeave(sender, e);
        }
        void _ChangeColorDataGrideView(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
        }
        public void LoadDriverLincenses(int PersonID)
        {
            _ChangeColorDataGrideView(dgvLocalLincensesList);
            _ChangeColorDataGrideView(dgvInternationalLincensesList);

            dgvLocalLincensesList.DataSource = clsBusinessLicenses.GetAllLocalLicensesFor(PersonID);
            lblNumberOfLocalRecords.Text = dgvLocalLincensesList.RowCount.ToString();
            if (dgvLocalLincensesList.RowCount == 0)
            {
                lblWrongMessageLocal.Visible = true;
            }
            else
            {
                lblWrongMessageLocal.Visible = false;
            }


            dgvInternationalLincensesList.DataSource = clsBusinessLicenses.GetAllInternationalLicensesFor(PersonID);
            lblNumberOfInternationalRecords.Text = dgvInternationalLincensesList.RowCount.ToString();
            if (dgvInternationalLincensesList.RowCount == 0)
            {
                lblWrongMessageInternational.Visible = true;
            }
            else
            {
                lblWrongMessageInternational.Visible = false;
            }
        }
        private void showLocalLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseInfo2 licenseInfo2 = new frmLicenseInfo2((int)dgvLocalLincensesList.CurrentRow.Cells[1].Value);
            licenseInfo2.ShowDialog();
        }
        private void showIntLicenseInfoToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            frmLicenseInfo2 licenseInfo2 = new frmLicenseInfo2(clsBusinessLicenses.Find((int)dgvInternationalLincensesList.CurrentRow.Cells[2].Value, true).ApplicationID);
            licenseInfo2.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cmLocalLicenses_Opening(object sender, CancelEventArgs e)
        {
            if(lblWrongMessageLocal.Visible)
            {
                showLocalLicenseInfoToolStripMenuItem.Enabled = false;
            }
            else
            {
                showLocalLicenseInfoToolStripMenuItem.Enabled=true;
            }
        }

        private void cmIntLicense_Opening(object sender, CancelEventArgs e)
        {
            if(lblWrongMessageInternational.Visible)
            {
                showIntLicenseInfoToolStripMenuItem.Enabled = false;   
            }
            else
            {
                showIntLicenseInfoToolStripMenuItem.Enabled = true;
            }
        }
    }
}
