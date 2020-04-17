using Git_Diff_Checker.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Git_Diff_Checker
{
    public static class HelperFunctions
    {
        //private variable created for watching the line number within this specific class
        private static int lineNumber = 1;

        //method which resets the value of line number back to 1
        public static void ResetLineNumber()
        {
            lineNumber = 1;
        }

        //function to check for a new line
        private static bool NewLine(string[] file, int currentFilePosition)
        {
            //returns a bool for if there was a space or not
            return (file[currentFilePosition] == "");
        }

        //function for when the words are the same 
        public static Change ReadUnchanged(string[] file, int currentFilePosition)
        {
            //the word's action is set to be unchanged and the necessary extra attributes are added ot the list as well
            return new Change { Word = file[currentFilePosition], Position = currentFilePosition, LineNumber = lineNumber, Action = Actions.Unchanged, WordColour = ConsoleColor.White };
        }

        //funciton to read ahead in the file to search for a specific character
        public static List<Change> ReadAhead(string searchString, string[] file, int currentFilePosition, Actions action, ConsoleColor colour)
        {
            //bool to flag when a match is found
            bool foundMatch = false;
            //new list is created to hold possibles
            List<Change> possibleChanges = new List<Change>();
            //when the end of the file is reached
            if (file.Length == currentFilePosition)
            {
                //changes found get returned
                return possibleChanges;
            }
            //loops through the file from the specified position until the end of the file is met
            for (int i = currentFilePosition; i < file.Length; i++)
            {
                //if the action is a removal and a new line has been found
                if (action == Actions.Removal && NewLine(file, i))
                {
                    //line number is increased
                    lineNumber++;

                }
                //if the searchstring is found
                if (searchString == file[i])
                {
                    //match flag updated and the loop is broken out of
                    foundMatch = true;
                    break;
                }
                //values added to the possible changes list
                possibleChanges.Add(new Change { Word = file[i], Position = i, LineNumber = lineNumber, Action = action, WordColour = colour });
            }
            ////when the match flag is not updated
            //if (!foundMatch)
            //{
            //    //changes list is set to null 
            //    possibleChanges = null;
            //}
            ////possible changes are returned
            return possibleChanges;
        }

        //bool function checking if the end of the file has been met
        public static bool EndOfFile(string[] file, int currentFilePosition)
        {
            return file.Length <= currentFilePosition;
        }
        public static bool EndOfFile(List<Change> file, int currentFilePosition)
        {
            return file.Count <= currentFilePosition;
        }

        //function to return any values left on the end of a file
        public static List<Change> ReadToEnd(string[] file, int currentFilePosition, Actions action, ConsoleColor colour)
        {
            //new list made to hold changes
            List<Change> possibleChanges = new List<Change>();
            //check fo rhte end of file being met
            if (file.Length == currentFilePosition)
            {
                //changes returned
                return possibleChanges;
            }
            //loops through all values in the file left after the given position
            for (int i = currentFilePosition; i < file.Length; i++)
            {
                //chacks for new line number
                if (action == Actions.Removal && NewLine(file, i))
                {
                    //increase of line number
                    lineNumber++;
                }
                //values added to the change list
                possibleChanges.Add(new Change { Word = file[i], Position = i, LineNumber = lineNumber, Action = action, WordColour = colour });
            }
            //change list returned
            return possibleChanges;
        }

        private static int offsetCount(List<Change> possibleAdditions, List<Change> possibleRemovals, int offset)
        {
            bool firstFound = false;
            bool nextDifference = false;
            int matchCount = 0;
            int addPosition = 0;
            int removePosition = 0;

            if (possibleAdditions.Count < possibleRemovals.Count)
            {
                removePosition = offset;
            }
            else
            {
                addPosition = offset;
            }

            while (!nextDifference && !EndOfFile(possibleAdditions, addPosition) && !EndOfFile(possibleRemovals, removePosition)) 
            {
                if(possibleAdditions[addPosition].Word == possibleRemovals[removePosition].Word)
                {
                    firstFound = true;
                    matchCount++;
                }
                if(firstFound && possibleAdditions[addPosition].Word != possibleRemovals[removePosition].Word)
                {
                    nextDifference = true;
                }
                addPosition++;
                removePosition++;
            
            }
            return matchCount; 
        }

        public static List<Change> MergeReadAhead(List<Change> possibleAdditions, List<Change> possibleRemovals) 
        {
            var shorterList = Math.Min(possibleAdditions.Count, possibleRemovals.Count);
            var longerList = Math.Max(possibleAdditions.Count, possibleRemovals.Count);
            Dictionary<int, int> matchCount = new Dictionary<int, int>();

            for(int i = 0; i < longerList - shorterList; i++)
            {
                matchCount.Add(i, offsetCount(possibleAdditions, possibleRemovals, i));
            }

            var j = matchCount.FirstOrDefault(x => x.Value == matchCount.Values.Max()).Key;
            List<Change> mergedChanges = new List<Change>();
            int k = 0;
            while(k < j)
            {
                mergedChanges.Add(new Change { Word = possibleAdditions[k].Word, Position = possibleAdditions[k].Position, LineNumber = possibleAdditions[k].LineNumber, Action = possibleAdditions[k].Action, WordColour = possibleAdditions[k].WordColour });
                k++;
            }
            

            for (int i = 0; i < shorterList; i++)
            {                
                if(possibleAdditions[i+j].Word == possibleRemovals[i].Word)
                {
                    break;
                    //mergedChanges.Add(new Change { Word = possibleAdditions[i].Word, Position = possibleAdditions[i].Position, LineNumber = possibleAdditions[i].LineNumber, Action = Actions.Unchanged, WordColour = ConsoleColor.White});
                }

                  mergedChanges.Add(possibleAdditions[i + j]);
                  mergedChanges.Add(possibleRemovals[i]);
            }

            return mergedChanges;
        }

    }

}
