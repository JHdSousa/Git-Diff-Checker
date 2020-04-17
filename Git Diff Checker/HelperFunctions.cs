using Git_Diff_Checker.Enums;
using System;
using System.Collections.Generic;

namespace Git_Diff_Checker
{
    public static class HelperFunctions
    {
        private static int lineNumber = 1;

        private static bool NewLine(string[] file, int currentFilePosition)
        {
            return (file[currentFilePosition] == "");
        }

        public static Change ReadUnchanged(string[] file, int currentFilePosition)
        {
            return new Change { Word = file[currentFilePosition], Position = currentFilePosition, LineNumber = lineNumber, Action = Actions.Unchanged, WordColour = ConsoleColor.White };
        }

        public static List<Change> ReadAhead(string searchString, string[] file, int currentFilePosition, Actions action, ConsoleColor colour)
        {
            bool foundMatch = false;
            List<Change> possibleChanges = new List<Change>();

            if (file.Length == currentFilePosition)
            {
                return possibleChanges;
            }

            for (int i = currentFilePosition; i < file.Length; i++)
            {
                if (action == Actions.Addition && NewLine(file, i))
                {
                    lineNumber++;
                }
                if (searchString == file[i])
                {
                    foundMatch = true;
                    break;
                }

                possibleChanges.Add(new Change { Word = file[i], Position = i, LineNumber = lineNumber, Action = action, WordColour = colour });
            }

            if (!foundMatch)
            {
                possibleChanges = null;
            }

            return possibleChanges;
        }
        public static bool EndOfFile(string[] file, int currentFilePosition)
        {
            return file.Length <= currentFilePosition;
        }

        public static List<Change> ReadToEnd(string[] file, int currentFilePosition, Actions action, ConsoleColor colour)
        {
            List<Change> possibleChanges = new List<Change>();
            if (file.Length == currentFilePosition)
            {
                return possibleChanges;
            }

            for (int i = currentFilePosition; i < file.Length; i++)
            {
                if (action == Actions.Addition && NewLine(file, i))
                {
                    lineNumber++;
                }
                possibleChanges.Add(new Change { Word = file[i], Position = i, LineNumber = lineNumber, Action = action, WordColour = colour });
            }
            return possibleChanges;
        }
    }

}
