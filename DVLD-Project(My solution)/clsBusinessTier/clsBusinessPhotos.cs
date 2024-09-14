using clsDataAccessTier;
using System;
using System.Data;
using System.Net.Configuration;
using System.Runtime.CompilerServices;

namespace clsBusinessTier
{
    public class clsBusinessPhotos
    {
        enMode Mode;
        enum enMode
        {
            Add, Update
        }


        public int ID { get; set; }
        public int PersonID { get; set; }
        public string ImagePath { get; set; }
        public string GuidName { get; set; }


        private bool _AddNewPhoto()
        {
            this.ID = clsDataAccessPhotos.AddNewPhoto(PersonID, ImagePath, GuidName);
            return (this.ID != -1);
        }

        private bool _UpdatePhoto()
        {
            return clsDataAccessPhotos.UpdatePhoto(PersonID, ImagePath, GuidName);
        }
        clsBusinessPhotos(int iD, int personID, string imagePath, string guidName)
        {
            ID = iD;
            PersonID = personID;
            ImagePath = imagePath;
            GuidName = guidName;
            Mode = enMode.Update;
        }
        public clsBusinessPhotos()
        {
            ID = -1;
            PersonID = -1;
            ImagePath = string.Empty;
            GuidName = string.Empty;
            Mode = enMode.Add;
        }

       public bool Save()
        {
            switch(Mode)
            {
                case enMode.Add:
                    {
                        Mode = enMode.Update;
                        return _AddNewPhoto();
                    }
                    case enMode.Update:
                    {
                        return _UpdatePhoto();
                    }
            }
            return false;
        }

        public static clsBusinessPhotos Find(int PersonID)
        {
            int ID = -1;
            string ImagePath = "";
            string GuidName = "";
            if(clsDataAccessPhotos.Find(ref ID, PersonID, ref ImagePath,ref GuidName))
            {
                return new clsBusinessPhotos(ID, PersonID, ImagePath, GuidName);
            }
            return null;

        }

        public static bool IsExists(int  PersonID)
        {
            return clsDataAccessPhotos.IsExistsPhoto(PersonID);
        }

        public static bool DeletePhoto(int PersonID)
        {
            return clsDataAccessPhotos.DeletePhoto(PersonID);
        }

        public static bool DeleteAll()
        {
            return clsDataAccessPhotos.DeleteAll();
        }
        public static DataTable GetAllPhotos()
        {
            return clsDataAccessPhotos.GetAllPhotos();
        }

    }
}
