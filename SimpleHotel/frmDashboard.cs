using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleHotel
{
    public partial class frmDashboard : Form
    {
        public static frmDashboard instance;
        public frmDashboard()
        {
            InitializeComponent();
            instance = this;
        }



       
        public static frmRentRoom.stRentInfo UserRent;


        public stBoxesInfo boxesInfo;
        public struct stBoxesInfo
        {
           
           public int NumberOfRent, TotalPrice;
        }


        void SetLabelDateAndTime()
        {
           
              DateTime dateTime = DateTime.Now;
            lblTime.Text = dateTime.Hour.ToString() + " : " + dateTime.Minute + " : " + dateTime.Second;
            lblDay.Text = dateTime.DayOfWeek.ToString();
            lblDateOfDay.Text = dateTime.Date.ToShortDateString();
        }

       public bool IsUserHasRent()
        {
            //Clear RentsUser to new user
            frmRentRoom.RentsUserQ.Clear();
            frmRentRoom.RentsUserQ = new Queue<frmRentRoom.stRentInfo>();
            foreach ( frmRentRoom.stRentInfo info in frmRentRoom.RentInfos)
            {
               
                if (info.Username == frmCreateAccount.CurrentuserInfo.Username && info.Password == frmCreateAccount.CurrentuserInfo.Password)
                {
                    frmRentRoom.RentsUserQ.Enqueue(info);
                    //return info;
                }
            }

            if (frmRentRoom.RentsUserQ.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
          
        }

      
        void FillstBoxesInfo()
        {
            int NumberOfRent = 0, TotalPrice = 0;
            foreach (frmRentRoom.stRentInfo info in frmRentRoom.RentsUserQ)
            {
                NumberOfRent++;
                TotalPrice += info.Price;
            }

            boxesInfo.NumberOfRent = NumberOfRent;
            boxesInfo.TotalPrice = TotalPrice;

            lblTotalPrice.Text = boxesInfo.TotalPrice.ToString() + " $";
            lblNumberOfRents.Text = boxesInfo.NumberOfRent.ToString() + " Rent(s).";

        }

       public void SetLabelaUserInfo(frmCreateAccount.stUserInfo CurrentuserInfo)
        {
           
            lblWelcomeToUser.Text = "Hi, " + CurrentuserInfo.Username + " :-)";
            
            picUser.Image  = Image.FromFile(CurrentuserInfo.PathImageUser);
           // picUser.Image = Image.FromFile(stringImage);
            lblFullNameUser.Text = CurrentuserInfo.FirstName + " Bin " + CurrentuserInfo.LastName;
            lblEmailUser.Text = CurrentuserInfo.Email;

            
        }

       void FillListRentRecord()
        {
            listRentsRecord.Items.Clear();
            foreach (frmRentRoom.stRentInfo info in frmRentRoom.RentsUserQ)
            {
              ListViewItem item = new ListViewItem("Room [ " + info.NumberOfRoom + " ]");
              item.SubItems.Add(info.Date.Start.ToShortDateString());
              item.SubItems.Add(info.Date.End.ToShortDateString());
              item.SubItems.Add(info.NumberOfDays.ToString() + " Day(s).");
              item.SubItems.Add(info.Price.ToString() + " $ ");
              listRentsRecord.Items.Add(item);
            }
        }

        void MouseEnterPanel(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            panel.BackColor = Color.OliveDrab;
        }
        void MouseLeavePanel(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            panel.BackColor = Color.YellowGreen;
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            timer1.Start();
            this.Size = new Size(749, 586);
            SetLabelDateAndTime();
            SetLabelaUserInfo(frmCreateAccount.CurrentuserInfo);

           
                //Two boxes
                if (IsUserHasRent())
                {
                    FillstBoxesInfo();

                    //if (frmRentRoom.RentsUserQ.Count > 0)
                    //    frmRentRoom.RentsUserQ.Clear();
                    //ListViewRents
                    FillListRentRecord();
                }
              
           
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Form form = new frmShowUserInfo();
            form.ShowDialog();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SetLabelDateAndTime();
        }

        private void picShowUserInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
