using clsDataAccessTier;
using System;
using System.Data;

namespace clsBusinessTier
{
    public class clsBusinessLicenseClasses
    {
       public int LicenseClassID { get; set; }
         public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set;}
        public decimal ClassFees { get; set; }

        public clsBusinessLicenseClasses()
        {
            LicenseClassID = -1;
            ClassName = string.Empty;
            ClassDescription = string.Empty;
            MinimumAllowedAge = 0;
            DefaultValidityLength = 0;
            ClassFees = -1;
        }
        clsBusinessLicenseClasses(int LicenseClassesID, string ClassName, string ClassDescription, byte MinimumAllowedAge, byte DefaultValidityLength, decimal ClassFees)
        {
            this.LicenseClassID = LicenseClassesID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
        }

        public static clsBusinessLicenseClasses Find(int LicenseClassID)
        {
            string ClassName = string.Empty, ClassDescriotion = string.Empty;
            byte  DefaultValidityLength = 0, MinimumAllowedAge=0;
          
            decimal ClassFees = -1;
            if(clsDataAccessLicenseClasses.Find(LicenseClassID, ref  ClassName, ref ClassDescriotion, ref MinimumAllowedAge,ref DefaultValidityLength, ref ClassFees))
            {
                return new clsBusinessLicenseClasses(LicenseClassID, ClassName, ClassDescriotion, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            }
            return null;
        }

        public static DataTable GetAllData()
        {
            return clsDataAccessLicenseClasses.GetAllData();
        }


    }
}
