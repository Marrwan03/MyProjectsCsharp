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
    public partial class frmUserDetails : Form
    {
        clsBusinessUsers _User;
        public frmUserDetails(clsBusinessUsers User)
        {
            InitializeComponent();
            _User = User;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void LoadctrlPersonInformtion1(clsBusinessPeople clsPerson)
        {
            ctrlPersonInformtion1.LoadctrlPersonInformtion(clsPerson);
        }

        private void ctrlPersonInformtion1_OnLinkUpdate()
        {
            frmAdd_UpdatePerson frmUpdate_Person = new frmAdd_UpdatePerson(_User.PersonID);
            frmUpdate_Person.DataBack += LoadctrlPersonInformtion1;
            frmUpdate_Person.ShowDialog();

        }

        private void frmUserDetails_Load(object sender, EventArgs e)
        {
            LoadctrlPersonInformtion1(clsBusinessPeople.Find(_User.PersonID));
            ctrlLoginInformation1.LoadctrlLoginInformation(_User);
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
           clsColorControl.Label_MouseEnter(sender, e);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
           clsColorControl.Label_MouseLeave(sender, e);
        }

        public  void Button_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.Button_MouseEnter(sender, e);
        }

        public  void Button_MouseLeave(object sender, EventArgs e)
        {
           clsColorControl.Button_MouseLeave(sender, e);
        }
    }
}
