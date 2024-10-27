using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalMarketUsingEventPublisher
{
    public class clsBillInfo
    {
        public double Price { get; }
        public byte Tax { get; }
        public double TotalBillAmount { get; }
        public clsAnimalInfo AnimalInfo { get; }
        public DateTime DateTime { get; }

        public clsBillInfo(double price, clsAnimalInfo animalInfo, DateTime dateTime)
        {
            Price = price;
            Tax = 15;
            TotalBillAmount = Price + (price * 0.15);
            AnimalInfo = animalInfo;
            DateTime = dateTime;
        }
    }
}
