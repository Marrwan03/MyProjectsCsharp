using MyFirstLibraryInForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyFirstLibraryInForm;
namespace FlipTheNumbers
{
    public partial class FrmGame : Form
    {
        public static FrmGame instance;

        public FrmGame()
        {
           
            InitializeComponent();
            instance = this;
        }



        public stGame Game;
        public struct stGame
        {
            public Button[] Buttons,ButtonsTries;
            public byte CounterTimerPlay, CounterOfWin,CounterOfLose, CounterRepetNumber, CounterRound,CounterTag,CounterTriesGame, NumberOfRound;
            public bool IsPass;

        };

        void FillGameInfo()
        {
            lblColorName.Text = FrmRequarmensGame.Instance.InfoGame.ColorName;
            lblNumberOfRound.Text = FrmRequarmensGame.Instance.InfoGame.NumberOfRound.ToString();
            Game.NumberOfRound = FrmRequarmensGame.Instance.InfoGame.NumberOfRound;
        }

        
        void FillTheButtonNumbersInArr()
        {
            Game.Buttons[0] = button1;
            Game.Buttons[1] = button2;
            Game.Buttons[2] = button3;
            Game.Buttons[3] = button4;
            Game.Buttons[4] = button5;
            Game.Buttons[5] = button6;
          Game.Buttons[6] = button7;
          Game.Buttons[7] = button8;
          Game.Buttons[8] = button9;
          Game.Buttons[9] = button10;
          Game.Buttons[10] = button11;
          Game.Buttons[11] = button12;
          Game.Buttons[12] = button13;
          Game.Buttons[13] = button14;
          Game.Buttons[14] = button15;
          Game.Buttons[15] = button16;
          Game.Buttons[16] = button17;
          Game.Buttons[17] = button18;
          Game.Buttons[18] = button19;
          Game.Buttons[19] = button20;
          Game.Buttons[20] = button21;
          Game.Buttons[21] = button22;
          Game.Buttons[22] = button23;
          Game.Buttons[23] = button24;
          Game.Buttons[24] = button25;
          Game.Buttons[25] = button26;
          Game.Buttons[26] = button27;
          Game.Buttons[27] = button28;
          Game.Buttons[28] = button29;
          Game.Buttons[29] = button30;
          Game.Buttons[30] = button31;
          Game.Buttons[31] = button32;
          Game.Buttons[32] = button33;
          Game.Buttons[33] = button34;
          Game.Buttons[34] = button35;
          Game.Buttons[35] = button36;
          Game.Buttons[36] = button37;
          Game.Buttons[37] = button38;
          Game.Buttons[38] = button39;
          Game.Buttons[39] = button40;
          Game.Buttons[40] = button41;
          Game.Buttons[41] = button42;
          Game.Buttons[42] = button43;
          Game.Buttons[43] = button44;
          Game.Buttons[44] = button45;
          Game.Buttons[45] = button46;
          Game.Buttons[46] = button47;
          Game.Buttons[47] = button48;
          Game.Buttons[48] = button49;
          Game.Buttons[49] = button50;
          Game.Buttons[50] = button51;
          Game.Buttons[51] = button52;
          Game.Buttons[52] = button53;
          Game.Buttons[53] = button54;
          Game.Buttons[54] = button55;
          Game.Buttons[55] = button56;
          Game.Buttons[56] = button57;
          Game.Buttons[57] = button58;
          Game.Buttons[58] = button59;
          Game.Buttons[59] = button60;
          Game.Buttons[60] = button61;
          Game.Buttons[61] = button62;
          Game.Buttons[62] = button63;
          Game.Buttons[63] = button64;
          Game.Buttons[64] = button65;
          Game.Buttons[65] = button66;
          Game.Buttons[66] = button67;
          Game.Buttons[67] = button68;
          Game.Buttons[68] = button69;
          Game.Buttons[69] = button70;
          Game.Buttons[70] = button71;
          Game.Buttons[71] = button72;
          Game.Buttons[72] = button73;
          Game.Buttons[73] = button74;
          Game.Buttons[74] = button75;
          Game.Buttons[75] = button76;
          Game.Buttons[76] = button77;
          Game.Buttons[77] = button78;

        }
        void FillTheButtonTriesInArr()
        {
            Game.ButtonsTries[0] = btnTry1;
            Game.ButtonsTries[1] = btnTry2;
            Game.ButtonsTries[2] = btnTry3;
            Game.ButtonsTries[3] = btnTry4;
            Game.ButtonsTries[4] = btnTry5;
            Game.ButtonsTries[5] = btnTry6;
            Game.ButtonsTries[6] = btnTry7;
            Game.ButtonsTries[7] = btnTry8;
            Game.ButtonsTries[8] = btnTry9;
            Game.ButtonsTries[9] = btnTry10;
        }
      
