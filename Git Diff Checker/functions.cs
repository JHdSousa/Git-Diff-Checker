using System;
using System.Collections.Generic;
using System.Text;


namespace Git_Diff_Checker
{
    class functions
    {
        public static void diff(string file1, string file2)
        {
            if(file1 == file2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The files are the same", Console.ForegroundColor);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The files are different", Console.ForegroundColor);
            }
            System.Environment.Exit(0);
        }
    }
}
