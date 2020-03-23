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
            FileSelection.ChooseFiles();

            }
            
        }
    }
}
