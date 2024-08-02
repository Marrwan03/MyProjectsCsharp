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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        public int PinCode = 0;
        public int Timer = 0;
       public static clsBusniesePerson _Person;


        int _SetRandomePinCode()
        {
            Random rnd = new Random();
            return rnd.Next(1000, 9999);
        }

        void _SetNotify()
        {
            PinCode = _SetRandomePinCode();
            notifyIcon1.BalloonTipTitle = "PinCode";
            notifyIcon1.Icon = SystemIcons.Application;
            notifyIcon1.BalloonTipText = PinCode.ToString();
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.ShowBalloonTip(6);

        }

        void VisiablePanel()
        {
            if (clsBusniesePerson.NumberOfPersons() == 0)
            {
                pAddNewAccount.Visible = true;
                maskPhone.ReadOnly = true;
            }
            else
            {
                pAddNewAccount.Visible = false;
                maskPhone.ReadOnly = false;
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            VisiablePanel();
            timeTitle.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _Person = clsBusniesePerson.Find(maskPhone.Text);
            if(_Person == null)
            {
                if(MessageBox.Show("This NumberPhone is not here, Enter another phone", "Wrong Number", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    maskPhone.Text = string.Empty;
                    pAddNewAccount.Visible =true;
                }

            }
            else
            {

                lblTitlePinCode.Visible = true;
                txtPinCode.Visible = true;
               lblTimer.Visible = true;
                btnLogin.Visible = true;
               _SetNotify();
                timer1.Start();
            }
        }

        void _RepeatOperation()
        {
            Timer = 0;
            lblTimer.Text = Timer.ToString() + " Second";
            _SetNotify();
            timer1.Start();
            txtPinCode.Text = string.Empty;
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if(Timer != 10)
            {
                Timer += 1;
                lblTimer.Text = Timer.ToString() + " Second";

            }
           else
            {
                timer1.Stop();
                if (MessageBox.Show("Now, you will recieve another PinCode", "Time Is Up", MessageBoxButtons.OK, MessageBoxIcon.Stop) == DialogResult.OK)
                {
                    _RepeatOperation();
                }

            }

        }

        private void maskPhone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

       

       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPinCode.Text == PinCode.ToString())
            {
                timer1.Stop();
                MessageBox.Show($"Welcome {_Person.FirstName}");
               
                this.Hide();
                //frmPerson person = new frmPerson(_Person);
                //person.ShowDialog();

                frmMain Main = new frmMain(_Person);
                Main.Show();

            }
            else
            {
                if (MessageBox.Show("This Pincode is not like Notification`s PinCode.", "Wrong PinCode!", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    _RepeatOperation() ;
                }
            }
        }

        private void btnLogin_Enter(object sender, EventArgs e)
        {
            if (txtPinCode.Text == PinCode.ToString())
            {
                btnLogin.ForeColor = Color.Green;
            }
            else
            {
                btnLogin.ForeColor = Color.Red;
            }
        }

        private void txtPinCode_TextChanged(object sender, EventArgs e)
        {
            if (txtPinCode.Text.Length == 4)
            {
                btnLogin.Enabled = true;

            }
            else
            {
                btnLogin.Enabled = false;
            }
        }

        Color GetColor(int Index)
        {
            Color[] colors = { Color.Blue, Color.Red, Color.Purple, Color.Orange };
           
            return colors[Index];
        }

        string GetPathImage()
        {
            string[] PathImages = { "C:\\Photos\\Messenger1.png", "C:\\Photos\\Messenger2.png", "C:\\Photos\\Messenger3.png" };
            Random RandomeChoice = new Random();
            int Randome = RandomeChoice.Next(0, 2);
            return PathImages[Randome];
        }

        void ChangeColorText()
        {
            int Randome1, Randome2, Randome3, Randome4;
            Random RandomeChoice = new Random();
            Randome1 = RandomeChoice.Next(0, 3);
            lbl1.ForeColor = GetColor(Randome1);
            Randome2 = RandomeChoice.Next(0, 3);
            lbl2.ForeColor = GetColor(Randome2);
            Randome3 = RandomeChoice.Next(0, 3);
            lbl3.ForeColor = GetColor(Randome3);
            Randome4 = RandomeChoice.Next(0, 3);
            lbl4.ForeColor = GetColor(Randome4);
        }
        void ChangePhoto()
        {
            string Path = GetPathImage();
            pic1.Image = Image.FromFile(Path);
            pic2.Image = Image.FromFile(Path);
        }

        private void picAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdateNewPerson frm = new frmAddUpdateNewPerson(-1);
            frm.ShowDialog();
            VisiablePanel();
        }

        private void timeTitle_Tick(object sender, EventArgs e)
        {
            ChangeColorText();
            ChangePhoto();
        }

      
    }
}
