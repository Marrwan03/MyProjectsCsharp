using System;
using System.IO;
using System.Data;

using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections;
using clsBusinessTier;
using MyLibrary;
using System.Drawing;

namespace DVLD_Project
{
    public partial class frmLoginSystem : Form
    {
        public frmLoginSystem()
        {
            InitializeComponent();
        }
        public static frmLoginSystem frmLogin;
        clsBusinessUsers _CurrentUser;

       public void RefreshLoginData(string UserName,  string Password)
        {
            txtUsername.Text = UserName;
            txtPassword.Text = Password;
        }

        bool setLoginDataInTextBoxes()
        {
            string Path = @"C:\Users\lenovo\OneDrive\Desktop\LoginData\";
            if (File.Exists(Path + "LoginData.txt"))
            {
                string LoginData = File.ReadAllText(Path + "LoginData.txt");
                string[] Data = LoginData.Split('#');
                txtUsername.Text = Data[0];
                txtPassword.Text = Data[1];
                return true;
            }
           
            return false;
        }

       bool Check(string Username, string Password)
        {
            _CurrentUser = clsBusinessUsers.Find(Username, Password);
            if( _CurrentUser != null )
            {
                return true;
            }
            return false;
        }

        void _RefreshLoginData()
        {
            if (setLoginDataInTextBoxes())
            {
                chbrememberme.Checked = true;
                lblTitleLogin.Text = "We cannot forget you,\nWelcome Back :-)";
            }
            else
            {
                lblTitleLogin.Text = "Login to your account...";
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
            }
        }

        private void frmLoginSystem_Load(object sender, EventArgs e)
        {
            frmLogin = this;
            _RefreshLoginData();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(!Check(txtUsername.Text, txtPassword.Text))
            {
                MessageBox.Show("Invalid Username / Password", "Wrong Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!_CurrentUser.IsActive)
            {
                MessageBox.Show("You haven`t access in this system", "Wrong Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(chbrememberme.Checked)
            {
                clsFiles.LoginDataInFile(txtUsername.Text, txtPassword.Text,false, true);
            }
            else
            {
                clsFiles.LoginDataInFile(txtUsername.Text, txtPassword.Text, true, false);
            }

            frmLogin.Hide();
            frmMain mainScreen = new frmMain(_CurrentUser.UserID);
            mainScreen.DataBack += _RefreshLoginData;
            mainScreen.Show();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmLogin.Close();
        }

        private void txtPassword_MouseEnter(object sender, EventArgs e)
        {
            clsForm.ShowPassword(sender, e);
            clsColorControl.TextBox_MouseEnter(sender, e);
        }

        private void txtPassword_MouseLeave(object sender, EventArgs e)
        {
            clsForm.HidePassword(sender, e, '*');
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
        public  void CheckBox_MouseEnter(object sender, EventArgs e)
        {
           clsColorControl.CheckBox_MouseEnter(sender, e);
        }
        public  void CheckBox_MouseLeave(object sender, EventArgs e)
        {
           clsColorControl.CheckBox_MouseLeave(sender, e);
        }

        public  void TextBox_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.TextBox_MouseEnter(sender, e);
        }
        public  void TextBox_MouseLeave(object sender, EventArgs e)
        {
           clsColorControl.TextBox_MouseLeave(sender, e);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
