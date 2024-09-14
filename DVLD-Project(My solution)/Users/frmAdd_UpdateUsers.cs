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
    public partial class frmAdd_UpdateUsers : Form
    {
       
        clsBusinessPeople _clsPerson;
        int _UserID;
        clsBusinessUsers _clsUsers;
        public frmAdd_UpdateUsers(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }
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

       
        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtUserName.Text))
            {
                e.Cancel = true;
                txtUserName.Focus();
                errorProvider1.SetError(txtUserName, "UserName is Requarid in system.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUserName, "");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProvider1.SetError(txtPassword, "Password is Requarid in system.");
            }
            else if(!string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    
                    txtConfirmPassword.Focus();
                    errorProvider1.SetError(txtConfirmPassword, "Password doesn`t match,\nBe focus when set password");
                    return;
                }
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, "");
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
           else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                txtUserName.Focus();
                errorProvider1.SetError(txtConfirmPassword, "First, Set Password");
                return;
            }
           else if(txtPassword.Text != txtConfirmPassword.Text)
            {
                e.Cancel = true;
                txtUserName.Focus();
                errorProvider1.SetError(txtConfirmPassword, "Password doesn`t match,\nBe focus when set password");
                return;
            }
            else
            {
                e.Cancel= false;
                errorProvider1.SetError(txtConfirmPassword, "");
            }

           
        }



        private void frmAdd_UpdateUsers_Load(object sender, EventArgs e)
        {
            if(_UserID == -1)
            {
                _clsUsers = new clsBusinessUsers();
                ctrlPersonInfoWithFilter1.ctrlFilter1.Enabled = true;
                lblTitle.Text = "Add New User";
                this.Text = lblTitle.Text;
                return;
            }
            ctrlPersonInfoWithFilter1.ctrlFilter1.Enabled = false;
            _clsUsers = clsBusinessUsers.Find(_UserID);
            _clsPerson = clsBusinessPeople.Find(_clsUsers.PersonID);
            lblTitle.Text = $"Update User {_clsUsers.UserID}";
            this.Text = lblTitle.Text;
            ctrlPersonInfoWithFilter1.ctrlFilter1.cbFilter.SelectedIndex = 0;
            ctrlPersonInfoWithFilter1.ctrlFilter1.txtFilterName.Text = _clsPerson.NationalNo;
            ctrlPersonInfoWithFilter1.ctrlFilter1.Enabled = false;
            ctrlPersonInfoWithFilter1.ctrlPersonInformtion1.LoadctrlPersonInformtion(_clsPerson);
            lblUserID.Text = _clsUsers.UserID.ToString();
            txtUserName.Text = _clsUsers.Username.ToString();
            txtPassword.Text = _clsUsers.Password;
            txtConfirmPassword.Text = _clsUsers.Password;
            cbIsActive.Checked = _clsUsers.IsActive;
            lblUserID.Tag = "!";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_clsPerson == null || string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtConfirmPassword.Text) || txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Save is fail, \nYou must fill Each data", "Fail Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_UserID == -1)
            {
                _clsUsers.PersonID = _clsPerson.ID;
            }
            lblUserID.Tag = "!";
            _clsUsers.Username = txtUserName.Text;
            _clsUsers.Password = txtPassword.Text;  
            _clsUsers.IsActive = cbIsActive.Checked;

            if(_clsUsers.Save())
            {
                lblTitle.Text = $"Update User {_clsUsers.UserID}";
                ctrlPersonInfoWithFilter1.ctrlFilter1.Enabled = false;
                lblUserID.Text = _clsUsers.UserID.ToString();

                MessageBox.Show("Save is succeeded", "Succeeful Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Save is fail", "Fail Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public  void CheckBox_MouseEnter(object sender, EventArgs e)
        {
           clsColorControl.CheckBox_MouseEnter(sender, e);
        }
        public  void CheckBox_MouseLeave(object sender, EventArgs e)
        {
           clsColorControl.CheckBox_MouseLeave(sender, e);
        }

       

        private void ShowPassword(object sender, EventArgs e)
        {
            clsForm.ShowPassword(sender, e);
            TextBox_MouseEnter(sender, e);
        }

        private void HidePassword(object sender, EventArgs e)
        {
           clsForm.HidePassword(sender, e, '*');
            TextBox_MouseLeave(sender, e);
        }

      

       

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(ctrlPersonInfoWithFilter1.ctrlFilter1.txtFilterName.Text))
            {
                if(MessageBox.Show("You must set some Filter to continue.", "Wrong!", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    return;
                }
            }
            _clsPerson = clsBusinessPeople.Find(int.Parse(ctrlPersonInfoWithFilter1.ctrlPersonInformtion1.lblPersonID.Text));
            if (lblUserID.Tag == "!" )
            {
                tcAdd_UpdateUser.SelectedTab = tpLoginInfo;
                return;
            }
            if (clsBusinessUsers.IsExists(_clsPerson.ID))
            {
                MessageBox.Show("This Person is already refrance with another user.", "Set Another Person!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tcAdd_UpdateUser.SelectedTab = tpLoginInfo;
        }

        private void ctrlPersonInfoWithFilter1_OnLinkUpdate()
        {
            frmAdd_UpdatePerson frmAdd_Person = new frmAdd_UpdatePerson(int.Parse(ctrlPersonInfoWithFilter1.ctrlPersonInformtion1.lblPersonID.Text));
            frmAdd_Person.ShowDialog();
            _clsPerson = clsBusinessPeople.Find(int.Parse(ctrlPersonInfoWithFilter1.ctrlPersonInformtion1.lblPersonID.Text));
            ctrlPersonInfoWithFilter1.ctrlPersonInformtion1.LoadctrlPersonInformtion(_clsPerson);
        }
    }
}
