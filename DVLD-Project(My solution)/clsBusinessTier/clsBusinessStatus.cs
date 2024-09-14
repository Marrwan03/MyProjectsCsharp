using clsDataAccessTier;
using System;
using System.Data;

namespace clsBusinessTier
{
    public class clsBusinessStatus
    {
        public int ID { get; set; }
        public string Name { get; set; }

         clsBusinessStatus(int iD, string name)
        {
            ID = iD;
            Name = name;
        }
      public  clsBusinessStatus() 
        {
            ID = -1;
            Name = string.Empty;
        }

        public static clsBusinessStatus Find(string Name)
        {
            int ID = -1;
            if(clsDataAccessStatus.Find(ref ID, Name))
            {
                return new clsBusinessStatus(ID, Name);
            }
            return null;
        }

        public static clsBusinessStatus Find(int ID)
        {
            string Name = string.Empty;
            if (clsDataAccessStatus.Find( ID,ref Name))
            {
                return new clsBusinessStatus(ID, Name);
            }
            return null;
        }

    }
}
