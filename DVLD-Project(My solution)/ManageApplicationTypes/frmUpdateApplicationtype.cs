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
    public partial class frmUpdateApplicationtype : Form
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




        clsBusinessApplicationTypes _Application;
        public frmUpdateApplicationtype(int ApplicationTypeID)
        {
            InitializeComponent();
            _Application = clsBusinessApplicationTypes.Find(ApplicationTypeID);
        }

        void _LoadData()
        {
            lblApplicationTypeID.Text = _Application.ApplicationTypeID.ToString();
            txtApplicationTypeTitle.Text = _Application.ApplicationTypeTitle;
            txtApplicationTypeFees.Text = Convert.ToInt32(_Application.ApplicationFees).ToString();
        }

        private void frmUpdateApplicationtype_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Application.ApplicationTypeTitle = txtApplicationTypeTitle.Text;
            _Application.ApplicationFees = Convert.ToDecimal(txtApplicationTypeFees.Text);

            if(_Application.Save())
            {
                if (MessageBox.Show("Update Application is succeeded", "Save Data!", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    return;
                }
               

            }
            else
            {
                MessageBox.Show("Update Application is Faild", "Save Data!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string _LastApplicationTypeFees;
        private void txtApplicationTypeFees_TextChanged(object sender, EventArgs e)
        {
            if(!clsTextProcessing.TextHasLetter(txtApplicationTypeFees.Text))
            {
                _LastApplicationTypeFees = txtApplicationTypeFees.Text;
            }
            txtApplicationTypeFees.Text = _LastApplicationTypeFees;
            txtApplicationTypeFees.SelectionStart = txtApplicationTypeFees.Text.Length;
        }

        private void lblTitlePage_MouseEnter(object sender, EventArgs e)
        {
            lblTitlePage.ForeColor = Color.DarkGray;
        }

        private void lblTitlePage_MouseLeave(object sender, EventArgs e)
        {
            lblTitlePage.ForeColor = Color.Black;
        }
    }
}
