using System;
using System.Data;

namespace MyLibrary
{
    public class clsDate
    {
        public static DateTime GetMaxDate()
        {

            DateTime dt1 = DateTime.Now;

            DateTime dt2 = DateTime.Now;
            int dt1Year = dt1.Year;
            while (dt2.Year - dt1Year != 18)
            {
                dt1Year--;
            }

            return new DateTime(dt1Year, dt1.Month, dt1.Day);
        }

        public static DateTime GetBirthDate(decimal Age)
        {
            DateTime dt1 = DateTime.Now;

            DateTime dt2 = DateTime.Now;
            int dt1Year = dt1.Year;
            while (dt2.Year - dt1Year != Age)
            {
                dt1Year--;
            }

            return new DateTime(dt1Year, dt1.Month, dt1.Day);
        }

    }
}
