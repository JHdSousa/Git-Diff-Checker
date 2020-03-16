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
            Console.ForegroundColor = ConsoleColor.White;
            FileSelection.ChooseFile1();
        }
    }
}
