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
    public partial class frmMain : Form
    {
        public void ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
          clsColorControl.ToolStripMenuItem_MouseEnter(sender, e);
        }
        public void ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.ToolStripMenuItem_MouseLeave(sender, e);
        }


        public delegate void MyDelegate();
        public event MyDelegate DataBack;

        void _RefreshCurrentUser()
        {
            clsGlobalSettings.CurrentUser = clsBusinessUsers.Find(_CurrentUserID);
        }
        int _CurrentUserID;
        public frmMain(int UserID)
        {
            InitializeComponent();
            _CurrentUserID = UserID;
            clsGlobalSettings.CurrentUser = clsBusinessUsers.Find(_CurrentUserID);
        }
        void _CloseAllForms(bool CloseMainForm = false)
        {
            if(frmPeople != null)
                frmPeople.Close();
            if(frmusers != null)
                frmusers.Close();
            if(userDetails != null)
                userDetails.Close();
            if(changePassword != null)
                changePassword.Close();
            if(manageApplicationTypes != null)
                manageApplicationTypes.Close();
            if(manageTestTypes != null)
                manageTestTypes.Close();
            if(localDrivingLicenseApplications != null)
                localDrivingLicenseApplications.Close();
            if(newLocalDrivingLicensesApplication  != null)
                newLocalDrivingLicensesApplication.Close();
            if(listDrivers  != null)
                listDrivers.Close();
            if(newInternationalDrivingLicenseApplicaiton!=null)
                newInternationalDrivingLicenseApplicaiton.Close();
            if(listIntLIcenseApp != null)
                listIntLIcenseApp.Close();
            if (renewLicenseApplication != null)
                renewLicenseApplication.Close();
            if(replacementforDamagedorLostLicenses != null)
                replacementforDamagedorLostLicenses.Close();
            if (releaseDetainLicense != null)
                releaseDetainLicense.Close();
            if(listDetainedLicenses != null)
                listDetainedLicenses.Close();
            if(detainLicense != null)
                detainLicense.Close();

            if (CloseMainForm)
                this.Close();


        }

        public frmPeople frmPeople ;
        private void peToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CloseAllForms();
            frmPeople = new frmPeople();
            frmPeople.MdiParent = this;
            frmPeople.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        frmUserDetails userDetails;
        private void currentUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CloseAllForms();
            userDetails = new frmUserDetails(clsGlobalSettings.CurrentUser);
            userDetails.Show();
            //_RefreshCurrentUser();
        }

        private void signToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure, \nDo you want Sign out?","Sign Out!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _CloseAllForms(true);
                clsGlobalSettings.CurrentUser = clsBusinessUsers.Find(clsGlobalSettings.CurrentUser.UserID);
                DataBack?.Invoke();
                frmLoginSystem.frmLogin.Show();
            }
        }

        frmUsers frmusers;
        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CloseAllForms();
            frmusers = new frmUsers();
          
            frmusers.Show();
          
        }

        frmChangePassword changePassword;
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CloseAllForms();
            changePassword = new frmChangePassword(clsGlobalSettings.CurrentUser);
            changePassword.MdiParent = this;
            changePassword.Show();
           
        }

        frmManageApplicationTypes manageApplicationTypes;
        private void manageApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CloseAllForms();
            manageApplicationTypes = new frmManageApplicationTypes();
            manageApplicationTypes.MdiParent= this;
            manageApplicationTypes.Show();
        }

        frmManageTestTypes manageTestTypes;
        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CloseAllForms();
            manageTestTypes = new frmManageTestTypes();
            manageTestTypes.MdiParent=this;
            manageTestTypes.Show();
        }

        frmLocalDrivingLicenseApplications localDrivingLicenseApplications;
        private void localDrivingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CloseAllForms();
            localDrivingLicenseApplications = new frmLocalDrivingLicenseApplications();
            localDrivingLicenseApplications.MdiParent = this;
            localDrivingLicenseApplications.Show();
        }

        private void newDrivingLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        frmAdd_UpdateLocalDrivingLicensesApplication newLocalDrivingLicensesApplication;
        private void localLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CloseAllForms();
            newLocalDrivingLicensesApplication = new frmAdd_UpdateLocalDrivingLicensesApplication(-1);
            newLocalDrivingLicensesApplication.MdiParent = this;
            newLocalDrivingLicensesApplication.Show();

        }

        frmListDrivers listDrivers;
        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CloseAllForms();
            listDrivers = new frmListDrivers();
            listDrivers.MdiParent = this;
            listDrivers.Show();
        }

        private void accountSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        frmNewInternationalDrivingLicenseApplicaiton newInternationalDrivingLicenseApplicaiton;
        private void internationalLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CloseAllForms();
            newInternationalDrivingLicenseApplicaiton = new frmNewInternationalDrivingLicenseApplicaiton();
            newInternationalDrivingLicenseApplicaiton.MdiParent = this;
            newInternationalDrivingLicenseApplicaiton.Show();


        }

        frmListIntLIcenseApp listIntLIcenseApp;
        private void internationalLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CloseAllForms();
            listIntLIcenseApp = new frmListIntLIcenseApp();
            listIntLIcenseApp.MdiParent = this;
            listIntLIcenseApp.Show();
        }

        


        frmDetainLicense detainLicense;
        private void detainLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _CloseAllForms();
            detainLicense = new frmDetainLicense();
            detainLicense.MdiParent = this;
            detainLicense.Show();
        }

        frmReleaseDetainLicense releaseDetainLicense;
        private void releaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CloseAllForms();
            releaseDetainLicense = new frmReleaseDetainLicense(-1);
            releaseDetainLicense.MdiParent = this;
            releaseDetainLicense.Show();
        }

        frmListDetainedLicenses listDetainedLicenses;
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _CloseAllForms();
            listDetainedLicenses = new frmListDetainedLicenses();
            listDetainedLicenses.MdiParent = this;
            listDetainedLicenses.Show();
        }

        private void releaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _CloseAllForms();
            releaseDetainLicense = new frmReleaseDetainLicense(-1);
            releaseDetainLicense.MdiParent = this;
            releaseDetainLicense.Show();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CloseAllForms();
            localDrivingLicenseApplications = new frmLocalDrivingLicenseApplications();
            localDrivingLicenseApplications.MdiParent = this;
            localDrivingLicenseApplications.Show();
        }

        private void applicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        frmRenewLicenseApplication2 renewLicenseApplication;
        private void renewDrivingLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CloseAllForms();
            renewLicenseApplication = new frmRenewLicenseApplication2();
            renewLicenseApplication.MdiParent = this;
            renewLicenseApplication.Show();
        }

        frmReplacementforDamagedorLostLicenses22 replacementforDamagedorLostLicenses;
        private void replacementForDamagedOrLostLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CloseAllForms();
            replacementforDamagedorLostLicenses = new frmReplacementforDamagedorLostLicenses22();
            replacementforDamagedorLostLicenses.MdiParent = this;
            replacementforDamagedorLostLicenses.Show();

        }
    }
}
