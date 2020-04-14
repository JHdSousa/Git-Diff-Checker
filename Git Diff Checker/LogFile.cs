using System;
using System.Collections.Generic;
using System.IO;


namespace Git_Diff_Checker
{
    class LogFile
    {
        public static string GetLogFile()
        {
           return $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\LogFile.txt";
        }
        public static void FileCreation(List<Change> differencesList, List<string> ChangedList)
        {
            
            try
            {
                using (StreamWriter writer = new StreamWriter(GetLogFile()))
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

