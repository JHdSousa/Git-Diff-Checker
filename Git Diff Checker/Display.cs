using System;
using System.Collections.Generic;

namespace Git_Diff_Checker
{
    class Display
    {
        public static void NoChange() 
        {
            Console.WriteLine(":> These files are the same");
        }
        public static void OutputToUser(List<Change>differences) 
        {
            var lineNumber = 0;
            Console.Write(":> ");
            foreach(var difference in differences)
            {
                if (difference.Word != string.Empty )
                {
                    if(lineNumber != difference.LineNumber)
                    {
                        Console.WriteLine();
                        Console.Write($":> Line: {difference.LineNumber}", Console.ForegroundColor = ConsoleColor.Blue);
                        lineNumber = difference.LineNumber;
                    }
                    Console.Write($" {difference.Word} ", Console.ForegroundColor = difference.WordColour);
                }                
            }

            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
