using clsBusinessTier;
using MyLibrary;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        DataTable dtUsers;
        DataView dvUsers;

        void _RefreshData(bool UsingFilter = false)
        {
            if(UsingFilter)
            {
                lblNumberOfRecord.Text = dvUsers.Count.ToString();
                dgvUsersList.DataSource = dvUsers;
                return;
            }

            dtUsers = clsBusinessUsers.GetAllUsers();
            dvUsers = dtUsers.DefaultView;
            dgvUsersList.DataSource = dtUsers;
            lblNumberOfRecord.Text = dtUsers.Rows.Count.ToString();
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
           
            cbFilter.SelectedIndex = 0;
            _RefreshData();

            dgvUsersList.EnableHeadersVisualStyles = false;
            dgvUsersList.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
        }

        string GetFilterType()
        {
            switch(cbFilter.SelectedIndex)
            {
                case 1:
                    {
                        return "UserID";
                    }
                    case 2:
                    {
                        return "PersonID";
                    }
                default:
                    {
                        return "FullName";
                    }
                    
            }
           
        }

        void FilterTxtDataView(string FilterName)
        {
            string FilterType = GetFilterType();
            if(FilterType == "PersonID" || FilterType == "UserID")
            {
                dvUsers.RowFilter = "convert(" + FilterType + " , 'System.String') like '" + FilterName + "%' ";
            }
            else
            {
                dvUsers.RowFilter = FilterType + " like '" + FilterName + "%' ";
            }
            
        }

        int GetNumberActive()
        {
            switch(cbFilterActive.SelectedIndex)
            {
                case 1:
                    return 1;
                    case 2:
                    return 0;
            }
            return -1;
        }

        bool FilterCbActive()
        {
            int NActive= GetNumberActive();
            if(NActive == -1)
            {
                return false;
            }

            bool isActive = false;
            if(NActive == 1)
            {
                isActive = true;
            }
            dvUsers.RowFilter = "IsActive = '" + isActive + "'";
            return true;
            
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Text = string.Empty;
            switch (cbFilter.SelectedIndex)
            {
                case 0:
                    {
                        txtFilter.Visible = false;
                        cbFilterActive.Visible = false;
                        _RefreshData();
                        break;
                    }
                case 5:
                    {
                        txtFilter.Visible = false;
                        cbFilterActive.SelectedIndex = 0;
                        cbFilterActive.Visible = true;
                        break;
                    }
                default:
                    {
                        txtFilter.Visible = true;
                        cbFilterActive.Visible = false;
                        break;
                    }
            }

        }

        string _LastFiltertxt ="";
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if(cbFilter.SelectedIndex == 1 || cbFilter.SelectedIndex == 2)
            {
                if (!clsTextProcessing.TextHasLetter(txtFilter.Text))
                {
                    _LastFiltertxt = txtFilter.Text;
                }

                txtFilter.Text = _LastFiltertxt;
                txtFilter.SelectionStart = _LastFiltertxt.Length;
            }
            FilterTxtDataView(txtFilter.Text);
            _RefreshData(true);
        }

        private void cbFilterActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FilterCbActive())
                _RefreshData(true);
            else
                _RefreshData();
            
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsBusinessUsers.DeleteUser((int)dgvUsersList.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("Delete is Succeed", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshData();

            }
            else
            {
                MessageBox.Show("Delete is Faild,\nbecause this user has refrance", "Wrong Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdd_UpdateUsers frmAdd_User = new frmAdd_UpdateUsers((int)dgvUsersList.CurrentRow.Cells[0].Value);
            frmAdd_User.ShowDialog();
            _RefreshData();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChangePass = new frmChangePassword(clsBusinessUsers.Find((int)dgvUsersList.CurrentRow.Cells[0].Value));
            frmChangePass.ShowDialog();
            _RefreshData();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserDetails userDetails = new frmUserDetails(clsBusinessUsers.Find((int)dgvUsersList.CurrentRow.Cells[0].Value));
            userDetails.ShowDialog();
            _RefreshData();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmAdd_UpdateUsers frmAdd_User = new frmAdd_UpdateUsers(-1);
            frmAdd_User.ShowDialog();
            _RefreshData();
        }

        private void lblTitlePage_MouseEnter(object sender, EventArgs e)
        {
            lblTitlePage.ForeColor = Color.DarkGray;
        }

        private void lblTitlePage_MouseLeave(object sender, EventArgs e)
        {
            lblTitlePage.ForeColor = Color.Black;
        }

        public  void Button_MouseEnter(object sender, EventArgs e)
        {
           clsColorControl.Button_MouseEnter(sender, e);
        }

        public  void Button_MouseLeave(object sender, EventArgs e)
        {
           clsColorControl.Button_MouseLeave(sender, e);
          }
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
        public  void comboBox_MouseEnter(object sender, EventArgs e)
        {
           clsColorControl.comboBox_MouseEnter(sender, e);
        }
        public  void comboBox_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.comboBox_MouseLeave(sender, e);
        }
        void ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.ToolStripMenuItem_MouseEnter(sender, e);
        }
        void ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.ToolStripMenuItem_MouseLeave(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
