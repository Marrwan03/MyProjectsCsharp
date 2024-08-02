using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleHotel
{
    public partial class frmCreateAccount : Form
    {
        public static frmCreateAccount instance;
        public frmCreateAccount()
        {
           
            InitializeComponent();
            instance = this;
        }
        public static stUserInfo CurrentuserInfo;
        public static Queue<stUserInfo> Quserinfo = new Queue<stUserInfo>();
        public static Queue<stUserInfo> UPDATEQuserinfo = new Queue<stUserInfo>();

        public static stUserInfo userInfo;
        public struct stUserInfo
        {
            public string FirstName, LastName , PhoneNumber, Email, Country, Gender, BirthDate,Username, Password, PathImageUser;
            //public Image ImageUser;
        }

       void ValidatingTextBoxForUserAndPass(object sender, CancelEventArgs e)
        {
            frmSignup.Instance.ValidatingTextBox(sender, e);
        }


        

        private void frmCreateAccount_Load(object sender, EventArgs e)
        {
           
        }

        bool IsUserReady()
        {
            if(MessageBox.Show("Are you sure,This data is correct?","Login!",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if(!IsDataFull() || !IsDataLengthCorrect() || picUser.Tag.ToString() == "?"  )
                {
                    if(MessageBox.Show("Wrong save, fill all data And add picture", "Wrong!", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                    {
                        return false;
                    }
                }
                else
                { return true; }
               
                
            }
            return false;
        }

        stUserInfo FillstUserInfo()
        {
            stUserInfo userInfo2 = new stUserInfo();
            userInfo2.FirstName = txtFirstName.Text;
            userInfo2.LastName = txtLastName.Text;
            userInfo2.PhoneNumber = txtPhoneNumber.Text;
            userInfo2.Email = masktxtEmail.Text;
            userInfo2.Country = txtCountry.Text;
            userInfo2.Gender = cbGender.Text;
            userInfo2.BirthDate = masktxtBirthDate.Text;
            userInfo2.Username = txtUsername.Text;
            userInfo2.Password = txtPassword.Text;
            userInfo2.PathImageUser = saveFileDialog1.FileName;
            return userInfo2;
        }

       

       
      
       public void ValidatingMaskTextboxEmailAndBirthDate(object sender, CancelEventArgs e)
        {
            MaskedTextBox txt = (MaskedTextBox)sender;
           
            if (!txt.MaskFull)
            {
                e.Cancel = true;
                txt.Focus();
                errorProvider1.SetError(txt, "You must Fill this box");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txt, "");
            }
        }

       public void ValidatingTextPhone(object sender, CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;

            if (txt.Text.Length < 10)
            {
                e.Cancel = true;
                txt.Focus();
                errorProvider1.SetError(txt, "You must full this box [10] Numbers");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txt, "");
            }
        }

       public void ValidatingComboboxGender(object sender, CancelEventArgs e)
        {
            ComboBox txt = (ComboBox)sender;

            if (txt.Text.Length < 1)
            {
                e.Cancel = true;
                txt.Focus();
                errorProvider1.SetError(txt, "You must Choice from this comboBox");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txt, "");
            }
        }

        public void EmptyTextBox()
        {
            txtUsername.Text = default;
            txtPassword.Text = default;
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(frmSignup.Instance.FindUser(txtUsername.Text,txtPassword.Text,true) )
            {
                if (MessageBox.Show("The UserName OR Password already exist.\n\n\nPlease enter another one", "Account is already exist",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    EmptyTextBox();
                }
                return;
            }

            if(IsUserReady())
            {
                Quserinfo.Enqueue(FillstUserInfo());
                this.Close();
            }
        }


        public bool IsDataFull()
        {
            return !string.IsNullOrEmpty(txtFirstName.Text) && !string.IsNullOrEmpty(txtLastName.Text) && !string.IsNullOrEmpty(txtPhoneNumber.Text)
                && !string.IsNullOrEmpty(txtCountry.Text) && !string.IsNullOrEmpty(txtUsername.Text) && !string.IsNullOrEmpty(txtPassword.Text) && masktxtBirthDate.MaskFull
                && masktxtEmail.MaskFull;
               
        }

       public bool IsDataLengthCorrect()
        {
            return (txtFirstName.Text.Length > 4) && (txtLastName.Text.Length > 4)
                && (txtUsername.Text.Length > 4) && (txtPassword.Text.Length > 4);
        }

       public Point GetRandomePoint(int x1, int y1,int x2, int y2)
        {
            Random Randome = new Random();
            Point point = new Point();
            short x, y;
            x = (short)(Randome.Next(x1, x2));
            y = (short)(Randome.Next(y1, y2));
            point = new Point(x, y);
            return point;
        }

        void WhenMouseEnterbtnSave()
        {
            if(IsDataFull())
            {
                if(IsDataLengthCorrect())
                {
                    btnLogin.BackColor = Color.Green;
                }
                else
                {
                    btnLogin.BackColor = Color.Red;
                    btnLogin.Location = GetRandomePoint(3, 3,300,65);
                }
            }
            else
            {
                btnLogin.BackColor = Color.Red;
                btnLogin.Location = GetRandomePoint(3, 3, 300, 65);
            }
        }

        void ChangeSizePicture(bool LargeSize)
        {
           if(LargeSize)
            {
                picUserLarge.Visible = true;
            }
           else
            {
                picUserLarge.Visible = false;
            }

        }
       

        public void txtFirstNameAndLast_Validating(object sender, CancelEventArgs e)
        {
            frmSignup.Instance.ValidatingTextBox(sender, e,4);
        }

        private void txtPhoneNumber_Validating(object sender, CancelEventArgs e)
        {
            ValidatingTextPhone(sender,e);
        }

        private void masktxtEmail_Validating(object sender, CancelEventArgs e)
        {
            frmSignup.Instance.ValidatingTextBox(sender, e, 5);
        }

        private void txtCountry_Validating(object sender, CancelEventArgs e)
        {
            frmSignup.Instance.ValidatingTextBox(sender, e, 1);
        }

        private void cbGender_Validating(object sender, CancelEventArgs e)
        {
            ValidatingComboboxGender(sender,e);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            //if(CheckPasswordLength(txtPassword.Text) )
            //    btnLogin.Enabled = true;
            //else
            //    btnLogin.Enabled = false;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            WhenMouseEnterbtnSave();
        }

        private void masktxtEmail_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = "png";
            saveFileDialog1.Filter = "png files (*.png)|*.png";


            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picUser.Tag = "!";

               // By  saveFileDialog1.FileName

                picUser.Image = Image.FromFile(saveFileDialog1.FileName);
                picUserLarge.Image = Image.FromFile(saveFileDialog1.FileName);
                userInfo.PathImageUser = saveFileDialog1.FileName;
            }
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void picUser_Click(object sender, EventArgs e)
        {
            ChangeSizePicture(true);
        }

        private void picUserLarge_Click(object sender, EventArgs e)
        {
            ChangeSizePicture(false);
        }
    }
}
