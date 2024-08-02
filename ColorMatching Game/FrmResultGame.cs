using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorMatching_Game
{
    public partial class FrmResultGame : Form
    {
        public static FrmResultGame Instance;
        public FrmResultGame()
        {
            Instance = this;
            InitializeComponent();
        }

    //  Form frmReqGame = new FrmRequarmensGame();

        void SetImageAndColorsLables(bool Pass)
        {
            if(Pass)
            {
                lblNumberOfGame.ForeColor = Color.Green;
                lblLevelGame.ForeColor = Color.Green;
                lblNumberOfTime.ForeColor = Color.Green;
                lblFinishGameTimer.ForeColor = Color.Green;
                lblColors.ForeColor = Color.Green;

                btnRoundResult.Text = "Lose";
                btnRoundResult.ForeColor = Color.Red;
                picResult.Image = Image.FromFile(@"c:\Photos\ResultIvfoWin.jpg");
            }
            else
            {
                lblNumberOfGame.ForeColor = Color.Red;
                lblLevelGame.ForeColor = Color.Red;
                lblNumberOfTime.ForeColor = Color.Red;
                lblFinishGameTimer.ForeColor = Color.Red;
                lblColors.ForeColor = Color.Red;

                btnRoundResult.Text = "Win";
                btnRoundResult.ForeColor = Color.Green;
                picResult.Image = Image.FromFile(@"C:\Photos\ResultInfoLose.jpg");
            }
        }
        void SetLables()
        {
            lblNumberOfGame.Text = FrmGame.Instance.ResultG.NumberOfGame + " Game(s).";
            lblLevelGame.Text = FrmGame.Instance.ResultG.LevelGame + " Level.";
            lblNumberOfTime.Text = FrmGame.Instance.ResultG.NumberOfTime + " Second(s).";
            lblFinishGameTimer.Text = FrmGame.Instance.ResultG.FinishGameTimer + " Second(s).";
            lblColors.Text = FrmGame.Instance.ResultG.Colors;
        }
        void ChangeLocbtnRoundResult()
        {
            int X, Y;

            Random rnd = new Random();
            X = rnd.Next(5, 350);
            Y = rnd.Next(5, 350);

            btnRoundResult.Location = FrmGame.Instance.GetLocation(X, Y);
        }
       
        private void FrmResultGame_Load(object sender, EventArgs e)
        {
            //Size(531, 493);
            this.Size = FrmGame.Instance.GetSize(531, 493);
            FrmGame.Instance.FillResultGame();
            SetImageAndColorsLables(FrmGame.Instance.ResultG.Pass);
            SetLables();
        }

        private void btnAgain_Click(object sender, EventArgs e)
        {
           FrmGame.Instance.PlayAgain();
          
            this.Close();
        }

      

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnRoundResult_MouseEnter(object sender, EventArgs e)
        {
            ChangeLocbtnRoundResult();
        }

        private void btnRoundResult_Click(object sender, EventArgs e)
        {
           
        }

        private void picResult_Click(object sender, EventArgs e)
        {

        }
    }
}
