using clsBusinessTier;
using clsBusinessTier.View;
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
    public partial class frmTakeTest : Form
    {
        public void Label_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.Label_MouseEnter(sender, e);
        }

        public void Label_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.Label_MouseLeave(sender, e);
        }
        public void Button_MouseEnter(object sender, EventArgs e)
        {
           clsColorControl.Button_MouseEnter(sender, e);
        }

        public void Button_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.Button_MouseLeave(sender, e);
        }
        public void RadioButton_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.RadioButton_MouseEnter(sender, e);
        }
        public void RadioButton_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.RadioButton_MouseLeave(sender, e);
        }



        int _TestAppointmentID;
        clsBusinessTests _Test;
        clsBusinessTestAppointments _TestAppointments;
        clsBusinessMYLocalDrivingLicenseApplications_View _LocalDrivingLicenseApplications_View;
        public frmTakeTest(int TestAppointmentID)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;
        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtNotes_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.TextBox_MouseEnter(sender, e);
            txtNotes.BorderStyle = BorderStyle.Fixed3D;
        }

        private void txtNotes_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.TextBox_MouseLeave(sender, e);
            txtNotes.BorderStyle = BorderStyle.FixedSingle;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            _TestAppointments = clsBusinessTestAppointments.FindBy(_TestAppointmentID);
            ctrlTakeTest1.LoadTakeTest(_TestAppointmentID);
            this.Text = ctrlTakeTest1.gbTitle.Text;
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            if (rbPass.Checked || rbFail.Checked)
            {
                _Test = new clsBusinessTests();
                _Test.TestAppointmentID = _TestAppointmentID;
                _Test.TestResult = rbPass.Checked? true : false;
                _Test.Notes = txtNotes.Text;
                _Test.UserID = clsBusinessTestAppointments.FindBy(_TestAppointmentID).ByUserID;
                _TestAppointments.IsLocked = true;
            
                if (_Test.Save()&& _TestAppointments.Save() )
                {
                    if(MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        if(!_Test.TestResult)
                        {
                            MessageBox.Show("Good Luck , You can pass this test try again", "Failed :-(", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            
                            MessageBox.Show("Congratulations, We are proud of you", "Pasased :-)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        
                        ctrlTakeTest1.LoadTakeTest(_TestAppointmentID);
                        btnSave.Enabled = false;
                        panel1.Enabled = false;
                        txtNotes.Enabled = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("You must set the result!", "Set Final Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void ctrlTakeTest1_Load(object sender, EventArgs e)
        {

        }
    }
}
