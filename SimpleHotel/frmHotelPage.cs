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
    public partial class frmHotelPage : Form
    {
        public static frmHotelPage instance;
        public frmHotelPage()
        {
            InitializeComponent();
            instance = this;
        }



        private void frmHotelPage_Load(object sender, EventArgs e)
        {
           
        }



        frmDashboard frmDashboard = new frmDashboard();
        frmUsers frmUsers = new frmUsers();
        frmRentRoom frmRentRoom = new frmRentRoom();
       
        
        frmCreateAccount frmCreateAccount = new frmCreateAccount();
       
        void ShowfrmRentRoom()
        {
            if (frmRentRoom.IsDisposed)
            {
                frmRentRoom = new frmRentRoom();
                frmRentRoom.MdiParent = this;
                frmRentRoom.Show();
                return;
            }
            frmRentRoom.Show();
        }
        void ShowUsers()
        {

            if (frmUsers.IsDisposed)
            {
                frmUsers = new frmUsers();
                frmUsers.MdiParent = this;
                frmUsers.Show();
                return;
            }
            frmUsers.Show();
        }
        void ShowfrmHotelPage()
        {
           
            if (frmDashboard.IsDisposed)
             {
                frmDashboard = new frmDashboard();
                frmDashboard.MdiParent = this;
                frmDashboard.Show();
                return;
            }
            frmDashboard.Show();
        }

        bool IsSureToLogOut()
        {
            if(MessageBox.Show("Are you sure, Do you wanna to LogOut? ", "LogOut!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }


        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picWelcomeHotel.Visible = false;
            frmUsers.Close();
            frmRentRoom.Close();
            frmDashboard.MdiParent = this;
            ShowfrmHotelPage();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picWelcomeHotel.Visible = false;
            frmDashboard.Close();
            frmRentRoom.Close();
            frmUsers.MdiParent = this;
            ShowUsers();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(IsSureToLogOut())
            {
                frmUsers.Close();
                frmRentRoom.Close();
                frmDashboard.Close();
                
                frmCreateAccount.Close();

                this.Close();
                frmSignup.Instance.Show();
              //  frmSignup.Show();
            }

           
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            picWelcomeHotel.Visible = false;
            frmUsers.Close();
            frmDashboard.Close();
            frmRentRoom.MdiParent = this;
            ShowfrmRentRoom();
        }
    }
}
