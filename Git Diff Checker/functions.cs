using System;
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
                //looks for differneces in the file and creates a list variable
                List<Change> differences = new DetailedDiff().Changes(file1, file2, Actions.Addition);

                //if the file returned contains values and is not empty
                if (differences.Count > 0)
                {
                    differences = HelperFunctions.SetLineNumbers(differences);
                    //displays the differences to the user
                    Display.OutputToUser(differences);

                    //creates a log file that holds all the differences found
                    LogFile.FileCreation(differences);
                }
                else
                {
                    //if there are no changes a different display function is called
                    Display.NoChange();
                }

                //returns an empty string if the the displaying and logfile creation was successful
                return string.Empty;
            }
        }

        //checks command word entered by the user
        public static string ValidCommand(string Command, string[] file1, string[] file2)
        {
            switch (Command)
            {
                //when the command given is diff
                case "diff":
                    //runs the test for file exists and returns any errorr messages returned from the check
                    return FileExist(file1, file2);

                //when the input is not diff, the user is displayed an errorr message    
                default:
                    return ":> [OUTPUT] Unknown command";
            }
        }
    }
}
