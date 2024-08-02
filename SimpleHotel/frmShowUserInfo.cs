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
    public partial class frmShowUserInfo : Form
    {
        public static frmShowUserInfo instance;
        public frmShowUserInfo()
        {
            InitializeComponent();
            instance = this;
        }

       void SetPhoto(Label label, PictureBox picture)
        {
            if (label.Text == "Male")
                picture.Image = Image.FromFile(@"C:\Photos\Player.png");
            else
            {
                picture.Image = Image.FromFile(@"C:\Photos\Player2.png");
            }
        }

       public void SetAllUserInformation(frmCreateAccount.stUserInfo CurrentuserInfo)
        {
            //Person Info
            lblNameUser.Text =  CurrentuserInfo.FirstName + " " + CurrentuserInfo.LastName;
            lblGenderUser.Text = CurrentuserInfo.Gender;
            lblEmailUser.Text = CurrentuserInfo.Email;
            lblDateOfBirthUser.Text = CurrentuserInfo.BirthDate;
            lblPhoneUser.Text = CurrentuserInfo.PhoneNumber;
            lblCountryUser.Text = CurrentuserInfo.Country;
            SetPhoto(lblGenderUser, picUser);
            

            //Login Info
            lblUsernameUser.Text = CurrentuserInfo.Username;
            lblPasswordUser.Text = CurrentuserInfo.Password;

            
        }

        void ChangeForeColorLabel(Label lbl, Color color)
        {
            lbl.ForeColor = color;
        }

       

        

        void ChangeForeColorLabels(Color color,bool PersonalInfo)//Personal Info
        {
            if (PersonalInfo)
            {
                ChangeForeColorLabel(lblNameUser, color);
                ChangeForeColorLabel(lblGenderUser, color);
                ChangeForeColorLabel(lblEmailUser, color);
                ChangeForeColorLabel(lblDateOfBirthUser, color);
                ChangeForeColorLabel(lblPhoneUser, color);
                ChangeForeColorLabel(lblCountryUser, color);
               
                picUser.Image = Image.FromFile(frmCreateAccount.CurrentuserInfo.PathImageUser);

            }
            else
            {
                ChangeForeColorLabel(lblUsernameUser, color);
                ChangeForeColorLabel(lblPasswordUser, color);
                
            }
            
        }

        public void WhenButtonEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.ForeColor = Color.Red;
            btn.FlatAppearance.BorderColor = Color.Red;   
        }

        public void WhenButtonLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.ForeColor = Color.Black;
            btn.FlatAppearance.BorderColor = Color.Black;
        }


        private void frmShowUserInfo_Load(object sender, EventArgs e)
        {
           SetAllUserInformation(frmCreateAccount.CurrentuserInfo);
        }

        private void pPersonInformation_MouseEnter(object sender, EventArgs e)
        {
            linklblEditUserInfo.Enabled = true;
            ChangeForeColorLabels(Color.White,true);
         
        }

       

        private void pLoginInformation_MouseEnter(object sender, EventArgs e)
        {
            ChangeForeColorLabels(Color.White, false);
        }

        Form frmEditPersonInfo = new frmEditPersonInfo();
        void ShowfrmEditPersonInfo()
        {
            if (frmEditPersonInfo.IsDisposed)
            {
                frmEditPersonInfo = new frmEditPersonInfo();
                frmEditPersonInfo.ShowDialog();
                return;
            }
            frmEditPersonInfo.ShowDialog();
        }
        private void linklblEditUserInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowfrmEditPersonInfo();
        }

        private void lblTitleForm_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
