using clsBusinessTier;
using MyLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class frmUpdateTestType : Form
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

        public  void TextBox_MouseEnter(object sender, EventArgs e)
        {
           clsColorControl.TextBox_MouseEnter(sender, e);
        }
        public  void TextBox_MouseLeave(object sender, EventArgs e)
        {
           clsColorControl.TextBox_MouseLeave(sender, e);
        }

        clsBusinessTestTypes Test;
        public frmUpdateTestType(int TestID)
        {
            InitializeComponent();
            Test = clsBusinessTestTypes.Find(TestID);
        }

        void _LoadData()
        {
            lblTestTypeID.Text = Test.ID.ToString();
            txtTestTypeTitle.Text = Test.Title.ToString();
            txtTestTypeDescription.Text = Test.Description.ToString();
            txtTestTypeFees.Text = Convert.ToInt32(Test.Fees).ToString();
        }

        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        string _LastFees ;
        private void txtTestTypeFees_TextChanged(object sender, EventArgs e)
        {
           
            if (!clsTextProcessing.TextHasLetter(txtTestTypeFees.Text))
            {
                _LastFees = txtTestTypeFees.Text;    
            }
            txtTestTypeFees.Text = _LastFees;
            txtTestTypeFees.SelectionStart = txtTestTypeFees.Text.Length;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Test.Title = txtTestTypeTitle.Text;
            Test.Description = txtTestTypeDescription.Text;
            Test.Fees = Convert.ToDecimal( txtTestTypeFees.Text);
            if(Test.Save())
            {
                if (MessageBox.Show("Update Test is succeeded", "Save Data!", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    return;
                }

            }
            else
            {
                MessageBox.Show("Update Test is Faild", "Save Data!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
