using DataAccesseTier;
using System;
using System.Data;

using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace BusinesseTier
{
    public class clsBusniesePerson
    {
        enum enMode
        {
            Add,
            Update
        }

        enMode mode;
         
        public int ID {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string phone { get; set; }
        public int CountryID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ImagePath { get; set; }

        private bool _AddNewPerson()
        {
            this.ID = clsDataAccessePerson.AddNewPerson(FirstName, LastName, Gender, phone, CountryID, DateOfBirth, ImagePath);
            return this.ID != -1;
        }

        private bool _UpdatePerson()
        {
            return clsDataAccessePerson.UpdatePerson(ID, FirstName, LastName, Gender,phone, CountryID, DateOfBirth, ImagePath);
        }

      public clsBusniesePerson() 
        {
            ID = -1;
            FirstName=string.Empty;
            LastName=string.Empty;
            Gender = string.Empty;
            phone = string.Empty;
            CountryID = -1;
            DateOfBirth = DateTime.MinValue;
            ImagePath = string.Empty;
            mode = enMode.Add;
        }
        clsBusniesePerson(int ID,string firstname, string lastname, string gender, string phone, int countryid, DateTime dateOfBirth, string imagePath)
        {
            this.ID = ID;
            FirstName = firstname;
            LastName = lastname;
            Gender = gender;
            this.phone = phone;
            CountryID = countryid;
            DateOfBirth = dateOfBirth;
            ImagePath = imagePath;
            mode = enMode.Update;
        }

        public static DataTable GetAllPersons(int PersonID)
        {
            return clsDataAccessePerson.GetAllPersons(PersonID);
        }

        public bool Save()
        {
            switch(mode)
            {
                case enMode.Add:
                    {
                        mode = enMode.Update;
                        return _AddNewPerson();
                    }
                    case enMode.Update:
                    {
                        return _UpdatePerson();
                    }

            }
            return false;
        }

        public static clsBusniesePerson Find(int ID)
        {
            string Firstname = string.Empty, Lastname = string.Empty, Gender = string.Empty , Phone = string.Empty, imagepath = string.Empty;
            int CountryID = 0;
            DateTime DateOfBirth = DateTime.Now;


            if(clsDataAccessePerson.Find(ID,ref Firstname, ref Lastname, ref Gender, ref Phone, ref CountryID, ref DateOfBirth,ref imagepath))
            {
                return new clsBusniesePerson(ID,  Firstname,  Lastname,  Gender,  Phone,  CountryID,  DateOfBirth, imagepath);
            }
            else
                return null;
        }

        public static clsBusniesePerson Find(string Phone)
        {
            string Firstname = string.Empty, Lastname = string.Empty, Gender = string.Empty, ImagePath = string.Empty;
            int CountryID = 0, ID = 0;
            DateTime DateOfBirth = DateTime.Now;


            if (clsDataAccessePerson.FindByPhone(Phone,ref ID, ref Firstname, ref Lastname, ref Gender, ref CountryID, ref DateOfBirth,ref ImagePath))
            {
                return new clsBusniesePerson(ID, Firstname, Lastname, Gender, Phone, CountryID, DateOfBirth, ImagePath);
            }
            else
                return null;
        }

        public static bool IsFirstNameExists(int ID, string FirstName)
        {
            return clsDataAccessePerson.IsFirstnameExists(ID, FirstName);
        }


        public static bool IsPhoneExists(int ID,string Phone)
        {
            return clsDataAccessePerson.IsPhoneExists(ID,Phone);
        }

        public static bool IsPersonExists(int ID)
        {
            return clsDataAccessePerson.IsExists(ID);
        }


        public static bool DeletePerson(int ID)
        {
            return clsDataAccessePerson.DeletePerson(ID);
        }

        public static int NumberOfPersons()
        {
            return clsDataAccessePerson.NumberOfPerson();
        }

        public static int GetPersonID(string FirstName)
        {
            return clsDataAccessePerson.GetPersonID(FirstName);
        }

    }
}
