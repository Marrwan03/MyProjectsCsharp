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
    public partial class Customer : Form
    {

        Seller _Seller;
       public static butcher _Butcher;
        public Customer(Seller seller)
        {
            InitializeComponent();
            _Seller = seller;
        }

        public Customer(butcher butcher)
        {
            InitializeComponent();
            _Butcher = butcher;
        }

        public void Subscribe(Seller seller)
        {
            seller.OrderChanged += FillAnimalinfo;
        }
        public void UnSubscribe(Seller seller)
        {
            seller.OrderChanged -= FillAnimalinfo;
        }
        clsAnimalInfo _animalInfo;
        public void FillAnimalinfo(object sender,clsAnimalInfo animalInfo)
        {
            _animalInfo = animalInfo;
         ctrlAnimalInfo1.ctrlAnimalInfo_Load(_animalInfo);
            this.Size = new System.Drawing.Size(732, 555);
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(732, 555);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public event EventHandler<clsAnimalInfo> OnBuyAnimal;
        private void lblBuy_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure do you want buy it?", "Buy", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (OnBuyAnimal != null)
                    OnBuyAnimal(this, _animalInfo);
            }
          
        }

        private void btnSubscribe_Click(object sender, EventArgs e)
        {
            Subscribe(_Seller);
        }

        private void OnSubscribe_Click(object sender, EventArgs e)
        {
            UnSubscribe(_Seller);
        }

        void SubscribeWithButcher(butcher butcher1)
        {
            butcher1.OnBillInfo += _LoadBillInfo;
        }
        void UnSubscribeWithButcher(butcher butcher1)
        {
            butcher1.OnBillInfo -= _LoadBillInfo;
        }

        void _LoadBillInfo(object s,  clsBillInfo billInfo)
        {
            this.Size = new System.Drawing.Size(1249, 555);
            ctrlBillinfo1.ctrlBillinfo_Load(billInfo);
        }

        private void btnSubScriveButcher_Click(object sender, EventArgs e)
        {
            SubscribeWithButcher(_Butcher);
        }

        private void btnUnSubscribeButcher_Click(object sender, EventArgs e)
        {
            UnSubscribeWithButcher(_Butcher);
        }
    }
}
