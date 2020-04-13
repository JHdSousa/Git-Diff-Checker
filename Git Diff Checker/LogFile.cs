using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Git_Diff_Checker.Enums;

namespace Git_Diff_Checker
{
    class LogFile
    {
        public static void FileCreation(List<Change> differencesList, List<string> ChangedList)
        {
            string path = @"c:\Desktop\LogFile.txt";
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    foreach (var difference in differencesList)
                    {
                        writer.WriteLine($"Position {difference.Position} Type {difference.Action}");
                    }
                }

            }
            catch (NullReferenceException) { Console.WriteLine("no values found"); }
        }
    }
}

