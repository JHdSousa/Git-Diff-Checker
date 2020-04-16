using System;
using System.Collections.Generic;
using System.Text;

namespace Git_Diff_Checker
{
    class Display
    {
        public static void OutputToUser(List<Change>differences, IEnumerable<string>connectedFiles) 
        {
            Console.Write(":> ");
            foreach(string differ in connectedFiles)
            {
                if (differ != " ")
                {
                    Console.Write($" {differ} ");
                }
                else
                {
                    Console.WriteLine();
                    Console.Write(":> ");
                    continue;
                }
            }



        }
    }
}
