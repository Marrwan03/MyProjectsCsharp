using clsDataAccessTier;
using System;
using System.Data;
namespace clsBusinessTier
{
    public class clsBusinessCountries
    {

        public int ID { get; set; }
        public string Name { get; set; }

        public clsBusinessCountries()
        {
            ID = -1;
            Name = "";
        }
        clsBusinessCountries(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public static DataTable GetAllCountries()
        {
            return clsDataAccessCountries.GetAllCountries();
        }

        public static string GetCountryName(int countryId)
        {
            return clsDataAccessCountries.GetCountryName(countryId);
        }

        public static int GetCountryID(string countryname)
        {
            return clsDataAccessCountries.GetCountryID(countryname);
        }

        public static clsBusinessCountries Find(int countryId)
        {
            string Name = "";
            if(clsDataAccessCountries.Find(countryId, ref Name))
            {
                return new clsBusinessCountries(countryId, Name);
            }
            return null;
        }

        public static clsBusinessCountries Find(string CountryName)
        {
           int Id = -1;
            if(clsDataAccessCountries.Find(ref Id, CountryName))
            {
                return new clsBusinessCountries(Id, CountryName);
            }
            return null;
        }

    }
}
