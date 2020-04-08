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
        public   void DisplayColour()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        //checking the file exists
        /* public static void FileExist (string[] file1, string[] file2)
         {
             if (file1.Length == 0 || file2.Length == 0)
             {
                 Console.WriteLine(":> [OUTPUT] One of the files selected does not exist");
             }
             else
             { Basicdiff(file1, file2); }
             }*/
        //runs basic diff check on the files
        /* public static void Basicdiff(string[] file1, string[] file2)
         {         
                 if (Enumerable.SequenceEqual(file1, file2))
                 {
                 //if it is a match the text becomes green and the user is told the files are the same
                 DisplayColour();
                 Console.WriteLine("The files are the same", Console.ForegroundColor);

                 }
                 else
                 {
                     //if it is a match the text becomes red and the user is told the files are not the same
                     Console.ForegroundColor = ConsoleColor.Red;
                     Console.WriteLine("The files are different", Console.ForegroundColor);
                 }            
         }*/
        //internal virtual string[] Changes(string[] file1, string[] file2, int longest)
        internal virtual List<Change> Changes(string[] file1, string[] file2, Actions action)
        {
            List<Change> changeList = new List<Change>();
            if (Enumerable.SequenceEqual(file1, file2))
            {
                //if it is a match the text becomes green and the user is told the files are the same
               return changeList;
            }
            else
            {
                int diffs = 0;
                for (int i =0; i < 5; i++)
                {
                    if (file1[i] == file2[i])
                    {
                     //   changes[i] = " ";
                    }
                    else
                    {
                        //changes[i] = i;
                    }
                }
                return changeList;
            }
        }
    }
    //class for if things have been added to the file
    class Addition : Diff
    {
        //overrides the display colour from parent class to green
        public void OverrideDisplayColour()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        //internal override string[] Changes(string[] file1, string[] file2, int longest)
        internal override List<Change> Changes(string[] file1, string[] file2, Actions action)
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
                int positionFile2 = 0; //i
                int positionFile1 = 0; //j
                int possibleFile1Offset = 0;

                while (positionFile2 <= file2.Length-1)
                {
                    if (file2.Length > positionFile2 && file1[positionFile1 + possibleFile1Offset] == file2[positionFile2])
                    {
                        positionFile2++;
                        positionFile1++;
                        continue;
                    }

                    List<Change> possibleAdditions = new List<Change>();

                    bool additionFound = false;

                    while (positionFile1 + possibleFile1Offset <= file1.Length)
                    {
                        if (file1.Length <= positionFile1 + possibleFile1Offset || file1[positionFile1 +possibleFile1Offset] != file2[positionFile2])
                        {
                            possibleAdditions.Add(new Change { Position = positionFile1 + possibleFile1Offset, Action = action });
                        }
                        else
                        {
                            additionFound = true;
                            break;
                        }

                       positionFile1++;
                    }

                    if (additionFound)
                    {
                        changeList.AddRange(possibleAdditions);
                    }
                    else
                    {
                        positionFile1 -= possibleAdditions.Count() - 1; // possibleAdditions.Count() -1;
                    }

                    possibleFile1Offset = 0;

                    possibleAdditions = new List<Change>();

                    positionFile2++;
                }

                if (positionFile2 >= file2.Length)
                {
                    for (var k = positionFile2; k <= file1.Length; k++)
                    {
                        changeList.Add(new Change { Position = k, Action = action });
                    }
                }
                //for (int i = 0; i <= file1.Length; i++)
                //{
                //    //if (file2.Length > i +offset && file1[i] == file2[i + offset])
                //    //{
                //    //    continue;
                //    //}
                //    //List<Change> possibleAdditions = new List<Change>();
                //    //bool additionFound = false;
                //    for(int j = i+offset; j <= file2.Length; j++)
                //    {
                //        //if (file1[j] != file2[i])
                //        //{
                //        //    possibleAdditions.Add(new Change { Position = j, Action = action });
                //        //}
                //        //else
                //        //{
                //        //    additionFound = true;
                //        //    break;
                //        //}
                //    }

                //    if (additionFound)
                //    {
                //        offset += possibleAdditions.Count();
                //        changeList.AddRange(possibleAdditions);
                //    }
                //}
                //return changes;
                return changeList;
            }
        }
    }

        
    //for if things have been removed from the file
    class Removed : Diff
    {
        //overrides the display colour from parent class to red
        public void OverrideDisplayColour()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        //internal override string[] Changes(string[] file1, string[] file2, int longest)
        //{
        //    string[] changes = new string[] { };
        //    if (Enumerable.SequenceEqual(file1, file2))
        //    {
        //        //if it is a match the text becomes green and the user is told the files are the same
        //        return changes;
        //    }
        //    else
        //    {
        //       int Removed = 0;
        //        for (int i = 0; i < longest; i++)
        //        {
        //            if (file1[i] != file2[i+ Removed] && file2[i + 1] == file1[i] && i +1 <= longest)
        //            {
        //                changes[i] = i.ToString();
        //                Removed += 1;
        //            }
        //            else
        //            {
        //                changes[i] = " ";
        //            }
        //        }
        //        return changes;
        //    }
        //}
    }
    }

