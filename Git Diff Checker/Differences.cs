using System;
using System.Collections.Generic;
using System.Linq;
using Git_Diff_Checker.Enums;

namespace Git_Diff_Checker
{
    //basic class foe checking if the files are different
    public class Diff
    {
        //set the display to white during the basic diff
        public void DisplayColour()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

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
                changeList.Add(new Change { Word = "Different"});
                return changeList;
            }
        }
    }
    //class identifying detailed differences in the files
    public class DetailedDiff : Diff
    {
        //overrides the display colour from parent class to green
        public void OverrideDisplayColour()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        //internal override string[] Changes(string[] file1, string[] file2, int longest)
        public override List<Change> Changes(string[] file1, string[] file2, Actions action)
        {
            HelperFunctions.ResetLineNumber();
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

                //        if (possibleAdditions == null)
                //        {
                //            //the removals are added to the changlist
                //            changeList.AddRange(possibleRemovals);
                //            //position in the files are ammended so that the section tat been added will not be rechecked
                //            positionFile2 += possibleRemovals.Count;
                //        }

                //        //if there are no removals
                //        if (possibleRemovals == null)
                //        {
                //            //the additions are added to the changelist
                //            changeList.AddRange(possibleAdditions);
                //            //position in the files are ammended so that the section tat been added will not be rechecked
                //            positionFile1 += possibleAdditions.Count;
                //        }
                //        //if there are values in both of the lists
                //        if (possibleRemovals != null && possibleAdditions != null)
                //        {
                //            //the shortest of the two is the one that weill be added to the changelist
                //            if (possibleRemovals.Count < possibleAdditions.Count)
                //            {
                //                //here removals are added to the changelist
                //                changeList.AddRange(possibleRemovals);
                //                //position in the files are ammended so that the section tat been added will not be rechecked
                //                positionFile2 += possibleRemovals.Count;
                //            }
                //            else
                //            {
                //                //here additions are added to the changelist
                //                changeList.AddRange(possibleAdditions);
                //                //position in the files are ammended so that the section tat been added will not be rechecked
                //                positionFile1 += possibleAdditions.Count;
                //            }
                //        }
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

