using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorMatching_Game
{
    public partial class FrmRequarmensGame : Form
    {
        public static FrmRequarmensGame Instance;
        public FrmRequarmensGame()
        {
            Instance = this;
            InitializeComponent();
        }
        public stReq Req;
        public struct stReq
        {
            public byte Counter;
            public Color Color;
            public string Color1, Color2, Color3, Color4;
            public string StringYourColors;
            public byte Timer;
            public string LevelGame;
        };

       
        void FillButtonColor(Button btn,  Color color)
        {
            btn.Visible = true;
            btn.BackColor = color;
        }
        void FillColorByCounter(byte Counter, Color color)
        {
            switch(Counter)
            {
              case 1:
              {
                  FillButtonColor(btnFirstColor, color);
                  return;
              }
              case 2:
              {
                  FillButtonColor(btnSecondColor, color);
                  return;
              }
              case 3:
              {
                  FillButtonColor(btnThirdColor, color);
                  return;
              }
              case 4:
              {
                  FillButtonColor(btnForthColor, color);
                  return;
              }
                  
            }
        }

        void FillStructReq(byte Counter, Color color)
        {
            Req.Counter = Counter;
            Req.Color = color;
        }
        
        string GetStringColors(string Color1,string Color2, string Color3, string Color4)
        {
            if (Req.LevelGame == "Easy")
                return Color1 + ", " + Color2;
            else
                return Color1 + ", " + Color2 + ", " + Color3 + ", " + Color4;
        }

        void WhenPressCheckBox(RadioButton rb)
        {
           
            byte Tag = Convert.ToByte(rb.Tag);
            switch (Tag)
            {
                case 1:
                    {
                        if(rbRed.Checked)
                        {
                           FillStructReq(Tag, Color.Red);
                            Req.Color1 = "Red";
                        }
                        else
                        {
                            FillStructReq(Tag, Color.DarkRed);
                            Req.Color1 = "Dark Red";
                        }
                        break;
                    }
                    case 2:
                    {
                        if (rbYellow.Checked)
                        {
                            FillStructReq(Tag, Color.Yellow);
                            Req.Color2 = "Yellow";
                        }
                        else
                        {
                            FillStructReq(Tag, Color.LightYellow);
                            Req.Color2 = "Light Yellow";
                        }
                        break;
                    }
                case 3:
                    {
                        if(rbGreen.Checked)
                        {
                            FillStructReq(Tag, Color.Green);
                            Req.Color3 = "Green";
                        }
                        else
                        {
                            FillStructReq (Tag, Color.DarkGreen);
                            Req.Color3 = "Dark Green";
                        }
                        break;
                    }
                case 4:
                    {
                        if(rbBlue.Checked)
                        {
                            FillStructReq(Tag, Color.Blue);
                            Req.Color4 = "Blue";
                        }
                        else
                        {
                            FillStructReq(Tag, Color.LightBlue);
                            Req.Color4 = "Light Blue";
                        }
                        break;
                    }
            }

            Req.StringYourColors = GetStringColors(Req.Color1, Req.Color2, Req.Color3, Req.Color4);
        }
        bool VisableStartGame()
        {
            if(string.IsNullOrEmpty(Req.LevelGame))
            {
                return false;
            }
            switch (Req.LevelGame)
            {
                case "Easy":
                    return (btnFirstColor.Visible == true && btnSecondColor.Visible == true) && numericTime.Value > 0;
                default:

                    return (btnFirstColor.Visible == true && btnSecondColor.Visible == true && btnThirdColor.Visible == true && btnForthColor.Visible == true) && numericTime.Value > 0;
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            WhenPressCheckBox((RadioButton)sender);
            FillColorByCounter(Req.Counter, Req.Color);
            if (VisableStartGame())
            {
                btnStartGame.Visible = true;
            }
        }

       
        public void ResetRequarmensGame()
        {
            rbBlue.Checked = false;
            rbGreen.Checked = false;
            rbYellow.Checked = false;
            rbRed.Checked = false;
            rbDarkGreen.Checked = false;
            rbDarkRed.Checked = false;
            rbLightBlue.Checked = false;
            rbLightYellow.Checked = false;

            btnStartGame.Visible = false;
            gbColor.Visible = false;
            numericTime.Value = 0;
            numericTime.Visible = false;

            btnFirstColor.Visible = false;
            btnSecondColor.Visible = false;
            btnThirdColor.Visible = false;
            btnForthColor.Visible = false;
        }



        void ChangeSizegbColorByLevel()
        {
            System.Drawing.Size size;
            switch (Req.LevelGame)
            {
                case "Easy":
                     size = new System.Drawing.Size(320, 113);
                    btnThirdColor.Visible = false;
                    btnForthColor.Visible = false;
                    break;

                default:
                    size = new System.Drawing.Size(320, 201);
                    if(rbGreen.Checked || rbDarkGreen.Checked)
                    {
                        btnThirdColor.Visible = true;
                    }
                    else
                    {
                        btnThirdColor.Visible = false;
                    }
                    if (rbBlue.Checked || rbLightBlue.Checked)
                    {
                        btnForthColor.Visible = true;
                    }
                    else
                    {
                        btnForthColor.Visible = false;
                    }


                    break;
            }
            gbColor.Size = size;
            
           
        }


        private void FrmRequarmensGame_Load(object sender, EventArgs e)
        {
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            gbColor.Visible = true;
        }

        private void btnSetColor_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_MouseEnter_1(object sender, EventArgs e)
        {
            numericTime.Visible = true;
        }

        private void btnSetTimer_Click(object sender, EventArgs e)
        {

        }

        private void cbRed_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void numericTime_ValueChanged(object sender, EventArgs e)
        {
            Req.Timer = Convert.ToByte(numericTime.Value);
            if (VisableStartGame())
            {
                btnStartGame.Visible = true;
            }
            else
            {
                btnStartGame.Visible = false;
            }
        }

      
        
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            Form FormGame = new FrmGame();
            FormGame.Show();
            this.Hide();
        }

        private void gbColor_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSetLevel_MouseEnter(object sender, EventArgs e)
        {
            cbLevel.Visible = true;
        }

        private void cbLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Req.LevelGame = cbLevel.Text;
            ChangeSizegbColorByLevel();
            if (VisableStartGame())
            {
                btnStartGame.Visible = true;
            }
            else
            {
                btnStartGame.Visible = false;
            }
        }

        private void gbColor_Enter_1(object sender, EventArgs e)
        {

        }
    }
}