        void FillAllButtonNAndC()
        {
            Random rnd = new Random();
            int RandomeNumber = 0;
            for (short i = 0; i < 78; i++)
            {
                RandomeNumber = rnd.Next(1, 100);
                Game.Buttons[i].Text = RandomeNumber.ToString();
                Game.Buttons[i].ForeColor = FrmRequarmensGame.Instance.InfoGame.Color;
                Game.Buttons[i].BackColor = Color.White ;
                Game.Buttons[i].FlatAppearance.BorderColor = Color.Black;
            }
        }

        bool CheckNumber(int Number)
        {
            for (byte i = 0; i < 78; i++)
            {

                if (Number.ToString() == Game.Buttons[i].Text)
                {
                    return true;                }
            }
            return false;
        }

        void FillbuttonNumberQuestion()
        {
            Random rnd = new Random();
            int Number = rnd.Next(1, 100) + 2;

            for (byte i = 0; i < 78; i++)
            {
                if (CheckNumber(Number)) 
               {
                    btnNumberQuestion.Text = Number.ToString();

                    break;
                }
                
                Number = rnd.Next(1, 100) ;
            }
        }

        byte CounterRepetNumberQuestion()
        {
            byte Counter = default(byte);

            for (byte i = 0; i < 78; i++)
            {
                if (btnNumberQuestion.Text == Game.Buttons[i].Text)
                {
                    Counter++;
                }
            }
            return Counter;
        }

        stChoices Choices;
        struct stChoices
        {
            public byte Choice1,Choice2,Choice3;
            public bool UseChoice1,UseChoice2,UseChoice3;
        }

        void ResetNumberChoices()
        {
            Choices.Choice1 = 0;
            Choices.Choice2 = 0;
            Choices.Choice3 = 0;
        }

        void ResetBoolChoices()
        {
            Choices.UseChoice1 = false;
            Choices.UseChoice2 = false;
            Choices.UseChoice3 = false;
        }

        byte RandomeChoiceNumberQuestion(int RandomeNumber)
        { 
            ResetNumberChoices();

            Choices.Choice1 = Game.CounterRepetNumber;

            Choices.Choice2 =  Game.CounterRepetNumber;
            Choices.Choice2 += 2;

            Choices.Choice3 = Game.CounterRepetNumber;
            if(Game.CounterRepetNumber <= 2)
            {
                Choices.Choice3 += 4;
            }
            else
            {
                Choices.Choice3 -= 2;
            }

            byte[] ChoiceNumber = { Choices.Choice1, Choices.Choice2, Choices.Choice3 };
            return ChoiceNumber[RandomeNumber - 1];
        }

        bool IsMatching(Button btn ,int randomeNumber)
        {
            switch (randomeNumber)
            {
                case 1:

                    if(Choices.UseChoice1)
                    {
                        return true;
                    }
                    Choices.UseChoice1 = true;

                    return btn.Text == Choices.Choice2.ToString() || btn.Text == Choices.Choice3.ToString();
                    case 2:

                    if (Choices.UseChoice2)
                    {
                        return true;
                    }
                    Choices.UseChoice2 = true;

                    return btn.Text == Choices.Choice1.ToString() || btn.Text == Choices.Choice3.ToString();
                default:

                    if (Choices.UseChoice3)
                    {
                        return true;
                    }
                    Choices.UseChoice3 = true;

                    return btn.Text == Choices.Choice2.ToString() || btn.Text == Choices.Choice3.ToString();
            }

        }

        bool SpecialMode(Button btn)
        {
            if(  Choices.UseChoice1 && Choices.UseChoice2)
            {
                btn.Text = Choices.Choice3.ToString();
                return true;
            }
            else
            {
                return false;
            }
        }

        bool BaseCheckButtonChoice(Button button, int RandomeNumber)
        {
            button.Text = RandomeChoiceNumberQuestion(RandomeNumber).ToString();

            if(SpecialMode(button))
            {
                return true;
            }

            if (IsMatching(button, RandomeNumber))
            {
                return false;
            }

            return true;
        }
                               //1,3
       void CheckButtonChoice(Button button)
        {
            Random random = new Random();
            int RandomeNumber = random.Next(1, 3);

            while (!BaseCheckButtonChoice(button, RandomeNumber))
            {
                RandomeNumber = random.Next(1, 3);
            }
            return;
        }

