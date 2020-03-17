using System;
using System.Collections.Generic;
using System.Text;


namespace Git_Diff_Checker
{
    class functions
    {
        //function to compare the two files 
        public static void diff(string file1, string file2)
        {
            if(file1 == file2)
            {
                //if it is a match the text becomes green and the user is told the files are the same
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The files are the same", Console.ForegroundColor);
            }
            else
            {
                //if it is a match the text becomes red and the user is told the files are not the same
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The files are different", Console.ForegroundColor);
            }
            //closes the program when the check is complete
            System.Environment.Exit(0);
        }
    }
}
