using FirsGUNA.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirsGUNA
{
    public partial class ctrl8Pool : UserControl
    {
        public ctrl8Pool()
        {
            InitializeComponent();
        }
        // 60 Mins -> 10 $
        // 1 Min   -> 0.1666666666666667 $
        // 1 Sec   -> 0.0027777777777778 $

        byte _HourlyRate = 10;

      
       public enum enStatusGame { Start, Stop, End}
        public string NameOfTable { get { return gbTable.Text; } set { gbTable.Text = value; } }
        public enum enTypeOfTable { None, Normal, VIP};
        enTypeOfTable _TypeOfTable;
        public enTypeOfTable TypeOfTable { get { return _TypeOfTable; } set 
            {
                _TypeOfTable = value;

                switch (_TypeOfTable)
                {
                    case enTypeOfTable.None:
                        {
                            picTable.Tag = "?";
                            picTable.Image = Resources.QuestionMark;
                            return;
                        }
                        case enTypeOfTable.Normal:
                        {
                            cbTypeOfTable.Text = "Normal";
                            break;
                        }
                        case enTypeOfTable.VIP:
                        {
                            cbTypeOfTable.Text = "VIP";
                            break;
                        }
                }


                _ChangePicture(false);
            } 
        }
        public Color ColorOfHeader { get { return gbTable.CustomBorderColor; } set { gbTable.CustomBorderColor = value; } }
        public Color ColorOfBody { get { return gbTable.FillColor; } 
            set 
            {
                gbTable.FillColor = value;
                lblTimer.BackColor = value;
            } }
        public Color ColorOfbtnEnd
        {
            get { return btnEnd.FillColor; }
            set
            {
                btnEnd.FillColor = value;
            }
        }
        public Color ColorOfbtnStart
        {
            get { return btnSwitch.FillColor; }
            set
            {
                btnSwitch.FillColor = value;
            }
        }
        public static int _GetTotalSeconds(DateTime dt)
        {
            int Total = dt.Hour * 60 * 60;
            Total += dt.Minute * 60;
            Total += dt.Second;
            
            return Total;
        }

       static double _GetPrice(int TotalSeconds, double SecondlyRate)
        {
            return TotalSeconds * SecondlyRate;
        }
    
     
        public class clsEvent8Pool : EventArgs
        {
            public string NameOfTable { get; }
            public enStatusGame statusGame { get; }
            public string StringStatusGame {
                get
                {
                    switch (statusGame)
                    {
                        case enStatusGame.Start:
                            return "Start";
                            case enStatusGame.Stop:
                            return "Stop";
                        default:
                            return "End";
                    }

                }
            }
            public DateTime Date { get; }
            public int TotalSeconds { get; }
            public double Price { get; }
            public string TypeOfTable { get; }

            public clsEvent8Pool(string NameOfTable,enTypeOfTable typeOfTable,enStatusGame statusGame, DateTime date)
            {
                this.statusGame = statusGame;
                Date = date;
                this.NameOfTable = NameOfTable;
                
                TotalSeconds = _GetTotalSeconds(date);
              
                
                if(typeOfTable == enTypeOfTable.Normal)
                {
                    TypeOfTable = "Normal";
                Price = _GetPrice(TotalSeconds, 0.0027777777777778);
                }
                else
                {
                    TypeOfTable = "VIP";
                    Price = _GetPrice(TotalSeconds, 0.0083333333333334);
                }
            }
        }


        public event EventHandler<clsEvent8Pool> OnStart8Pool;
        public event EventHandler<clsEvent8Pool> OnStop8Pool;
        public event EventHandler<clsEvent8Pool> OnEnd8Pool;

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            if(picTable.Tag == "?")
            {
                MessageBox.Show("Set Table Information to play", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (Tag == null)
                Tag = "On";

            if(Tag == "On")
            {
                Tag = "Off";
                btnSwitch.Text = "Stop";
                timer1.Start();
                OnStart8Pool?.Invoke(this,new clsEvent8Pool(NameOfTable, _TypeOfTable,enStatusGame.Start, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, PartHours,PartMinutes, PartSeconds)));
            }
            else
            {
                Tag = "On";
                btnSwitch.Text = "Start";
                timer1.Stop();
                OnStop8Pool?.Invoke(this, new clsEvent8Pool(NameOfTable, _TypeOfTable, enStatusGame.Stop, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, PartHours, PartMinutes, PartSeconds)));
            }

            _ChangePicture(true);

            nameOfTableToolStripMenuItem1.Enabled = false;
            typeOfTableToolStripMenuItem.Enabled = false;
            
        }


        byte PartHours = 0, PartMinutes = 0, PartSeconds = 0;

        void _ChangePicture(bool WithLamp)
        {
            picTable.Tag = "!";
            switch (cbTypeOfTable.Text)
            {
                case "Normal":
                    {
                        
                        if (WithLamp)
                            picTable.Image = Resources.Normal_Table_With_Lamp;
                        else
                            picTable.Image = Resources.Normal_Table_Without_Lamp;

                        break;
                    }
                default:
                    {
                        if (WithLamp)
                            picTable.Image = Resources.VIP_Table_With_Lamp;
                        else
                            picTable.Image = Resources.VIP_Table_Without_Lamp;
                        break;
                    }
                   
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //_Date.AddSeconds(1);
            //_Date.Add(new TimeSpan(0, 0, 0, 1));
            //DateTime dt = _Date; 
            PartSeconds++;
            if (PartMinutes == 60)
            {
                PartMinutes = 0;
                ++PartHours;
            }
            if(PartSeconds == 60)
            {
                ++PartMinutes;
                PartSeconds = 0;
            }
            

            lblTimer.Text = $"{PartHours} : {PartMinutes} : {PartSeconds}";

        }
        void _RefreshData()
        {

            picTable.Image = Resources.QuestionMark;
            picTable.Tag = "?";
            gbTable.Text = "Programming Advice";
            gbTable.CustomBorderColor = Color.Green;
            gbTable.FillColor = Color.DarkSlateGray;
            lblTimer.BackColor = Color.DarkSlateGray;
            btnSwitch.FillColor = Color.Green;
            btnEnd.FillColor = Color.Green;
            PartHours = 0;
            PartMinutes = 0;
            PartSeconds = 0;
            lblTimer.Text = "00 : 00 : 00";
            btnSwitch.Text = "Start";
            btnSwitch.Tag = "On";
            nameOfTableToolStripMenuItem1.Enabled = true;
            typeOfTableToolStripMenuItem.Enabled = true;
            cbTypeOfTable.SelectedIndex = -1;
           // _ChangePicture(false);
        }

       

        

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            NameOfTable = toolStripTextBox1.Text;
        }

        private void cmsTable_Opening_1(object sender, CancelEventArgs e)
        {
            toolStripTextBox1.Text = NameOfTable;
        }

      



        void _TableInfo(string TypeOfTable, int HournltRate)
        {
            MessageBox.Show($@"Type Of Table is : {TypeOfTable},

Hourly Rate       : {HournltRate}.", "Table Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void picTable_DoubleClick(object sender, EventArgs e)
        {
            switch (cbTypeOfTable.Text)
            {
                case "Normal":
                    {
                        _TableInfo("Normal", 10);
                        break;
                    }
                case "VIP":
                    {
                        _TableInfo("VIP", 30);
                        break;
                    }
                default:
                    {
                        _TableInfo("NULL", 00);
                        break;
                    }
                   
            }
        }

        private void cbTypeOfTable_Click(object sender, EventArgs e)
        {

        }

        private void colorOfHeaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(cdControl.ShowDialog() == DialogResult.OK)
            {
                gbTable.CustomBorderColor = cdControl.Color;
            }
        }

        private void colorOfBodyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cdControl.ShowDialog() == DialogResult.OK)
            {
                gbTable.FillColor = cdControl.Color;
                lblTimer.BackColor = cdControl.Color;
            }
        }

        private void colorOfSwitchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cdControl.ShowDialog() == DialogResult.OK)
            {
                btnSwitch.FillColor = cdControl.Color;
                btnEnd.FillColor = cdControl.Color;
            }
        }

        private void typeOfTableToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

      

        private void cbTypeOfTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            picTable.Tag = "!";
            switch (cbTypeOfTable.Text)
            {
                case "Normal":
                    {
                        picTable.Image = Resources.Normal_Table_Without_Lamp;
                       // _TableInfo("Normal", 10);
                        break;
                    }
                case "VIP":
                    {
                        picTable.Image = Resources.VIP_Table_Without_Lamp;
                       // _TableInfo("VIP", 30);
                        break;
                    }
                default:
                    {
                        picTable.Tag = "?";
                        //_TableInfo("NULL", 00);
                        break;
                    }

            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            if(picTable.Tag=="!")
            {
                timer1.Stop();
                OnEnd8Pool?.Invoke(this, new clsEvent8Pool(NameOfTable, _TypeOfTable, enStatusGame.End, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, PartHours, PartMinutes, PartSeconds)));
                _RefreshData();
            }
           
        }

        private void lblTimer_Click(object sender, EventArgs e)
        {

        }
    }
}
