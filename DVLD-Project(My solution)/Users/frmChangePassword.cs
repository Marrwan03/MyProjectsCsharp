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
    public partial class frmChangePassword : Form
    {
      

        clsBusinessUsers _User;
        clsBusinessPeople _Person;
        bool _IsCurrentUser = false;
        public frmChangePassword(clsBusinessUsers User)
        {
            InitializeComponent();
            _User = User;
            if(_User.UserID == clsGlobalSettings.CurrentUser.UserID)
            {
                _IsCurrentUser = true;
            }
            _Person = clsBusinessPeople.Find(_User.PersonID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //Databack?.Invoke();
            this.Close();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            ctrlLoginInformation1.LoadctrlLoginInformation(_User);
            ctrlPersonInformtion1.LoadctrlPersonInformtion(_Person);

        }

        private void ctrlPersonInformtion1_OnLinkUpdate()
        {
            frmAdd_UpdatePerson frmUpdate_Person = new frmAdd_UpdatePerson(_Person.ID);
            frmUpdate_Person.ShowDialog();
            _Person = clsBusinessPeople.Find(_User.PersonID);//Refresh
            ctrlPersonInformtion1.LoadctrlPersonInformtion(_Person);
        }

        private void ShowPassword(object sender, EventArgs e)
        {
            clsForm.ShowPassword(sender, e);
            clsColorControl.TextBox_MouseEnter(sender, e);
        }

        private void HidePassword(object sender, EventArgs e)
        {
            clsForm.HidePassword(sender, e, '*');
            clsColorControl.TextBox_MouseLeave(sender, e);
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtCurrentPassword.Text))
            {
                e.Cancel = true;
                txtCurrentPassword.Focus();
                errorProvider1.SetError(txtCurrentPassword, "you must fill CurrentPassword");
                return;

            }

            if(txtCurrentPassword.Text != _User.Password)
            {
                e.Cancel = true;
                txtCurrentPassword.Focus();
                errorProvider1.SetError(txtCurrentPassword, "This password is not correct,\nPlease,Set correct password");
                return;
            }
            else
            {
                e.Cancel = false;
                
                errorProvider1.SetError(txtCurrentPassword, "");
                return;
            }


        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                e.Cancel = true;
                txtNewPassword.Focus();
                errorProvider1.SetError(txtNewPassword, "Password is Requarid in system.");
            }
            else if (!string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                if (txtNewPassword.Text != txtConfirmPassword.Text)
                {

                    txtConfirmPassword.Focus();
                    errorProvider1.SetError(txtConfirmPassword, "Password doesn`t match,\nBe focus when set password");
                    return;
                }
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNewPassword, "");
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                e.Cancel = true;
                txtConfirmPassword.Focus();
                errorProvider1.SetError(txtConfirmPassword, "Confirm Password is Requarid in system.");
                return;
            }
            else if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                e.Cancel = true;
                txtNewPassword.Focus();
                errorProvider1.SetError(txtConfirmPassword, "First, Set Password");
                return;
            }
            else if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                e.Cancel = true;
                txtNewPassword.Focus();
                errorProvider1.SetError(txtConfirmPassword, "Password doesn`t match,\nBe focus when set password");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, "");
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_User == null || txtCurrentPassword.Text != _User.Password || txtNewPassword.Text == txtCurrentPassword.Text || txtConfirmPassword.Text != txtNewPassword.Text)
            {
                MessageBox.Show("First, Add Correct Data to save,\nOr You set password same the cuurent password","Wrong Save!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clsFiles.LoginDataInFile(_User.Username, _User.Password, true);
            _User.Password = txtNewPassword.Text;
            if(_User.Save())
            {
                if(MessageBox.Show("Password Changed successfully.", "Save data", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    clsFiles.LoginDataInFile(_User.Username, _User.Password, false, true);
                    //if(_IsCurrentUser)
                    //{
                    //    clsGlobalSettings.CurrentUser = clsBusinessUsers.Find(clsGlobalSettings.CurrentUser.UserID);
                    //}
                    txtCurrentPassword.Text = _User.Password;
                    txtNewPassword.Text = string.Empty;
                    txtConfirmPassword.Text = string.Empty;
                }
            }
            else
            {
                if(MessageBox.Show("Save is fail.", "Save data", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    txtCurrentPassword.Text = string.Empty;
                    txtNewPassword.Text = string.Empty;
                    txtConfirmPassword.Text = string.Empty;
                }

            }


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
     



    }
}
