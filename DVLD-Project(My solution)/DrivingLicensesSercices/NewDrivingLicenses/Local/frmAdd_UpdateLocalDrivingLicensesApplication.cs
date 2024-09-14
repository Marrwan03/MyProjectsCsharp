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
    public partial class frmAdd_UpdateLocalDrivingLicensesApplication : Form
    {
        public void Label_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.Label_MouseEnter(sender, e);
        }

        public void Label_MouseLeave(object sender, EventArgs e)
        {
          clsColorControl.Label_MouseLeave(sender, e);
        }

        public void Button_MouseEnter(object sender, EventArgs e)
        {
           clsColorControl.Button_MouseEnter(sender, e);
        }

        public void Button_MouseLeave(object sender, EventArgs e)
        {
           clsColorControl.Button_MouseLeave(sender, e);
        }



        clsBusinessPeople _clsPerson;
        clsBusinessApplications _clsApplications;
        clsBusinessLocalDrivingLicenseApplications _clsLocalDrivingLicenseApplications;
        clsBusinessLicenseClasses _clsLicenseClasses;
        int _IDLicenseClass;
        int _AppID;
        public frmAdd_UpdateLocalDrivingLicensesApplication(int AppID)
        {
            InitializeComponent();
           _AppID = AppID;
        }

        public void FillcbLicenseClass()
        {
            foreach(DataRow dataRow in clsBusinessLicenseClasses.GetAllData().Rows)
            {
                cbLicenseClass.Items.Add(dataRow[1]);
            }
        }

        void LoadData()
        {
            

            if (_AppID == -1)
            {
                _clsApplications = new clsBusinessApplications();
                lblTitlePage.Text = "New Local Driving License Applications";
                lblAppDate.Text = DateTime.Now.ToShortDateString();
                ctrlPersonInfoWithFilter1.ctrlFilter1.Enabled = true;
              
            }
            else
            {
             lblAppID.Text = _clsApplications.AppID.ToString();
             lblAppDate.Text = _clsApplications.AppDate.ToString();
             cbLicenseClass.SelectedIndex = --clsBusinessLocalDrivingLicenseApplications.Find(_clsApplications.AppID).LicenseClassID;
             
             lblTitlePage.Text = "Update Local Driving License Applications";
             ctrlPersonInfoWithFilter1.ctrlFilter1.Enabled = false;

            }
            lblCreatBy.Text = clsGlobalSettings.CurrentUser.Username;
            lblAppFees.Text = Convert.ToInt32(clsBusinessApplicationTypes.Find(1).ApplicationFees).ToString();
            if(_clsPerson != null)
            {
                TimeSpan spam = DateTime.Now.Subtract(_clsPerson.DateOfBirth);
                DateTime Age = new DateTime(spam.Ticks);
                lblYourAge.Text = Age.Year.ToString();
            }
           
        }
       
       

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_clsPerson == null || _clsApplications == null)
            {
                MessageBox.Show("You Must fill all data,\nOr set this person to user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //CountOfNew                                                 
            int IDLicense1 = (cbLicenseClass.SelectedIndex +1);
            if (clsBusinessLocalDrivingLicenseApplications.CountOfLicenseWith(IDLicense1, _clsPerson.ID) > 0)
            {
                if (MessageBox.Show("This person already has \n [ "+cbLicenseClass.Text+" ].", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    cbLicenseClass.Focus();
                   // LoadData();
                    return;
                }
            }
            
            TimeSpan ts = DateTime.Now.Subtract(_clsPerson.DateOfBirth);
            DateTime Age = new DateTime(ts.Ticks);
            int MinimumAge = clsBusinessLicenseClasses.Find(IDLicense1).MinimumAllowedAge;
            if (Age.Year < MinimumAge)
            {
                if(MessageBox.Show($"This person cannot have this license because,\n\n his age isn`t equal (MinimumAllowedAge),\n\n{Age.Year} (Age) !=  {MinimumAge} (MinimumAllowedAge).", "Wrong Enter", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    return;
                }
            }


            _clsApplications.PersonID = _clsPerson.ID;
            _clsApplications.AppDate = Convert.ToDateTime(lblAppDate.Text.ToString());
            _clsApplications.AppTypeID = 1;
            _clsApplications.AppStatus = 1;
            _clsApplications.LastStatusDate = DateTime.Now;
            _clsApplications.PaidFees = clsBusinessApplicationTypes.Find(_clsApplications.AppTypeID).ApplicationFees;
            _clsApplications.UserID = clsGlobalSettings.CurrentUser.UserID;
            


            if(_clsApplications.Save())
            {
                if(MessageBox.Show("Save is succeeded", "Save Data!", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    lblAppID.Tag = "!";
                    lblAppID.Text= _clsApplications.AppID.ToString();
                    _AppID = _clsApplications.AppID;


                    _clsLocalDrivingLicenseApplications = clsBusinessLocalDrivingLicenseApplications.Find(_AppID);

                    if(_clsLocalDrivingLicenseApplications == null)
                        _clsLocalDrivingLicenseApplications = new clsBusinessLocalDrivingLicenseApplications();

                    _clsLocalDrivingLicenseApplications.AppID = _clsApplications.AppID;
                     _IDLicenseClass = (cbLicenseClass.SelectedIndex+1);
                    _clsLocalDrivingLicenseApplications.LicenseClassID = _IDLicenseClass;

                    if(_clsLocalDrivingLicenseApplications.Save())
                    {
                        
                        LoadData();
                        MessageBox.Show("Save in LocalDrivingLicenseApplications is succeeded", "Save Data!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Save in LocalDrivingLicenseApplications is Faild", "Save Data!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }
            }
            else
            {
              if( MessageBox.Show("Save is fail", "Save Data", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    tabControl1.SelectedTab = tabPersonInfo;

                }
            }

        }

       

        private void frmNewLocalDrivingLicensesApplication_Load(object sender, EventArgs e)
        {
            
            FillcbLicenseClass();
            LoadData();
            cbLicenseClass.SelectedIndex = 2;
            _IDLicenseClass = (cbLicenseClass.SelectedIndex + 1);
            _clsLicenseClasses = clsBusinessLicenseClasses.Find(_IDLicenseClass);
            picVehicle.Image = Image.FromFile(GetImagePath(cbLicenseClass.SelectedIndex));
        }

        string GetImagePath(int Index)
        {
            switch(Index)
            {
                case 0:
                    {
                        return @"C:\Users\lenovo\OneDrive\Desktop\BlackICON\small Motorcycle.png";
                    }
                    case 1:
                    {
                        return @"C:\Users\lenovo\OneDrive\Desktop\BlackICON\Heavy Motorcycle.png";
                    }
                    case 2:
                    {
                        return @"C:\Users\lenovo\OneDrive\Desktop\BlackICON\Ordinary driving.png";
                    }
                    case 3:
                    {
                        return @"C:\Users\lenovo\OneDrive\Desktop\BlackICON\Commercial Vehicle.png";
                    }
                    case 4:
                    {
                        return @"C:\Users\lenovo\OneDrive\Desktop\BlackICON\Agricultural Vehicle.png";
                    }
                    case 5:
                    {
                        return @"C:\Users\lenovo\OneDrive\Desktop\BlackICON\Small and medium bus.png";
                    }
                default:
                    {
                        return @"C:\Users\lenovo\OneDrive\Desktop\BlackICON\Truck and heavy vehicle.png";
                    }
            }
        }

        private void cbLicenseClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            picVehicle.Image = Image.FromFile(GetImagePath(cbLicenseClass.SelectedIndex));
            _IDLicenseClass = (cbLicenseClass.SelectedIndex + 1);
            _clsLicenseClasses = clsBusinessLicenseClasses.Find(_IDLicenseClass);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblTitlePage_MouseEnter(object sender, EventArgs e)
        {
            lblTitlePage.ForeColor = Color.DarkGray;
        }

        private void lblTitlePage_MouseLeave(object sender, EventArgs e)
        {
            lblTitlePage.ForeColor = Color.Black;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(ctrlPersonInfoWithFilter1.ctrlFilter1.cbFilter.SelectedIndex==0)
            {
                _clsPerson = clsBusinessPeople.Find(ctrlPersonInfoWithFilter1.ctrlFilter1.txtFilterName.Text);
            }
            else
            {
                _clsPerson = clsBusinessPeople.Find(int.Parse(ctrlPersonInfoWithFilter1.ctrlFilter1.txtFilterName.Text));
            }
            if (_clsPerson == null)
            {
                MessageBox.Show("You Must fill all data,\nOr set this person to user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadData();
           
            tabControl1.SelectedTab = tabAppInfo;
        }

       
        private void picVehicle_Click(object sender, EventArgs e)
        {
            string Result = "You can`t ";
            if(decimal.Parse(lblYourAge.Text) >= _clsLicenseClasses.MinimumAllowedAge)
            {
                Result = "You Can";
            }
            MessageBox.Show($"Class Name : {_clsLicenseClasses.ClassName},\n\nMinimum Age is {_clsLicenseClasses.MinimumAllowedAge},\n\n{Result}", "License Class Information", MessageBoxButtons.OK, MessageBoxIcon.Information );
        }

        private void ctrlPersonInfoWithFilter1_OnLinkUpdate_1()
        {
            frmAdd_UpdatePerson _UpdatePerson = new frmAdd_UpdatePerson(int.Parse(ctrlPersonInfoWithFilter1.ctrlPersonInformtion1.lblPersonID.Text));
            _UpdatePerson.ShowDialog();

            _clsPerson = clsBusinessPeople.Find(int.Parse(ctrlPersonInfoWithFilter1.ctrlPersonInformtion1.lblPersonID.Text));
            ctrlPersonInfoWithFilter1.ctrlPersonInformtion1.LoadctrlPersonInformtion(_clsPerson);
        }
    }
}
