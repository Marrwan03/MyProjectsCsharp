using System;
using System.IO;

namespace MyLibrary
{
    public class clsFiles
    {
        public static void LoginDataInFile(string Username, string Password, bool Delete = false, bool Add = false)
        {
            string Path = @"C:\Users\lenovo\OneDrive\Desktop\LoginData\";
            string LoginData = Username + "#" + Password;
            if (Add)
                File.WriteAllText(Path + "LoginData.txt", LoginData);
            if (Delete)
            {
                if (File.Exists(Path + "LoginData.txt"))
                {
                    File.Delete(Path + "LoginData.txt");
                }
            }

        }
    }
}
