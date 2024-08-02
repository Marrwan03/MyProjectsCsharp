using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleHotel
{
    public partial class frmRentRoom : Form
    {
        public static frmRentRoom instance;
        public frmRentRoom()
        {
            InitializeComponent();
            instance = this;
        }

        public static byte timer = 0;

     
       public static Queue<stRentInfo> RentInfos = new Queue<stRentInfo>(), RentsUserQ = new Queue<stRentInfo>();
    //  public static Queue<stRentInfo> RentsUserQ = new Queue<stRentInfo>();

        public  stRentInfo CurrentRentInfo;

        public static stRentInfo RentInfost;
        public  struct stRentInfo
        {
            public int Price;
            public byte NumberOfDays, NumberOfRoom;
            public SelectionRange Date;
            public string Username, Password;
        }



     
        byte NumberOfRent(SelectionRange Date)
        {
            byte Number = 0;
            
            
            DateTime StartDay =  Date.Start;
            DateTime EndDay = Date.End;
            TimeSpan Diff = EndDay.Subtract(StartDay);

            Number = Convert.ToByte(Diff.Days);
            return Number;
        }

        void FillstructDateAndlabel(MonthCalendar Date)
        {
            CurrentRentInfo.Date = Date.SelectionRange;
            lblStartDate.Text = CurrentRentInfo.Date.Start.ToShortDateString();
            lblEndDate.Text = CurrentRentInfo.Date.End.ToShortDateString();
        }

        void FillStruct()
        {
            CurrentRentInfo.NumberOfDays = NumberOfRent(CurrentRentInfo.Date);
            CurrentRentInfo.NumberOfRoom = Convert.ToByte(ComboNumberOfRoom.SelectedItem.ToString());
            CurrentRentInfo.Price = Convert.ToByte(CurrentRentInfo.NumberOfDays * 25);
            CurrentRentInfo.Username = frmCreateAccount.CurrentuserInfo.Username;
            CurrentRentInfo.Password = frmCreateAccount.CurrentuserInfo.Password;

        }

        void FillPanelFromStruct()
        {
            
            lblNumberOfDays.Text = CurrentRentInfo.NumberOfDays.ToString() + " Day(s).";
            //lblNumberOfRoom.Text = CurrentRentInfo.NumberOfRoom.ToString();
            lblPrice.Text = CurrentRentInfo.Price.ToString() + " $";
        }

        bool IsFullData()
        {
            return ComboNumberOfRoom.SelectedIndex != -1 && (CalenderDate.SelectionRange.End.Day != CalenderDate.SelectionRange.Start.Day);
        }

        

        void FillLabelsPanel()
        {
           if (IsFullData())
            {
                FillStruct();
                FillPanelFromStruct();
                btnRent.Enabled = true;
            }
           else
            {
                btnRent.Enabled = false;
            }
        }

        void MessageEvery15Second()
        {
            if (MessageBox.Show("Please Enter [NumberOfRoom & FillDate] to can rent room", "Fill Data!", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                return;
            return;
        }

        bool IsOverlapDate(DateTime dt, SelectionRange Date )
        {
            return dt >= Date.Start && dt <= Date.End;
        }

        bool IsOverlapRent()
        {
            foreach(stRentInfo Rentinfo in RentInfos)
            {
                if(Rentinfo.NumberOfRoom == CurrentRentInfo.NumberOfRoom)
                {
                    if(IsOverlapDate(CurrentRentInfo.Date.Start,Rentinfo.Date) || IsOverlapDate(CurrentRentInfo.Date.End, Rentinfo.Date))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        void ShowNotifcation()
        {
            notifyIcon1.Icon = SystemIcons.Error;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
            notifyIcon1.BalloonTipTitle = "Wrong Rent!";
            notifyIcon1.BalloonTipText = "Your Date overlap with another user,\n\nPlease enter another {Date OR NumberOfRoom}.";
            notifyIcon1.ShowBalloonTip(10);

        }

       
        void WhenPressRent(object sender, EventArgs e)
        {
            if (IsOverlapRent())
            {
                ShowNotifcation();
            }
            else
            {
                if (MessageBox.Show("Are you sure, do you want Rent This Room? \n\nInfo your Rent : \n\nNumberOfRoom {" + CurrentRentInfo.NumberOfRoom + "}\n\n" +
                    "StartDate {" + CurrentRentInfo.Date.Start.ToShortDateString() + "}\n\n" + "EndDate {" + CurrentRentInfo.Date.End.ToShortDateString() + "}.", "Agree Rent!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    RentInfos.Enqueue(CurrentRentInfo);
                  //  RentsUserQ = RentInfos;

                  

                    if(MessageBox.Show("Do you want to Rent Another room ? ", "Again Rent!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        this.Close();
                    }
                   
                    //GoToMenue
                }
            }
            return;
        }

        void MouseEnterPanel(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            panel.BackColor = Color.Black;
            panel.ForeColor = Color.YellowGreen;
        }

        void MouseLeavePanel(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            panel.BackColor = Color.YellowGreen;
            panel.ForeColor = Color.Black;
        }



        private void frmRentRoom_Load(object sender, EventArgs e)
        {
            TimerToFillData.Start();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

       
        private void CalenderStartDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            FillstructDateAndlabel((MonthCalendar)sender);
            FillLabelsPanel();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblPrice_Click(object sender, EventArgs e)
        {

        }

        private void cbDate_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbNumberOfRoom_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TimerToFillData_Tick(object sender, EventArgs e)
        {
            if(IsFullData())
                TimerToFillData.Stop();

            timer++;
            if(timer == 15)
            {
                MessageEvery15Second();
                timer = 0;
            }
        }

        private void lblNumberOfRoom_Click(object sender, EventArgs e)
        {

        }

        private void ComboNumberOfRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblNumberOfRoom.Text = ComboNumberOfRoom.SelectedItem.ToString();
            FillLabelsPanel();
        }
    }
}
