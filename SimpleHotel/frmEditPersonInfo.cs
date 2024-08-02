using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SimpleHotel.frmCreateAccount;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SimpleHotel
{
    public partial class frmEditPersonInfo : Form
    {
        public frmEditPersonInfo()
        {
            InitializeComponent();
        }

   

        private void btnNumberPhone_Click(object sender, EventArgs e)
        {

        }

       

        void WhenButtonEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Visible = false;
         
        }


     
        void SetAlltextbox()
        {

            txtFirstName.Text = frmCreateAccount.CurrentuserInfo.FirstName;
            txtLastName.Text = frmCreateAccount.CurrentuserInfo.LastName;
            txtPhoneNumber.Text = frmCreateAccount.CurrentuserInfo.PhoneNumber;
            txtCountry.Text = frmCreateAccount.CurrentuserInfo.Country;
            masktxtEmail.Text = frmCreateAccount.CurrentuserInfo.Email;
            cbGender.Text = frmCreateAccount.CurrentuserInfo.Gender;
            masktxtBirthDate.Text = frmCreateAccount.CurrentuserInfo.BirthDate;
            txtUsername.Text = frmCreateAccount.CurrentuserInfo.Username;
            txtPassword.Text = frmCreateAccount.CurrentuserInfo.Password;
            picUser.Image = Image.FromFile(frmCreateAccount.CurrentuserInfo.PathImageUser);
           
        }

      public frmCreateAccount.stUserInfo SaveAlltextboxToStruct( )
        {
            frmCreateAccount.stUserInfo CurrentuserInfo;
            CurrentuserInfo.FirstName   = txtFirstName.Text;
            CurrentuserInfo.LastName    = txtLastName.Text;
            CurrentuserInfo.PhoneNumber = txtPhoneNumber.Text;
            CurrentuserInfo.Country     = txtCountry.Text;
            CurrentuserInfo.Email       = masktxtEmail.Text;
            CurrentuserInfo.Gender      = cbGender.Text;
            CurrentuserInfo.BirthDate   = masktxtBirthDate.Text;
            CurrentuserInfo.Username    = txtUsername.Text;
            CurrentuserInfo.Password    = txtPassword.Text;
            CurrentuserInfo.PathImageUser = saveFileDialog2.FileName;
            // CurrentuserInfo.UpdateInfo  = false;

            return CurrentuserInfo;
        }

        void CopyQueueData()
        {
            foreach (frmCreateAccount.stUserInfo info in frmCreateAccount.UPDATEQuserinfo)
            {
                frmCreateAccount.Quserinfo.Enqueue(info);
            }
        }

        void UpdateQueue()
        {
            frmCreateAccount.UPDATEQuserinfo.Clear();

            foreach (frmCreateAccount.stUserInfo info in frmCreateAccount.Quserinfo)
            {
                if(info.Username == frmCreateAccount.CurrentuserInfo.Username && info.Password == frmCreateAccount.CurrentuserInfo.Password)
                {
                   
                    frmCreateAccount.UPDATEQuserinfo.Enqueue(SaveAlltextboxToStruct());
                    frmCreateAccount.CurrentuserInfo = SaveAlltextboxToStruct();

                }
                else
                {
                    frmCreateAccount.UPDATEQuserinfo.Enqueue(info);
                }
            }

            frmCreateAccount.Quserinfo.Clear();
         CopyQueueData();
        }

        void UpdateDataForms()
        {
            frmDashboard.instance.SetLabelaUserInfo(frmCreateAccount.CurrentuserInfo);
            frmShowUserInfo.instance.SetAllUserInformation(frmCreateAccount.CurrentuserInfo);
        }

        bool IsUserReady()
        {
            if (MessageBox.Show("Are you sure,This data is correct?", "Login!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
               return true;
            }
            return false;
        }

      

        bool CheckTextboxbool(TextBox textBox, int MaxLength)
        {
            return textBox.Text.Length >= MaxLength;
        }
        bool CheckMaskboxbool(object sender, MaskInputRejectedEventArgs e)
        {
            MaskedTextBox maskedTextBox = (MaskedTextBox)sender;
            return maskedTextBox.MaskFull;
        }


        bool IsFullData()
        {
            return CheckTextboxbool(txtFirstName, 5) && CheckTextboxbool(txtLastName,5) && CheckTextboxbool(txtPassword,5) &&
                CheckTextboxbool(txtUsername, 5) && CheckTextboxbool(txtCountry, 5)  && CheckTextboxbool(txtPhoneNumber, 10) &&
                masktxtEmail.MaskFull && masktxtBirthDate.MaskFull;
        }

        void CheckTextBox(object sender, EventArgs e)
        {
            //int maxLength = 5;
            //TextBox textBox = (TextBox)sender;

            //if(textBox.Text.Length >= 10)
            //    maxLength = 10;

            if(IsFullData() )
            {
                btnSaveData.Enabled = true;
            }
            else
            {
                btnSaveData.Enabled = false;
            }
        }

        void EnterWrongMainData( Button btn, TextBox txt)
        {
            //if (Data1)
            //{
            //    txt.BackColor = Color.White;
            //    if (Data2)
            //        btn.Enabled = true;
            //    else
            //        btn.Enabled = false;
            //}
           
                txt.BackColor = Color.Red;
                btn.Enabled = false;
        
        }


        void CheckTextBoxLoginData(object sender)
        {
            TextBox text = (TextBox) sender;

            bool CheckUsername, CheckPassword;
            CheckUsername = IsDataCorrectByUsername();
            CheckPassword = IsDataCorrectByPassword();

            if (IsFullData())
            {
                if(!CheckUsername)
                {
                    EnterWrongMainData(btnSaveData, txtUsername);
                }
                else 
                {
                    txtUsername.BackColor = Color.White;

                    if(CheckPassword)
                        btnSaveData.Enabled= true;
                    else
                        btnSaveData.Enabled = false;

                }

                if(!CheckPassword)
                {
                    EnterWrongMainData(btnSaveData, txtPassword);
                }
                else if(CheckPassword)
                {
                    txtPassword.BackColor = Color.White;

                    if (CheckUsername)
                        btnSaveData.Enabled = true;
                    else
                        btnSaveData.Enabled = false;
                }

            }
            else
            {
                btnSaveData.Enabled = false;
            }
        }

        void CheckMaskBox(object sender, MaskInputRejectedEventArgs e)
        {
            if (IsFullData())
            {
                btnSaveData.Enabled = true;
            }
            else
            {
                btnSaveData.Enabled = false;
            }
        }

        bool IsWantChangePhoto()
        {
            if(MessageBox.Show("Are you sure do you Change Your Photo ? ", "Change Photo! ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }


        private void frmEditPersonInfo_Load(object sender, EventArgs e)
        {
            SetAlltextbox();
           
        }

        private void txtFirstNameAndLast_Validating(object sender, CancelEventArgs e)
        {
            frmSignup.Instance.ValidatingTextBox(sender, e, 4);
        }
        void ValidatingMaskTextboxEmailAndBirthDate(object sender, CancelEventArgs e)
        {
            frmCreateAccount.instance.ValidatingMaskTextboxEmailAndBirthDate(sender, e);
        }



        private void txtPhoneNumber_Validating(object sender, CancelEventArgs e)
        {
            frmCreateAccount.instance.ValidatingTextPhone(sender, e);
        }

        private void masktxtEmail_Validating(object sender, CancelEventArgs e)
        {
            frmCreateAccount.instance.ValidatingMaskTextboxEmailAndBirthDate(sender, e);
        }

     

        private void txtCountry_Validating(object sender, CancelEventArgs e)
        {
            frmSignup.Instance.ValidatingTextBox(sender, e, 1);
        }

        private void cbGender_Validating(object sender, CancelEventArgs e)
        {
            frmCreateAccount.instance.ValidatingComboboxGender(sender, e);
        }

       bool IsDataCorrectByUsername() //Username && Password
        {
            if (frmCreateAccount.CurrentuserInfo.Username.ToLower() == txtUsername.Text.ToLower())
            {
                return true;
            }
            
            foreach (frmCreateAccount.stUserInfo userInfo in frmCreateAccount.Quserinfo)
            {
                if (userInfo.Username.ToLower() == txtUsername.Text.ToLower())
                {
                    return false;
                }
            }
            return true;
        }

        bool IsDataCorrectByPassword() //Username && Password
        {
            if (frmCreateAccount.CurrentuserInfo.Password.ToLower() == txtPassword.Text.ToLower())
            {
                return true;
            }
               

            foreach (frmCreateAccount.stUserInfo userInfo in frmCreateAccount.Quserinfo)
            {
                if (userInfo.Password.ToLower() == txtPassword.Text.ToLower())
                {
                    return false;
                }
            }
            return true;
        }

        void SetAnotherData()
        {
            if (MessageBox.Show("This (Username OR Password) is find, Please enter another (Username OR Password)", "Wrong Data!", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
            {
                txtUsername.Text = default;
                txtPassword.Text = default;
            }
            else
            {
                txtUsername.Text = default;
                txtPassword.Text = default;
            }

        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
         
            if (IsUserReady())
            {
                    if(picUser.Tag == "?")
                    {
                        saveFileDialog2.FileName = frmCreateAccount.instance.saveFileDialog1.FileName;
                    }

                    UpdateQueue();
                    UpdateDataForms();
                    this.Close();
                }
                else
                {
                    SetAnotherData();
                }
                
            }
        

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFirstName_TextChanged_1(object sender, EventArgs e)
        {
          
        }

        private void txtPassword_MouseEnter(object sender, EventArgs e)
        {
            frmSignup.Instance.txtPassword_MouseEnter(sender, e);
        }

        private void txtPassword_MouseLeave(object sender, EventArgs e)
        {
            frmSignup.Instance.txtPassword_MouseLeave(sender, e);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTitleForm_Click(object sender, EventArgs e)
        {

        }

        public bool IsDataFull()
        {
            return !string.IsNullOrEmpty(txtFirstName.Text) && !string.IsNullOrEmpty(txtLastName.Text) && !string.IsNullOrEmpty(txtPhoneNumber.Text)
                && !string.IsNullOrEmpty(txtCountry.Text) && !string.IsNullOrEmpty(txtUsername.Text) && !string.IsNullOrEmpty(txtPassword.Text);
        }

        public bool IsDataLengthCorrect()
        {
            return (txtFirstName.Text.Length > 4) && (txtLastName.Text.Length > 4)
                && (txtUsername.Text.Length > 4) && (txtPassword.Text.Length > 4);
        }

        private void btnPhoto_MouseEnter(object sender, EventArgs e)
        {
            WhenButtonEnter(sender, e);
           

        }

        private void btnChangePhoto_Click(object sender, EventArgs e)
        {
            if (IsWantChangePhoto())
            {
                saveFileDialog2.DefaultExt = "png";
                saveFileDialog2.Filter = "png files (*.png)|*.png";


                if (saveFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    picUser.Tag = "!";
                    picUser.Image = Image.FromFile(saveFileDialog2.FileName);

                    if (IsFullData())
                        btnSaveData.Enabled = true;
                    else
                        btnSaveData.Enabled = false;
                }
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxLoginData(sender);
        }

        private void txtPassword_TextChanged_1(object sender, EventArgs e)
        {
            CheckTextBoxLoginData(sender);
        }
    }
}
