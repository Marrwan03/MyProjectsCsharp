using MyFirstLibraryInForm;
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
    public partial class FrmResultGame : Form
    {
        public static FrmResultGame instance;

        public FrmResultGame()
        {
            InitializeComponent();
            instance = this;
        }



        public static stPlayerInfo[] arrPlayerInfosAll = new stPlayerInfo[50];

        stGame game;
        public  struct stGame
        {
            
            public static byte CounterPlayer;
        }

        public static Queue<stPlayerInfo> QueuePlayerInfos = new Queue<stPlayerInfo>();

        stPlayerInfo playerInfo;
         public struct stPlayerInfo
        {
        
            public Image ImagePLayer;
            public string UserName;
            public string Password;
            //Diff = diffrenet between (NumberOfRounds && NumberOfTries)
            public byte NumberOfTrue, NumberOfFalse, NumberOfRounds,NumberOfTries, Diff;
            public string FinalResult;
            public string Gender;
           
        };

        stPlayerInfo FillstPlayerInfo()
        {
            stPlayerInfo playerInfo;
            playerInfo.Gender = FrmSignUp.instance.playerInfo.Gender;

            if (playerInfo.Gender == "Boy")
                playerInfo.ImagePLayer = Image.FromFile(@"C:\Photos\NewBoy.png");
            else
                playerInfo.ImagePLayer = Image.FromFile(@"C:\Photos\NewGirl.png");
            playerInfo.UserName = FrmSignUp.instance.playerInfo.UserName;
            playerInfo.Password = FrmSignUp.instance.playerInfo.Password;
            playerInfo.NumberOfTrue = FrmGame.instance.Game.CounterOfWin;
            playerInfo.NumberOfFalse = FrmGame.instance.Game.CounterOfLose;
            playerInfo.NumberOfRounds = FrmGame.instance.Game.NumberOfRound;
            playerInfo.NumberOfTries = FrmGame.instance.Game.CounterTriesGame;
            playerInfo.Diff = Convert.ToByte (playerInfo.NumberOfRounds - playerInfo.NumberOfTries);
           

            if (playerInfo.NumberOfTrue >= playerInfo.NumberOfFalse)
            {
                lblResultGame.ForeColor = Color.Green;
                playerInfo.FinalResult = "Pass :-)";
            }
            else
            {
                lblResultGame.ForeColor = Color.Red;
                playerInfo.FinalResult = "Fail :-(";
            }
            return playerInfo;
               
        }

        void SetForeColor(Color color)
        {
          
          txtUserName.ForeColor = color;
          txtPassword.ForeColor = color;
          txtNumberOfRounds.ForeColor = color;
          txtNumberOfTries.ForeColor = color;
          txtNumberOfTrue.ForeColor = color;
          txtNumberOfFalse.ForeColor = color;

            //Back
         
          btnPlayAgain.BackColor = color;
          btnShowRank.BackColor = color;
          btnExit.BackColor = color;
         
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

       public void FillDataCountrol(stPlayerInfo playerInfo)
        {
            SetImage();

            picImageGender.Image = playerInfo.ImagePLayer;
            txtUserName.Text = playerInfo.UserName;
            txtPassword.Text = playerInfo.Password;
            txtNumberOfRounds.Text = playerInfo.NumberOfRounds.ToString() + " Round(s).";
            txtNumberOfTries.Text = playerInfo.NumberOfTries.ToString() + " Try(ies).";
            txtNumberOfTrue.Text = playerInfo.NumberOfTrue.ToString() + " True.";
            txtNumberOfFalse.Text = playerInfo.NumberOfFalse.ToString() + " False.";
            lblResultGame.Text = playerInfo.FinalResult;
        }

        void WhenPressExit()
        {
            if(MessageBox.Show("Are you sure do you want exit game ? ", "Exit Game",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FrmSignUp.instance.Close();
                FrmRequarmensGame.Instance.Close();
                FrmGame.instance.Close();
                this.Close();
            }
        }

        void WhenPressPlayAgain()
        {

            this.Hide();
  
            FrmRequarmensGame.Instance.Close();
            FrmGame.instance.Close();
            //FrmGame.instance.PlayAgain();
            //FrmRequarmensGame.Instance.PlayAgain(false);
            if (arrPlayerInfosAll[0].NumberOfRounds == 0) //AllPlayer_Deleted
            {
                FrmSignUp.ShowFoundPlayer = false;
            }
            else
            {
                FrmSignUp.ShowFoundPlayer = true;
            }
            
            FrmSignUp.instance.PlayAgain();

        }

        void FillListaView(stPlayerInfo playerInfo, byte Rank)
        {
            ListViewItem item = new ListViewItem(Rank.ToString());

            if (playerInfo.Gender =="Boy")
            {
                item.ImageIndex = 0;
            }
            else
            {
                item.ImageIndex = 1;
            }

            item.SubItems.Add(playerInfo.UserName);
            item.SubItems.Add(playerInfo.Password);
            item.SubItems.Add(playerInfo.Diff.ToString());

            if (playerInfo.NumberOfTrue >= playerInfo.NumberOfFalse)
            {
                item.SubItems.Add("Yes :-)");
            }
            else
            {
                item.SubItems.Add("No :-(");
            }

            listRanking.Items.Add(item);

        }

       public stPlayerInfo CheckStruct(stPlayerInfo playerInfoCheck)
        {

            for (int i = 0; i < stGame.CounterPlayer; i++)
            {
                if(playerInfoCheck.Diff >= arrPlayerInfosAll[i].Diff && arrPlayerInfosAll[i].NumberOfRounds != 0)
                {
                    playerInfoCheck = arrPlayerInfosAll[i];
                }
            }

            return playerInfoCheck;
        }


       


        stPlayerInfo[] UpdatearrPlayerInfosAll(stPlayerInfo playerInfoCheck)
        {
            stPlayerInfo[] arrPlayerInfosAllUpdate = new stPlayerInfo[arrPlayerInfosAll.Length];
            int index = 0;
            for (int i = 0; i < stGame.CounterPlayer; i++)
            {
                if (playerInfoCheck.UserName != arrPlayerInfosAll[i].UserName && (playerInfoCheck.Password != arrPlayerInfosAll[i].Password) && (arrPlayerInfosAll[i].NumberOfRounds != 0))
                {
                    arrPlayerInfosAllUpdate[index] = arrPlayerInfosAll[i];
                    index++;
                }
            }


            return arrPlayerInfosAllUpdate;
           
        }

        void FillDataInArr()
        {
           
            stPlayerInfo playerInfo1;
            stPlayerInfo[] arrPlayerInfosAllUpdate = new stPlayerInfo[arrPlayerInfosAll.Length];

            if(stGame.CounterPlayer > 1)
            {
                //playerInfo1 = arrPlayerInfosAll[0];
                //QueuePlayerInfos.Enqueue(playerInfo1);
                //return;
                int index = 0;
                for (int i = 0; i < stGame.CounterPlayer; i++)
                {
                    
                    playerInfo1 = CheckStruct(arrPlayerInfosAll[i]);//
                    
                    arrPlayerInfosAllUpdate[index] = playerInfo1;
                    index++;

                    arrPlayerInfosAll = UpdatearrPlayerInfosAll(playerInfo1);
                    if (arrPlayerInfosAll[0].NumberOfRounds == 0)
                    {
                        i = stGame.CounterPlayer;
                    }
                    else
                    {
                        i = -1;
                    }
                    //DeleteDataFromStack(playerInfo1);
                    //FillListaView(playerInfo, Counter);
                }
                arrPlayerInfosAll = arrPlayerInfosAllUpdate;
            }
           
        }

        void FillDataArrInListViewTop_Down()
        {
            lblFilterName.Text = "Top - Down";
            byte Counter = default;
            listRanking.Items.Clear();
            for (int i = 0; i < stGame.CounterPlayer; i++)
            {
                Counter++;
                FillListaView(arrPlayerInfosAll[i], Counter);
            }
        }

        void FillDataArrInListViewDown_Top()
        {
            lblFilterName.Text = "Down - Top";
            byte Counter = stGame.CounterPlayer;
            listRanking.Items.Clear();
            for (int i = stGame.CounterPlayer - 1; i >= 0; i--)
            {
                FillListaView(arrPlayerInfosAll[i], Counter);
                Counter--;
            }
        }

        void FillDataArrInListViewOnlyBoy()
        {
            lblFilterName.Text = "Only Boys";
            byte Counter = default;
            listRanking.Items.Clear();
            for (int i = 0; i < stGame.CounterPlayer; i++)
            {
                Counter++;
                if (arrPlayerInfosAll[i].Gender == "Boy")
                {
                    FillListaView(arrPlayerInfosAll[i], Counter);
                } 
            }
        }

        void FillDataArrInListViewOnlyGirl()
        {
            lblFilterName.Text = "Only Girls";
            byte Counter = default;
            listRanking.Items.Clear();
            for (int i = 0; i < stGame.CounterPlayer; i++)
            {
                Counter++;
                if (arrPlayerInfosAll[i].Gender == "Girl")
                {
                    FillListaView(arrPlayerInfosAll[i], Counter);
                }
            }
        }


        void WhenPressShowRank()
        {
            this.Size = new Size(691, 594);
        }

        void WhenMouseLeaveButton(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.ForeColor = Color.Black;
        }

        void WhenMouseEnterButton(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.ForeColor = Color.White;
        }

        void ShowYourMessage(object sender, EventArgs e,string Title, string YourMessage)
        {
            if(MessageBox.Show(YourMessage,Title, MessageBoxButtons.OK) == DialogResult.OK)
            {
                return;
            }
        }

       public void DeletePlayer(string username, string password)
        {
            //-1 To Equal from 0
           
            stPlayerInfo[] arrPlayerInfo = new stPlayerInfo[50];
            int index = 0;
            byte CounterPlayer = stGame.CounterPlayer;

            for (int i = 0; i < stGame.CounterPlayer; i++)
            {
                if (username != arrPlayerInfosAll[i].UserName && password != arrPlayerInfosAll[i].Password)
                {
                    arrPlayerInfo[index] = arrPlayerInfosAll[i];
                    index++;
                }
                else
                {
                    CounterPlayer--;
                }
            }
            stGame.CounterPlayer = CounterPlayer;
            arrPlayerInfosAll = arrPlayerInfo;
        }

        private void FrmResultGame_Load(object sender, EventArgs e)
        {
            this.Size = new Size(321, 594);
            stGame.CounterPlayer++;
            
            playerInfo =  FillstPlayerInfo();
            arrPlayerInfosAll[stGame.CounterPlayer - 1] = playerInfo;
            //Rank 
            FillDataCountrol(playerInfo);
            FillDataInArr();//
            FillDataArrInListViewTop_Down();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            WhenPressExit();
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            WhenPressPlayAgain();
        }

        private void btnShowRank_Click(object sender, EventArgs e)
        {
            WhenPressShowRank();
        }

        private void btnCloseRanking_Click(object sender, EventArgs e)
        {
            this.Size = new Size(321, 594);
        }

        private void rankToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void topDownToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FillDataArrInListViewTop_Down();
        }

        private void rankToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ShowYourMessage(sender, e, "Info Rank", "To show players` levels.");
        }

        private void userNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowYourMessage(sender, e, "Info UserName", "To show players` UserName.");
        }

        private void passwordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowYourMessage(sender, e, "Info Password", "To show players` Password.");
        }

        private void dIFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowYourMessage(sender, e, "Info DIFF", "DIFF = Difference between [NumberOfRounds AND NumberOfTries].");
        }

        private void passToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowYourMessage(sender, e, "Info PAss", "To show the player`s result.");
        }

        private void downTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FillDataArrInListViewDown_Top();
        }

        private void onlyBoyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FillDataArrInListViewOnlyBoy();
        }

        private void onlyGirlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FillDataArrInListViewOnlyGirl();
        }

        private void topDownToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
    }
}
