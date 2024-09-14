using clsDataAccessTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsBusinessTier
{
    public class clsBusinessDrivers
    {
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }
        bool _AddNewDriver()
        {
            this.DriverID = clsDataAccessDrivers.AddNewDriver(PersonID, CreatedByUserID, CreatedDate);
            return this.DriverID != -1;
        }
        public clsBusinessDrivers()
        {
            DriverID = 0;
            PersonID = 0;
            CreatedByUserID = 0;
            CreatedDate = DateTime.Now;
        }
        clsBusinessDrivers(int driverID,  int personID, int ByUserID, DateTime createdDate)
        {
            DriverID = driverID;
            PersonID = personID;
            CreatedByUserID = ByUserID;
            CreatedDate = createdDate;
        }

        public static clsBusinessDrivers Find(int driverID)
        {
            int personID=0, createdByUserID = 0;
            DateTime createdDate = DateTime.Now;    
            if(clsDataAccessDrivers.Find(driverID, ref personID, ref createdByUserID, ref createdDate))
            {
                return new clsBusinessDrivers(driverID, personID, createdByUserID, createdDate);
            }
            return null;
        }

        public static DataTable GetAllDrivers()
        {
            return clsDataAccessDrivers.GetAllDrivers();
        }

        public bool Save()
        {
            return _AddNewDriver();
        }


    }
}
