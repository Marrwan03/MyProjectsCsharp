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
    public partial class butcher : Form
    {
        public void Subscribe(Customer customer)
        {
            customer.OnBuyAnimal += PrintAnimalInfo;
        }
        public void UnSubscribe(Customer customer)
        {
            customer.OnBuyAnimal -= PrintAnimalInfo;
        }
        clsAnimalInfo _animalInfo;
        public void PrintAnimalInfo(object sender, clsAnimalInfo animalInfo)
        {
          _animalInfo = animalInfo;
            pbProcess.Value = 0;
            _Timer = 0;
            lblPercentProcess.Text = "00 %";
            btnStartKill.Enabled = true;
            ctrlAnimalInfo1.ctrlAnimalInfo_Load(_animalInfo);
        }

        Customer _customer;
        public butcher(Customer customer)
        {
            InitializeComponent();
            _customer = customer;
        }

        private void Slaughterhouse_Load(object sender, EventArgs e)
        {

        }

        double _Money;
        private void btnSubscribe_Click(object sender, EventArgs e)
        {
            Subscribe(_customer);
        }

        private void btnUnSubscribe_Click(object sender, EventArgs e)
        {
            UnSubscribe(_customer);
        }

        private void btnStartKill_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        public event EventHandler<clsBillInfo> OnBillInfo;
        byte _Timer = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
           
            
            _Timer++;
            lblPercentProcess.Text = _Timer.ToString() + " %";
            pbProcess.Value++;
            if (_Timer == 100)
            {
                timer1.Stop();
                btnStartKill.Enabled = false;
                if (MessageBox.Show("The animal slaughter is complete.", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    if (MessageBox.Show("Press [Ok] to show the bill", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        _OnBillInfo();

                    }
                }

            }
        }

        double _GetPriceButcher()
        {
            switch(_animalInfo.animalType)
            {
                case clsAnimalInfo.enAnimalType.Camel:
                    return 50;
                case clsAnimalInfo.enAnimalType.Cow:
                    return 35;
                default:
                    return 15;
            }
        }

        void _OnBillInfo()
        {
            double Price = _GetPriceButcher();
            _Money += Price+(Price * 0.15); //0.15 The Tax
           lblMoney.Text = _Money.ToString();
            if (OnBillInfo != null)
            { OnBillInfo(this, new clsBillInfo(Price, _animalInfo, DateTime.Now)); }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
