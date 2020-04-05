using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Git_Diff_Checker
{
    //basic class foe checking if the files are different
    public class Diff
    {
        //set the display to blue during the basic diff
        public  static void DisplayColour()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        } 
        //checking the file exists
        public static void FileExist (string[] file1, string[] file2)
        {
            if (file1.Length == 0 || file2.Length == 0)
            {
                Console.WriteLine(":> [OUTPUT] One of the files selected does not exist");
            }
            else
            { Basicdiff(file1, file2); }
            }
        //runs basic diff check on the files
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
    //class for if things have been added to the file
    class Addition : Diff
    {
        //overrides the display colour from parent class to green
        public static void OverrideDisplayColour()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public static void Additions(string[] file1, string[] file2)
        {

        }
    }
    //for if things have been removed from the file
    class Removed : Diff
    {
        //overrides the display colour from parent class to red
        public static void OverrideDisplayColour()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        public static void Removals(string[] file1, string[] file2)
        {

        }
    }
}
