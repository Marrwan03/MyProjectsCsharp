using BusinesseTier;
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

//using static System.Net.Mime.MediaTypeNames;

namespace Massenger
{
    public partial class frmAddUpdateNewPerson : Form
    {
        void _FillcbCountries()
        {
          
            DataTable dt = clsBusniesCountries.GetAllCountries();
            foreach (DataRow row in dt.Rows)
            {
                cbCountries.Items.Add(row["Name"]);
            }
        }
        enum enMode
        {
            Add,
            Update
        }
        enMode mode;
        int _PersonID;
        clsBusniesePerson _person;

        public frmAddUpdateNewPerson(int ID)
        {
            InitializeComponent();
            _PersonID = ID;
            if(_PersonID == -1)
            {
                mode = enMode.Add;
            }
            else
            {
                mode = enMode.Update;
            }
        }

        void _LoadData()
        {
          _FillcbCountries();
          if(mode == enMode.Add)
            {
                lblTitle.Text = "Add New Person";
                _person = new clsBusniesePerson();
                return;
            }

            _person = clsBusniesePerson.Find(_PersonID);
            if(_person == null)
            {
                MessageBox.Show("This Person is not here now");
                return;
            }
            lblID.Text = _PersonID.ToString();
            lblTitle.Text = $"Update Person {_person.ID}.";
            txtFirstName.Text = _person.FirstName;
            txtLastName.Text = _person.LastName;
            if(_person.Gender == "M")
            {
                rbMale.Checked = true;
            }
            else
            {
                rbFemale.Checked = true;
            }
            picPerson.Load(_person.ImagePath);
            maskPhone.Text = _person.phone;
            
            cbCountries.SelectedIndex = cbCountries.FindString(clsBusniesCountries.Find(_person.CountryID).CountryName );
            dtpDateOfBirth.Value = _person.DateOfBirth;
           
           
        }

        bool _IsDataFull()
        {
            return (txtFirstName.Text.Length >= 4) && (txtLastName.Text.Length >= 4) && (rbMale.Checked || rbFemale.Checked) && maskPhone.MaskFull && (cbCountries.SelectedItem != null) && dtpDateOfBirth.Text != DateTime.Now.ToLongDateString();
        }

        private void Name_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if(txt.Text.Length <= 4)
            {
                e.Cancel = true;
                errorProvider1.SetError(txt, "You Must Set Upper than 4 letters");
                txt.Focus();
                txt.ForeColor = Color.Red;
            }
            else
            {
                e.Cancel = false;
                txt.ForeColor = Color.Black;
                errorProvider1.SetError(txt, "");
            }

        }

        private void radio_Validating(object sender, CancelEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if(!rb.Checked)
            {
                e.Cancel = true;
                rb.Focus();
                errorProvider1.SetError(rb, "");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(rb, "");
            }


        }


        private void mask_Validating(object sender, CancelEventArgs e)
        {
            MaskedTextBox mask = (MaskedTextBox)sender;
            if(!mask.MaskFull)
            {
                e.Cancel = true;
                mask.Focus();
                mask.ForeColor = Color.Red;
                errorProvider1.SetError(mask, "Fill All The Spaces");

            }
            else
            {
                e.Cancel = false;
               
                mask.ForeColor = Color.Black;
                errorProvider1.SetError(mask, "");
            }


        }

        private void ComboBox_Validating(object sender, CancelEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if(cb.SelectedItem == null)
            {
                e.Cancel= true;
                cb.Focus();
                errorProvider1.SetError(cb, "Choice From ComboBox");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cb, "");
            }


        }

        bool _CheckButtonSave()
        {
            if (_IsDataFull())
            {

                btnSave.ForeColor = Color.Green;
              
                return true;
            }
            else
            {
                MessageBox.Show("You Must Fill All Data", "Fill Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.ForeColor = Color.Red;
            
                return false;
            }
        }


        void _Save()//CheckPathImage
        {
            //if(string.IsNullOrEmpty(saveFileDialog1.FileName))
            //{
            //    MessageBox.Show("You must enter your photo,\n Please enter your photo", "Your Photo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if(clsBusniesePerson.IsPhoneExists(_PersonID,maskPhone.Text))
            {
                MessageBox.Show("Number Phone is already here,\n Please enter another Number phone", "Number Phone!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (clsBusniesePerson.IsFirstNameExists(_PersonID, txtFirstName.Text))
            {
                MessageBox.Show("First Name is already here,\n Please enter another First Name", "First Name!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!_CheckButtonSave())
            {
                return;
            }
            
            _person.FirstName = txtFirstName.Text;
            _person.LastName = txtLastName.Text;
            if(rbMale.Checked)
            {
                _person.Gender = "M";
            }
            else
            {
                _person.Gender = "F";
            }
            _person.phone = maskPhone.Text;
            _person.CountryID = clsBusniesCountries.Find(cbCountries.SelectedItem.ToString()).ID;
            _person.DateOfBirth = dtpDateOfBirth.Value;
           if(picPerson.ImageLocation == "")
            {
                _person.ImagePath = "";
            }
           else
            {
                _person.ImagePath = picPerson.ImageLocation;
            }
           
            if (_person.Save())
            {
                MessageBox.Show("person saved successed");
            }
            else
            {
                MessageBox.Show("Faild Saved");
                return;
            }
            lblID.Text = _person.ID.ToString();
            lblTitle.Text = $"Update Person {_person.ID}.";

        }

        private void frmAddNewPerson_Load(object sender, EventArgs e)
        {
            clsForm.SetForm(this, 914, 465);
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maskPhone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSetImage_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = "png";
            saveFileDialog1.Filter = "png files (*.png)|*.png";

            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picPerson.Load(saveFileDialog1.FileName);
            }


        }

        private void picPerson_Click(object sender, EventArgs e)
        {
            if(picPerson.Tag == "?")
            {
                picPerson.Tag = "!";
                picPerson.Location = new Point(614, 132);
                picPerson.Size = new Size(169, 130);

            }
            else
            {
                picPerson.Tag = "?";
                picPerson.Location = new Point(622, 141);
                picPerson.Size = new Size(143, 115);
            }
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            picPerson.Load("C:\\Photos\\MenIcon.png");

        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
           
            picPerson.Load("C:\\Photos\\WomanIcon.png");
           

        }
    }
}
