using System;
using System.Data;

namespace MyLibrary
{
    public class clsTextProcessing
    {
       private static bool IsLetter(char C1)
        {
            for (int i = 65; i < 95; i++)
            {
                if (C1 == i)
                    return true;
            }
            return false;
        }

       public static bool TextHasLetter(string S1)
        {


            for (int i = 0; i < S1.Length; i++)
            {
                if (IsLetter(char.ToUpper(S1[i])))
                    return true;
            }

            return false;
        }
       
    }
}
