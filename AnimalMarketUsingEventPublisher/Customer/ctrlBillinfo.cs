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
    public partial class ctrlBillinfo : UserControl
    {
        public ctrlBillinfo()
        {
            InitializeComponent();
        }

        public void ctrlBillinfo_Load(clsBillInfo _BillInfo)
        {
            lblPrice.Text = _BillInfo.Price.ToString() + " $";
            lblTax.Text = _BillInfo.Tax.ToString() + " %";
            lblTotalBillAmount.Text = _BillInfo.TotalBillAmount.ToString() + " $";
            lblBillDate.Text = _BillInfo.DateTime.ToString("f");
            ctrlAnimalInfo1.ctrlAnimalInfo_Load(_BillInfo.AnimalInfo);
        }

        private void ctrlBillinfo_Load(object sender, EventArgs e)
        {

        }

        private void ctrlAnimalInfo1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
