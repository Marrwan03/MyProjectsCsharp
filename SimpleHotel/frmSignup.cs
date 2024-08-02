using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleHotel
{
    public partial class frmSignup : Form
    {
        public static frmSignup Instance;
        public frmSignup()
        {
            InitializeComponent();
            Instance = this;
        }

     

        public bool FindUser(string username, string password,bool FirstLogin) 
        {
            foreach(frmCreateAccount.stUserInfo userInfo in frmCreateAccount.Quserinfo)
            {
                if (userInfo.Username.ToLower() == username.ToLower() || userInfo.Password.ToLower() == password.ToLower())
                {
                    return true;
                }
            }
            return false;
            
        }

        frmCreateAccount.stUserInfo FindUser(string username, string password)
        {
            foreach (frmCreateAccount.stUserInfo userInfo in frmCreateAccount.Quserinfo)
            {
                if (userInfo.Username.ToLower() == username.ToLower() && userInfo.Password.ToLower() == password.ToLower())
                {
                    return userInfo;
                }
            }
            return default;
        }

        void CreateAccount()
        {
            frmCreateAccount frmCreateAccount = new frmCreateAccount();
            frmCreateAccount.ShowDialog();

        }

       public void EmptyTextBox()
        {
            txtUserName.Text = default;
            txtPassword.Text = default;
        }

        bool EmptyData()
        {
            return (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text));
        }

      

       public void ValidatingTextBox(object sender, CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;

            if(txt.Text.Length <= 4)
            {
                e.Cancel = true;
                txt.Focus();
                errorProvider1.SetError(txt, "You must enter almost Upper than 4 letters");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txt, "");
            }
        }

        public void ValidatingTextBox(object sender, CancelEventArgs e, int NumberOfLength)
        {
            TextBox txt = (TextBox)sender;

            if (txt.Text.Length <= NumberOfLength)
            {
                e.Cancel = true;
                txt.Focus();
                errorProvider1.SetError(txt, "You must enter almost Upper than "+NumberOfLength.ToString()+ " letters");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txt, "");
            }
        }

        bool CheckCountletterTextbox(string text)
        {
            return text.Length <= 4;
        }

        void EnableButtonLogin(object sender, EventArgs e)
        {
            if(EmptyData() || CheckCountletterTextbox(txtUserName.Text) || CheckCountletterTextbox(txtPassword.Text))
            {
                btnLogin.Enabled = false;
            }
            else
            {
                btnLogin.Enabled = true;
            }
        }

        void FirstLoginInProject()
        {
            if (MessageBox.Show("username OR password is not here!\n\n-if you don`t have account Press [Yes] to Create new account.", "Wrong Account!",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button3) == DialogResult.Yes)
            {
                CreateAccount();
            }
            else
            {
                EmptyTextBox();
            }
        }

        Form frmHotelPage = new frmHotelPage();
        void ShowfrmHotelPage()
        {
            if (frmHotelPage.IsDisposed)
            {
                frmHotelPage = new frmHotelPage();
                frmHotelPage.Show();
                return;
            }
            frmHotelPage.Show();
        }


        void SecondLoginInProject()//When set one User
        {
            frmCreateAccount.stUserInfo userInfo = new frmCreateAccount.stUserInfo();
            userInfo = FindUser(txtUserName.Text, txtPassword.Text);
            if (string.IsNullOrEmpty(userInfo.Username))
            {
                if (MessageBox.Show("username OR password is not here!.\n\n\nPlease enter another one", "Account is already exist",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    EmptyTextBox();
                }
                else
                {
                    FirstLoginInProject();
                }
            }
            else
            {
                frmCreateAccount.CurrentuserInfo = userInfo;
                ShowfrmHotelPage();
                this.Hide();
            }
        }

        void WhenUserPressLogin()
        {
           
            if(!FindUser(txtUserName.Text, txtPassword.Text,true))
            {
                FirstLoginInProject();
                return;
            }
            SecondLoginInProject();
            
            return;
        }

        public void WhenButtonEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.ForeColor = Color.Red;
            btn.FlatAppearance.BorderColor = Color.Red;
        }

        public void WhenButtonLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.ForeColor = Color.Black;
            btn.FlatAppearance.BorderColor = Color.Black;
        }

     
        bool IsSureToCreateAccount()
        {
            if (MessageBox.Show("Are you sure, Do you wanna to Create New Account? ", "Create Account!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }

        void EnterButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.ForeColor = Color.White;
        }

        void LeaveButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.ForeColor = Color.Black;
        }

        public void txtPassword_MouseEnter(object sender, EventArgs e)
        {
            char CharPassword = default;
            TextBox textBox = (TextBox)sender;
            textBox.PasswordChar = CharPassword;
        }

        public void txtPassword_MouseLeave(object sender, EventArgs e)
        {
            char CharPassword = '*';
            TextBox textBox = (TextBox)sender;
            textBox.PasswordChar = CharPassword;
        }

        private void frmSignup_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            WhenUserPressLogin();
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            WhenButtonEnter(sender, e);
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            WhenButtonLeave(sender, e);
        }

       

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if(IsSureToCreateAccount())
            {
               CreateAccount();
            }
        }
    }
}
