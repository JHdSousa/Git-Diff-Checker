using System.Collections.Generic;

namespace Git_Diff_Checker
{
    public class FileSelection
    {
        private string[] file { get; set; }
        private int FileLen = 0;

        //constructors for file variables
        public FileSelection(string fileName)
        {
            file = GetFile(fileName);
            FileLen = file.Length;
        }

        //getter for file contnets
       public string[] GetContents()
        {
            return file;
        }

        //getter for file length
        public int GetLength()
        {
            return FileLen;
        }

       //funciton to remove the extra third space in the file created by new lines
       private static string[] RemoveExtraSpaces(string[] file)
        {
            //new list made to hold the edited file contents
            List<string> editFile = new List<string> { };
            //loop to cycle through all the values in the current file
            for (var i = 0; i < file.Length ; i++)
            {
                //if its a single blank space or not 
                if(!(file[i] == string.Empty && file[i + 1] == string.Empty))
                {
                    //value added to the list
                    editFile.Add(file[i]);
                }
                //if there are three blanks in a row
                else if (file[i] == string.Empty && file[i + 1] == string.Empty && file[i + 2] == string.Empty)
                {
                    //two blanks are added to the file while the other is discarded
                    editFile.Add(file[i]);
                    editFile.Add(file[i+1]);
                    //i increased by two to make sure the thrid space doesnt get caught by the search for a singluar one
                    i+=2;
                }
            }
            //list converted to an array before being returned
            return editFile.ToArray();
        }
        
        //assigns the users choice of file and converts the array to a string each time. 
        //the string is then returned to be used in the comparative function
        public static string[] GetFile(string fileChoice)
        {
            //empty string made to start so that it can be check for contents to see if a file was found or not later on
            string[]  file = new string[] { };
            switch (fileChoice)
            {
                //the file corrispoding with the user input is appended into the file variable
                case "GitRepositories_1a.txt":
                    file = Properties.Resources.GitRepositories_1a.Split();
                    break;

                case "GitRepositories_1b.txt":
                    file = Properties.Resources.GitRepositories_1b.Split();
                    break;

                case "GitRepositories_2a.txt":
                    file = Properties.Resources.GitRepositories_2a.Split();
                    break;

                case "GitRepositories_2b.txt":
                    file = Properties.Resources.GitRepositories_2b.Split();
                    break;

                case "GitRepositories_3a.txt":
                    file = Properties.Resources.GitRepositories_3a.Split();
                    break;

                case "GitRepositories_3b.txt":
                    file = Properties.Resources.GitRepositories_3b.Split();
                    break;

                case "3.txt":
                    file = Properties.Resources.file3.Split();
                    break;

                case "2.txt":
                    file = Properties.Resources.file2.Split();
                    break;

                case "1.txt":
                    file = Properties.Resources.file1.Split();
                    break;
            }
            //removes the extra thrid space created by a  new line which is blank
            return RemoveExtraSpaces(file);
        }
    }
}
