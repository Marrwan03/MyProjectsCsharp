using AnimalMarketUsingEventPublisher.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimalMarketUsingEventPublisher
{
    


    public partial class Seller : Form
    {
        clsAnimalInfo _AnimalInfo;
        public event EventHandler<clsAnimalInfo> OrderChanged;
        public void SetNewAnimal()        
        {
            _FillAnimalInfo();
            llblShowAnimalInfo.Enabled = false;
            if (OrderChanged != null)
                OrderChanged(this, _AnimalInfo);
        }

        public Seller()
        {
            InitializeComponent();
        }
        public static Customer customer;
      
        private void Order_Load(object sender, EventArgs e)
        {
           
        }

        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {
            if(materialSingleLineTextField1.Text == "Amount ???")
                materialSingleLineTextField1.Text = string.Empty;


        }

        void _FillAnimalInfo()
        {
            //Fill in data then fill the constractor
           
            clsAnimalInfo.enAnimalType animalType;
           
            if (rbCamel.Checked)
            {
                animalType = clsAnimalInfo.enAnimalType.Camel;
               
            }
            else if (rbSheep.Checked)
            {
                animalType = clsAnimalInfo.enAnimalType.Sheep;

            }
            else
            {
                animalType = clsAnimalInfo.enAnimalType.Cow;

            }

             byte Age = Convert.ToByte( numericUpDown1.Value);

            clsAnimalInfo.enSize size;
            if(rbSmall.Checked)
            {
                size = clsAnimalInfo.enSize.Small;

            }
            else if(rbMedium.Checked)
            {
                size = clsAnimalInfo.enSize.Medium;
            }
            else
            {
                size = clsAnimalInfo.enSize.Large;
            }

            clsAnimalInfo.enGendor gendor;
            if (rbMale.Checked)
                gendor = clsAnimalInfo.enGendor.Male;
            else
                gendor = clsAnimalInfo.enGendor.Female;


            double Amount = Convert.ToDouble(materialSingleLineTextField1.Text);

            _AnimalInfo = new clsAnimalInfo(animalType, gendor, Age, Amount, size, DateTime.Now );
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure dou want publish this animal info?", "Publishing!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            SetNewAnimal();

        }

      

        double _Money;
        clsAnimalInfo _animalOfCustomer;
        void CalculateSellerCard(object s, clsAnimalInfo animalInfo)
        {
            notifyIcon1.BalloonTipTitle = "New Buy For Seller";
            notifyIcon1.BalloonTipText = "The Customer buys your animal,\n\n"+animalInfo.Amount+" $ +++";
            _animalOfCustomer = animalInfo;
            llblShowAnimalInfo.Enabled = true;
            _Money += _animalOfCustomer.Amount;
            lblMoney.Text = _Money.ToString() + " $";
        }

        private void llblShowAnimalInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AnimalInformation animalInformation = new AnimalInformation(_animalOfCustomer);
            animalInformation.ShowDialog();
        }

        private void btnSubscribe_Click(object sender, EventArgs e)
        {
            customer.OnBuyAnimal += CalculateSellerCard;
        }

        private void btnUnSubscribe_Click(object sender, EventArgs e)
        {
            customer.OnBuyAnimal -= CalculateSellerCard;
        }
    }
}
