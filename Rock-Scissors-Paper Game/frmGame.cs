using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rock_Scissors_Paper_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string NameWinner;
        stCounters Counters;
        stChoiceGame ChoiceGame;
        enWinner Winner;
        enPlayer Player;
        struct stCounters
        {
            public byte CounterRound;
            public byte CounterPlayer1Win;
            public byte CounterPlayer2Win;
            public byte CounterComputerWin;
            public byte CounterDraw;
        };


        enum enPlayer
        {
            enPlayer1,
            enPlayer2,
            enComputer
        }

        enum enGameChoice
        {
            enStone,
            enPaper,
            enScissors
        }
        enum enWinner
        {
            enPlayer1Win,
            enPlayer2Win,
            enComputerWin,
            enDraw

        }
        struct stChoiceGame
        {
            public enGameChoice Player1Choice;
            public enGameChoice Player2Choice;
            public enGameChoice ComputerChoice;
        }

        static bool TurnLeft = true;

        //RadioButton
        enPlayer FillPlayerName()
        {
            if (TurnLeft)
            {
                return enPlayer.enPlayer1;
            }
            else
            {
                if (rbPlayer2.Checked)
                {
                    return enPlayer.enPlayer2;

                }

                else
                    return enPlayer.enComputer;
            }

        }

        enGameChoice FillPlayerChoice(Button btnChoice)
        {
            if (btnChoice.Tag.ToString().ToLower() == "stone")
            {
                return enGameChoice.enStone;
            }
            else if (btnChoice.Tag.ToString().ToLower() == "paper")
            {
                return enGameChoice.enPaper;
            }
            else
            {
                return enGameChoice.enScissors;
            }
        }
        enGameChoice FillComputerChoice(int NumberOfChoice)
        {
            //1 --> Stone
            //2 --> Paper
            //3 --> Scissors

            if (NumberOfChoice == 1)
                return enGameChoice.enStone;
            else if (NumberOfChoice == 2)
                return enGameChoice.enPaper;
            else
                return enGameChoice.enScissors;
        }
        void FillPlayersChoice(Button btnChoice)
        {
            if (TurnLeft)
            {
                ChoiceGame.Player1Choice = FillPlayerChoice(btnChoice);


            }
            else
            {
                if (rbPlayer2.Checked)
                {
                    ChoiceGame.Player2Choice = FillPlayerChoice(btnChoice);
                }

            }
        }
        enWinner WhoWinInTheRoundVsComputer(enGameChoice Choice1, enGameChoice Choice2)
        {
            if (Choice1 == Choice2)
            {
                return enWinner.enDraw;
            }
            switch (Choice1)
            {
                case enGameChoice.enStone:
                    {
                        if (Choice2 == enGameChoice.enPaper)
                        {
                            return enWinner.enComputerWin;
                        }
                    }
                    break;

                case enGameChoice.enPaper:
                    {
                        if (ChoiceGame.Player2Choice == enGameChoice.enScissors)
                        {
                            return enWinner.enComputerWin;
                        }
                    }
                    break;

                case enGameChoice.enScissors:
                    {
                        if (Choice2 == enGameChoice.enStone)
                        {
                            return enWinner.enComputerWin;
                        }
                    }
                    break;
            }

            return enWinner.enPlayer1Win;
        }
        enWinner WhoWinInTheRoundVsPlayer2(enGameChoice Choice1, enGameChoice Choice2)
        {
            if (Choice1 == Choice2)
            {
                return enWinner.enDraw;
            }
            switch (Choice1)
            {
                case enGameChoice.enStone:
                    {
                        if (Choice2 == enGameChoice.enPaper)
                        {
                            return enWinner.enPlayer2Win;
                        }
                    }
                    break;

                case enGameChoice.enPaper:
                    {
                        if (ChoiceGame.Player2Choice == enGameChoice.enScissors)
                        {
                            return enWinner.enPlayer2Win;
                        }
                    }
                    break;

                case enGameChoice.enScissors:
                    {
                        if (Choice2 == enGameChoice.enStone)
                        {
                            return enWinner.enPlayer2Win;
                        }
                    }
                    break;
            }

            return enWinner.enPlayer1Win;
        }

        //RadioButton
        enWinner FillWinnerInTheRound()
        {
            if (rbPlayer2.Checked)
            {
                return WhoWinInTheRoundVsPlayer2(ChoiceGame.Player1Choice, ChoiceGame.Player2Choice);
            }
            else
            {
                return WhoWinInTheRoundVsComputer(ChoiceGame.Player1Choice, ChoiceGame.ComputerChoice);
            }
        }


        void FillCounterWin()
        {
            switch (Winner)
            {
                case enWinner.enPlayer1Win:
                    {
                        Counters.CounterPlayer1Win++;
                        lblCountWinPlayer1.Text = Counters.CounterPlayer1Win.ToString();
                    }
                    break;
                case enWinner.enPlayer2Win:
                    {
                        Counters.CounterPlayer2Win++;
                        lblCountWinlayer2OrComputer.Text = Counters.CounterPlayer2Win.ToString();
                    }
                    break;
                case enWinner.enComputerWin:
                    {
                        Counters.CounterComputerWin++;
                        lblCountWinlayer2OrComputer.Text = Counters.CounterComputerWin.ToString();
                    }
                    break;

                case enWinner.enDraw:
                    {
                        Counters.CounterDraw++;
                        lblDrawCounter.Text = Counters.CounterDraw.ToString();
                    }

                    break;

            }

        }

        //RadioButton
        void FillPictureWinnerAndLosser()
        {
            if (rbPlayer2.Checked)
            {

                if (Counters.CounterPlayer2Win == Counters.CounterPlayer1Win)
                {
                    picWinner.Image = Image.FromFile(@"c:\Photos\BlackScreen.jpg");
                    picLosser.Image = Image.FromFile(@"c:\Photos\BlackScreen.jpg");
                    NameWinner = "Draw";

                }
                else if (Counters.CounterPlayer2Win > Counters.CounterPlayer1Win)
                {
                    picWinner.Image = Image.FromFile(@"c:\Photos\KilwaWin.jpg");
                    picLosser.Image = Image.FromFile(@"c:\Photos\GonLoss.jpg");
                    NameWinner = cbPlayer2.Text;
                }
                else
                {
                    picWinner.Image = Image.FromFile(@"c:\Photos\GonWin.jpg");
                    picLosser.Image = Image.FromFile(@"c:\Photos\KilwaLoss.jpg");

                    NameWinner = cbPlayer1.Text;
                }

            }
            else
            {
                if (Counters.CounterComputerWin == Counters.CounterPlayer1Win)
                {
                    picWinner.Image = Image.FromFile(@"c:\Photos\BlackScreen.jpg");
                    picLosser.Image = Image.FromFile(@"c:\Photos\BlackScreen.jpg");
                    NameWinner = "Draw";

                }
                else if (Counters.CounterComputerWin > Counters.CounterPlayer1Win)
                {
                    picWinner.Image = Image.FromFile(@"c:\Photos\RobotWin.jpg");
                    picLosser.Image = Image.FromFile(@"c:\Photos\GonLoss.jpg");
                    NameWinner = cbComputer.Text;
                }
                else
                {
                    picWinner.Image = Image.FromFile(@"c:\Photos\GonWin.jpg");
                    picLosser.Image = Image.FromFile(@"c:\Photos\RobotLoss.jpg");
                    NameWinner = cbPlayer1.Text;
                }

            }
        }
        void FillPictureTurn()
        {
            if (TurnLeft)
            {

                if (rbComputer.Checked)
                {
                    Thread.Sleep(1000);
                }
                picTurn.Image = Image.FromFile(@"c:\Photos\TurnRight.jpg");
            }
            else
            {
                picTurn.Image = Image.FromFile(@"c:\Photos\TurnLeft.jpg");
            }
        }

        void PicuteChoice(enGameChoice GameChoice, Button btn)
        {
            switch (GameChoice)
            {
                case enGameChoice.enStone:
                    {
                        btn.BackColor = Color.Gray;
                        btn.Text = btnStoneChoice.Tag.ToString();
                    }
                    break;
                case enGameChoice.enPaper:
                    {
                        btn.BackColor = Color.LightGray;
                        btn.Text = btnPaperChoice.Tag.ToString();
                    }
                    break;
                case enGameChoice.enScissors:
                    {
                        btn.BackColor = Color.DarkGray;
                        btn.Text = btnScissorsChoice.Tag.ToString();
                    }
                    break;
            }
        }

        void FillPicuteMode()
        {
            if (TurnLeft)
            {
                picPlayer1.Image = Image.FromFile(@"c:\Photos\GonDon`tLook2.jpg");
                if (rbPlayer2.Checked)
                {
                    picPlayer2OrComputer.Image = Image.FromFile(@"c:\Photos\KilwaThink.jpg");
                }
                else
                {
                    Thread.Sleep(1000);
                    picPlayer2OrComputer.Image = Image.FromFile(@"c:\Photos\RobotThink.jpg");

                }
            }
            else
            {
                picPlayer1.Image = Image.FromFile(@"c:\Photos\GonThink.jpg");
                if (rbPlayer2.Checked)
                {
                    picPlayer2OrComputer.Image = Image.FromFile(@"c:\Photos\KilwaDon`tLook2.jpg");
                }
                else
                {

                    picPlayer2OrComputer.Image = Image.FromFile(@"c:\Photos\RobotDon`tLook.jpg");

                }

            }
        }
        //RadioButton
        void FillPictureChoice()
        {
            if (TurnLeft)
            {
                PicuteChoice(ChoiceGame.Player1Choice, btnChoicePlayer1);
            }
            else
            {
                if (rbPlayer2.Checked)
                {
                    PicuteChoice(ChoiceGame.Player2Choice, btnChoicePlayer2OrComputer);
                }
                else
                {
                    PicuteChoice(ChoiceGame.ComputerChoice, btnChoicePlayer2OrComputer);
                }
            }

        }


        void CheckNamePlayers(ComboBox cmb1, ComboBox cmb2, bool cmb1Null = true)
        {
            if (cmb1.Text != "" && cmb2.Text != "")
            {
                if (cmb1.Text == cmb2.Text)
                {
                    if (MessageBox.Show("You should use different names", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                    {
                        if (cmb1Null)
                            cmb1.Text = null;

                        else
                            cmb2.Text = null;
                    }
                }
            }

        }


        void CheckRadioButton(bool Player2 = false, bool Computer = false)
        {
            if (Player2)
            {
                cbPlayer2.Enabled = true;
                cbComputer.Enabled = false;
                cbComputer.Text = null;

                lblPlayer2.Visible = true;
                lblComputer.Visible = false;
                lblNamePlayer2OrComputerInGameInfo.Visible = true;

                lblNameComputerInGame.Visible = false;
                lblNamePlayer2InGame.Visible = true;

            }
            else if (Computer)
            {
                cbComputer.Enabled = true;
                cbPlayer2.Enabled = false;
                cbPlayer2.Text = null;

                lblComputer.Visible = true;
                lblPlayer2.Visible = false;
                lblNamePlayer2OrComputerInGameInfo.Visible = true;

                lblNameComputerInGame.Visible = true;
                lblNamePlayer2InGame.Visible = false;
            }

        }

        void FillRequirementsGame()
        {
            if (MessageBox.Show("Now, you can Fill The Game Requirements", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                gbBGameRequirements.Enabled = true;
            }

        }
        void ResetGame()
        {
            btnPress.Visible = true;
            cbRounds.Text = null;
            cbPlayer1.Text = null;
            cbPlayer2.Text = null;
            cbComputer.Text = null;

            Counters.CounterRound = 0;
            lblNumberOfRound.Text = NumberOfRound();
            Counters.CounterDraw = 0;
            Counters.CounterComputerWin = 0;
            Counters.CounterPlayer1Win = 0;
            Counters.CounterPlayer2Win = 0;

            btnStoneChoice.Enabled = true;
            btnPaperChoice.Enabled = true;
            btnScissorsChoice.Enabled = true;
            gbBGameRequirements.Enabled = true;

            gbBStartGame.Enabled = false;
            //CountWin...
            lblPlayer1Count.Visible = false;
            lblCountWinPlayer1.Text = "In Progress";
            lblCountWinPlayer1.Visible = false;


            lblPlayer2Count.Visible = false;
            lblCountWinlayer2OrComputer.Visible = false;
            lblCountWinlayer2OrComputer.Text = "In Progress";

            lblComputerCount.Visible = false;



            lblDrawCounter.Visible = false;
            lblDrawCounter.Text = "In Progress";
            lblDraw.Visible = false;

            //GameInfo
            lblRounds.Visible = false;
            lblRoundsInGameInfo.Visible = false;

            lblPlayer1.Visible = false;
            lblNamePlayer1InGameInfo.Visible = false;

            lblNamePlayer2OrComputerInGameInfo.Visible = false;
            lblComputer.Visible = false;
            lblPlayer2.Visible = false;

            //Picutre
            picLosser.Image = Image.FromFile(@"c:\Photos\BlackScreen.jpg");
            picWinner.Image = Image.FromFile(@"c:\Photos\BlackScreen.jpg");
            picPlayer1.Image = Image.FromFile(@"c:\Photos\BlackScreen.jpg");
            picPlayer2OrComputer.Image = Image.FromFile(@"c:\Photos\BlackScreen.jpg");

            btnChoicePlayer1.Text = null;
            btnChoicePlayer2OrComputer.Text = null;

        }
        void VisibleCountWIn()
        {


            //Player1CountWin
            lblPlayer1Count.Visible = true;
            lblCountWinPlayer1.Visible = true;

            if (rbPlayer2.Checked)
            {
                //Player2CountWin
                lblPlayer2Count.Visible = true;
                lblCountWinlayer2OrComputer.Visible = true;
            }
            else
            {
                //ComputerCountWin
                lblComputerCount.Visible = true;
                lblCountWinlayer2OrComputer.Visible = true;

            }
            lblDrawCounter.Visible = true;
            lblDraw.Visible = true;

        }


        string NumberOfRound()
        {

            return Counters.CounterRound + "/" + cbRounds.Text;
        }



        void FillTheGameInfoRounds()
        {
            lblRounds.Visible = true;
            lblRoundsInGameInfo.Visible = true;
            lblRoundsInGameInfo.Text = cbRounds.Text;
        }
        void FillTheGameInfoPlayer1()
        {
            //GameInfo
            lblPlayer1.Visible = true;
            lblNamePlayer1InGameInfo.Visible = true;
            lblNamePlayer1InGameInfo.Text = cbPlayer1.Text;

            lblNamePlayer1InGame.Text = cbPlayer1.Text;
        }
        void FillTheGameInfoPlayer2OrComputer()
        {
            if (rbPlayer2.Checked)
            {
                lblNamePlayer2OrComputerInGameInfo.Text = cbPlayer2.Text;
                lblNamePlayer2InGame.Text = cbPlayer2.Text;
            }
            else
            {
                lblNamePlayer2OrComputerInGameInfo.Text = cbComputer.Text;
                lblNameComputerInGame.Text = cbComputer.Text;
            }
        }

        bool CheckTheRequirementsGame(ComboBox cb1, ComboBox cb2, ComboBox cb3)
        {
            if (cb1.Text == "" || cb2.Text == "" || cb3.Text == "")
            {

                if (MessageBox.Show("You should Fill The Game Requirements", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    btnFilliinfo.Visible = true;
                    return true;
                }
            }
            return false;
        }
        void AfterCheckFillGameRequirements()
        {
            btnFilliinfo.Visible = false;
            gbBStartGame.Enabled = true;
            gbBGameRequirements.Enabled = false;
        }
        void MessageEndGame()
        {
            if (Counters.CounterRound.ToString() == cbRounds.Text)
            {
                if (MessageBox.Show("GameOver\nWinner is : " + NameWinner + "", "GameOver", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    btnRestGame.Visible = true;
                    btnStoneChoice.Enabled = false;
                    btnPaperChoice.Enabled = false;
                    btnScissorsChoice.Enabled = false;
                    return;
                }

            }
        }
        void ComputerChoice()
        {
            if (rbComputer.Checked)
            {
                Random Number = new Random();
                ChoiceGame.ComputerChoice = FillComputerChoice(Number.Next(1, 3));
            }
        }
        void PlayGame(Button btn)
        {
            if (TurnLeft)
            {
                Counters.CounterRound++;
                lblNumberOfRound.Text = NumberOfRound();
                FillPlayersChoice(btn);
                FillPictureChoice();
                FillPicuteMode();
                FillPictureTurn();

                //Turn Computer...
                if (rbComputer.Checked)
                {
                    TurnLeft = false;
                    ComputerChoice();
                    FillPictureChoice();
                    FillPicuteMode();
                    Winner = FillWinnerInTheRound();
                    FillCounterWin();
                    FillPictureWinnerAndLosser();
                    FillPictureTurn();
                    MessageEndGame();
                    TurnLeft = true;
                }

            }
            else
            {
                lblNumberOfRound.Text = NumberOfRound();
                FillPlayersChoice(btn);
                FillPictureChoice();
                FillPicuteMode();
                Winner = FillWinnerInTheRound();
                FillCounterWin();
                FillPictureWinnerAndLosser();
                FillPictureTurn();
                btnChoicePlayer1.Text = "";
                btnChoicePlayer2OrComputer.Text = "";
                MessageEndGame();
            }

        }

        public void btnStoneOrPaperOrScissorsOnClick(Button btn)
        {

            if (TurnLeft) //it Means Turn Player1
            {
                PlayGame(btn);
                if (rbPlayer2.Checked)
                {
                    TurnLeft = false;
                }

            }
            else
            {
                PlayGame(btn);
                TurnLeft = true;
            }


        }
        void FillFirsPicureMode()
        {
            picPlayer1.Image = Image.FromFile(@"c:\Photos\NormalGon.jpg");
            if (rbPlayer2.Checked)
            {
                picPlayer2OrComputer.Image = Image.FromFile(@"c:\Photos\NormalKilwa.jpg");
                gbBStartGame.BackColor = Color.SlateGray;
            }
            else
            {
                picPlayer2OrComputer.Image = Image.FromFile(@"c:\Photos\NormalRobot.jpg");
                gbBStartGame.BackColor = Color.SlateGray;
            }
        }

        void StartGame()
        {

            gbBGameRequirements.Enabled = false;

            if (rbPlayer2.Checked)
            {
                if (CheckTheRequirementsGame(cbRounds, cbPlayer1, cbPlayer2))
                    return;

            }
            else
            {
                if (CheckTheRequirementsGame(cbRounds, cbPlayer1, cbComputer))
                    return;
            }

            VisibleCountWIn();
            AfterCheckFillGameRequirements();
            FillFirsPicureMode();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }




        private void rbPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            CheckRadioButton(rbPlayer2.Checked);


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            CheckNamePlayers(cbPlayer1, cbPlayer2, false);
            FillTheGameInfoPlayer2OrComputer();
        }

        private void cbPlayer1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckNamePlayers(cbPlayer1, cbPlayer2);
            FillTheGameInfoPlayer1();
        }

        private void rbComputer_CheckedChanged(object sender, EventArgs e)
        {
            CheckRadioButton(false, rbComputer.Checked);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void gbBGameInfo_Enter(object sender, EventArgs e)
        {

        }

        private void btnFilliinfo_Click(object sender, EventArgs e)
        {
            FillRequirementsGame();
        }

        private void lblNumberOfRound_Click(object sender, EventArgs e)
        {

        }

        private void gbBMode_Enter(object sender, EventArgs e)
        {
            //if don`t time delete me...
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void lblComputerCount_Click(object sender, EventArgs e)
        {

        }

        private void gbBGameInfo_Enter_1(object sender, EventArgs e)
        {

        }

        private void lblNamePlayer1InGameInfo_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            btnPress.Visible = false;
        }
        private void button_Click(object sender, EventArgs e)
        {
            btnStoneOrPaperOrScissorsOnClick((Button)sender);
        }

        private void btnStoneChoice_Click(object sender, EventArgs e)
        {

        }

        private void btnPaperChoice_Click(object sender, EventArgs e)
        {

        }

        private void btnScissorsChoice_Click(object sender, EventArgs e)
        {

        }

        private void lblCountWinPlayer1_Click(object sender, EventArgs e)
        {

        }

        private void cbComputer_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillTheGameInfoPlayer2OrComputer();
        }

        private void cbRounds_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillTheGameInfoRounds();
        }

        private void btnChoicePlayer1_Click(object sender, EventArgs e)
        {

        }

        private void btnRestGame_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void lblNameComputerInGame_Click(object sender, EventArgs e)
        {

        }
    }
}