        void FillCounterRepetNumberQuestion()
        {
            Game.CounterRepetNumber = CounterRepetNumberQuestion();
        }

        void FillThreeChoices()
        {
            ResetBoolChoices();
            CheckButtonChoice(btnChoiceOne);
            CheckButtonChoice(btnChoiceTwo);
            CheckButtonChoice(btnChoicethree);
        }

        bool IsPass(Button btn)
        {
            return btn.Text == Game.CounterRepetNumber.ToString();
        }

        void FillCounterWinnerAndLoser(bool Pass)
        {
            if(Pass)
            {
                picModeGame.Image = Image.FromFile(@"C:\Photos\ModeWin.png");
                Game.CounterOfWin++;
               
            }
            else
            {
                picModeGame.Image = Image.FromFile(@"C:\Photos\ModeLose.png");
                Game.CounterOfLose++;
                Game.CounterTriesGame--;
            }
        }

        void FillColorToButtonNumbers()
        {
            for (byte i = 0; i < 78; i++)
            {
                if(Game.IsPass)
                {
                    if (Game.Buttons[i].Text == btnNumberQuestion.Text ) 
                    {
                        Game.Buttons[i].BackColor = Color.Green;
                    }
                }
                else
                {
                    if (Game.Buttons[i].Text == btnNumberQuestion.Text)
                    {
                        Game.Buttons[i].BackColor = Color.Green;
                    }
                    else
                    {
                        Game.Buttons[i].BackColor = Color.Red;
                    }
                }
            }
        }

        //void ResetColorButton()
        //{
        //    for (byte i = 0; i < 84; i++)
        //    {
        //        Game.Buttons[i].ForeColor= Color.Black;
        //        Game.Buttons[i].FlatAppearance.BorderColor = Color.Red;
        //    }
        //}

        void EnableForThreeButtons(bool Enable)
        {
            if(!Enable)
            {
                btnChoiceOne.Enabled = false;
                btnChoiceTwo.Enabled = false;
                btnChoicethree.Enabled = false;
            }

            else
            {
                btnChoiceOne.Enabled = true;
                btnChoiceTwo.Enabled = true;
                btnChoicethree.Enabled = true;
            }

        }

        void SetRoundGame(byte NumberOfRound)
        {
            lblRouundGame.Text = NumberOfRound.ToString() + "/" + /*Game.NumberOfRound */FrmRequarmensGame.Instance.InfoGame.NumberOfRound.ToString() + "Round(s)";
        }

      

        //Button in button Number [Game]
        void WhenPressbuttonNumbers(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //string Tag = btn.Tag.ToString();
            if (btn.Tag == null)
            {
                Game.CounterTag++;
                btn.Tag = Game.CounterTag;
                btn.FlatAppearance.BorderColor = Color.Red;

            }
            else
            {
                Game.CounterTag--;
                btn.Tag = null;
                btn.FlatAppearance.BorderColor = Color.Black;
            }
        }

        void ResetForm()
        {
            Game.CounterTag = 0;
            Game.CounterTimerPlay = 0;
            Game.CounterOfWin = 0;
            Game.CounterOfLose = 0;
            Game.CounterRepetNumber = 0;

            btnPlay.Visible = true;
            btnNextRound.Visible = false;
        }

        void VisibleButtonAndNot(byte index, bool Visible)
        {
            if (!Visible)
                --index;
            Game.ButtonsTries[index].Visible = Visible;
        }
        void SetVisibleinPanelTries()
        {
            byte TriesGame = Game.CounterTriesGame;
            while(TriesGame < Game.NumberOfRound)
            {
                TriesGame++;
                VisibleButtonAndNot(TriesGame , false);
            }

            for (byte i = 0; i < Game.CounterTriesGame; i++)
            {
                VisibleButtonAndNot(i, true);
            }

        }

        Form frmResultGame = new FrmResultGame();

        void ShowResultGame()
        {
            if (frmResultGame.IsDisposed)
            {
                frmResultGame = new FrmGame();
                frmResultGame.Show();
                return;
            }
            frmResultGame.Show();
        }


