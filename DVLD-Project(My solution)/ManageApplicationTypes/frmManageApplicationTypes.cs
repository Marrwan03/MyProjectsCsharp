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
    public partial class frmManageApplicationTypes : Form
    {
        public  void Button_MouseEnter(object sender, EventArgs e)
        {
           clsColorControl.Button_MouseEnter(sender, e);
        }

        public  void Button_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.Button_MouseLeave(sender, e);
        }
        public  void Label_MouseEnter(object sender, EventArgs e)
        {clsColorControl.Label_MouseEnter(sender, e);
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

        void ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.ToolStripMenuItem_MouseEnter(sender, e);
        }
        void ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.ToolStripMenuItem_MouseLeave(sender, e);
        }

        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }
        DataTable dtApplicationTypes;
        DataView dvApplicationTypes;

        void _RefreshData()
        {
            
            dtApplicationTypes = clsBusinessApplicationTypes.GetAllApplicationTypes();
            dvApplicationTypes = dtApplicationTypes.DefaultView;
            dgvApplicationType.DataSource = dtApplicationTypes;
           
            lblCountOfRecord.Text = dtApplicationTypes.Rows.Count.ToString();
        }

        void _RefreshData(bool UsingFilter)
        {
            dgvApplicationType.DataSource = dvApplicationTypes;
            lblCountOfRecord.Text = dgvApplicationType.Rows.Count.ToString();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            //clsForm.SetForm(this, 816, 573);
            cbFilter.SelectedIndex = 0;
            
            _RefreshData();
            dgvApplicationType.EnableHeadersVisualStyles = false;
            dgvApplicationType.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
        }

        private void editAoolicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateApplicationtype updateApplicationtype = new frmUpdateApplicationtype((int)dgvApplicationType.CurrentRow.Cells[0].Value);
          
            updateApplicationtype.ShowDialog();
           
            NumricFees.Minimum = clsBusinessApplicationTypes.MinimumFees();
            NumricFees.Maximum = clsBusinessApplicationTypes.MaximumFees();
            NumricFees.Value = NumricFees.Maximum;
            _RefreshData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblTitlePage_MouseEnter(object sender, EventArgs e)
        {
            lblTitlePage.ForeColor = Color.DarkGray;
        }

        private void lblTitlePage_MouseLeave(object sender, EventArgs e)
        {
            lblTitlePage.ForeColor = Color.Black;
        }

        void VisibleControl(bool Showtxt =false, bool ShowNumricUpDown = false)
        {
            if (Showtxt)
            {
                txtFilterName.Visible = true;
                NumricFees.Visible = false;
                lblTitleNumric.Visible = false;
            }
            else if(ShowNumricUpDown)
            {
                txtFilterName.Visible = false;
                NumricFees.Visible = true;
                lblTitleNumric.Visible = true;
            }
            else
            {
                txtFilterName.Visible = false;
                NumricFees.Visible = false;
                lblTitleNumric.Visible = false;
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
            switch (cbFilter.SelectedIndex)
            {
                case 0:
                    {
                        _RefreshData();
                        VisibleControl(false, false);
                        break;
                    }
                    case 3:
                    {
                       
                        NumricFees.Minimum = clsBusinessApplicationTypes.MinimumFees();
                        NumricFees.Maximum = clsBusinessApplicationTypes.MaximumFees();
                        NumricFees.Value = NumricFees.Minimum;
                        FilterNumbericUpDown(NumricFees.Value);
                        VisibleControl(false, true); break;
                    }
                    default:
                    {
                        txtFilterName.Text = string.Empty;
                        VisibleControl(true, false); break;
                    }
            }
        }

        

        string _LastTxt;
        private void txtFilterName_TextChanged(object sender, EventArgs e)
        {
            if(cbFilter.SelectedIndex == 1)
            {
                if(!clsTextProcessing.TextHasLetter(txtFilterName.Text))
                {
                    _LastTxt = txtFilterName.Text;
                }
                txtFilterName.Text = _LastTxt;
                txtFilterName.SelectionStart = txtFilterName.Text.Length;
                dvApplicationTypes.RowFilter = "convert(ApplicationTypeID,'System.String') like '" + txtFilterName.Text + "%'";

            }
            else
            {
                dvApplicationTypes.RowFilter = "ApplicationTypeTitle like '" + txtFilterName.Text + "%'";
            }
            _RefreshData(true);
        }

        void FilterNumbericUpDown(decimal FilterValue)
        {
            dvApplicationTypes.RowFilter = "ApplicationFees <= " + FilterValue;
        }

        private void NumricFees_ValueChanged(object sender, EventArgs e)
        {
            FilterNumbericUpDown(NumricFees.Value);
            _RefreshData(true);
        }

        private void highestFeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"The Highest Application Fees is [ {Convert.ToInt32(NumricFees.Maximum)} $].", "Highest Fees!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lowestFeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"The Lowest Application Fees is [ {Convert.ToInt32(NumricFees.Minimum)} $].", "Lowest Fees!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
