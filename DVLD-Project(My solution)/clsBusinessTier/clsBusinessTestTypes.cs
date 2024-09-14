using clsDataAccessTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsBusinessTier
{
    public class clsBusinessTestTypes
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set;}
        public decimal Fees { get; set; }

        public clsBusinessTestTypes()
        {
            ID = -1;
            Title = string.Empty;
            Description = string.Empty;
            Fees = -1;
        }

        clsBusinessTestTypes(int id, string title, string description, decimal fees)
        {
            ID = id;
            Title = title;
            Description = description;
            Fees = fees;
        }

        bool _UpdateTestType()
        {
            return clsDataAccessTestTypes.UpdateTestType(ID, Title, Description, Fees);
        }

        public static DataTable GetAllTestTypes()
        {
            return clsDataAccessTestTypes.GetAllTestTypes();
        }

        public static clsBusinessTestTypes Find(int ID)
        {
            string Title = string.Empty, Description = string.Empty;
            decimal Fees = 0;
            if(clsDataAccessTestTypes.Find(ID, ref Title,ref Description,ref Fees) )
            {
                return new clsBusinessTestTypes(ID, Title, Description, Fees);
            }
            return null;
        }

        public bool Save()
        {
            return _UpdateTestType();
        }

        public static decimal MinimumFees()
        {
            return clsDataAccessTestTypes.GetMinimumFees();
        }
        public static decimal MaximumFees()
        {
            return clsDataAccessTestTypes.GetMaximumFees();
        }


    }
}
