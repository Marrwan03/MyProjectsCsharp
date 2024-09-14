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
    public partial class ctrlFilterPerson : UserControl
    {
        public event Action<string> OnSearchPerson;
        protected virtual void SearchPerson(string S1)
        {
            if(OnSearchPerson != null)
            {
                OnSearchPerson(S1);
            }
        }


        public event Action OnAddPerson;
        protected virtual void AddPerson()
        {
            if (OnAddPerson != null)
            {
                OnAddPerson();
            }
        }

        public ctrlFilterPerson()
        {
            InitializeComponent();
        }


        private void picSearch_Click(object sender, EventArgs e)
        {
            if (OnSearchPerson != null)
            {
                OnSearchPerson(txtFilterName.Text);
            }
        }

        private void picAddNewPerson_Click(object sender, EventArgs e)
        {
           if(OnAddPerson != null)
            {
                OnAddPerson();
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void ctrlFilter_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
        }

        string _LastTxt;
        private void txtFilterName_TextChanged(object sender, EventArgs e)
        {
            if(cbFilter.SelectedIndex == 1)
            {
                if(!clsTextProcessing.TextHasLetter(txtFilterName.Text))
                {
                    _LastTxt = txtFilterName.Text;
                }
                txtFilterName.Text = _LastTxt;
                txtFilterName.SelectionStart = txtFilterName.Text.Length;
            }
        }
    }
}
