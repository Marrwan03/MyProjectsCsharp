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
    public partial class ctrlPersonInformtion : UserControl
    {
        public event Action OnLinkUpdate;
        protected virtual void LinkUpdate()
        {
            if (OnLinkUpdate != null)
                OnLinkUpdate();
        }

        public ctrlPersonInformtion()
        {
            InitializeComponent();
        }
        clsBusinessPeople _Person;
        public void LoadctrlPersonInformtion(clsBusinessPeople Person)
        {
            _Person = Person;
            if (_Person != null)
            {
                groupBox1.Text = _Person.FirstName + " Information";
                lblPersonID.Text = _Person.ID.ToString();
                lblName.Text = _Person.FirstName + " " + _Person.SecondName + " " + _Person.ThirdName + " " + _Person.LastName;
                lblNational.Text = _Person.NationalNo;
                if (_Person.Gendor == 0)
                {
                    lblGendor.Text = "Male";
                }
                else
                {
                    lblGendor.Text = "Female";
                }


                if (!string.IsNullOrEmpty(_Person.Email))
                {
                    lblEmail.Text = _Person.Email;
                }

                lblAddress.Text = _Person.Address;
                lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
                lblPhone.Text = _Person.Phone;
                lblCountry.Text = clsBusinessCountries.GetCountryName(_Person.NationalityCountryID);
                if (!string.IsNullOrEmpty(_Person.ImagePath))
                {
                    picPerson.Load(_Person.ImagePath);
                }
                else
                {
                    picPerson.ImageLocation = null;
                    picPerson.Image = null;
                }
            }
            else
            {
                lblPersonID.Text = "[???]";
                lblName.Text = "[???]";
                lblNational.Text = "[???]";
                lblGendor.Text = "[???]";
                lblEmail.Text = "[???]";
                lblAddress.Text = "[???]";
                lblDateOfBirth.Text = "[???]";
                lblPhone.Text = "[???]";
                lblCountry.Text = "[???]";
                picPerson.ImageLocation = null;
                picPerson.Image = null;
            }

        }

       

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (OnLinkUpdate != null)
                OnLinkUpdate();

          
        }

        public void Label_MouseEnter(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.White;
        }

        public void Label_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.Black;
        }

       
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
