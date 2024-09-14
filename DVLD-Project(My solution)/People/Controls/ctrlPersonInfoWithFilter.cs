using clsBusinessTier;
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
    public partial class ctrlPersonInfoWithFilter : UserControl
    {
        public event Action OnLinkUpdate;
        protected virtual void LinkUpdate()
        {
            if (OnLinkUpdate != null)
                OnLinkUpdate();
        }

        clsBusinessPeople _clsPerson;

        public ctrlPersonInfoWithFilter()
        {
            InitializeComponent();
        }

        private void ctrlFilter1_OnAddPerson()
        {
            frmAdd_UpdatePerson frmAdd_Person = new frmAdd_UpdatePerson(-1);
            frmAdd_Person.ShowDialog();
        }

        private void ctrlFilter1_OnSearchPerson(string obj)
        {
          
            if (string.IsNullOrEmpty(obj))
            {
                MessageBox.Show("You don`t set any thing, Please set national No.", "Set Something!", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                return;
            }

            if (ctrlFilter1.cbFilter.SelectedIndex == 0)
            {
                _clsPerson = clsBusinessPeople.Find(obj);
            }
            else
            {
                _clsPerson = clsBusinessPeople.Find(int.Parse(obj));
            }
                
            if (_clsPerson == null)
            {
                if(ctrlFilter1.cbFilter.SelectedIndex ==0)
                {
                    MessageBox.Show($"no person with national No = {obj}.", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"no person with ID = {obj}.", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
             
            }
            ctrlPersonInformtion1.LoadctrlPersonInformtion(_clsPerson);
        }

        private void ctrlPersonInformtion1_OnLinkUpdate()
        {
           if(OnLinkUpdate != null)
            {
                OnLinkUpdate();
            }
        }

        private void ctrlFilter1_Load(object sender, EventArgs e)
        {
           
        }

       
        private void ctrlPersonInfoWithFilter_Load(object sender, EventArgs e)
        {

        }

        private void ctrlPersonInformtion1_Load(object sender, EventArgs e)
        {

        }
    }
}
