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
    public partial class frmPersonDetails : Form 
    {
        clsBusinessPeople _CurrentPerson;
        int _PersonID;
        public frmPersonDetails(int PersonID)
        {
        
            InitializeComponent();
            _PersonID = PersonID;
            _CurrentPerson = clsBusinessPeople.Find(_PersonID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadData(clsBusinessPeople Person)
        {
            ctrlPersonInformtion1.LoadctrlPersonInformtion(Person);
        }

        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
            LoadData(_CurrentPerson);
        }

        private void ctrlPersonInformtion1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlPersonInformtion1_OnLinkUpdate()
        {
            frmAdd_UpdatePerson frm_UpdatePerson = new frmAdd_UpdatePerson(_PersonID);
            frm_UpdatePerson.DataBack += LoadData;
            frm_UpdatePerson.ShowDialog();
            

        }

     


        //Create Fun For all Control
        private void ctrlPersonInformtion1_Enter(object sender, EventArgs e)
        {
          
        }

        public  void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            btn.ForeColor = Color.White;
        }

        public  void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.ForeColor = Color.Black;
        }
        public  void Label_MouseEnter(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.White;
        }

        public  void Label_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.Black;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           if( clsBusinessUsers.IsExists(_CurrentPerson.ID))
            {
                clsBusinessUsers User = clsBusinessUsers.FindByPersonID(_CurrentPerson.ID);
                MessageBox.Show($"This is  [ {_CurrentPerson.FirstName} ]  Info In Application:\n\n**************************\n_Username : {User.Username}.\n\n_Password : {User.Password}.\n**************************", "Private Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           else
            {
                MessageBox.Show($"This Person [ {_CurrentPerson.FirstName} ]  doesn`t have AccountUser.", "Private Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
