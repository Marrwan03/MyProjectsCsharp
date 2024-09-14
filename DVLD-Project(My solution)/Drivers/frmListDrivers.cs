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
    public partial class frmListDrivers : Form
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
        {
           clsColorControl.Label_MouseEnter(sender, e);
        }

        public  void Label_MouseLeave(object sender, EventArgs e)
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

        public  void TextBox_MouseEnter(object sender, EventArgs e)
        {
          clsColorControl.TextBox_MouseEnter(sender, e);
        }
        public  void TextBox_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.TextBox_MouseLeave(sender, e);
        }


        public frmListDrivers()
        {
            InitializeComponent();
        }
        DataTable _dtDrivers;
        DataView _dvDrivers;

        void _RefreshData(bool UsingFilter=false)
        {
            if (UsingFilter)
            {
                dgvListDrivers.DataSource = _dvDrivers;
            }
            else
            {
               
                _dtDrivers = clsBusinessDrivers.GetAllDrivers();
                dgvListDrivers.DataSource= _dtDrivers;
            }
            lblNumberOfRecord.Text = dgvListDrivers.RowCount.ToString();
        }

        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            _dtDrivers = clsBusinessDrivers.GetAllDrivers();
            _dvDrivers = _dtDrivers.DefaultView;
            cbFilter.SelectedIndex = 0;
            _RefreshData();

            dgvListDrivers.EnableHeadersVisualStyles = false;
            dgvListDrivers.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
        }

        void _VisibleControl(bool TextBox, bool PanelRadioButton)
        {
            txtFilter.Visible = TextBox;
            PrbActive.Visible = PanelRadioButton;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _RefreshData();
            switch (cbFilter.SelectedIndex)
            {
               case 0:
               {
                   _VisibleControl(false, false);
                        
                   break;
               }
               case 4:
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

        string _Lasttxt;

        //"convert(" + FilterType + " , 'System.String') like '" + FilterName + "%' ";

        string _GetFilterString()
        {
            switch (cbFilter.SelectedIndex)
            {
                case 1:
                    {
                        return "DriverID";
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

        void _Filtertextbox()
        {
            string FilterType = _GetFilterString();
            if (cbFilter.SelectedIndex == 1 || cbFilter.SelectedIndex == 2)
            {
                _dvDrivers.RowFilter = "convert("+FilterType+ " , 'System.String') like '" + txtFilter.Text +"%'";
            }
            else
            {
                _dvDrivers.RowFilter = FilterType + " like '" + txtFilter.Text + "%'";
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if(cbFilter.SelectedIndex == 1 || cbFilter.SelectedIndex == 2)
            {
                if(!clsTextProcessing.TextHasLetter(txtFilter.Text))
                {
                    _Lasttxt = txtFilter.Text;
                }
                txtFilter.Text = _Lasttxt;
                txtFilter.SelectionStart = txtFilter.Text.Length;
            }
            _Filtertextbox();
            _RefreshData(true);
        }

        void FilterRadioButton(object sender, EventArgs e)
        {
            bool IsActive = false;
            if(rbYes.Checked)
            {
                IsActive = true;
            }
            _dvDrivers.RowFilter = "IsActive = " + IsActive;
            _RefreshData(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
