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
                //looks for additions in the file and creates a list variable
                var differences = new Addition().Changes(file1, file2, Actions.Addition);
                //adds more values to the list if there are removals also found in the file
                //differences.AddRange(new Removed().Changes(file1, file2, Actions.Removal));
                //joines the two original files into one file contianing all the changes within it
                IEnumerable<string> changedFile = (from theFiles in file1.Union(file2)
                                            select theFiles).ToList<string>();
                Display.OutputToUser(differences, changedFile);


                LogFile.FileCreation(differences);

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
