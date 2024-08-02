using DataAccesseTier;
using System;
using System.Data;

namespace BusinesseTier
{
    public class clsBusniesCountries
    {
        public int ID { get; set; }
        public string CountryName { get; set; }

       private clsBusniesCountries() 
        {
            ID = -1;
            CountryName = string.Empty;

        }
        public clsBusniesCountries(int ID, string CountryName)
        {
            this.ID = ID;
            this.CountryName = CountryName;
        }

        public static DataTable GetAllCountries()
        {
            return clsDataAccesseCountries.GetAllCountries();
        }

        public static clsBusniesCountries Find(int ID)
        {
            string Name = string.Empty;
            if(clsDataAccesseCountries.Find(ID, ref Name))
            {
                return new clsBusniesCountries(ID, Name);
            }
            return null;

        }

        public static clsBusniesCountries Find(string Name)
        {
            int ID = 0;
            if (clsDataAccesseCountries.Find(ref ID,  Name))
            {
                return new clsBusniesCountries(ID, Name);
            }
            return null;

        }

       

    }
}
