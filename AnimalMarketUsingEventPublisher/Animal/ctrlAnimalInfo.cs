using AnimalMarketUsingEventPublisher.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimalMarketUsingEventPublisher
{
    public partial class ctrlAnimalInfo : UserControl
    {
        public ctrlAnimalInfo()
        {
            InitializeComponent();
        }

        public void ctrlAnimalInfo_Load(clsAnimalInfo _animalInfo)
        {
            lblGendor.Text = _animalInfo.StringGendor();
            lblAge.Text = _animalInfo.Age.ToString();
            lblAmount.Text = _animalInfo.Amount.ToString() + " $";
            lblSize.Text = _animalInfo.StringSize();
            lblDatetime.Text = _animalInfo.DateTime.ToString("dd/MMM/yyyy");
            lblAnimalType.Text = _animalInfo.animalType.ToString();
            switch(_animalInfo.animalType)
            {
                case clsAnimalInfo.enAnimalType.Camel:
                    {
                        picAnimal.Image = Resources.Camel;
                        break;
                    }
                    case clsAnimalInfo.enAnimalType.Cow:
                    {
                        picAnimal.Image = Resources.Cow;
                        break;
                    }
                default:
                    {
                        picAnimal.Image = Resources.Sheep; break;
                    }
                    
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void picAnimal_Click(object sender, EventArgs e)
        {

        }
    }
}
