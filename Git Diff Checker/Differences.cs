using System;
using System.Collections.Generic;
using System.Linq;
using Git_Diff_Checker.Enums;

namespace Git_Diff_Checker
{
    //basic class for checking if the files are different
    public class Diff
    {
        //set the display to red during the basic diff if the files are different
        public void DisplayColour()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        //basic difference checking function
        public virtual List<Change> Changes(string[] file1, string[] file2, Actions action)
        {
            List<Change> changeList = new List<Change>();
            if (Enumerable.SequenceEqual(file1, file2))
            {
                //if it is a match the text becomes green and the user is told the files are the same
                return changeList;
            }
            else
            {
                //basic return to show that the files are different, the content isnt relevent in this case
                changeList.Add(new Change { Word = "Different" });
                return changeList;
            }
        }
    }

    //class identifying detailed differences in the files
    public class DetailedDiff : Diff
    {
        //overrides the display colour from parent class to white as a reset
        public void OverrideDisplayColour()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        public override List<Change> Changes(string[] file1, string[] file2, Actions action)
        {
            int[] changes = new int[] { };
            List<Change> changeList = new List<Change>();

            if (Enumerable.SequenceEqual(file1, file2))
            {
                //if it is a match the text becomes green and the user is told the files are the same
                return changeList;
            }
            else
            {
                int positionFile2 = 0; //shows the current place in the original file
                int positionFile1 = 0; //shows the current place in the edited file

                //set the line number to 1 to start
                int LineNumber = 1;

                //to loop through all the values in the original array
                while (!HelperFunctions.EndOfFile(file2, positionFile2) && !HelperFunctions.EndOfFile(file1, positionFile1))
                {
                    if (file2[positionFile2] == string.Empty)
                    {
                        //increase of line number
                        LineNumber++;
                    }

                    if (file1[positionFile1] == file2[positionFile2])//for when the values are the same
                    {
                        //both positions are increased and the word is marked as unchanged in the changeList
                        changeList.Add(HelperFunctions.ReadUnchanged(file1, positionFile1));
                        positionFile2++;
                        positionFile1++;
                        continue;
                    }
                    else
                    {
                        //list created to hold possible additions that the application has come across in the file
                        List<Change> possibleAdditions = HelperFunctions.ReadAhead(file2[positionFile2], file1, positionFile1, Actions.Addition, ConsoleColor.Green);
                        
                        //list created to hold possible Removals that the application has come across in the file
                        List<Change> possibleRemovals = HelperFunctions.ReadAhead(file1[positionFile1], file2, positionFile2, Actions.Removal, ConsoleColor.Red);
                        List<Change> MergedChanges = HelperFunctions.MergeReadAhead(possibleAdditions, possibleRemovals);

                        changeList.AddRange(MergedChanges);

                        positionFile1 += MergedChanges.Count(x => x.Action != Actions.Removal);
                        positionFile2 += MergedChanges.Count(x => x.Action != Actions.Addition);
                    }
                }

                //if the ends of either of the files have been reached
                //if it is not the end of file 1
                if (!HelperFunctions.EndOfFile(file2, positionFile2))
                {
                    //the rest of file two is added and they are marked as removals as they are not in the first file as it has no contents left ot check
                    changeList.AddRange(HelperFunctions.ReadToEnd(file2, positionFile2, Actions.Removal, ConsoleColor.Red));
                }

                //if the end of file 1 has not been reached
                if (!HelperFunctions.EndOfFile(file1, positionFile1))
                {
                    //the rest of file two is added and they are marked as removals as they are not in the first file as it has no contents left ot check
                    changeList.AddRange(HelperFunctions.ReadToEnd(file1, positionFile1, Actions.Addition, ConsoleColor.Green));
                }

                //the changelist is returned
                return changeList;
            }
        }
    }
}

