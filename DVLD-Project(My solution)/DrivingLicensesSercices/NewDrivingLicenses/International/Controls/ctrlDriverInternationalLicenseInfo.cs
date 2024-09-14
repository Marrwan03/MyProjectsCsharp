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
    public partial class ctrlDriverInternationalLicenseInfo : UserControl
    {

        public  void Label_MouseEnter(object sender, EventArgs e)
        {
          clsColorControl.Label_MouseEnter(sender, e);
        }

        public  void Label_MouseLeave(object sender, EventArgs e)
        {
           clsColorControl.Label_MouseLeave(sender, e);
        }

        public ctrlDriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        clsBusinessPeople _clsPerson;
       // clsBusinessApplications _clsApplication;
        clsBusinessInternationalLicense _clsInternationalLicense;
        int _InternationalLicenseID;


        void _identificationClasses()
        {
            _clsInternationalLicense = clsBusinessInternationalLicense.Find2(_InternationalLicenseID);
            _clsPerson = clsBusinessPeople.Find(clsBusinessApplications.Find(_clsInternationalLicense.ApplicationID).PersonID);

        }
       
        public void LoadDriverInternationalLicenseInfo(int InternationalLicenseID)
        {
            _InternationalLicenseID=InternationalLicenseID;
            _identificationClasses();

            lblName.Text = _clsPerson.FirstName + ' ' + _clsPerson.SecondName + ' ' + _clsPerson.ThirdName + ' ' + _clsPerson.LastName;
            lblIntLicenseID.Text = _clsInternationalLicense.InternationalLicenseID.ToString();
            lblLicenseID.Text = _clsInternationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblNationalNo.Text = _clsPerson.NationalNo;
            if(_clsPerson.Gendor == 0)
            {
                lblGendor.Text = "Male";
            }
            else
            {
                lblGendor.Text = "Female";
            }
            lblIssueDate.Text = _clsInternationalLicense.IssueDate.ToString("dd/MMM/yyyy");
            lblAppID.Text = _clsInternationalLicense.ApplicationID.ToString();
            if(_clsInternationalLicense.IsActive)
            {
                lblIsActive.Text = "Yes";
            }
            else
            {
                lblIsActive.Text = "No";
            }
            lblDateOfBirth.Text = _clsPerson.DateOfBirth.ToString("dd/MMM/yyyy");
            lblDriverID.Text = _clsInternationalLicense.DriverID.ToString();
            lblExperationDate.Text = _clsInternationalLicense.ExpirationDate.ToString("dd/MMM/yyyy");
            if(_clsPerson.ImagePath != null )
            {
                picDriver.Image = Image.FromFile(_clsPerson.ImagePath);
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void picDriver_Click(object sender, EventArgs e)
        {

        }
    }
}
