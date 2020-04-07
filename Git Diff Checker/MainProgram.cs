using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using Git_Diff_Checker.Properties;

namespace Git_Diff_Checker
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            while (true)
            {
            //sets the text colour to white
            Console.ForegroundColor = ConsoleColor.White;
                //sends the user to select the first file
                Console.WriteLine(":> [INPUT] ");
                string[] UserIn = Console.ReadLine().Split();
                try
                {
                    //reading in files as arrays
                    FileSelection file1 = new FileSelection(UserIn[1]);
                    FileSelection file2 = new FileSelection(UserIn[2]);
                    //check for command word
                    CommandCheck.CheckCommand(UserIn[0], file1.GetContents(), file2.GetContents());
                }
                catch
                {
                    Console.WriteLine("Input missing component, please use the format: diif file1.txt fil2.txt");
                }
                //FileSelection.ChooseFiles();

            }
            
        }
    }
}
