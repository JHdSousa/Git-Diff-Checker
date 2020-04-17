using System;
using System.Collections.Generic;
using System.Linq;
using Git_Diff_Checker.Enums;

namespace Git_Diff_Checker
{
    //basic class foe checking if the files are different
    public class Diff
    {
        //set the display to blue during the basic diff
        public void DisplayColour()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
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

                int LineNumber = 1;

                //to loop through all the values in the original array

                while (!HelperFunctions.EndOfFile(file2, positionFile2) && !HelperFunctions.EndOfFile(file1, positionFile1))
                {
                    if (file2[positionFile2] == string.Empty)
                    {
                        LineNumber++;
                    }
                    if (file1[positionFile1] == file2[positionFile2])//for when the values are the same
                    {
                        //both positions are increased
                        changeList.Add(HelperFunctions.ReadUnchanged(file1, positionFile1));
                        positionFile2++;
                        positionFile1++;
                        continue;
                    }
                    else
                    {
                        //list created to hold possible additions that the application has come across in the file
                        List<Change> possibleAdditions = HelperFunctions.ReadAhead(file2[positionFile2], file1, positionFile1, Actions.Addition, ConsoleColor.Green);
                        List<Change> possibleRemovals = HelperFunctions.ReadAhead(file1[positionFile1], file2, positionFile2, Actions.Removal, ConsoleColor.Red);

                        if (possibleAdditions == null && possibleRemovals == null)
                        {
                            break;
                        }
                        if (possibleAdditions == null)
                        {
                            changeList.AddRange(possibleRemovals);
                            positionFile2 += possibleRemovals.Count;
                        }

                        if (possibleRemovals == null)
                        {
                            changeList.AddRange(possibleAdditions);
                            positionFile1 += possibleAdditions.Count;
                        }

                        if (possibleRemovals != null && possibleAdditions != null)
                        {
                            if (possibleRemovals.Count < possibleAdditions.Count)
                            {
                                changeList.AddRange(possibleRemovals);
                                positionFile2 += possibleRemovals.Count;
                            }
                            else
                            {
                                changeList.AddRange(possibleAdditions);
                                positionFile1 += possibleAdditions.Count;
                            }
                        }
                    }
                }

                if (!HelperFunctions.EndOfFile(file2, positionFile2))
                {
                    changeList.AddRange(HelperFunctions.ReadToEnd(file2, positionFile2, Actions.Removal, ConsoleColor.Red));
                }

                if (!HelperFunctions.EndOfFile(file1, positionFile1))
                {
                    changeList.AddRange(HelperFunctions.ReadToEnd(file1, positionFile1, Actions.Addition, ConsoleColor.Green));
                }
                return changeList;
            }
        }


    }
}

