using System;
using System.Collections.Generic;

namespace Git_Diff_Checker
{
    public class Display
    {
        //when the files are the same
        public static void NoChange() 
        {
            //displays to the user that the files they entered are the same
            Console.WriteLine(":> These files are the same");
        }

        //if the files entered did have differences
        public static void OutputToUser(List<Change>differences) 
        {
            //lineNumber variable to hold what the current line number is 
            int lineNumber = 0;
            Console.Write(":> ");

            //loop through everything stored in the change list
            foreach(Change difference in differences)
            {
                ////checks for empty string
                if (difference.Word != string.Empty )
                {
                    //check to see if the line number needs to be updated
                    if(lineNumber != difference.LineNumber)
                    {
                        //two blank lines added to space out the lines
                        Console.WriteLine();
                        Console.WriteLine();

                        //new line number added to the beginning of a new line before anymore of the changle list contents is displayed 
                        Console.Write($":> Line: {difference.LineNumber}", Console.ForegroundColor = ConsoleColor.Blue);

                        //line number counter increased to mathc the line number just displayed
                        lineNumber = difference.LineNumber;
                    }
                    //the next word displayed on the same line in the correct corrisponding colour
                    Console.Write($" {difference.Word} ", Console.ForegroundColor = difference.WordColour);
                }                
            }
            //once the file has displayed everything  a blank line is added
            Console.WriteLine();

            //the foreground colour is reset 
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
