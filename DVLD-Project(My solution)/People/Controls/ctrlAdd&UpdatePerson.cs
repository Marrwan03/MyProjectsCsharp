using clsBusinessTier;
using System;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Windows.Forms;
using MyLibrary;

namespace DVLD_Project
{
    public partial class ctrlAdd_UpdatePerson : UserControl
    {
        public bool CompleteSave = false;
        public event Action<clsBusinessPeople> OnSave;
        protected virtual void Save(clsBusinessPeople obj)
        {
            if(OnSave != null) OnSave(obj);

        }


        public event Action OnClose;
        protected virtual void Close()
        {
            if (OnClose != null) OnClose();

        }

        void _FillCbCountries()
        {
            DataTable dt = clsBusinessCountries.GetAllCountries();
            foreach(DataRow row in dt.Rows)
            {
                cbCountries.Items.Add(row["CountryName"]);
            }
        }

       
        
        public ctrlAdd_UpdatePerson()
        {
            InitializeComponent();
            _FillCbCountries();
           

            if(_PersonId == -1)
            {
                llblRemove.Visible = false;
            }

            dtDateOfBirth.MaxDate = clsDate.GetMaxDate();
            dtDateOfBirth.Value = dtDateOfBirth.MaxDate;
            cbCountries.SelectedIndex = 149;
        }

        clsBusinessPeople _Person;
        int _PersonId = 0;
        public void LoadData(int PersonID)
        {
           _PersonId=PersonID;
            if(_PersonId == -1) 
            {
                llblRemove.Visible = false;
                _Person = new clsBusinessPeople();
                return;
            }

           _Person = clsBusinessPeople.Find(PersonID);
            if (_Person != null)
            {
                llblRemove.Visible = true;
                txtFirstName.Text = _Person.FirstName;
                txtSecondName.Text = _Person.SecondName;
                txtThirdName.Text = _Person.ThirdName;
                txtLastName.Text = _Person.LastName;
                txtNationalNo.Text = _Person.NationalNo;
                if (_Person.Gendor == 0)
                {
                    rbMale.Checked = true;
                  
                }
                else
                {
                    
                    rbFemale.Checked = true;
                }
                if(!string.IsNullOrEmpty(_Person.Email))
                {
                    txtEmail.Text = _Person.Email;
                }
               
                txtAddress.Text = _Person.Address;
                dtDateOfBirth.Value = _Person.DateOfBirth;
                txtPhone.Text = _Person.Phone;
               
                cbCountries.SelectedIndex = cbCountries.FindString(clsBusinessCountries.Find(_Person.NationalityCountryID).Name);
                if (!string.IsNullOrEmpty(_Person.ImagePath))
                {
                    picPerson.Load(_Person.ImagePath);
                   
                }
                
            }



        }

        private void ctrlAdd_UpdatePerson_Load(object sender, EventArgs e)
        {
            //LoadData(_PersonId);
        }

       
        int _IndexPoint = 0;
        int _IndexHashtag = 0;
        int _GetIndexHashtag(string Email)
        {
            int Count = 0;
            int Index = 0;
            for(int i = 0; i < Email.Length; i++)
            {
                if (Email[i] == '@')
                {
                    Index = i;
                    Count++;
                }
            }

            if(Count == 1)
                return Index;
            else
                return 0;
        }

        int _GetFullStopIndex(string Email)
        {
            int Index = 0;
            for (int i = 0; i < Email.Length; i++)
            {
                if (Email[i] == '.')
                    Index = i;
            }
            return Index;
        }

        bool _CheckLastPartInEmail(string Email)
        {
            int Index = _GetFullStopIndex(Email);
            if(Index == 0) return false;

            int Counter = 0;
            for (int i = Index; i < Email.Length; i++)
            {
                if (Email[i] == '.' || char.ToLower(Email[i]) == 'c' || char.ToLower(Email[i]) == 'o' || char.ToLower(Email[i]) == 'm')
                {
                    Counter++;
                }
            }
            return Counter == 4;
        }

        bool _CheckTitleEmail(string Email)
        {
            _IndexPoint = _GetFullStopIndex(Email);
            _IndexHashtag = _GetIndexHashtag(Email);
            if (++_IndexHashtag == _IndexPoint)
                return false;
            return true;
        }

