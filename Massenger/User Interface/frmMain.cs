using BusinesseTier;
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
    public partial class frmMain : Form
    {
        clsBusniesePerson _CurrentPerson;
        public frmMain(clsBusniesePerson Person)
        {
            InitializeComponent();
            _CurrentPerson = clsBusniesePerson.Find(Person.ID);
        }

        


        int _NumberOfMessges;
        int _NumberOfYourMessage;

       public void RefreshData()
        {
            _NumberOfMessges = clsBusnieseMessages.CounterMessage(_CurrentPerson.ID);
            _NumberOfYourMessage = clsBusnieseMessages.CounterYourMessage(_CurrentPerson.ID);

            yourMessagesToolStripMenuItem.Text = "Your Messages [" + _NumberOfYourMessage + "].";
            messagesToolStripMenuItem.Text = "Messages [" + _NumberOfMessges + "].";
        }

        void _CloseForms()
        {
            if (person != null)
            {
                person.Close();
            }
            if (chatYourMessage != null)
            {
                chatYourMessage.Close();
            }
            if (chat != null)
            {
                chat.Close();
            }
            if (accountInformation != null)
            {
                accountInformation.Close();
            }

        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            RefreshData();
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
        }

        frmAccountInformation accountInformation;
        private void accountInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CloseForms();
            accountInformation = new frmAccountInformation(_CurrentPerson);
            accountInformation.MdiParent = this;
            accountInformation.Show();
           
        }

        FrmChat chat;
        private void messagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CloseForms();
            if (_NumberOfMessges == 0)
            {
                MessageBox.Show("You don`t have any message to show");
                return;
            }
             chat = new FrmChat(0, _CurrentPerson.ID);
            chat.MdiParent = this;
            chat.Show();
            RefreshData();
        }

        FrmChat chatYourMessage;
        private void yourMessagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CloseForms();
            if (_NumberOfYourMessage == 0)
            {
                MessageBox.Show("You don`t have any message to show");
                return;
            }
            chatYourMessage = new FrmChat(_CurrentPerson.ID);
            chatYourMessage.MdiParent = this;
            chatYourMessage.Show();
            RefreshData();
        }

        frmPerson person;
        private void peToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CloseForms();
             person = new frmPerson(_CurrentPerson);
          
            person.MdiParent = this;
            person.Show();
            RefreshData();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            this.Close();
            frmLogin.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
