using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalMarketUsingEventPublisher
{
    public class clsAnimalInfo : EventArgs
    {
        public enum enAnimalType { Sheep=1, Camel, Cow }
        public enAnimalType animalType {  get; set; }
        public string StringAnimalType()
        {
            switch(animalType)
            {
                case enAnimalType.Sheep:
                    {
                        return "Sheep";
                    }
                    case enAnimalType.Camel:
                    {
                        return "Camel";
                    }
                    default:
                    {
                        return "Cow";
                    }
            }
        }

        public enum enGendor { Male=1, Female}
        public enGendor gendor { get; set; }
        public string StringGendor()
        {
            switch(gendor)
            {
                case enGendor.Male:
                    return "Male";
                default:
                    return "Female";
            }
        }

        public byte Age {  get; set; }

        public double Amount { get; set; }

        public enum enSize { Small, Medium, Large};
        public enSize size { get; set; }
        public string StringSize()
        {
            switch(size)
            {
                case enSize.Small:
                    return "Small";
                case enSize.Medium:
                    return "Medium";
                default:
                    return "Large";
            }
        }

       

        public DateTime DateTime { get; set; }

        public clsAnimalInfo(enAnimalType animalType, enGendor gendor, byte age, double amount, enSize size,  DateTime dateTime)
        {
            this.animalType = animalType;
            this.gendor = gendor;
            Age = age;
            Amount = amount;
            this.size = size;
           
            DateTime = dateTime;
        }
    }
}
