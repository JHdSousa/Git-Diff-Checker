﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Git_Diff_Checker.Enums;

namespace Git_Diff_Checker
{
    public class CommandCheck
    {
        
        //checks the two files both exist before trying to find differences
        private static string FileExist(string[] file1, string[] file2)
        {
            //checks that the file array isnt empty
            if (file1.Length == 0 || file2.Length == 0)
            {
                //if it is empty then the file entered could not be found by the system 
                return ":> [OUTPUT] One of the files selected does not exist";
            }
            else
            {
                //looks for additions in the file and creates a list variable
                var differences = new DetailedDiff().Changes(file1, file2, Actions.Addition);
                if(differences.Count > 0 )
                {
                    Display.OutputToUser(differences);


                    LogFile.FileCreation(differences);
                }
                else
                {
                    Display.NoChange();
                }

                return string.Empty;
            
            }
        }
        //checks command word entered by the user
        public static string ValidCommand(string Command, string[] file1, string[] file2)
        {
            switch (Command)
            {
                case "diff":
                    
                    return FileExist(file1,file2);
                    
                    
                default:
                    return ":> [OUTPUT] Unknown command";
                    
            }
        }
    }
}
