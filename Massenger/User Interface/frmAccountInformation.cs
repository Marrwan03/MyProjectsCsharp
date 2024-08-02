using BusinesseTier;
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

namespace Massenger
{
    public partial class frmAccountInformation : Form
    {
        clsBusniesePerson _Person;
        public frmAccountInformation(clsBusniesePerson person)
        {
            InitializeComponent();
            _Person = clsBusniesePerson.Find(person.ID);
        }

       

        private void frmAccountInformation_Load(object sender, EventArgs e)
        {
            clsForm.SetForm(this, 919, 284);
            ctrlPersonInfo1.ctrlPersonInfo_Load(_Person);
           
        }

        private void ctrlPersonInfo1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlPersonInfo1_OnClose()
        {
            this.Close();
        }

        private void ctrlPersonInfo1_OnEditInformation(clsBusniesePerson obj)
        {
            frmAddUpdateNewPerson frm = new frmAddUpdateNewPerson(obj.ID);
            frm.ShowDialog();

            //RefreshData
            obj = clsBusniesePerson.Find(obj.ID);
            ctrlPersonInfo1.ctrlPersonInfo_Load(obj);
        }
    }
}
