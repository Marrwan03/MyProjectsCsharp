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
    public partial class ctrlDriverLicenseInformation : UserControl
    {
        public ctrlDriverLicenseInformation()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void Label_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.Label_MouseEnter(sender, e);
        }
        public void Label_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.Label_MouseLeave(sender, e);
        }
        clsBusinessApplications _clsApp;
        clsBusinessLicenses _clsBusinessLicenses;
        clsBusinessPeople _clsPerson;
        public void LoadDriverLicenseInfo(int AppID)
        {
            _clsApp = clsBusinessApplications.Find(AppID);
            _clsPerson = clsBusinessPeople.Find(_clsApp.PersonID);
            _clsBusinessLicenses = clsBusinessLicenses.Find(_clsApp.AppID);
            if (_clsBusinessLicenses != null)
            {
                lblClass.Text = clsBusinessLicenseClasses.Find(_clsBusinessLicenses.LicenseClass).ClassName;
                lblLicenseID.Text = _clsBusinessLicenses.LicenseID.ToString();
                lblIssueDate.Text = _clsBusinessLicenses.IssueDate.ToString("dd/MMM/yyyy");
                lblIssueReason.Text = clsBusinessApplicationTypes.Find(_clsBusinessLicenses.IssueReason).ApplicationTypeTitle;
                if (string.IsNullOrEmpty(_clsBusinessLicenses.Notes))
                {
                    lblNotes.Text = "No Notes";
                }
                else
                {
                    lblNotes.Text = _clsBusinessLicenses.Notes;
                }

                if (_clsBusinessLicenses.IsActive)
                {
                    lblIsActive.Text = "Yes";
                }
                else
                {
                    lblIsActive.Text = "No";
                }

                lblDriverID.Text = _clsBusinessLicenses.DriverID.ToString();
                lblExpDate.Text = _clsBusinessLicenses.ExpirationDate.ToString("dd/MMM/yyyy");
                if (clsBusinessDetainedLicenses.IsExists(_clsBusinessLicenses.LicenseID))
                {
                    lblIsDetained.Text = "Yes";
                }
                else
                {
                    lblIsDetained.Text = "No";
                }

            }



            lblName.Text = _clsPerson.FirstName + ' ' + _clsPerson.SecondName + ' ' + _clsPerson.ThirdName + ' ' + _clsPerson.LastName;

            lblNationalNo.Text = _clsPerson.NationalNo;
            if (_clsPerson.Gendor == 0)
            {
                lblGendor.Text = "Male";
            }
            else
            {
                lblGendor.Text = "Female";
            }


            lblDateOfBirth.Text = _clsPerson.DateOfBirth.ToString("dd/MMM/yyyy");

            if (_clsPerson.ImagePath != null)
            {
                picDriver.Image = Image.FromFile(_clsPerson.ImagePath);
            }

        }
        public void DefultLoadDriverLicenseInfo()
        {
            string defult = "[ ??? ]";
            lblClass.Text = defult;
            lblName.Text = defult;
            lblLicenseID.Text = defult;
            lblNationalNo.Text = defult;
            lblGendor.Text = defult;
            lblIssueDate.Text = defult;
            lblIssueReason.Text = defult;
            lblNotes.Text = defult;
            lblIsActive.Text = defult;
            lblDateOfBirth.Text = defult;
            lblDriverID.Text = defult;
            lblExpDate.Text = defult;
            lblIsDetained.Text = defult;
            picDriver.Image = Image.FromFile(@"C:\Users\lenovo\OneDrive\Desktop\BlackICON\QuestionMark.png");
        }
    }
}