        bool IsFormatEmailCorrect(string Email)
        {
            return (_GetIndexHashtag(Email) > 0) && _CheckLastPartInEmail(Email) && _CheckTitleEmail(Email);
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtEmail.Text))
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, "");
                return;
            }
            else
            {
                if(IsFormatEmailCorrect(txtEmail.Text))
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtEmail, "");
                }
                else
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
                }
            }
            if(clsBusinessPeople.IsEmailExists(txtEmail.Text, _PersonId))
            {
                e.Cancel = true;
                txtEmail.Focus();
                errorProvider1.SetError(txtEmail, "Email is already here, set another Email!");
            }



        }

        void TextBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtNames = (TextBox)sender;
            if (string.IsNullOrEmpty(txtNames.Text))
            {
                e.Cancel = true;
                txtNames.Focus();
                errorProvider1.SetError(txtNames, "You must set this box!");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNames, "");
            }



        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text))
            {
                e.Cancel = true;
                txtNationalNo.Focus();
                errorProvider1.SetError(txtNationalNo, "Set NationalNo!");
                return;
            }
            if(clsBusinessPeople.IsNationalNoExists(txtNationalNo.Text, _PersonId))
            {
                e.Cancel = true;
                txtNationalNo.Focus();
                errorProvider1.SetError(txtNationalNo, "NationalNo is already here, Set another NationalNo!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNationalNo, "");
            }
        }

        private void llblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picPerson.Load(openFileDialog1.FileName);

                

            }
         
        }

      bool _IsDataFull()
        {
          return  !string.IsNullOrWhiteSpace(txtFirstName.Text) && !string.IsNullOrWhiteSpace(txtSecondName.Text) && !string.IsNullOrWhiteSpace(txtThirdName.Text) && !string.IsNullOrWhiteSpace(txtLastName.Text)
                && !string.IsNullOrWhiteSpace(txtNationalNo.Text) && (rbMale.Checked || rbFemale.Checked) && !string.IsNullOrWhiteSpace(txtAddress.Text) &&( !string.IsNullOrWhiteSpace(txtPhone.Text) && CorrectPhone)
                && (cbCountries.Text.Length > 0);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_IsDataFull())
            {
                _Person.FirstName = txtFirstName.Text.Trim();
                _Person.SecondName = txtSecondName.Text.Trim();
                _Person.ThirdName = txtThirdName.Text.Trim();
                _Person.LastName = txtLastName.Text.Trim();
                _Person.NationalNo = txtNationalNo.Text.Trim();
                if (rbMale.Checked)
                {
                    _Person.Gendor = 0;
                }
                else
                {
                    _Person.Gendor = 1;
                }
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    _Person.Email = string.Empty;
                }
                else
                {
                    _Person.Email = txtEmail.Text.Trim();
                }

                _Person.Address = txtAddress.Text.Trim();
                _Person.DateOfBirth = dtDateOfBirth.Value;
                _Person.Phone = txtPhone.Text.Trim();

                _Person.NationalityCountryID = clsBusinessCountries.Find(cbCountries.Text).ID;

                if (picPerson.ImageLocation != null)
                {
                    _Person.ImagePath = picPerson.ImageLocation;

                }
                else
                {
                    _Person.ImagePath = null;
                }
              
                   CompleteSave = true;
               
            }
            else
            {
                CompleteSave = false;
            }

            if (OnSave != null)
                OnSave(_Person);


        }

    void _SetOriginalPhoto(string Path)
        {
            picPerson.Load(Path);
            if (_Person.ID != -1)
                llblRemove.Visible = true;
        }

    private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            _SetOriginalPhoto(@"C:\Photos\WomanIcon.png");
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            
            _SetOriginalPhoto(@"C:\Photos\MenIcon.png");
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if(OnClose!=null)
                OnClose();
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {
            
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void cbCountries_Validating(object sender, CancelEventArgs e)
        {
            if (cbCountries.Text.Length > 0)
            {
                e.Cancel = false;
                errorProvider1.SetError(cbCountries, "");
               
            }
            else
            {
                e.Cancel = true;
                cbCountries.Focus();
                errorProvider1.SetError(cbCountries, "You must choice you country!");
            }
        }
        bool CorrectPhone = true;

       

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                e.Cancel = true;
                txtPhone.Focus();
                CorrectPhone = false;
                errorProvider1.SetError(txtPhone, "You must set this box!");
                return;
            }

            else if(clsTextProcessing.TextHasLetter(txtPhone.Text))
            {
                e.Cancel = true;
                CorrectPhone = false;
                txtPhone.Focus();
                errorProvider1.SetError(txtPhone, "In Phone You should not use ant latter, \nSet Cottect format NumberPhone");
            }

            else if(clsBusinessPeople.IsPhoneExists(txtPhone.Text, _PersonId))
            {
                e.Cancel = true;
                txtPhone.Focus();
                CorrectPhone = false;
                errorProvider1.SetError(txtPhone, "This Phone already here, set another phone!");
            }
            else
            {
                e.Cancel = false;
                CorrectPhone = true;
                errorProvider1.SetError(txtPhone, "");
            }
        }

        private void llblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            picPerson.ImageLocation = null;
            picPerson.Image = null;
            llblRemove.Visible = false;
        }

        private void cbCountries_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public  void Button_MouseEnter(object sender, EventArgs e)
        {
           clsColorControl.Button_MouseEnter(sender, e);
        }

        public  void Button_MouseLeave(object sender, EventArgs e)
        {
          clsColorControl.Button_MouseLeave(sender, e);
        }
        public  void Label_MouseEnter(object sender, EventArgs e)
        {
           clsColorControl.Label_MouseEnter(sender, e);
        }

        public  void Label_MouseLeave(object sender, EventArgs e)
        {
           clsColorControl.Label_MouseLeave(sender, e);
        }

        public  void TextBox_MouseEnter(object sender, EventArgs e)
        {
           clsColorControl.TextBox_MouseEnter(sender, e);
        }
        public  void TextBox_MouseLeave(object sender, EventArgs e)
        {
           clsColorControl.TextBox_MouseLeave(sender, e);
        }
        public  void RadioButton_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.RadioButton_MouseEnter(sender, e);
        }
        public  void RadioButton_MouseLeave(object sender, EventArgs e)
        {
   clsColorControl.RadioButton_MouseLeave(sender, e);
        }



    }
}
