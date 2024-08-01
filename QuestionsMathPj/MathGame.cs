using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestionsMathPj
{
    public partial class MathGame : Form
    {
        public MathGame()
        {
            InitializeComponent();
        }
        enum enQuestionLevel
        {
            enEazy,
            enMed,
            enHard,
            enMix
        }
        enum enOperationType
        {
            enSum,
            enSub,
            enMul,
            enDiv,
            enMixOp
        }
        stRequarmensGame ReqGame;
        struct stRequarmensGame
        {
            public enQuestionLevel QuestionLevel;

            //M --> Male F --> Female
            public string Gender;
            public enOperationType OpType;
            public byte Rounds;
        };

        int RandomeNumber(int Min, int Max)
        {
            Random Number = new Random();
            return Number.Next(Min, Max);
        }

        enQuestionLevel FillLevelQuestion(int ValuetbLevel)
        {
            if(ValuetbLevel == 4)
            {
                ValuetbLevel = RandomeNumber(1, 3);
            }
            switch(ValuetbLevel)
            {
                case 1:
                    return enQuestionLevel.enEazy;

                case 2:
                    return enQuestionLevel.enMed;

                default:
                    return enQuestionLevel.enHard;
            }
        }
       
        enOperationType FillOperationType(int ValuetbOptype)
        {
            if(ValuetbOptype == 5)
            {
                ValuetbOptype = RandomeNumber(1, 4);
            }
            switch (ValuetbOptype)
            {
                case 1:
                    return enOperationType.enSum;

                case 2:
                    return enOperationType.enSub;

                case 3:
                    return enOperationType.enDiv;

                default:
                    return enOperationType.enMul;

              
            }
        }

      
        
        int CalculateTrackBar(TrackBar tb)
        {
            switch (tb.Value)
            {
                case 0:
                    return 0;
                default:
                    return 25;
            }
        }
        int CalculatebGender()
        {
            if(rbMale.Checked)
            {
                return 25;
            }
            else if(rbFemale.Checked)
            {
                return 25;
            }
            else
            {
                return 0;
            }
        }
       int CalculateRound()
        {
            switch(numericRound.Value)
            {
                case 0:
                    return 0;
                default:
                    return 25;
            }
        }

        int CalculaterProgressBar()
        {
            return (CalculateTrackBar(tbLevel) + CalculatebGender() + CalculateTrackBar(tbOperation) + CalculateRound());
        }
        void UpdateProgressBar()
        {
            progressBar1.Value = CalculaterProgressBar();
            progressBar1.Refresh();

            if(progressBar1.Value == 100)
            {
                btnStartGame.Enabled = true;
            }
            else
            {
                btnStartGame.Enabled = false;
            }
        }
        void UpdateGender()
        {
            if (rbMale.Checked)
            {
                ReqGame.Gender = "Male";
            }
            else
            {
                ReqGame.Gender = "Female";
            }
        }
        void ValidatingTrackBarError(TrackBar tb, string MessageError, CancelEventArgs e)
        {
            if(tb.Value == 0)
            {
                e.Cancel = true;
                tb.Focus();
                errorProvider1.SetError(tb, MessageError);
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tb, "");
            }
        }
        void ValidatingRadioButtonError(RadioButton rb, string MessageError, CancelEventArgs e)
        {
            if(!rb.Checked)
            {
                e.Cancel= true;
                rb.Focus();
                errorProvider1.SetError(rb, MessageError);
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(rb, "");
            }
        }
        void ValidatingnumericupdownError(NumericUpDown NUP, string MessageError, CancelEventArgs e)
        {
            if(NUP.Value == 0)
            {
                e.Cancel = true;
                NUP.Focus();
                errorProvider1.SetError(NUP, MessageError);
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(NUP, "");
            }
        }
        private void tbLevel_Scroll(object sender, EventArgs e)
        {
            UpdateProgressBar();
            ReqGame.QuestionLevel = FillLevelQuestion(tbLevel.Value);
        }
        void GoTotabPlayGame()
        {
            PlRequermensGame.Enabled = false;
            
           
            tabControl1.SelectedTab = tabPlayGame;
        }
        
        bool RuleBeforeStartAnyTab()
        {
            return progressBar1.Value == 100;
        }

        //PlayGame
        void BackTotabRequermensGame()
        {
            btnStartGame.Enabled = true;
          
            tabControl1.SelectedTab = tabRequarmensGame;
          
        }
       
        stQuiz Quizz;
        struct stQuiz
        {
            public int Number1, Number2;
            public string OpType;
            public int CorrectAnswer;
            public bool Help;
            public short NumberOfRightAnswer, NumberOfWrongAnswer;
            public int CountTimer, CountRound;
        };

       int SimpleCalculate(int Number1, int Number2, enOperationType OpType)
        {
            switch(OpType)
            {
                case enOperationType.enSum:

                    return Number1 + Number2;

                case enOperationType.enSub:
                    return Number1 - Number2;

                case enOperationType.enDiv:
                    return Number1 / Number2;

                case enOperationType.enMul:
                    return Number1 * Number2;

                default:
                    return Number1 + Number2;

            }
        }

       void FillNumbersAndCorrectAnswerForQuestions(int Min, int Max, enOperationType OpType)
        {
            Random Number = new Random();
            Quizz.Number1 = Number.Next(Min, Max);
            Quizz.Number2 = Number.Next(Min, Max);
            Quizz.CorrectAnswer = SimpleCalculate(Quizz.Number1, Quizz.Number2, OpType);
        }
        void GeneradeQuestion()
        {
            switch(ReqGame.QuestionLevel)
            {
                case enQuestionLevel.enEazy:
                    {
                        FillNumbersAndCorrectAnswerForQuestions(1, 25, ReqGame.OpType);
                        break;
                    }

                case enQuestionLevel.enMed:
                    {
                        FillNumbersAndCorrectAnswerForQuestions(25, 50, ReqGame.OpType);
                        break;
                    }

                case enQuestionLevel.enHard:
                    {
                        FillNumbersAndCorrectAnswerForQuestions(50, 100, ReqGame.OpType);
                        break;
                    }
            }
        }


        int RandomChoiceAnswerQuizz()

        {
            int RandomNumber = RandomeNumber(0, 2);
            int Number1 = Quizz.CorrectAnswer - 1;
            int Number2 = Quizz.CorrectAnswer + 1;
            int[] arrAnswer = { Quizz.CorrectAnswer, Number1, Number2 };
            return arrAnswer[RandomNumber];
        }

        void FillButtonChoice(Button btnChange)
        {
            btnChange.Text = RandomChoiceAnswerQuizz().ToString();
            if(btnChange.Tag.ToString() == "1")
            {
                while (btnChange.Text == btnChoice2.Text || btnChange.Text == btnChoice3.Text)
                {
                    btnChange.Text = RandomChoiceAnswerQuizz().ToString();
                }
                btnChoice1.Text = btnChange.Text;
            }
           else if(btnChange.Tag.ToString() == "2")
            {
                while (btnChange.Text == btnChoice1.Text || btnChange.Text == btnChoice3.Text)
                {
                    btnChange.Text = RandomChoiceAnswerQuizz().ToString();
                }
                btnChoice2.Text = btnChange.Text;
            }
            else
            {
                int Number1 = Quizz.CorrectAnswer - 1;
                int Number2 = Quizz.CorrectAnswer + 1;
                if (btnChoice1.Text == Quizz.CorrectAnswer.ToString())
                {
                    if (btnChoice2.Text == Number1.ToString())
                    {
                        btnChoice3.Text = Number2.ToString();
                    }
                    else
                    {
                        btnChoice3.Text = Number1.ToString();
                    }
                }
                else if(btnChoice2.Text == Quizz.CorrectAnswer.ToString())
                {
                    if (btnChoice1.Text == Number1.ToString())
                    {
                        btnChoice3.Text = Number2.ToString();
                    }
                    else
                    {
                        btnChoice3.Text = Number1.ToString();
                    }
                }
                else
                {
                    btnChoice3.Text = Quizz.CorrectAnswer.ToString();
                }
             
              
            }
        }

       
        void FillPictureModeRight()
        {
            if(rbMale.Checked)
            {
                picMode.Image = Image.FromFile(@"c:\Photos\RightAnswerMan.jpg");
            }
            else
            {
                picMode.Image = Image.FromFile(@"c:\Photos\RightAnswerWoman.jpg");
            }
        }
        void FillPictureModeWrong()
        {
            if (rbMale.Checked)
            {
                picMode.Image = Image.FromFile(@"c:\Photos\WrongAnswerMan.jpg");
            }
            else
            {
                picMode.Image = Image.FromFile(@"c:\Photos\WrongAnswerWoman.jpg");
            }
        }


        bool IsPlayerAnswerIsRight(Button btn)
        {
            return btn.Text == Quizz.CorrectAnswer.ToString();
        }
        void FillCounterWrongAndRightAnswer(Button btn)
        {
            if (IsPlayerAnswerIsRight(btn))
            {
                btn.BackColor = Color.Green;
                FillPictureModeRight();
                Quizz.NumberOfRightAnswer++; 
            }
            else
            {
                btn.BackColor = Color.Red;
                FillPictureModeWrong();
                Quizz.NumberOfWrongAnswer++;
                MessageBox.Show("The Result is : " + Quizz.CorrectAnswer.ToString());
            }
        }

        

        string StringOperationType()
        {
            switch (ReqGame.OpType)
            {
                case enOperationType.enSum:

                    return "+";

                case enOperationType.enSub:
                    return "-";

                case enOperationType.enDiv:
                    return "/";

                case enOperationType.enMul:
                    return "*";
                        
                default:
                    return "+";

            }
        }
        void FillgbQuizz()
        {
            lblNumber1.Text = Quizz.Number1.ToString();
            lblOpType.Text = StringOperationType();
            lblNumber2.Text = Quizz.Number2.ToString();
        }
        void StartTimer()
        {
            lblTimer.ForeColor = Color.White;
            timer1.Start();
        }
        void CalculatRound()
        {
            Quizz.CountRound++;
            lblNumberOfRound.Text = Quizz.CountRound.ToString() + "|" + numericRound.Value.ToString();
        }


        void FinishTimeRound()
        {
            if(Quizz.CountTimer == 30)
            {
                if(MessageBox.Show("The Time is out", "Finish Time", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    Quizz.NumberOfWrongAnswer++;
                    MessageBox.Show("The Result is : " + Quizz.CorrectAnswer.ToString() + "Result");
                    FillPictureModeWrong();
                    gBQuestions.Enabled = false;
                    btnNextQuiz.Enabled = true;
                }
            }
        }
        void StartQuestion()
        {
            if (MessageBox.Show("استعن بلله قبل البدء", "Start", MessageBoxButtons.OK) == DialogResult.OK)
            {
                btnStartQuiz.Enabled = false;
                gBQuestions.Enabled = true;
                btnBackToRequarmensGame.Enabled = false;

            }
            CalculatRound();
            FillPictrueGender();
            GeneradeQuestion();
            FillgbQuizz();
            FillButtonChoice(btnChoice1);
            FillButtonChoice(btnChoice2);
            FillButtonChoice(btnChoice3);
            StartTimer();
            
        }
        void Help()
        {
            if(btnHelp.Tag.ToString() == "?")
            {
                if(MessageBox.Show("لديك مساعده واحده فقط\n هل تريد استخدامها الان؟", "Help", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    btnHelp.Tag = "x";
                    notifyIconHelp.Icon = SystemIcons.Application;
                    notifyIconHelp.BalloonTipIcon = ToolTipIcon.Info;
                    notifyIconHelp.BalloonTipTitle = "Help for Quizz";
                    notifyIconHelp.BalloonTipText = lblNumber1.Text + lblOpType.Text + lblNumber2.Text + " = " + Quizz.CorrectAnswer;
                    notifyIconHelp.ShowBalloonTip(7);
                }
            }
            else
            {
                MessageBox.Show("لقد نفذت محاولات المساعده","Finish", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ChoiceClick(Button btn)
        {
            timer1.Enabled = false;
            gBQuestions.Enabled = false;
            if (numericRound.Value > 1)
            {
                btnNextQuiz.Enabled = true;
            }
            else
            {
                btnGoToResult.Visible = true;
            }
           
            FillCounterWrongAndRightAnswer(btn);
          
        }
        void FillPictrueGender()
        {
            if(rbMale.Checked)
            {
                picGender.Image = Image.FromFile(@"c:\Photos\ManMath.jpg");
            }
            else
            {
                picGender.Image = Image.FromFile(@"c:\Photos\WomanMath.jpg");
            }
        }
       
        void FinishQuizz()
        {
            btnGoToResult.Visible = true;
            if (MessageBox.Show("The quizz is out\nPlease Press GoToResult to show your result", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
            {
                
                gBQuestions.Enabled = false;
            }
        }

        void NextQuizz()
        {
            if (Quizz.CountRound == numericRound.Value)
            {
                FinishQuizz();
                return;
            }
            CalculatRound();
            if (Quizz.CountRound <= numericRound.Value)
            {

                Quizz.CountTimer = Convert.ToInt32(Quizz.CountTimer) - Convert.ToInt32(Quizz.CountTimer);

                btnChoice1.BackColor = Color.Transparent;
                btnChoice2.BackColor = Color.Transparent;
                btnChoice3.BackColor = Color.Transparent;

                gBQuestions.Enabled = true;
                GeneradeQuestion();
                FillgbQuizz();
                FillButtonChoice(btnChoice1);
                FillButtonChoice(btnChoice2);
                FillButtonChoice(btnChoice3);
                StartTimer();

                btnNextQuiz.Enabled = false;
               
            }
        }

        string StringQuizzLevelForListView()
        {
            switch (tbLevel.Value)
            {
                case 1:
                    {
                        return "Eazy";
                    }
                    case 2:
                    {
                        return "Medium";
                    }
                    case 3:
                    {
                        return "Hard";
                    }
                default:
                    {
                        return "Mix";
                    }
            }

        }

        string StringOperationTypeForListView()
        {
            switch (tbOperation.Value)
            {
                case 1:
                    {
                        return "Sum(+)";
                    }
                case 2:
                    {
                        return "Sub(-)";
                    }
                case 3:
                    {
                        return "Div(/)";
                    }
                case 4:
                    {
                        return "Mul(*)";
                    }
                default:
                    {
                        return "Mix";
                    }
            }

        }

        bool IsPass()
        {
            return Quizz.NumberOfRightAnswer > Quizz.NumberOfWrongAnswer;
        }
        
        void FillViewListAllPlayer()
        {
            string Gender;
            if (rbMale.Checked)
            {
                Gender = "Male";

            }
            else
            {
                Gender = "Female";
            }
            ListViewItem item = new ListViewItem(Gender);
            if (rbMale.Checked)
            {
               
                item.ImageIndex = 0;

            }
            else
            {
              
                item.ImageIndex = 1;
            }
            item.SubItems.Add(StringQuizzLevelForListView());
            item.SubItems.Add(StringOperationTypeForListView());

          

            item.SubItems.Add("(" + numericRound.Value.ToString() + ")Rounds");
            item.SubItems.Add(Quizz.NumberOfWrongAnswer.ToString());
            item.SubItems.Add(Quizz.NumberOfRightAnswer.ToString());
            
            if(IsPass())
            {
                item.SubItems.Add("Yes :-)");
            }
            else
            {
                item.SubItems.Add("No :-(");
            }

            listViewAllPlayer.Items.Add(item);

        }
        void ResultGame()
        {
            if (IsPass())
            {
                picInfo.Image = Image.FromFile(@"c:\Photos\ResultIvfoWin.jpg");
                picModeInResultGame.Image = Image.FromFile(@"c:\Photos\ModeWin.png");
                label23.ForeColor = Color.Green;
                label30.ForeColor = Color.Green;
                label27.ForeColor = Color.Green;
                label29.ForeColor = Color.Green;
                label28.ForeColor = Color.Green;
                label26.ForeColor = Color.Green;

            }
            else
            {
                picInfo.Image = Image.FromFile(@"c:\Photos\ResultInfoLose.jpg");
                picModeInResultGame.Image = Image.FromFile(@"c:\Photos\ModeLose.png");
                label23.ForeColor = Color.Red;
                label30.ForeColor = Color.Red;
                label27.ForeColor = Color.Red;
                label29.ForeColor = Color.Red;
                label28.ForeColor = Color.Red;
                label26.ForeColor = Color.Red;
            }
             if(rbMale.Checked)
            {
                lblGender.Text = "Male";
            }
             else
            {
                lblGender.Text = "Female";
            }
            lblQuestionLevel.Text = StringQuizzLevelForListView();
            lblOperationType.Text = StringOperationTypeForListView();
            lblRound.Text = numericRound.Value.ToString() + "Rounds";
            lblNumberOfWrongAnswer.Text = Quizz.NumberOfWrongAnswer.ToString();
            lblNumberOfRightAnswer.Text = Quizz.NumberOfRightAnswer.ToString();
        }

        void PlayAgain()
        {
            tabControl1.SelectedTab = tabRequarmensGame;
            //Requarmens
            PlRequermensGame.Enabled = true;
            btnStartGame.Enabled = false;
            tbLevel.Value = 0;
            tbOperation.Value = 0;
            numericRound.Value = 0;
           

            //PlayGame
            btnStartQuiz.Enabled = true;
            lblNumberOfRound.Text = "0 | 0";
            lblTimer.Text = "0";
            Quizz.CountTimer = 0;
            Quizz.CountRound = 0;
            Quizz.NumberOfWrongAnswer = 0;
            Quizz.NumberOfRightAnswer = 0;
            btnGoToResult.Visible = false;
            lblNumber1.Text = "00";
            lblOperationType.Text = "+";
            lblNumber2.Text = "00";
            btnChoice1.Text = "Choice 1";
            btnChoice2.Text = "Choice 2";
            btnChoice3.Text = "Choice 3";
            btnChoice1.BackColor = Color.Transparent;
            btnChoice2.BackColor = Color.Transparent;
            btnChoice3.BackColor = Color.Transparent;
            btnBackToRequarmensGame.Enabled = true;
            btnHelp.Tag = "?";
            btnNextQuiz.Enabled = false;
            picMode.Image = Image.FromFile(@"c:\Photos\question-mark-96.png");
            picGender.Image = Image.FromFile(@"c:\Photos\question-mark-96.png");

            //ResultGame
            lblGender.Text = " ";
            lblQuestionLevel.Text = " ";
            lblOperationType.Text = " ";
            lblRound.Text = " ";
            lblNumberOfWrongAnswer.Text = " ";
            lblNumberOfRightAnswer.Text = " ";
            picModeInResultGame.Image = Image.FromFile(@"c:\Photos\question-mark-96.png");

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            UpdateProgressBar();
            UpdateGender();
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            UpdateProgressBar();
            UpdateGender();
        }

        private void tbOperation_Scroll(object sender, EventArgs e)
        {
            UpdateProgressBar();
            ReqGame.OpType = FillOperationType(tbOperation.Value);
        }

        private void numericRound_ValueChanged(object sender, EventArgs e)
        {
            UpdateProgressBar();
            ReqGame.Rounds = Convert.ToByte(numericRound.Value);
        }

        private void tbLevel_Validating(object sender, CancelEventArgs e)
        {
            ValidatingTrackBarError(tbLevel, "You should fill trackbar QuestionLevel", e);
        }

        private void tbOperation_Validating(object sender, CancelEventArgs e)
        {
            ValidatingTrackBarError(tbOperation, "You should fill trackbar Operationtype", e);
        }

        private void rbMale_Validating(object sender, CancelEventArgs e)
        {
            ValidatingRadioButtonError(rbMale, "You should fill radiobutton Gender", e);
        }

        private void rbFemale_Validating(object sender, CancelEventArgs e)
        {
            ValidatingRadioButtonError(rbFemale, "You should fill radiobutton Gender", e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void numericRound_Validating(object sender, CancelEventArgs e)
        {
            ValidatingnumericupdownError(numericRound, "You should fill numericupdown Ropunds", e);
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            GoTotabPlayGame();
        }

        private void btnBackToRequarmensGame_Click(object sender, EventArgs e)
        {
            BackTotabRequermensGame();
        }

        private void label17_Click(object sender, EventArgs e)
        {
           
        }

        private void btnStartQuestion_Click(object sender, EventArgs e)
        {
            if(!RuleBeforeStartAnyTab())
            {
                if (MessageBox.Show("You can`t start, Because you don`t Fill Requarmens Game ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    tabControl1.SelectedTab = tabRequarmensGame;
                    return;
                }
            }
            
            StartQuestion();

            
        }

        private void btnNextQuiz_Click(object sender, EventArgs e)
        {
            NextQuizz();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
             Quizz.CountTimer++;
            lblTimer.Text = Quizz.CountTimer.ToString();

            if (Quizz.CountTimer == 30)
            {
                timer1.Enabled = false;
                FinishTimeRound();
              
                return;
            }
            if (Quizz.CountTimer >= 20)
            {
                lblTimer.Refresh();
                lblTimer.ForeColor = Color.Red;
            }
            
           
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Help();
        }
        private void btnChoice_Click(object sender, EventArgs e)
        {
            ChoiceClick((Button)sender);
        }

        private void btnGoToResult_Click(object sender, EventArgs e)
        {
            FillViewListAllPlayer();
            ResultGame();
            tabControl1.SelectedTab = tabResultGame;
        }

        private void tabResultGame_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabAllPlayer;
            btnAgain.Visible = true;
        }

        private void btnAgain_Click(object sender, EventArgs e)
        {
            PlayAgain();
        }

        private void btnGoToGame_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPlayGame;
        }

        private void listViewAllPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void notifyIconHelp_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void PlRequermensGame_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabAllPlayer_Click(object sender, EventArgs e)
        {

        }
    }
}
