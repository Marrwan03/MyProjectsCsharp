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
    public partial class AnimalInformation : Form
    {
        clsAnimalInfo _animalInfo;
        public AnimalInformation(clsAnimalInfo animalInfo)
        {
            InitializeComponent();
            _animalInfo = animalInfo;
        }

        private void AnimalInformation_Load(object sender, EventArgs e)
        {
            ctrlAnimalInfo1.ctrlAnimalInfo_Load(_animalInfo);
        }
    }
}
