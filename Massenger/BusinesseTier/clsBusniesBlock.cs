using DataAccesseTier;
using System;
using System.Data;

namespace BusinesseTier
{
    public class clsBusniesBlock
    {
        public int ID { get; set; }
        public int BlockedID { get; set; }
        public DateTime Time { get; set; }
        public int BlockedByPersonID { get; set; }

  
        public clsBusniesBlock(int BlockedID,  DateTime Time, int BlockedByPersonID)
        {
           // this.ID = ID;
            this.BlockedID = BlockedID;
            this.Time = Time;
            this.BlockedByPersonID = BlockedByPersonID;
        }

        public bool AddPersonBlock()
        {
            this.ID = clsDataAccesseBlock.AddBlockPerson(this.BlockedByPersonID, this.BlockedID, this.Time);
            return this.ID > 0;
        }

        public static bool IsBlocked(int BlockByPersonID, int BlockedID)
        {
            return clsDataAccesseBlock.IsBlock(BlockByPersonID, BlockedID);
        }

        public static bool UnBlock(int BlockedByPersonID, int BlockedID)
        {
            return clsDataAccesseBlock.DeleteBlock(BlockedByPersonID, BlockedID);
        }

        public static DataTable GetAllBlocked(int BlockedByPersonID)
        {
            return clsDataAccesseBlock.GetAllPersonsBlocked(BlockedByPersonID);
        }


    }
}
