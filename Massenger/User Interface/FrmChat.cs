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
    public partial class FrmChat : Form
    {
        enMode Mode;
        enum enMode
        {
            Sender,
            Receiver,
            Update
        }

        int _IDSender { get; set; }
        int _IDReceiver { get; set; }
        clsBusnieseMessages _Sender;
        clsBusniesePerson _PersonReceiver;

        public FrmChat(int SenderID, int ReceiverID)
        {
            InitializeComponent();
            _IDSender = SenderID;
            _IDReceiver = ReceiverID;

            if (_IDSender > 0)
            {
                Mode = enMode.Sender;

            }
            else
            {
                Mode = enMode.Receiver;
            }

            _PersonReceiver = clsBusniesePerson.Find(_IDReceiver);

        }
        public FrmChat(int SenderID)
        {
            InitializeComponent();
            _IDSender = SenderID;
            Mode = enMode.Update;
        }

        //  public static clsBusniesePerson _PersonReceiver; //To send to him message

        void _RefreshdgvMessages(string FirstName = " ", int ID = 0, bool ShowYourMessage = false)
        {
            if (ShowYourMessage)
            {
                dgvMessages.DataSource = clsBusnieseMessages.GetAllMessages(ID);
            }
            else
            {
                dgvMessages.DataSource = clsBusnieseMessages.GetAllMessages(FirstName);
            }
        }



        void _LoadData()
        {

            if (Mode == enMode.Sender)
            {
                this.AutoScroll = false;
                clsForm.SetForm(this, 421, 612);
               
                btnClose.Location = new Point(316, 12);
                txtTextMessage.ReadOnly = false;

                if (_PersonReceiver != null)
                {
                    lblReciverName.Text = _PersonReceiver.FirstName;
                }

               
            }
            else if (Mode == enMode.Receiver)
            {
                clsForm.SetForm(this, 1232, 612);
               
                btnClose.Location = new Point(1131, 12);
                dgvMessages.Location = new Point(564, 65);
               
                picPhoto2.Location = new Point(564, 2);
                lblTitleGradeView.Location = new Point(808, 9);
                lblTitleGradeView.Text = "Messages";
                txtTextMessage.ReadOnly = true;
                updateToolStripMenuItem.Enabled = false;
               // lblReciverName.Text = "Reciver";
                _RefreshdgvMessages(_PersonReceiver.FirstName);
                //To Show Messages`s Receiver
            }
            else//Show Your Messages
            {

                chatToolStripMenuItem.Enabled = false;
                pImagesIron.Visible = false;
                pReciver.Visible = false;
                // pUpdateMessage.Visible = true;
                clsForm.SetForm(this, 666, 612);
                
                picPhoto2.Location = new Point(30, 2);
                lblTitleGradeView.Text = "Your Messages";
                lblTitleGradeView.Location = new Point(211, 12);
                //lblReciverName.Location = new Point(203, 9);
                
                btnClose.Location = new Point(576, 12);
                dgvMessages.Location = new Point(39, 65);

                _RefreshdgvMessages(string.Empty, _IDSender, true);
            }
        }


        private void chatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure, \nDo you wanna to Replay his Message?", "Replay Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if(clsBusniesBlock.IsBlocked(_PersonReceiver.ID, (int)dgvMessages.CurrentRow.Cells[1].Value))
                {
                    MessageBox.Show("You cant`t replay or send him any message,\nBecause you block him", "Block Person1!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (clsBusniesBlock.IsBlocked((int)dgvMessages.CurrentRow.Cells[1].Value, _PersonReceiver.ID))
                {
                    MessageBox.Show("You cant`t replay or send him any message,\nBecause he blocks you", "Block Person1!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _PersonReceiver = clsBusniesePerson.Find((int)dgvMessages.CurrentRow.Cells[1].Value);
                if (_PersonReceiver == null)
                {
                    return;
                }
                txtTextMessage.ReadOnly = false;
                txtTextMessage.Text = "Send Message"; 
                lblReciverName.Text = _PersonReceiver.FirstName;
                

            }
        }

        private void FrmChat_Load(object sender, EventArgs e)
        {
            
            _LoadData();


        }

        void _FillPanelMessage()
        {

            lblTitlePanelMessage.Text = "Message Info : ";
            lblSenderInfo.Text = frmLogin._Person.FirstName;
            lblReciverInfo.Text = _PersonReceiver.FirstName;
            lblTime.Text = DateTime.Now.Hour + " : " + DateTime.Now.Minute;

            if ( txtTextMessage.Text[0] == 'C' && txtTextMessage.Text[1] == ':')
            {

                lblMessage.Visible = false;
                picPhoto.Visible = true;
                picPhoto.Image = Image.FromFile(txtTextMessage.Text);

               
            }
            else
            {
                lblMessage.Text = txtTextMessage.Text;
                lblMessage.Visible = true;
                picPhoto.Visible = false;
            }

        }



        void SendMessage(string Message)
        {
            _Sender = new clsBusnieseMessages(frmLogin._Person.ID, Message, DateTime.Now, _PersonReceiver.ID);
            if (_Sender.SendMessage())
            {
                if (MessageBox.Show("Send message succefull", "Send Message", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    txtTextMessage.ReadOnly = false;
                    pMessage.Visible = true;

                    _FillPanelMessage();

                    //Refresh if you replay to Yourself
                    _PersonReceiver = clsBusniesePerson.Find(frmLogin._Person.ID);
                    _RefreshdgvMessages(_PersonReceiver.FirstName);
                    _PersonReceiver = clsBusniesePerson.Find(_IDReceiver);
                }
            }
        }

        private void txtTextMessage_MouseEnter(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.ReadOnly)
                return;
            if (txt.Tag == "?")
            {
                txt.Text = string.Empty;
                txt.Tag = "!";
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //txtTextMessage.Text == string.Empty || txtTextMessage.Text == "Send Message" || lblReciverName.Text == "Reciver"
            if (txtTextMessage.ReadOnly || txtTextMessage.Text == string.Empty)
            {
                MessageBox.Show("You cannot send empty message", "Wrong Send!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            else
            {
                SendMessage(txtTextMessage.Text);
              
            }
        }

        //private void btnSendAgain_MouseEnter(object sender, EventArgs e)
        //{
        //    btnSendAgain.ForeColor = Color.Red;
        //}

        //private void btnSendAgain_MouseLeave(object sender, EventArgs e)
        //{
        //    btnSendAgain.ForeColor = Color.Black;
        //}

        //private void btnSendAgain_Click(object sender, EventArgs e)
        //{
        //    if (MessageBox.Show($"Are you sure, Do you want to send to {_PersonReceiver.FirstName} ? ", "Send Again!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //    {
        //        lblTitlePanelMessage.Text = "Last Message : ";
        //        txtTextMessage.Text = string.Empty;
        //    }

        //}

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
           
        }



        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure, \nDo you wanna to Delete his Message?", "Delete Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsBusnieseMessages.DeleteMessage(dgvMessages.CurrentRow.Cells[2].Value.ToString(), (DateTime)dgvMessages.CurrentRow.Cells[3].Value, clsBusniesePerson.GetPersonID(dgvMessages.CurrentRow.Cells[4].Value.ToString())))
                {
                    MessageBox.Show("Delete is succeeded :-)", "Delete!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    switch (Mode)
                    {
                        case enMode.Receiver:
                            {
                                _RefreshdgvMessages(_PersonReceiver.FirstName);
                            }
                            break;
                        default:
                            {
                                _RefreshdgvMessages(string.Empty, _IDSender, true);
                                break;
                            }
                    }


                }
            }
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.BackColor = Color.SeaShell;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.BackColor = Color.Tan;
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(clsBusniesBlock.IsBlocked(_IDSender,clsBusniesePerson.GetPersonID((string) dgvMessages.CurrentRow.Cells[4].Value)))
            {
                MessageBox.Show($"This Person [{(string)dgvMessages.CurrentRow.Cells[4].Value}] has a block,\nLift the block on him", "Wrong Update!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Size = new System.Drawing.Size(666, 751);
            pUpdateMessage.Visible = true;
            txtNewMessage.ReadOnly = false;
            string Message = dgvMessages.CurrentRow.Cells[2].Value.ToString();
           

            if(string.IsNullOrEmpty(Message))
            {
                btnUpdatePhoto.Visible = false;
                picCurrentPhoto.Visible = false;
                lblTitlePanel.Text = "Current Message : ";
                lblSetNewMessge.Visible = true;
                txtNewMessage.Visible = true;
                lblCurrentMessage.Visible = true;
                lblCurrentMessage.Text = "Empty";
                return;
            }

            if (Message[0] == 'C' && Message[1] == ':')
            {
                btnUpdatePhoto.Visible = true;
                picCurrentPhoto.Visible = true;
                lblTitlePanel.Text = "Current Photo : ";
                lblCurrentMessage.Text = "Current Message : ";
                lblSetNewMessge.Visible = false;
                txtNewMessage.Visible = false;
                lblCurrentMessage.Visible = false;
                picCurrentPhoto.Image = Image.FromFile(Message);
            }
            else
            {
                btnUpdatePhoto.Visible = false;
                picCurrentPhoto.Visible = false;
                lblTitlePanel.Text = "Current Message : ";
                lblSetNewMessge.Visible = true;
                txtNewMessage.Visible = true;
                lblCurrentMessage.Visible = true;
                lblCurrentMessage.Text = Message;
            }

        }

        private void btnUpdateMessage_Click(object sender, EventArgs e)
        {


            if(lblCurrentMessage.Text == "Current Message : " || string.IsNullOrEmpty(txtNewMessage.Text))
            {
                if (MessageBox.Show("Update Faild, Select any message or set photo to update it", "Wrong Update Message", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    return;
                }
            }

            if (clsBusnieseMessages.UpdateMessage(int.Parse(dgvMessages.CurrentRow.Cells[1].Value.ToString()), dgvMessages.CurrentRow.Cells[2].Value.ToString(), (DateTime)dgvMessages.CurrentRow.Cells[3].Value, clsBusniesePerson.GetPersonID(dgvMessages.CurrentRow.Cells[4].Value.ToString()), txtNewMessage.Text))
             {
                if (MessageBox.Show("Update Succeded", "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.Size = new System.Drawing.Size(666, 612);
                    pUpdateMessage.Visible = false;
                    _RefreshdgvMessages(" ", (int)dgvMessages.CurrentRow.Cells[1].Value, true);
                }
            }

        }

        private void txtNewMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTextMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
           
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
           
        }

        private void picSendPhoto_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = "png";
            saveFileDialog1.Filter = "png files (*.png)|*.png";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtTextMessage.Text = saveFileDialog1.FileName;
                
            }
        }

        private void dgvMessages_DoubleClick(object sender, EventArgs e)
        {
           
            string Message = dgvMessages.CurrentRow.Cells[2].Value.ToString();
            if (Message[0] == 'C' && Message[1] == ':' ) 
            {
                if (Mode == enMode.Update)
                {
                    btnUpdatePhoto.Visible = true;
                }
                picPhoto2.Visible = true;
                picPhoto2.Image = Image.FromFile( Message );
            }
            else
            {
                btnUpdatePhoto.Visible = false;
                picPhoto2.Visible = false;
                MessageBox.Show($"Message : {Message}", "Message!");
            }
        }

        //private void btnChangePhoto_Click(object sender, EventArgs e)
        //{
        //    saveFileDialog1.DefaultExt = "png";
        //    saveFileDialog1.Filter = "png files (*.png)|*.png";
        //    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        if (clsBusnieseMessages.UpdateMessage(int.Parse(dgvMessages.CurrentRow.Cells[1].Value.ToString()), dgvMessages.CurrentRow.Cells[2].Value.ToString(), (DateTime)dgvMessages.CurrentRow.Cells[3].Value, clsBusniesePerson.GetPersonID(dgvMessages.CurrentRow.Cells[4].Value.ToString()), saveFileDialog1.FileName))
        //        {
        //            if (MessageBox.Show("Update Succeded", "Update Photo!", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
        //            {
                       
        //                _RefreshdgvMessages(" ", (int)dgvMessages.CurrentRow.Cells[1].Value, true);
        //            }
        //        }
        //    }
        //}

        private void btnUpdatePhoto_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = "png";
            saveFileDialog1.Filter = "png files (*.png)|*.png";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
               txtNewMessage.Text = saveFileDialog1.FileName;
               picCurrentPhoto.Image = Image.FromFile(saveFileDialog1.FileName);
               lblCurrentMessage.Text = saveFileDialog1.FileName;
            }
        }

        private void cmsMessage_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}

