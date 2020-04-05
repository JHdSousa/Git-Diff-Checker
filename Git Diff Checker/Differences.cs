using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Git_Diff_Checker
{
    public class Diff
    {
       public  static void DisplayColour()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        } 
        public static void FileExist (string[] file1, string[] file2)
        {
            if (file1.Length == 0 || file2.Length == 0)
            {
                Console.WriteLine(":> [OUTPUT] One of the files selected does not exist");
            }
            else
            { Basicdiff(file1, file2); }
            }
        public static void Basicdiff(string[] file1, string[] file2)
        {         
                if (Enumerable.SequenceEqual(file1, file2))
                {
                //if it is a match the text becomes green and the user is told the files are the same
                DisplayColour();
                Console.WriteLine("The files are the same", Console.ForegroundColor);

                }
                else
                {
                    //if it is a match the text becomes red and the user is told the files are not the same
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The files are different", Console.ForegroundColor);
                }            
        }
    }
    class Addition : Diff
    {
        public static void DisplayColour()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }

    class Removed : Diff
    {
        public static void DisplayColour()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
    }
}
