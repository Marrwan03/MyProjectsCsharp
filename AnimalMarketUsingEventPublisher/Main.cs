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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        Seller _seller1;
        Customer _customer1;
        butcher _butcher1;

        private void button1_Click(object sender, EventArgs e)
        {
          _seller1 = new Seller();
            btnSellerScreen.Visible = false;
            _seller1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCustomerScreen_Click(object sender, EventArgs e)
        {
            _customer1 = new Customer(_seller1);
            Seller.customer = _customer1;
            btnCustomerScreen.Visible = false;
            _customer1.Show();
        }

        private void btnButcher_Click(object sender, EventArgs e)
        {
            _butcher1 = new butcher(_customer1);
            Customer._Butcher = _butcher1;
            
            btnButcher.Visible = false;
            _butcher1.Show();
        }
    }
}
