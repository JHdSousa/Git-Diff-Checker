using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using Git_Diff_Checker.Properties;


namespace Git_Diff_Checker
{
    class functions
    {
        public static void ChooseFiles()
        {
            Console.WriteLine("Avalible files:" +
                "1. File1  " +
                "2. File2  " +
                "3. File3");
          string FileChoice1 =  Console.ReadLine();
          GetFile(FileChoice1);
        }
        private static void GetFile(string choice)
        {

        }


    }
}
