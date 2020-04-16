using Git_Diff_Checker.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git_Diff_Checker
{
    public static class HelperFunctions
    {
        public static List<Change> ReadAhead(string searchString, string[] file, int currentFilePosition, Actions action)
        {
            List<Change> possibleChanges = new List<Change>();
            if(file.Length == currentFilePosition)
            {
                return possibleChanges;
            }
            for(int i = currentFilePosition; i < file.Length; i++)
            {
                if(searchString == file[i])
                {
                    break;
                }
                possibleChanges.Add(new Change { Word = file[i], Position = i, LineNumber = i, Action = action });
            }
            return possibleChanges;
        }
        public static bool EndOfFile(string[] file, int currentFilePosition)
        {
            return file.Length <= currentFilePosition;
        }
    }
}
