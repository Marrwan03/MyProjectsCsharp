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
    public partial class frmLicenseHistory2 : Form
    {
        int _AppID;
        public frmLicenseHistory2(int appID)
        {
            InitializeComponent();
            this._AppID = appID;
        }

        private void frmLicenseHistory2_Load(object sender, EventArgs e)
        {
            _RefreshPersonData();
            ctrlDriverLincensesHistory11.LoadDriverLincenses(_clsPerson.ID);
        }
        void Button_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.Button_MouseEnter(sender, e);
        }
        void Button_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.Button_MouseLeave(sender, e);
        }
        public void Label_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.Label_MouseEnter(sender, e);
        }
        public void Label_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.Label_MouseLeave(sender, e);
        }
       
        clsBusinessPeople _clsPerson;

        void _RefreshPersonData()
        {
            _clsPerson = clsBusinessPeople.Find(clsBusinessApplications.Find(_AppID).PersonID);
            ctrlPersonInfoWithFilter1.ctrlFilter1.txtFilterName.Text = _clsPerson.ID.ToString();
            ctrlPersonInfoWithFilter1.ctrlFilter1.cbFilter.SelectedIndex = 1;

            ctrlPersonInfoWithFilter1.ctrlFilter1.Enabled = false;
            ctrlPersonInfoWithFilter1.ctrlPersonInformtion1.LoadctrlPersonInformtion(_clsPerson);
        }
       
        private void ctrlPersonInformtion1_OnLinkUpdate()
        {
            if (_clsPerson == null)
            {
                MessageBox.Show("You must fill Each data, to update", "Stop!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmAdd_UpdatePerson frmUpdate_Person = new frmAdd_UpdatePerson(_clsPerson.ID);
            frmUpdate_Person.DataBack += ctrlPersonInfoWithFilter1.ctrlPersonInformtion1.LoadctrlPersonInformtion;
            frmUpdate_Person.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
