using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyFirstLibraryInForm;
namespace FlipTheNumbers
{
    public partial class FrmSignUp : Form
    {
        public static FrmSignUp instance;
        public FrmSignUp()
        {
            InitializeComponent();
        instance = this;
        }

        public static bool ShowFoundPlayer;

        public stPlayerInfo playerInfo;
       public struct stPlayerInfo
        {
            public string UserName, Password, Gender;
        }



        void ColorControl(Color color)
        {
            lblUserName.ForeColor = color;
            lblPassword.ForeColor = color;
            txtPassword.ForeColor = color;
            txtUserName.ForeColor = color;
            btnAccept.BackColor = color;
            btnFindPlayer.BackColor = color;
        }

        bool IsFullData()
        {
            return
                (rbBoy.Checked || rbGirl.Checked)
                && (!string.IsNullOrEmpty(playerInfo.UserName) && !string.IsNullOrEmpty(playerInfo.Password)
                && (playerInfo.UserName.Length > 4 && playerInfo.Password.Length > 4));
        }

        void TextBoxValidating(TextBox txt, CancelEventArgs e)
        {
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
        void EnableAcceptAndFind()
        {
            if (ShowFoundPlayer)
            {
                btnFindPlayer.Visible = true;
            }

            if (IsFullData())
            {
           
                btnAccept.Visible = true;
            }
            else
            {
                
                btnAccept.Visible = false;
            }
        }

        void ChangeSizeTextBox(TextBox txt)
        {
         
           if(txt.Text.Length >= 9) 
           {
               txt.Size = new Size(136, 27);
           }
           else
           {
               txt.Size = new Size(100, 27);
           }
          
        }

        

        Form frmRequarmens = new FrmRequarmensGame();
        void ShowFormRequarmensGame()
        {
            if(frmRequarmens.IsDisposed) 
            {
                frmRequarmens = new FrmRequarmensGame();
                frmRequarmens.Show();
                return; 
            }
            frmRequarmens.Show();
        }

       bool FoundPlayer(string userName, string password)
        {
            string FinalResult = default;
            for (int i = 0; i < FrmResultGame.stGame.CounterPlayer; i++)
            {
                if(userName == FrmResultGame.arrPlayerInfosAll[i].UserName || password == FrmResultGame.arrPlayerInfosAll[i].Password)
                {
                    return true;
                }
            }
            return false;
        }

        void WhenPressButtonAccept()
        {
            if(ShowFoundPlayer)
            {
                
                if (FoundPlayer(txtUserName.Text,txtPassword.Text))
                {
                    if(MessageBox.Show("The UserName OR Password already exist.\n\n\nPlease enter another one","Account is already exist",
                        MessageBoxButtons.OK,MessageBoxIcon.Error) == DialogResult.OK)
                    {
                        txtUserName.Text = default;
                        txtPassword.Text = default;
                        return;
                    }
                }


            }


            if(MessageBox.Show("Do you want save your data?\nAnd play ?","Start For Play",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ShowFormRequarmensGame ();
                this.Hide();
            }
        }

        void WhenPressFindPlayer()
        {
           FrmFindPlayerInfo findPlayerInfo = new FrmFindPlayerInfo();
            findPlayerInfo.ShowDialog();
        }

        private void PicBoyOrGirl_Click(object sender, EventArgs e)
        {
          
            if (PicGender.Tag.ToString() == "+")
            {
                PicGender.Tag = "-";
                rbGirl.Checked = true;

                //Color control
                ColorControl(Color.Orange);
                rbGirl.ForeColor = Color.Orange;
                rbBoy.ForeColor = Color.White;

                PicGender.Image = Image.FromFile(@"C:\Photos\NewGirl.png");
                PicRight.Image = Image.FromFile(@"C:\Photos\RightMark(Orange).jpg");
                PicLeft.Image = Image.FromFile(@"C:\Photos\LeftMark(Orange).jpg");

                playerInfo.Gender = "Girl";
              
            }
            
            else
            {
                PicGender.Tag = "+";
                rbBoy.Checked = true;

                //Color control
                ColorControl(Color.DarkCyan);
                rbGirl.ForeColor = Color.White;
                rbBoy.ForeColor = Color.DarkCyan;

                PicGender.Image = Image.FromFile(@"C:\Photos\NewBoy.png");
                PicRight.Image = Image.FromFile(@"C:\Photos\RightMark(Blue).jpg");
                PicLeft.Image = Image.FromFile(@"C:\Photos\LeftMark(Blue).jpg");

                playerInfo.Gender = "Boy";
               
            }

            EnableAcceptAndFind();

        }

        void ResetData()
        {
            playerInfo.UserName = string.Empty;
            playerInfo.Gender = string.Empty;
            playerInfo.UserName = string.Empty;

            rbBoy.Checked = false;
            rbGirl.Checked = false;
            txtUserName.Text = "";
            txtPassword.Text = "";

        }

        public void PlayAgain()
        {
            Application.OpenForms["FrmSignUp"].Show();
            ResetData();


        }

        void ChangeVisibleFind()
        {
            if (FrmResultGame.arrPlayerInfosAll[0].NumberOfRounds == 0) //AllPlayer_Deleted
            {
               btnFindPlayer.Visible = false;
                ShowFoundPlayer = false;
            }
            else
            {
                ShowFoundPlayer = true;
                btnFindPlayer.Visible=true;
            }
        }

        private void rbBoy_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            playerInfo.UserName = txtUserName.Text;
            ChangeSizeTextBox(txtUserName);
            EnableAcceptAndFind();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            playerInfo.Password = txtPassword.Text;
            ChangeSizeTextBox(txtPassword);
            EnableAcceptAndFind();
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            TextBoxValidating(txtUserName, e);
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            TextBoxValidating(txtPassword, e);
        }

        

        private void FrmSignUp_Load(object sender, EventArgs e)
        {
            this.Size = new Size(321, 594);
            if (ShowFoundPlayer)
            {
               
                btnFindPlayer.Visible = true;
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            WhenPressButtonAccept();
        }

        private void txtPassword_MouseEnter(object sender, EventArgs e)
        {
            char CharPassword = default;
            TextBox textBox = (TextBox)sender;
            textBox.PasswordChar = CharPassword;
        }

        private void txtPassword_MouseLeave(object sender, EventArgs e)
        {
            char CharPassword = '*';
            TextBox textBox = (TextBox)sender;
            textBox.PasswordChar = CharPassword;
        }

        private void btnFindPlayer_Click(object sender, EventArgs e)
        {
            WhenPressFindPlayer();
        }

        private void PicSignUp_Click(object sender, EventArgs e)
        {

        }

        private void PicSignUp_MouseEnter(object sender, EventArgs e)
        {
            ChangeVisibleFind();
        }
    }
}
