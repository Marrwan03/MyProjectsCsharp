using clsDataAccessTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace clsBusinessTier
{
    public class clsBusinessPeople
    {
        enMode mode;
        enum enMode : byte
        {
            Add, Update
        }


        public int ID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte Gendor {  get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        public clsBusinessPeople()
        {
            ID = -1;
            NationalNo = string.Empty;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = DateTime.Now;
            Gendor = 0;
            Address = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            NationalityCountryID = -1;
            ImagePath = string.Empty;
            mode = enMode.Add;
        }
        clsBusinessPeople(int id, string nationalNo, string firstName, string secondName, string thirdName,
            string lastName, DateTime dateOfBirth, byte gendor, string address, string phone, string email, int nationalityCountryID, string imagePath)
        {
            this.ID = id;
            this.NationalNo = nationalNo;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Gendor = gendor;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.NationalityCountryID = nationalityCountryID;
            this.ImagePath = imagePath;
            mode = enMode.Update;
        }
        bool _AddNewPerson()
        {
            this.ID = clsDataAccessPeople.AddNewPerson(NationalNo, FirstName, SecondName, ThirdName,LastName,DateOfBirth,Gendor,Address,Phone,Email,NationalityCountryID, ImagePath);
            return this.ID != -1;
        }

        bool _UpdatePerson()
        {
            return clsDataAccessPeople.UpdatePerson(ID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
        }

        public bool Save()
        {
            switch(mode)
            {
                case enMode.Add:
                    {
                        if(_AddNewPerson())
                        {
                            mode = enMode.Update;
                            return true;
                        }
                        break;
                    }
                    case enMode.Update:
                    {
                        return _UpdatePerson();
                    }

            }
            return false;
        }

        public static clsBusinessPeople Find(int PersonID)
        {
            string NationalNo = " ",FirstName = " ", SecondName = " ", ThirdName = " ",
                LastName = " ", Address = " ", Phone = " ", Email = " ", ImagePath = " ";
            int NationalityCountryID = -1;
            byte Gendor = 0;
            DateTime DateOfBirth = DateTime.Now;

            if (clsDataAccessPeople.FindPerson(PersonID,ref NationalNo,ref FirstName,ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth,
                ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsBusinessPeople(PersonID, NationalNo,FirstName,SecondName, ThirdName, LastName,DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath); 

            }
            return null;
        }

        public static clsBusinessPeople Find(string NationalNo)
        {
            string FirstName = " ", SecondName = " ", ThirdName = " ",
                LastName = " ", Address = " ", Phone = " ", Email = " ", ImagePath = " ";
            int NationalityCountryID = -1, PersonID =-1;
            byte Gendor = 0;
            DateTime DateOfBirth = DateTime.Now;

            if (clsDataAccessPeople.FindPerson(ref PersonID,  NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth,
                ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsBusinessPeople(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);

            }
            return null;
        }



        public static DataTable GetAllPeople()
        {
            return clsDataAccessPeople.GetAllPeople();
        }

        public static int GetPeopleCount()
        {
            return clsDataAccessPeople.GetPeopleCount();
        }

        public static bool IsNationalNoExists(string NationalNo, int PersonID)
        {
            return clsDataAccessPeople.IsNationalNoExists(NationalNo, PersonID);
        }

        public static bool IsEmailExists(string Email, int PersonID)
        {
            return clsDataAccessPeople.IsEmailExists(Email, PersonID);
        }

        public static bool IsPhoneExists(string Phone, int PersonID)
        {
            return clsDataAccessPeople.IsPhoneExists(Phone, PersonID);
        }

        public static bool DeletePerson(int PersonID)
        {
            return clsDataAccessPeople.DeletePerson(PersonID);
        }

        public static bool DeleteAllPeople()
        {
            return clsDataAccessPeople.DeleteAllPeople();
        }
       
    }
}
