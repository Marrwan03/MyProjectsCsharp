using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace ColorMatching_Game
{
   
    public partial class FrmGame : Form
    {
        public static FrmGame Instance;
        public FrmGame()
        {
            Instance = this;
            InitializeComponent();
        }
        
       FrmResultGame resultGame = new FrmResultGame();

        //Fill Info From FrmRequarmensGame...
        public stReq Req;
        public struct stReq
        {
            public Color Color1, Color2, Color3, Color4;
            public string StringYourColors;
            public byte Timer;
            public string LevelGame;
            public byte TimerGame;
        };
        void FillStructReq()
        {
            Req.Color1 = FrmRequarmensGame.Instance.btnFirstColor.BackColor;
            Req.Color2 = FrmRequarmensGame.Instance.btnSecondColor.BackColor;
            Req.Color3 = FrmRequarmensGame.Instance.btnThirdColor.BackColor;
            Req.Color4 = FrmRequarmensGame.Instance.btnForthColor.BackColor;
            Req.StringYourColors = FrmRequarmensGame.Instance.Req.StringYourColors;
            Req.Timer = FrmRequarmensGame.Instance.Req.Timer;
            Req.LevelGame = FrmRequarmensGame.Instance.Req.LevelGame;
            //---------------------------------------------------------------------

            //Fill GameInfo
            lblColorGame.Text = Req.StringYourColors;
            lblTimer.Text = Req.Timer.ToString();
            lblLevel.Text = Req.LevelGame;
        }
        

        stGameInfo gameInfo;
        struct stGameInfo
        {
            public byte NumberOfRightGuess, NumberOfWrongGuess;
        };

        stCounterColors CounterColors;
        struct stCounterColors
        {
            public byte CounterRed, CounterYellow, CounterGreen, CounterBlue;
            public byte CounterDarkRed, CounterLightYellow, CounterDarkGreen, CounterLightBlue;
        };

        public  stCounter Counter;
        public struct stCounter
        {
            public byte CounterShowColor, CounterRightGuess, CounterWrongAnswer;
            public static byte NumberOfGame;

        };

          stGame Game;
         struct stGame
        {
            //Choice button Player
            public Button btn1, btn2;
            //button In system
            public Button button1, button2;
            public bool Turn2;
            public bool Pass;
      
            
        };
        public stResultGame ResultG;
        public struct stResultGame
        {
            public string NumberOfGame;
            public string LevelGame;
            public string NumberOfTime;
            public string FinishGameTimer;
            public string Colors;
            public bool Pass;
        };
        

        byte GetMaxCounter()
        {
            if (Req.LevelGame == "Hard")
                return 4;
            else
                return 2;

        }

        bool CheckCounter(byte CounterColor, byte CounterColor2)
        {
            byte Max = GetMaxCounter();

            return CounterColor == Max || CounterColor2 == Max;
        }
        bool CheckCounter(byte CounterColor)
        {
            byte Max = GetMaxCounter();
            return CounterColor == Max;

        }



        bool FillColorEazy(Button btn, int Number)
        {

            //bool Choice1 = default, Choice2 = default;
            //Choice1 = CheckCounter(CounterColors.CounterRed, CounterColors.CounterDarkRed);
            //Choice2 = CheckCounter(CounterColors.CounterYellow, CounterColors.CounterLightYellow);

            //if (Choice1)
            //    Number = 2;
            //else if(Choice2)
            //    Number = 1;
            //else
            //    Number = random.Next(1, 4);

            switch (Number)
            {
                case 1:
                    {
                        if (FrmRequarmensGame.Instance.rbRed.Checked)
                        {
                            if (CheckCounter(CounterColors.CounterRed))
                            {
                                return false;
                            }
                            CounterColors.CounterRed++;
                            btn.BackColor = Color.Red;

                        }
                        else
                        {
                            if (CheckCounter(CounterColors.CounterDarkRed))
                            {
                                return false;
                            }
                            CounterColors.CounterDarkRed++;
                            btn.BackColor = Color.DarkRed;
                        }
                        return true;
                    }
                case 2:
                    {
                        if (FrmRequarmensGame.Instance.rbYellow.Checked)
                        {
                            if (CheckCounter(CounterColors.CounterYellow))
                            {
                                return false;
                            }
                            CounterColors.CounterYellow++;
                            btn.BackColor = Color.Yellow;
                        }
                        else
                        {
                            if (CheckCounter(CounterColors.CounterLightYellow))
                            {
                                return false;
                            }
                            CounterColors.CounterLightYellow++;
                            btn.BackColor = Color.LightYellow;
                        }
                        return true;
                    }
            }
            return false;
        }
        bool FillColorMediumAndHard(Button btn, int Number)
        {

            //if(CheckCounter(CounterColors.CounterRed, CounterColors.CounterDarkRed))
            //{
            //    //Delete  Red choice 
            //    Number = random.Next(2, 4);
            //}
            //if (CheckCounter(CounterColors.CounterYellow, CounterColors.CounterLightYellow) && CheckCounter(CounterColors.CounterRed, CounterColors.CounterDarkRed))
            //{
            //    //Delete Yellow & Red choice 
            //    Number = random.Next(3, 4);
            //}

            //if (CheckCounter(CounterColors.CounterBlue, CounterColors.CounterLightBlue))
            //{
            //    //Delete Blue choice 
            //    Number = random.Next(1, 3);
            //}
            //if (CheckCounter(CounterColors.CounterBlue, CounterColors.CounterLightBlue) && CheckCounter(CounterColors.CounterGreen, CounterColors.CounterDarkGreen))
            //{
            //    //Delete Green & Blue choice 
            //    Number = random.Next(1, 2);
            //}
            //if (Number == 3)//Exceptional case
            //{
            //    if (CheckCounter(CounterColors.CounterYellow, CounterColors.CounterLightYellow) && CheckCounter(CounterColors.CounterRed, CounterColors.CounterDarkRed))
            //    {
            //        if (CheckCounter(CounterColors.CounterGreen, CounterColors.CounterDarkGreen))
            //        {
            //            Number = 4;
            //        }
            //        else
            //        {
            //            Number = random.Next(3, 4);
            //        }
            //    }
            //}


            switch (Number)
            {
                case 1:
                    {
                        if (FrmRequarmensGame.Instance.rbRed.Checked)
                        {
                            if (CheckCounter(CounterColors.CounterRed))
                            {
                                return false;
                            }
                            CounterColors.CounterRed++;
                            btn.BackColor = Color.Red;

                        }
                        else
                        {
                            if (CheckCounter(CounterColors.CounterDarkRed))
                            {
                                return false;
                            }
                            CounterColors.CounterDarkRed++;
                            btn.BackColor = Color.DarkRed;
                        }
                        return true;
                    }
                case 2:
                    {
                        if (FrmRequarmensGame.Instance.rbYellow.Checked)
                        {
                            if (CheckCounter(CounterColors.CounterYellow))
                            {
                                return false;
                            }
                            CounterColors.CounterYellow++;
                            btn.BackColor = Color.Yellow;
                        }
                        else
                        {
                            if (CheckCounter(CounterColors.CounterLightYellow))
                            {
                                return false;
                            }
                            CounterColors.CounterLightYellow++;
                            btn.BackColor = Color.LightYellow;
                        }
                        return true;
                    }
                case 3:
                    {
                        if (FrmRequarmensGame.Instance.rbGreen.Checked)
                        {
                            if (CheckCounter(CounterColors.CounterGreen))
                            {
                                return false;
                            }
                            CounterColors.CounterGreen++;
                            btn.BackColor = Color.Green;
                        }
                        else
                        {
                            if (CheckCounter(CounterColors.CounterDarkGreen))
                            {
                                return false;
                            }
                            CounterColors.CounterDarkGreen++;
                            btn.BackColor = Color.DarkGreen;
                        }
                        return true;
                    }
                case 4:
                    {
                        if (FrmRequarmensGame.Instance.rbBlue.Checked)
                        {
                            if (CheckCounter(CounterColors.CounterBlue))
                            {
                                return false;
                            }
                            CounterColors.CounterBlue++;
                            btn.BackColor = Color.Blue;
                        }
                        else
                        {
                            if (CheckCounter(CounterColors.CounterLightBlue))
                            {
                                return false;
                            }
                            CounterColors.CounterLightBlue++;
                            btn.BackColor = Color.LightBlue;
                        }
                        return true;
                    }
            }
            return false;
        }
       
        void FillColorButton(Button btn)
        {
            bool Pass = false;
            Random random = new Random();
            int Number = default(int);
           while (!Pass)
            {
                if (Req.LevelGame == "Easy")
                {
                    Number = random.Next(1, 4);
                    Pass = FillColorEazy(btn, Number);
                }
                else
                {
                    Number = random.Next(1, 6);
                    Pass = FillColorMediumAndHard(btn, Number);
                }
            }
           
        }

        void FillColorButton()      
        {
            switch (Req.LevelGame)
            {
                case "Easy":
                    FillColorButton(btn1);
                    FillColorButton(btn5);
                    FillColorButton(btn2);
                    FillColorButton(btn4);
                    return;

                case "Medium":
                    FillColorButton(btn1);
                    FillColorButton(btn3);
                    FillColorButton(btn5);
                    FillColorButton(btn7);
                    FillColorButton(btn2);
                    FillColorButton(btn4);
                    FillColorButton(btn6);
                    FillColorButton(btn8);
                    return;

                case "Hard":
                    FillColorButton(btn1);
                    FillColorButton(btn3);
                    FillColorButton(btn5);
                    FillColorButton(btn7);
                    FillColorButton(btn9);
                    FillColorButton(btn11);
                    FillColorButton(btn13);
                    FillColorButton(btn15);
                    FillColorButton(btn2);
                    FillColorButton(btn4);
                    FillColorButton(btn6);
                    FillColorButton(btn8);
                    FillColorButton(btn10);
                    FillColorButton(btn12);
                    FillColorButton(btn14);
                    FillColorButton(btn16);
                    return;

            }

            
        }
        void HideQButton()
        {
            btn1Q.Visible = false;
            btn2Q.Visible = false;
            btn3Q.Visible = false;
            btn4Q.Visible = false;
            btn5Q.Visible = false;
            btn6Q.Visible = false;
            btn7Q.Visible = false;
            btn8Q.Visible = false;
            btn9Q.Visible = false;
            btn10Q.Visible = false;
            btn11Q.Visible = false;
            btn12Q.Visible = false;
            btn13Q.Visible = false;
            btn14Q.Visible = false;
            btn15Q.Visible = false;
            btn16Q.Visible = false;
        }
        void ShowQButton()
        {
            btn1Q.Visible = true;
            btn2Q.Visible = true;
            btn3Q.Visible = true;
            btn4Q.Visible = true;
            btn5Q.Visible = true;
            btn6Q.Visible = true;
            btn7Q.Visible = true;
            btn8Q.Visible = true;
            btn9Q.Visible = true;
            btn10Q .Visible = true;
            btn11Q .Visible = true;
            btn12Q .Visible = true;
            btn13Q .Visible = true;
            btn14Q .Visible = true;
            btn15Q .Visible = true;
            btn16Q .Visible = true;
        }

        //button اللي عليها الوان
        Button ReturnChoiceButton(Button Button)
        {
            int number = Convert.ToByte(Button.Tag);
            switch (number)
            {
                case 1:{ return btn1; }
                case 2:{ return btn2; }
                case 3:{ return btn3; }
                case 4:{ return btn4; }
                case 5:{ return btn5; }
                case 6:{ return btn6; }
                case 7:{ return btn7; }
                case 8:{ return btn8; }
                case 9:{ return btn9; }
                case 10:{ return btn10; }
                case 11:{ return btn11; }
                case 12:{ return btn12; }
                case 13:{ return btn13; }
                case 14:{ return btn14; }
                case 15:{ return btn15; }
                case 16:{ return btn16; }
            }
            return null;
        }
       
        void FillCounterWrongAndRightGuess(Button Button1, Button Button2)
        {
             if(Button1.BackColor.Name == Button2.BackColor.Name)
            {
                    Counter.CounterRightGuess++;
                
            }
            else
            {
                if (MessageBox.Show("try again", "Wrong Guess", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    Counter.CounterWrongAnswer++;
                    Game.button1.Visible = true;
                    Game.button2.Visible = true;
                }
            }


        }

        //Button اللي عليها علامة استفهام
        Button ReturnSystemButton(Button Button)
        {
            int number = Convert.ToByte(Button.Tag);
            switch (number)
            {
                case 1: { return btn1Q; }
                case 2: { return btn2Q; }
                case 3: { return btn3Q; }
                case 4: { return btn4Q; }
                case 5: { return btn5Q; }
                case 6: { return btn6Q; }
                case 7: { return btn7Q; }
                case 8: { return btn8Q; }
                case 9: { return btn9Q; }
                case 10: { return btn10Q; }
                case 11: { return btn11Q; }
                case 12: { return btn12Q; }
                case 13: { return btn13Q; }
                case 14: { return btn14Q; }
                case 15: { return btn15Q; }
                case 16: { return btn16Q; }

            }
            return null;
        }

        // public static List<ListViewItem> DataGame = new List<ListViewItem>();
        //public static Queue<ListViewItem> QData = new Queue<ListViewItem>();
        //void FillDataGame(bool Pass)
        //{
        //    ListViewItem item = new ListViewItem(stCounter.NumberOfGame.ToString());

        //    item.SubItems.Add(Req.LevelGame.ToString());
        //    item.SubItems.Add(Req.Timer.ToString() + " Second");
        //    item.SubItems.Add(Req.TimerGame.ToString() + " Second");
        //    if(Pass)
        //    {
        //        item.SubItems.Add("Yes :-)");
        //    }
        //    else
        //    {
        //        item.SubItems.Add("No :-(");
        //    }
        //    item.SubItems.Add(Req.StringYourColors);

        //   // DataGame.Add(item);
        //  QData.Enqueue(item);
        //}
        
    
        void GoToResultGame()
        {
            resultGame.Show();
            this.Close();
        }

        void WhenPlayerWin()
        {
            gbGame.BackColor = Color.DarkSeaGreen;

            if (MessageBox.Show("Congratulations on your win", "Game over", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
               GoToResultGame();
            }
           else
            {
                btnResultGame.ForeColor = Color.Green;
                btnResultGame.Visible = true;
            }
        }
        public void PlayAgain()
        {
            FrmRequarmensGame.Instance.ResetRequarmensGame();
            Application.OpenForms["FrmRequarmensGame"].Show();

            CounterColors.CounterRed = 0;
            CounterColors.CounterDarkRed = 0;
            CounterColors.CounterGreen = 0;
            CounterColors.CounterDarkGreen = 0;
            CounterColors.CounterYellow = 0;
            CounterColors.CounterLightYellow = 0;
            CounterColors.CounterBlue = 0;
            CounterColors.CounterLightBlue = 0;

            Game.btn1 = null;
            Game.btn2 = null;
            Game.button1 = null;
            Game.button2 = null;

            Counter.CounterRightGuess = 0;
            Counter.CounterWrongAnswer = 0;

           this.Close();
        }
        
        void WhenPlayerLose()
        {
           
            gbGame.BackColor = Color.Maroon;
            if (MessageBox.Show("HardLuck,\nif you want to see reslut game Press [Yes] ", "Game over", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                GoToResultGame();
            }
            else
            {
                btnResultGame.ForeColor = Color.Red;
                btnResultGame.Visible = true;
            }
        }

  
        
      
        
        //bool FinishBeforeTimeEazy()
        //{
        //    return 
        //}
      
        void ResultGame()
        {

            switch (Req.LevelGame)
            {
                case "Easy":
                    if (IsVisible(btn1Q) || IsVisible(btn2Q) || IsVisible(btn4Q) ||
              IsVisible(btn5Q))
                    {
                        Game.Pass = false;
                        WhenPlayerLose();
                        return;
                    }
                    break;

                case "Medium":
                    if (IsVisible(btn1Q) || IsVisible(btn2Q) || IsVisible(btn3Q) ||
             IsVisible(btn4Q) || IsVisible(btn5Q) || IsVisible(btn6Q) ||
             IsVisible(btn7Q) || IsVisible(btn8Q))
                    {
                        Game.Pass = false;
                        WhenPlayerLose();
                        return;
                    }
                    break;

                case "Hard":
                    if (IsVisible(btn1Q) || IsVisible(btn2Q) || IsVisible(btn3Q) ||
               IsVisible(btn4Q) || IsVisible(btn5Q) || IsVisible(btn6Q) ||
               IsVisible(btn7Q) || IsVisible(btn8Q) || IsVisible(btn9Q) ||
               IsVisible(btn10Q) || IsVisible(btn11Q) || IsVisible(btn12Q) ||
               IsVisible(btn13Q) ||IsVisible(btn14Q) || IsVisible(btn15Q) ||
               IsVisible(btn16Q))
                    {
                        Game.Pass = false;
                        WhenPlayerLose();
                        return;
                    }
                    break;


            }
              
                if (Counter.CounterRightGuess >= Counter.CounterWrongAnswer)
            {
                Game.Pass = true;
                WhenPlayerWin();
            }
            else
            {
                Game.Pass = false;
                WhenPlayerLose();
            }
        }
       void SetRecordGame()
        {
            lblNumberOfRightGuess.Text = Counter.CounterRightGuess.ToString();
            lblNumberOfWrongGuess.Text = Counter.CounterWrongAnswer.ToString();
        }
        bool IsVisible(Button button)
        {
            return button.Visible;
        }
        void FinishGameBeforeTimeEazy()
        {
            if (!IsVisible(btn1Q) && !IsVisible(btn2Q) && !IsVisible(btn4Q) &&
               !IsVisible(btn5Q))
            {
                TimerPb.Enabled = false;
                ResultGame();
            }

        }
        void FinishGameBeforeTimeMedium()
        {
            if(!IsVisible(btn1Q) &&  !IsVisible(btn2Q) && !IsVisible(btn3Q) &&
               !IsVisible(btn4Q) && !IsVisible(btn5Q) && !IsVisible(btn6Q)   &&
               !IsVisible(btn7Q) && !IsVisible(btn8Q))
            {
                TimerPb.Enabled = false;
                ResultGame();
            }

        }
        void FinishGameBeforeTimeHard()
        {
            if (!IsVisible(btn1Q) && !IsVisible(btn2Q) && !IsVisible(btn3Q) &&
               !IsVisible(btn4Q) && !IsVisible(btn5Q) && !IsVisible(btn6Q) &&
               !IsVisible(btn7Q) && !IsVisible(btn8Q) && !IsVisible(btn9Q) &&
               !IsVisible(btn10Q) && !IsVisible(btn11Q) && !IsVisible(btn12Q) &&
               !IsVisible(btn13Q) && !IsVisible(btn14Q) && !IsVisible(btn15Q) &&
               !IsVisible(btn16Q))
            {
                TimerPb.Enabled = false;
                ResultGame();
            }

        }
        void FinishGameBeforeTime()
        {
            switch (Req.LevelGame)
            {
                case "Easy":
                    FinishGameBeforeTimeEazy();
                    return;
                case "Medium":
                    FinishGameBeforeTimeMedium();
                    return;
                case "Hard":
                    FinishGameBeforeTimeHard();
                    return;
            }

        }
        void WhenPressButtonQuestionMark(Button button)
        {
            button.Visible = false;
            if(Game.Turn2)
            {
              
                Game.btn2 = ReturnChoiceButton(button);
                Game.button2 = ReturnSystemButton(button);
                FillCounterWrongAndRightGuess(Game.btn1, Game.btn2);
                SetRecordGame();
                FinishGameBeforeTime();
                Game.Turn2 = false;
            }
            else
            {
                Game.btn1 = ReturnChoiceButton(button);
                Game.button1 = ReturnSystemButton(button);
                Game.Turn2 = true;
            }

        }

        private void btnQMark_Click(object sender, EventArgs e)
        {
             WhenPressButtonQuestionMark((Button)sender);
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        
        

        public Size GetSize(int Width, int Height)
        {
            System.Drawing.Size size;
            size = new System.Drawing.Size(Width, Height);
            return size;
        }
      
        void ChangeSizeFormByLevel()
        {
            System.Drawing.Size size = new Size();
            switch (Req.LevelGame)
            {
                case "Easy":
                    size = GetSize(770, 605);
                    break;
                case "Medium":
                    size = GetSize(833, 605);
                    break;
                case "Hard":
                    size = GetSize(1203, 605);
                    break;
            }
          this.Size = size;
        }

        void ChangeSizeGbGameByLevel()
        {
            System.Drawing.Size size = new Size();
            switch (Req.LevelGame)
            {
                case "Easy":
                    size = GetSize(304, 248);
                    break;
                case "Medium":
                    size = GetSize(433, 353);
                    break;
                case "Hard":
                    size = GetSize(852, 353);
                    break;
            }
            gbGame.Size = size;
        }


       public Point GetLocation(int x, int y)
        {
            Point location = new Point(x,y);
            return location;
        }
        void ChangeLocation()
        {
            switch (Req.LevelGame)
            {
                case "Easy":
                    btnShowColors.Location = GetLocation(309, 72);
                    btnStartGame.Location = GetLocation(429, 58);
                    lblNumberOfProgressBar.Location = GetLocation(429, 56);
                    pbTimerGame.Location = GetLocation(429, 83);
                    lblTimerShowColors.Location = GetLocation(386, 376);
                    return;


                case "Medium":
                    btnShowColors.Location = GetLocation(309, 72);
                    btnStartGame.Location = GetLocation(429, 58);
                    lblNumberOfProgressBar.Location = GetLocation(429, 56);
                    pbTimerGame.Location = GetLocation(429, 83);
                    lblTimerShowColors.Location = GetLocation(449, 475);
                    return;


                case "Hard":
                    btnShowColors.Location = GetLocation(535, 73);
                    btnStartGame.Location = GetLocation(655, 58);
                    lblNumberOfProgressBar.Location = GetLocation(655, 56);
                    pbTimerGame.Location = GetLocation(655, 83);
                    lblTimerShowColors.Location = GetLocation(653, 475);
                    return;
            }
           
        }

        public void FillResultGame()
        {
            ResultG.NumberOfGame = stCounter.NumberOfGame.ToString();
            ResultG.LevelGame = Req.LevelGame;
            ResultG.NumberOfTime = Req.Timer.ToString();
            ResultG.FinishGameTimer = Req.TimerGame.ToString();
            ResultG.Colors = Req.StringYourColors;
            ResultG.Pass = Game.Pass;
        }

        void RestartGame()
        {
            btnStartGame.Visible = true;
            gbGame.Enabled = false;
            btnShowColors.Enabled = true;
            btnBacktoEdit.Enabled = true;
            btnResultGame.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillStructReq();
          RestartGame();
            ChangeSizeFormByLevel();
            ChangeSizeGbGameByLevel();
            ChangeLocation();
        }

        private void btnBacktoEdit_Click(object sender, EventArgs e)
        {
            Application.OpenForms["FrmRequarmensGame"].Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            stCounter.NumberOfGame++;
           
            gbGame.Enabled = true;
            btnStartGame.Visible = false;
            pbTimerGame.Maximum = Req.Timer;
            TimerPb.Start();
           
        }

        private void pbTimer_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimerPb.Enabled = true;
      
            Thread.Sleep(1000);
            pbTimerGame.Value += 1;
            Req.TimerGame++;
            lblNumberOfProgressBar.Text = "["+pbTimerGame.Value.ToString() + "] Second(s)";
            pbTimerGame.Refresh();

            if(pbTimerGame.Value == pbTimerGame.Maximum)
            {
                TimerPb.Enabled = false;
                ResultGame();
            }
        }
      

        private void btnShow_Click(object sender, EventArgs e)
        {
            
            if(MessageBox.Show("You have one attempt to show the colors,\nonly 3 Second STAY FOCUS", "Show Colors", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                btnBacktoEdit.Enabled = false;
                TimerShowColor.Start();
                HideQButton();
                FillColorButton();
                lblTimerShowColors.Visible = true;
            }
        }

        
        private void TimerShowColor_Tick(object sender, EventArgs e)
        {
            Counter.CounterShowColor++;
            lblTimerShowColors.Text = Counter.CounterShowColor.ToString();
            Thread.Sleep(1000);

            if(Counter.CounterShowColor == 4)
            {
                TimerShowColor.Enabled = false;
                ShowQButton();
                btnStartGame.Enabled = true;
                btnShowColors.Enabled = false;
                lblTimerShowColors.Visible = false;
                return;
            }
        }

        private void btnResultGame_Click(object sender, EventArgs e)
        {
            GoToResultGame();
        }
    }
}
