using System;
using System.Collections.Generic;
using System.Linq;
using Git_Diff_Checker.Enums;

namespace Git_Diff_Checker
{
    public static class HelperFunctions
    {
        //function to add words that are the same to the change list marked as unchanged 
        public static Change ReadUnchanged(string[] file, int currentFilePosition)
        {            
            return new Change { Word = file[currentFilePosition], Position = currentFilePosition, Action = Actions.Unchanged, WordColour = ConsoleColor.White };
        }

        //function to set the line number for the each word in the list
        internal static List<Change> SetLineNumbers(List<Change> differences)
        {
            int lineNumber = 1;
            foreach(Change difference in differences)
            {
                if (difference.Word == string.Empty) 
                {
                    lineNumber++;
                }
                difference.LineNumber = lineNumber;
            }

            return differences;
        }

        //function to read ahead in the file to search for a specific character
        public static List<Change> ReadAhead(string searchString, string[] file, int currentFilePosition, Actions action, ConsoleColor colour)
        {
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
                if (searchString == file[i])
                {
                    break;
                }

                //values added to the possible changes list
                possibleChanges.Add(new Change { Word = file[i], Position = i, Action = action, WordColour = colour });
            }

            return possibleChanges;
        }

        //bool function checking if the end of the file has been met, polymorphism is used with the follwoing 2 functions
        //so that lists can be chacked just like an array
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
                return possibleChanges;
            }

            //loops through all values in the file left after the given position
            for (int i = currentFilePosition; i < file.Length; i++)
            {
               possibleChanges.Add(new Change { Word = file[i], Position = i, Action = action, WordColour = colour });
            }

            return possibleChanges;
        }

        //function to check if there is an offset between the addition and removal files
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
            //loop while the next difference is not found and there are still values in the list
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

                //increase the position variables so that the loop doesn't get stuck in a loop
                addPosition++;
                removePosition++;            
            }

            return matchCount; 
        }

        //function that merges the possible additions and removals into a single change list that contains all the 
        //correct changes within the section of the file. taking into account the offset found.
        public static List<Change> MergeReadAhead(List<Change> possibleAdditions, List<Change> possibleRemovals) 
        {
            List<Change> shorterList;
            List<Change> longerList;

            //check for which of the two files is shorter and assigning them to variables to be held for easier use
            if(possibleAdditions.Count < possibleRemovals.Count)
            {
                shorterList = possibleAdditions;
                longerList = possibleRemovals;
            }
            else
            {
                shorterList = possibleRemovals;
                longerList = possibleAdditions;
            }

            //dictionary used to decide which offset is the correct one to use
            Dictionary<int, int> matchCount = new Dictionary<int, int>();

            for(int i = 0; i < longerList.Count - shorterList.Count; i++)
            {
                //building of the dic
                matchCount.Add(i, offsetCount(shorterList, longerList, i));
            }

            //checks the dictionary for the correct offset to use
            int offset = matchCount.FirstOrDefault(x => x.Value == matchCount.Values.Max()).Key;
            List<Change> mergedChanges = new List<Change>();

            //merging the two arrays togetehr using the correct offset and stopping when the values match in the arrays again
            for(int i = 0; i < offset; i++)
            {
                mergedChanges.Add(longerList[i]);
            }
            //merging the arrays while accounting for the left over offset
            for(int i = 0; i < shorterList.Count; i++)
            {                
                if(shorterList[i].Word == longerList[i+offset].Word)
                {
                    break;
                }

                mergedChanges.Add(longerList[i + offset]);
                mergedChanges.Add(shorterList[i]);
            }
            return mergedChanges;
        }
    }
}
