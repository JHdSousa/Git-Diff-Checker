using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.IO;
using Git_Diff_Checker.Enums;

namespace Git_Diff_Checker
{
    class LogFile
    {
        public void FileCreation(List<Change>differencesList)
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
    }
}
