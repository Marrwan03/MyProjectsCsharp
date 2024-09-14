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
    public partial class frmManageTestTypes : Form
    {
        public  void TextBox_MouseEnter(object sender, EventArgs e)
        {
          clsColorControl.TextBox_MouseEnter(sender, e);
        }
        public  void TextBox_MouseLeave(object sender, EventArgs e)
        {
           clsColorControl.TextBox_MouseLeave(sender, e);
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

        public  void ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
           clsColorControl.ToolStripMenuItem_MouseEnter(sender, e);
        }
        public  void ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
           clsColorControl.ToolStripMenuItem_MouseLeave(sender, e);
        }

        public frmManageTestTypes()
        {
            InitializeComponent();
        }
        DataTable _dtTestType;
        DataView  _dvTestType;

        void _RefreshData()
        {
            _dtTestType = clsBusinessTestTypes.GetAllTestTypes();
            _dvTestType = _dtTestType.DefaultView;
            dgvTestTypes.DataSource = _dtTestType;
            lblCountOfRecord.Text = _dtTestType.Rows.Count.ToString();
        }

        void _RefreshData(bool UsingFilter)
        {
            dgvTestTypes.DataSource = _dvTestType;
            lblCountOfRecord.Text = _dvTestType.Count.ToString();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
           // clsForm.SetForm(this, 831, 576);
            cbFilter.SelectedIndex = 0;
            _RefreshData();

            dgvTestTypes.EnableHeadersVisualStyles = false;
            dgvTestTypes.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;

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

        private void lblTitleNumric_Click(object sender, EventArgs e)
        {

        }

        string _Lasttxt;
        private void txtFilterName_TextChanged(object sender, EventArgs e)
        {
            if(cbFilter.SelectedIndex == 1)
            {
                if(!clsTextProcessing.TextHasLetter(txtFilterName.Text))
                {
                    _Lasttxt = txtFilterName.Text;
                }
                txtFilterName.Text = _Lasttxt;
                txtFilterName.SelectionStart = txtFilterName.Text.Length;
                _dvTestType.RowFilter = "convert(TestTypeID,'System.String') like '" + txtFilterName.Text + "%'";

            }
            else
            {
                _dvTestType.RowFilter = "TestTypeTitle like '" + txtFilterName.Text + "%'";
            }
            _RefreshData(true);
        }

        void _VisibleControl(bool ShowTextBox = false,bool ShownumricUpDown = false )
        {
            if (ShowTextBox)
            {
                lblTitleNumric.Visible = false;
                NumricFees.Visible = false;
                txtFilterName.Visible = true;
            }
            else if(ShownumricUpDown)
            {
                lblTitleNumric.Visible = true;
                NumricFees.Visible = true;
                txtFilterName.Visible = false;
            }
            else
            {
                lblTitleNumric.Visible = false;
                NumricFees.Visible = false;
                txtFilterName.Visible = false;
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cbFilter.SelectedIndex)
            {
                case 0:
                    {
                        _RefreshData();
                        _VisibleControl(false,false);
                        break;
                    }
                    case 3:
                    {
                        NumricFees.Minimum = clsBusinessTestTypes.MinimumFees();
                        NumricFees.Maximum = clsBusinessTestTypes.MaximumFees();
                        NumricFees.Value = NumricFees.Minimum;
                        _VisibleControl(false,true);
                        break;
                    }
                    default:
                    {
                        _VisibleControl(true,false);
                        txtFilterName.Text = string.Empty;
                        break;
                    }
            }
        }

        private void NumricFees_ValueChanged(object sender, EventArgs e)
        {
            _dvTestType.RowFilter = "TestTypeFees <= " + NumricFees.Value;
            _RefreshData(true);
        }

        private void updateTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateTestType UpdateTestType = new frmUpdateTestType((int)dgvTestTypes.CurrentRow.Cells[0].Value);
            
            UpdateTestType.ShowDialog();
           
            NumricFees.Minimum = clsBusinessTestTypes.MinimumFees();
            NumricFees.Maximum = clsBusinessTestTypes.MaximumFees();
            NumricFees.Value = NumricFees.Maximum;
            _RefreshData();
        }

        private void highestFeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"The Highest Test Fees is [ {Convert.ToInt32(NumricFees.Maximum)} $].", "Highest Fees!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lowestFeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"The Lower Test Fees is [ {Convert.ToInt32(NumricFees.Minimum)} $].", "Lower Fees!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