        void WhenYouArriveLastRound()
        {
            timerForPlay.Enabled = true;
            timerForPlay.Stop();
            if (MessageBox.Show("Press [Yes] to show your result", "Game Over", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ShowResultGame();
                this.Hide();

            }
            else
            {
                if (MessageBox.Show("Do You Want Play Again ? ", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    FrmRequarmensGame.Instance.PlayAgain(true);
                    this.Close();

                }
                else
                {
                    this.Close();
                }

            }
        }

        private void btnChoice_Click(object sender, EventArgs e)
        {
          
            EnableForThreeButtons(false);
            Game.IsPass = IsPass((Button)sender);
            FillCounterWinnerAndLoser(Game.IsPass);
            FillColorToButtonNumbers();
            SetVisibleinPanelTries();
            if (Game.CounterRound == Game.NumberOfRound)
            {
                WhenYouArriveLastRound();
                return;
            }
            else
            {
                btnNextRound.Visible = true;
            }
        }

        public void PlayAgain()
        {
            ResetForm();

            btnPlay.Visible = true;
            pChoices.Visible = false;
            lblTitleYourTries.Visible = false;
            pPicTries.Visible = false;
        }
      
        private void FrmGame_Load(object sender, EventArgs e)
        {
            this.Size = new Size(606, 610);

            ResetForm();

            Game.CounterTriesGame = FrmRequarmensGame.Instance.InfoGame.NumberOfRound;

            FillGameInfo();
            Game.Buttons = new Button[79];
            FillTheButtonNumbersInArr();

            EnableForThreeButtons(false);

            SetRoundGame(0);
            Game.CounterRound++;

            Game.ButtonsTries = new Button[10];
            FillTheButtonTriesInArr();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            btnPlay.Visible = false;
            PbForPlay.Visible = true;
            lblTimer.Visible = true;
            btnNextRound.Visible = false;
           pPicTries.Visible = true;
            btnShowColorEye.Visible = true;
            lblTitleYourTries.Visible=true;

            timerForPlay.Start();
            pChoices.Visible = true;
            lblRouundGame.Visible = true;
            SetVisibleinPanelTries();
           // ResetColorButton();
            SetRoundGame(Game.CounterRound);
            //N = Numbers & C = Color
            FillAllButtonNAndC();
            FillbuttonNumberQuestion();
            EnableForThreeButtons(true);
            FillCounterRepetNumberQuestion();
            FillThreeChoices();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

      

        private void PbForPlay_Click(object sender, EventArgs e)
        {

        }

        private void timerForPlay_Tick(object sender, EventArgs e)
        {
            
            if (Game.CounterTimerPlay == 30 )
            {
                if(Game.CounterOfWin + Game.CounterOfLose != Game.CounterRound)
                {
                    FillCounterWinnerAndLoser(false);
                    FillColorToButtonNumbers();
                    SetVisibleinPanelTries();

                }
                if (Game.CounterRound == Game.NumberOfRound)
                {
                    timerForPlay.Stop();
                    btnNextRound.Visible = false;
                    WhenYouArriveLastRound();
                    return;
                }

          
             btnNextRound.Visible = false;
             Game.CounterTimerPlay = 0;
             Game.CounterRound++;
           //  ResetColorButton();
             SetRoundGame(Game.CounterRound);
             //N = Numbers & C = Color
             FillAllButtonNAndC();
             FillbuttonNumberQuestion();
             EnableForThreeButtons(true);
             FillCounterRepetNumberQuestion();
             FillThreeChoices();
                return;
            }

            timerForPlay.Enabled = true;
            Game.CounterTimerPlay++;
            PbForPlay.Value = Game.CounterTimerPlay;
            lblTimer.Text = "(" + Game.CounterTimerPlay.ToString() + ") Second(s).";
        }

        private void btnNextRound_Click(object sender, EventArgs e)
        {
            picModeGame.Image = Image.FromFile(@"C:\Photos\BlackScreen.jpg");
            Game.CounterTimerPlay = 30;

            //picModeGame.Image = Image.FromFile(@"C:\Photos\BlackScreen.jpg");
            //Game.CounterTimerPlay = 0;
            //Game.CounterRound++;
            //ResetColorButton();
            //SetRoundGame(Game.CounterRound);
            ////N = Numbers & C = Color
            //FillAllButtonNAndC();
            //FillbuttonNumberQuestion();
            //EnableForThreeButtons(true);
            //FillCounterRepetNumberQuestion();
            //FillThreeChoices();
        }

       

        private void btnYourChoice1_Click(object sender, EventArgs e)
        {

        }

        private void btnTry1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblTimer_Click(object sender, EventArgs e)
        {

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

        private void btnPlay_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
