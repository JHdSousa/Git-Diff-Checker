using System;
using System.Collections.Generic;
using System.Text;
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
    //class for if things have been added to the file
    public class Addition : Diff
    {
        //overrides the display colour from parent class to green
        public void OverrideDisplayColour()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        //internal override string[] Changes(string[] file1, string[] file2, int longest)
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
                        changeList.Add(new Change { Word = file1[positionFile1], Position = positionFile1, LineNumber = LineNumber, Action = Actions.Unchanged });
                        positionFile2++;
                        positionFile1++;
                        continue;
                    }
                    else
                    {
                        //list created to hold possible additions that the application has come across in the file
                        List<Change> possibleAdditions = HelperFunctions.ReadAhead(file2[positionFile2], file1, positionFile1, Actions.Addition);
                        List<Change> possibleRemovals = HelperFunctions.ReadAhead(file1[positionFile1], file2, positionFile2, Actions.Removal);
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
                if(HelperFunctions.EndOfFile(file1, positionFile1))
                {
                    changeList.AddRange(HelperFunctions.ReadAhead(string.Empty, file2, positionFile2, Actions.Removal));
                }
                if (HelperFunctions.EndOfFile(file2, positionFile2)) 
                {
                    changeList.AddRange(HelperFunctions.ReadAhead(string.Empty, file1, positionFile1, Actions.Addition));
                }
                return changeList;
            }
        }


        //for if things have been removed from the file
        public class Removed : Diff
        {
            //overrides the display colour from parent class to red
            public void OverrideDisplayColour()
            {
                Console.ForegroundColor = ConsoleColor.Red;
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
                    int LineNumber = 1;

                    //to loop through all the values in the original array
                    while (positionFile2 <= file2.Length - 1)
                    {
                        if (file2[positionFile2] == string.Empty)
                        {
                            LineNumber++;
                        }
                        if (file2.Length > positionFile2 && file1.Length > 0 && positionFile1 < file1.Length && file1[positionFile1] == file2[positionFile2])//for when the values are the same
                        {
                            changeList.Add(new Change { Word = file1[positionFile1], Position = positionFile1, LineNumber = LineNumber, Action = Actions.Unchanged });
                            //both positions are increased
                            positionFile2++;
                            positionFile1++;
                            continue;
                        }
                        //list created to hold possible additions that the application has come across in the file
                        List<Change> possibleRemovals = new List<Change>();
                        //boolean which is originally set to false and becomes true if the difference found is an addition
                        bool RemovalFound = false;
                        //while loop to loop through all the values in the edited file
                        while (positionFile1 <= file1.Length)
                        {
                            //as long as the current position is not longer then the file length or postion is not the same as the one in original file
                            if (file1.Length - 1 >= positionFile1 && file1[positionFile1] != file2[positionFile2])
                            {
                                //a possible removal has been found and added to the list, continaing enums for position and action
                                possibleRemovals.Add(new Change { Word = file2[positionFile1], Position = positionFile1, LineNumber = LineNumber, Action = action });
                                positionFile1++;
                                continue;
                            }
                            else
                            {
                                //if the value being searched for is finally found in the edited file 
                                RemovalFound = true;
                                break;
                            }
                            //position in edited file increased

                        }
                        //checks if the possible additions have been marked as real additions
                        if (RemovalFound)
                        {
                            //adds the possible values to the channgelist
                            changeList.AddRange(possibleRemovals);
                            positionFile1 = positionFile2;
                        }
                        else
                        {
                            //resets position in edited file if possible removals  not confirmed
                            positionFile1 -= possibleRemovals.Count() - 1; // possibleAdditions.Count() -1;
                        }
                        //reset for possible addiotns list
                        possibleRemovals = new List<Change>();
                        //increase position in original file
                        positionFile2++;
                    }
                    //if end of original file reached but values left in file one they are classed as additions
                    if (positionFile1 > file1.Length && positionFile2 <= file2.Length)
                    {
                        //each value left in edited file
                        for (var k = positionFile1; k <= file2.Length; k++)
                        {
                            //each value added to the change file
                            changeList.Add(new Change { Word = file2[k - 1], Position = k - 1, Action = action });
                        }
                    }
                    //complete change list returned 
                    return changeList;
                }
            }
        }
    }
}

