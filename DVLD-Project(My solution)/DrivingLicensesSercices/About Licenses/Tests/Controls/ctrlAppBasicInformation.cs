using clsBusinessTier;
using MyLibrary;
using System;

using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class ctrlAppBasicInformation : UserControl
    {

        public void Label_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.Label_MouseEnter(sender, e);
        }

        public void Label_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.Label_MouseLeave(sender, e);
        }


        public event Action OnPersonInfo;
        protected virtual void PersonInfo()
        {
            if (OnPersonInfo != null)
                OnPersonInfo();
        }


        public ctrlAppBasicInformation()
        {
            InitializeComponent();
            
          
        }

      public  void LoadData(clsBusinessApplications CurrentApp)
        {
            lblID.Text = CurrentApp.AppID.ToString();
            lblStatus.Text = clsBusinessStatus.Find(CurrentApp.AppStatus).Name;
            lblFees.Text = CurrentApp.PaidFees.ToString();
            lblType.Text = clsBusinessApplicationTypes.Find(CurrentApp.AppTypeID).ApplicationTypeTitle;
            clsBusinessPeople Person = clsBusinessPeople.Find(CurrentApp.PersonID);
            lblApplicant.Text = Person.FirstName + " " + Person.SecondName + " " + Person.ThirdName + " " + Person.LastName;
            lblDate.Text = CurrentApp.AppDate.ToString("dd/MMM/yyyy");
            lblStatusDate.Text = CurrentApp.LastStatusDate.ToString("dd/MMM/yyyy");
            lblCreatedBy.Text = clsBusinessUsers.Find(CurrentApp.UserID).Username;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void llblPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (OnPersonInfo != null)
                OnPersonInfo();
        }

        private void ctrlAppBasicInformation_Load(object sender, EventArgs e)
        {

        }
    }
}
