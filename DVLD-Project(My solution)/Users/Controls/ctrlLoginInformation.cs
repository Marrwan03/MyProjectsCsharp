using clsBusinessTier;
using MyLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class ctrlLoginInformation : UserControl
    {
        public ctrlLoginInformation()
        {
            InitializeComponent();
        }

        public void LoadctrlLoginInformation(clsBusinessUsers User)
        {
            lblUserID.Text = User.UserID.ToString();
            lblUserName.Text = User.Username;
            if(User.IsActive)
            {
                lblisActive.Text = "Yes";
            }
            else
            {
                lblisActive.Text = "No";
            }
        }

        public  void Label_MouseEnter(object sender, EventArgs e)
        {
           clsColorControl.Label_MouseEnter(sender, e);
        }

        public  void Label_MouseLeave(object sender, EventArgs e)
        {
           clsColorControl.Label_MouseLeave(sender, e);
        }


        

        private void gbLoginInformation_Enter(object sender, EventArgs e)
        {

        }

        private void ctrlLoginInformation_Load(object sender, EventArgs e)
        {

        }

        private void gbLoginInformation_Enter_1(object sender, EventArgs e)
        {

        }
    }
}
