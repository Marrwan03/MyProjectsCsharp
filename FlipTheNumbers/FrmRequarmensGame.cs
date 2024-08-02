using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FlipTheNumbers.FrmRequarmensGame;
using MyFirstLibraryInForm;
namespace FlipTheNumbers
{
    public partial class FrmRequarmensGame : Form
    {
        public static FrmRequarmensGame Instance;
        public FrmRequarmensGame()
        {
            
            InitializeComponent();
            Instance = this;
        }
        stCounter counter;
        struct stCounter
        {
            public byte CounterTime;
        };

        public stInfoGame InfoGame;
        public struct stInfoGame
        {
            public Color Color;
            public string ColorName;
     
            public byte  NumberOfRound;
        }


        bool IsTimeFinish()
        {
            return counter.CounterTime == 100;
        }

        void WhenPressPlayGameButton()
        {
            
           if(IsTimeFinish())
            {
               if(MessageBox.Show("You can play right now","Wait",MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    return;
                }
                return;
            }

           if(!IsFullData())
            {
                if (MessageBox.Show("You must fill the Requarmes", "Stop", MessageBoxButtons.OKCancel,MessageBoxIcon.Stop) == DialogResult.OK)
                {
                    btnRequarmes.Focus();
                    btnRequarmes.ForeColor = Color.White;
                    return;
                }
                return;
            }

            lblTimer.Visible = true;
            pbTimer.Visible = true;
            timer1.Enabled = true;
            lblWait.Visible = true;
        }

        public void PlayAgain(bool ShowForm)
        {
            if(ShowForm)
                Application.OpenForms["FrmRequarmensGame"].Show();


            counter.CounterTime = 0;
            this.Size = GetSize(274, 484);
            InfoGame.ColorName = null;
            InfoGame.NumberOfRound = 0;
            NUDRound.Value = 0; NUDRound.Visible = false;

            lblTimer.Visible = false;
            pbTimer.Visible = false;
            timer1.Enabled = false;
            lblWait.Visible = false;
            lblFinishLoad.Visible = false;

        }

        void FillLabelWelcome()
        {
            string Welcome;
            Welcome = "Welcome : " + FrmSignUp.instance.playerInfo.UserName;

            lblWelcomePlayerName.Text = Welcome;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ResetForm();
            this.Size = new Size(321, 594);
           // this.Size = GetSize(274, 484);
            FillLabelWelcome();
        }

//
        Form frmGame = new FrmGame();

        void ShowFormGame()
        {
            if(frmGame.IsDisposed)
            {
                frmGame = new FrmGame();
                frmGame.Show();
                return;
            }
            frmGame.Show();
        }

      //  public Form Game { get { return frmGame;} }
        private void timer1_Tick(object sender, EventArgs e)
        {
           
            counter.CounterTime += 10;
            pbTimer.Value = counter.CounterTime;
            lblTimer.Text = counter.CounterTime.ToString() + "%";
            if(counter.CounterTime == 100) 
            {
                timer1.Enabled=false;
                lblWait.Visible=false;
                lblFinishLoad.Visible=true;
                if(MessageBox.Show("Now, You can play","Finish Time !",MessageBoxButtons.OK) == DialogResult.OK)
                {
                    this.Hide();

                    ShowFormGame();

                }

            }
        }

        void VisibleSaveData()
        {
            if (IsFullData())
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }

        void VisibleNumericUpDown(NumericUpDown NUD)
        {
            NUD.Visible = true;
        }

        byte ValueNUD(NumericUpDown NUD)
        {
            return Convert.ToByte(NUD.Value);
        }
  
        bool IsFullData()
        {
            return  InfoGame.NumberOfRound > 0 && !string.IsNullOrEmpty(InfoGame.ColorName);
        }

       
      
        
        private void btnPlayGame_Click(object sender, EventArgs e)
        {
            WhenPressPlayGameButton();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Now,You can play Enjoy!", "Save");
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

      

        private void btnSetColor_MouseEnter(object sender, EventArgs e)
        {
          
        }

        private void btnSetColor_Click(object sender, EventArgs e)
        {
            
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                if (colorDialog1.Color == Color.White)
                {
                   
                    if (MessageBox.Show("You can`t choice white color, Choice another color", "Another Color", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                    {

                        InfoGame.ColorName = null;
                        VisibleSaveData();
                        return;
                    }
                }


                InfoGame.Color = colorDialog1.Color;
                InfoGame.ColorName = InfoGame.Color.Name;
                VisibleSaveData();
            }

        }

       

      
                                            //353 - 557 Without Settings
       public Size GetSize(int Width, int Height) //845 - 557 With Settings
        {
            Size size = new Size(Width, Height);
            return size;
        }

      

        private void gbYourOrder_Enter(object sender, EventArgs e)
        {

        }

        private void btn3C_Click(object sender, EventArgs e)
        {

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            pSettings.Visible = true;
            this.Size = GetSize(837, 594);
        }

       
        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure, Do you want Exit The Game?","Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                
              FrmSignUp.instance.Close();
  
                this.Close();
            }
           
        }

        private void btnCloseSettings_Click(object sender, EventArgs e)
        {
            pSettings.Visible = false;
            //this.Size = GetSize(274, 484);
            this.Size = new Size(321, 594);
        }

        private void pbTimer_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            VisibleNumericUpDown(NUDRound);
        }

        private void NUDRound_ValueChanged(object sender, EventArgs e)
        {
            InfoGame.NumberOfRound = ValueNUD(NUDRound);
            VisibleSaveData();
        }

        private void btnYourOrder_MouseEnter(object sender, EventArgs e)
        {

        }

        private void btnSetCoulmns_Click(object sender, EventArgs e)
        {

        }

        private void NUDCoulmns_ValueChanged(object sender, EventArgs e)
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
            btn.ForeColor = Color.White;
        }
    }
}
