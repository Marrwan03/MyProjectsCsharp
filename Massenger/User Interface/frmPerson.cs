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
    public partial class frmPerson : Form
    {
        clsBusniesePerson _CurrentPerson;
        public frmPerson(clsBusniesePerson _Person)
        {
            InitializeComponent();
            _CurrentPerson = clsBusniesePerson.Find(_Person.ID);

        }



        void _FillCurrentPerson()
        {
            lblPersonName.Text = _CurrentPerson.FirstName;
            lblCurrentPersonID.Text = _CurrentPerson.ID.ToString();
            lblTimeClock.Text = DateTime.Now.Hour + " : " + DateTime.Now.Minute + " : " + DateTime.Now.Second;
            lblDate.Text = DateTime.Now.Day + " / " + DateTime.Now.Month + " / " + DateTime.Now.Year;
        }

      

        public void _RefreshData()
        {
            dgvPersons.DataSource = clsBusniesePerson.GetAllPersons(_CurrentPerson.ID);
            picCurrentPerson.Image = Image.FromFile(_CurrentPerson.ImagePath);



            if (dgvPersons.CurrentCell == null )
            {
                lblTitleEmpty.Visible = true;
            }
            else
            {
                lblTitleEmpty.Visible = false;
            }
        }

        private void frmPerson_Load(object sender, EventArgs e)
        {
            timer1.Start();
            _RefreshData();
        }

   
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmAddUpdateNewPerson frm = new frmAddUpdateNewPerson(-1);
            frm.ShowDialog();
            _RefreshData();
        }

        private void dgvPersons_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dgvPersons.CurrentRow.Cells[0].Value.ToString());
        }

        private void delteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show($"Are you sure, do you want delete {dgvPersons.CurrentRow.Cells[1].Value.ToString()}", "Delete Person", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (clsBusniesePerson.DeletePerson((int)dgvPersons.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("person is deleting :-");
                    _RefreshData();
                }
                else
                {
                    MessageBox.Show("person is not deleting :-(\n he has refrence in another table");
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateNewPerson frm = new frmAddUpdateNewPerson((int)dgvPersons.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshData();
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            _FillCurrentPerson();
        }

        private void sendMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            FrmChat chat = new FrmChat(_CurrentPerson.ID, (int)dgvPersons.CurrentRow.Cells[0].Value);
            chat.ShowDialog();
            _RefreshData();

           
        }

        //private void pictureBox2_Click(object sender, EventArgs e)
        //{
        //    if(lblCountMessage.Text == "0")
        //    {
        //        MessageBox.Show("You don`t have any message to show");
        //        return;
        //    }
        //    FrmChat chat = new FrmChat(0, _CurrentPerson.ID);
        //    chat.ShowDialog();
        //    RefreshData();
        //}

        //private void picYourMessages_Click(object sender, EventArgs e)
        //{
        //    if (lblCountMessage.Text == "0")
        //    {
        //        MessageBox.Show("You don`t have any message to show");
        //        return;
        //    }
        //    FrmChat chat = new FrmChat(_CurrentPerson.ID);
        //    chat.ShowDialog();
        //    RefreshData();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
          
            this.Close();
            
        
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if(clsBusniesBlock.IsBlocked(_CurrentPerson.ID, (int)dgvPersons.CurrentRow.Cells[0].Value) || clsBusniesBlock.IsBlocked((int)dgvPersons.CurrentRow.Cells[0].Value, _CurrentPerson.ID))
            {
                sendMessageToolStripMenuItem.Enabled = false;

                if (clsBusniesBlock.IsBlocked((int)dgvPersons.CurrentRow.Cells[0].Value, _CurrentPerson.ID))
                {
                    blockToolStripMenuItem.Enabled = true;
                    unblockToolStripMenuItem.Enabled = false;
                }
                else
                {
                    blockToolStripMenuItem.Enabled = false;
                    unblockToolStripMenuItem.Enabled = true;
                }
               
            }
            else
            {
                sendMessageToolStripMenuItem.Enabled = true;
                blockToolStripMenuItem.Enabled = true;
                unblockToolStripMenuItem.Enabled = false;
            }

        }

        private void unblockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure, \nDo you want to UnBlock Him?", "Block!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(clsBusniesBlock.UnBlock(_CurrentPerson.ID, (int)dgvPersons.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Now, you can send him.", "UnBlock!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void blockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure, \nDo you want to Block Him?", "Block!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsBusniesBlock BlockByMe = new clsBusniesBlock((int)dgvPersons.CurrentRow.Cells[0].Value, DateTime.Now, _CurrentPerson.ID);
                if(BlockByMe != null)
                {
                    if(BlockByMe.AddPersonBlock())
                    {
                        MessageBox.Show($"Block {(string)dgvPersons.CurrentRow.Cells[1].Value} was succeeded.", "Done Block", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAccountInformation accountInformation = new frmAccountInformation(clsBusniesePerson.Find((int)dgvPersons.CurrentRow.Cells[0].Value));
            
            accountInformation.ShowDialog();
            _RefreshData();
        }

        private void lblCountYourMessages_Click(object sender, EventArgs e)
        {

        }

        private void lblCountMessage_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void picImagePerson_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }


      
        private void frmPerson_Resize(object sender, EventArgs e)
        {
            clsForm.SetForm(this, 836, 489);
        }

        private void frmPerson_Move(object sender, EventArgs e)
        {
            clsForm.SetForm(this, 836, 489);
        }
    }
}
