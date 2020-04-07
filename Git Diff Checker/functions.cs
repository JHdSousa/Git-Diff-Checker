﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Git_Diff_Checker
{
    public class CommandCheck 
    {
        /*  //function to compare the two files 
          public static void diff(string[] file1, string[] file2)
          {
              if (file1.Length == 0 || file2.Length == 0)
              {
                  Console.WriteLine(":> [OUTPUT] One of the files selected does not exist");
              }
              else
              {
                  if (Enumerable.SequenceEqual(file1, file2))
                  {
                      //if it is a match the text becomes green and the user is told the files are the same
                      Console.ForegroundColor = ConsoleColor.Green;
                      Console.WriteLine("The files are the same", Console.ForegroundColor);

                  }
                  else
                  {
                      //if it is a match the text becomes red and the user is told the files are not the same
                      Console.ForegroundColor = ConsoleColor.Red;
                      Console.WriteLine("The files are different", Console.ForegroundColor);
                  }
              }


          }*/
          //checks the two files both exist before trying to find differences
        public static void FileExist(string[] file1, string[] file2)
        {
            if (file1.Length == 0 || file2.Length == 0)
            {
                Console.WriteLine(":> [OUTPUT] One of the files selected does not exist");
            }
            else
            { Addition.Changes(file1, file2,5); }
        }
        //checks command word entered by the user
        public static void CheckCommand(string Command, string[] file1, string[] file2)
        {
            switch (Command)
            {
                case "diff":
                    try
                    {
                        FileExist(file1,file2);
                    }
                    catch (NullReferenceException )
                    {
                    }
                    break;
                default:
                    Console.WriteLine(":> [OUTPUT] Unknown command");
                    break;
            }
        }
    }
}
