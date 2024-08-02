using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FlipTheNumbers
{
    public partial class FrmFindPlayerInfo : Form
    {
        public FrmFindPlayerInfo()
        {
            InitializeComponent();
        }

        stPlayerInfo playerInfo;
        public struct stPlayerInfo
        {
            public Image ImagePLayer;
            public string UserName;
            public string Password;
            //Diff = diffrenet between (NumberOfRounds && NumberOfTries)
            public byte NumberOfTrue, NumberOfFalse, NumberOfRounds, NumberOfTries;
            public string FinalResult;
            public string Gender;
            
        };

        //stPlayerInfo FillstPlayerInfo(stPlayerInfo playerInfoFind)
        //{
        //    stPlayerInfo playerInfo;
        //    playerInfo.Gender = playerInfoFind.Gender;

        //    if (playerInfo.Gender == "Boy")
        //    {
        //        playerInfo.ImagePLayer = Image.FromFile(@"C:\Photos\NewBoy.png");
        //        lblTitleRank.Text = "His Rank : ";
        //    }
               
        //    else
        //    {
        //        playerInfo.ImagePLayer = Image.FromFile(@"C:\Photos\NewGirl.png");
        //        lblTitleRank.Text = "Her Rank : ";
        //    }
               
        //    playerInfo.UserName = playerInfoFind.UserName;
        //    playerInfo.Password = playerInfoFind.Password;
        //    playerInfo.NumberOfTrue = playerInfoFind.NumberOfTrue;
        //    playerInfo.NumberOfFalse = playerInfoFind.NumberOfFalse;
        //    playerInfo.NumberOfRounds = playerInfoFind.NumberOfRounds;
        //    playerInfo.NumberOfTries = playerInfoFind.NumberOfTries;
        //    playerInfo.Diff = Convert.ToByte(playerInfoFind.NumberOfRounds - playerInfoFind.NumberOfTries);


        //    if (playerInfo.NumberOfTrue >= playerInfo.NumberOfFalse)
        //    {
        //        lblResultGame.ForeColor = Color.Green;
        //        playerInfo.FinalResult = "Pass :-)";
        //    }
        //    else
        //    {
        //        lblResultGame.ForeColor = Color.Red;
        //        playerInfo.FinalResult = "Fail :-(";
        //    }
        //    return playerInfo;

        //}

        bool IsFullData()
        {
            return (!string.IsNullOrEmpty(txtUserNameFound.Text) && !string.IsNullOrEmpty(txtPasswordFound.Text));

        }

        void EnableButtonFind()
        {
            if(IsFullData())
            {
                btnFindPlayer.Enabled = true;
            }
            else
            {
                btnFindPlayer.Enabled = false;
            }
        }

        bool FoundPlayer(string username, string password)
        {
            for (int i = 0; i < FrmResultGame.stGame.CounterPlayer; i++)
            {
                if (username == FrmResultGame.arrPlayerInfosAll[i].UserName && password == FrmResultGame.arrPlayerInfosAll[i].Password)
                {
                    lblRank2.Text = Convert.ToString(i + 1);
                    playerInfo.ImagePLayer = FrmResultGame.arrPlayerInfosAll[i].ImagePLayer;
                    playerInfo.UserName = FrmResultGame.arrPlayerInfosAll[i].UserName;
                    playerInfo.Password = FrmResultGame.arrPlayerInfosAll[i].Password;
                    playerInfo.NumberOfRounds = FrmResultGame.arrPlayerInfosAll[i].NumberOfRounds;
                    playerInfo.NumberOfTries = FrmResultGame.arrPlayerInfosAll[i].NumberOfTries;
                    playerInfo.NumberOfTrue = FrmResultGame.arrPlayerInfosAll[i].NumberOfTrue;
                    playerInfo.NumberOfFalse = FrmResultGame.arrPlayerInfosAll[i].NumberOfFalse;
                    playerInfo.Gender = FrmResultGame.arrPlayerInfosAll[i].Gender;
                 //   playerInfo.Diff = Convert.ToByte(playerInfo.NumberOfRounds - playerInfo.NumberOfTries);
                    playerInfo.FinalResult = FrmResultGame.arrPlayerInfosAll[i].FinalResult;
                    return true;
                }
            }
            return false;
        }

        void SetForeColor(Color color)
        {
            txtUserName2.ForeColor = color;
            txtPassword2.ForeColor = color;
            txtNumberOfRounds2.ForeColor = color;
            txtNumberOfTries2.ForeColor = color;
            txtNumberOfTrue2.ForeColor = color;
            txtNumberOfFalse2.ForeColor = color;
        }

        public void SetImage()
        {
            if (playerInfo.Gender == "Boy")
            {
                picUserName.Image = Image.FromFile(@"C:\Photos\PersonMark(Blue).jpg");
                picPassword.Image = Image.FromFile(@"C:\Photos\PasswordMark(Blue).jpg");
                picNumberOfRound.Image = Image.FromFile(@"C:\Photos\RoundMark(Blue).jpg");
                picNumberOfTries.Image = Image.FromFile(@"C:\Photos\TryMark(Blue).jpg");
                picNumberOfTrue.Image = Image.FromFile(@"C:\Photos\TrueMark(Blue).jpg");
                picNumberOfFalse.Image = Image.FromFile(@"C:\Photos\FalseMark(Blue).jpg");

                SetForeColor(Color.DarkCyan);
            }
            else
            {
                picUserName.Image = Image.FromFile(@"C:\Photos\PersonMark(Orange).jpg");
                picPassword.Image = Image.FromFile(@"C:\Photos\PasswordMark(Orange).jpg");
                picNumberOfRound.Image = Image.FromFile(@"C:\Photos\RoundMark(Orange).jpg");
                picNumberOfTries.Image = Image.FromFile(@"C:\Photos\TryMark(Orange).jpg");
                picNumberOfTrue.Image = Image.FromFile(@"C:\Photos\TrueMarket(Orange).jpg");
                picNumberOfFalse.Image = Image.FromFile(@"C:\Photos\FalseMarket(Orange).jpg");
                SetForeColor(Color.Orange);
            }
        }

        void FillDataInControl2Find()
        {
            SetImage();
            picImageGender2.Image = playerInfo.ImagePLayer;
            txtUserName2.Text = playerInfo.UserName;
            txtPassword2.Text = playerInfo.Password;
            txtNumberOfRounds2.Text = playerInfo.NumberOfRounds.ToString() + " Round(s).";
            txtNumberOfTries2.Text = playerInfo.NumberOfTries.ToString() + " Try(ies).";
            txtNumberOfTrue2.Text = playerInfo.NumberOfTrue.ToString() + " True.";
            txtNumberOfFalse2.Text = playerInfo.NumberOfFalse.ToString() + " False.";
            lblResultGame2.Text = playerInfo.FinalResult;
        }

        void SetPlayerDataInControl()
        {

            FillDataInControl2Find();

            if (playerInfo.Gender == "Boy")
                {
                   // playerInfo.ImagePLayer = Image.FromFile(@"C:\Photos\NewBoy.png");
                    lblTitleRank.Text = "His Rank : ";
                }

                else
                {
                    //playerInfo.ImagePLayer = Image.FromFile(@"C:\Photos\NewGirl.png");
                    lblTitleRank.Text = "Her Rank : ";
                }

                if (playerInfo.NumberOfTrue >= playerInfo.NumberOfFalse)
                {
                    lblResultGame2.ForeColor = Color.Green;
                   // playerInfo.FinalResult = "Pass :-)";
                }
                else
                {
                    lblResultGame2.ForeColor = Color.Red;
                   // playerInfo.FinalResult = "Fail :-(";
                }

               
        }

        void DeletePlayer2Find(string username,string password)
        {
            FrmResultGame.instance.DeletePlayer(username,password);
        }

       

        void WhenPressDeletePlayer()
        {
            if(txtPlayerDelete.Visible)
            {
               if(MessageBox.Show("This Player is delete already!", "Delete Player!",MessageBoxButtons.OK) == DialogResult.OK)
                {
                    return;
                }
            }

            if(MessageBox.Show("Are you sure, Do you want delete this Player["+playerInfo.UserName+"] ? ","Delete Player!",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DeletePlayer2Find(txtUserName2.Text, txtPassword2.Text);
                notifyIcon1.Icon = SystemIcons.Application;
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon1.BalloonTipTitle = "Delete Player";
                notifyIcon1.BalloonTipText = "The player [" + playerInfo.UserName + "] has been successfully deleted";
                notifyIcon1.ShowBalloonTip(10);
                txtPlayerDelete.Visible = true;
            }
            else
            {
                txtPlayerDelete.Visible = false;
                
            }
           
        }

        void WhenMouseLeaveButton(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.ForeColor = Color.Black;
        }

        void WhenMouseEnterButton(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.ForeColor = Color.Red;
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

        private void FrmFindPlayerInfo_Load(object sender, EventArgs e)
        {
            txtPlayerDelete.Visible = false;
            this.Size = new System.Drawing.Size(321, 302);
        }

        private void txtUserNameFound_TextChanged(object sender, EventArgs e)
        {
            EnableButtonFind();
        }

        private void txtPasswordFound_TextChanged(object sender, EventArgs e)
        {
            EnableButtonFind();
        }

        private void btnFindPlayer_Click(object sender, EventArgs e)
        {
            if(FoundPlayer(txtUserNameFound.Text,txtPasswordFound.Text))
            {
                if (txtPlayerDelete.Visible)
                    txtPlayerDelete.Visible = false;
                SetPlayerDataInControl();
                this.Size = new System.Drawing.Size(321, 615);
            }
            else
            {
                if(MessageBox.Show("Username Or Password is Not Found","Wrong data!",MessageBoxButtons.OKCancel,MessageBoxIcon.Error) == DialogResult.OK)
                {
                    return;
                }
                else
                    this.Close();
               // this.Hide();
            }
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WhenPressDeletePlayer();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pPlayerInfo_MouseEnter(object sender, EventArgs e)
        {

        }
    }
}
