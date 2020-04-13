using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using Git_Diff_Checker.Properties;


namespace Git_Diff_Checker
{
    public class FileSelection
    {
        private string[] file { get; set; }
        private int FileLen = 0;
        public FileSelection(string fileName)
        {
            file = GetFile(fileName);
            FileLen = file.Length;
        }
       public string[] GetContents()
        {
            return file;
        }
        public int GetLength()
        {
            return FileLen;
        }
        //choosing the first file
       /* public static void ChooseFiles()
        {
            Console.WriteLine(":> [INPUT] ");
          string [] UserIn  = Console.ReadLine().Split();
            try
            {
                //reading in files as arrays
            string[] file1 =  GetFile(UserIn[1]);
            string[] file2 = GetFile(UserIn[2]);
                //check for command word
             CommandCheck.CheckCommand(UserIn[0], file1, file2);
            }
            catch
            {
                Console.WriteLine("Input missing component, please use the format: diif file1.txt fil2.txt");
            }
            
        }*/
        
        
        //assigns the users choice of file and converts the array to a string each time. 
        //the string is then returned to be used in the comparative function
        public static string[] GetFile(string fileChoice)
        {
            string[]  file = new string[] { };
            switch (fileChoice)
            {
                case "GitRepositories_1a.txt":
                    file = Properties.Resources.GitRepositories_1a.Split();
                    break;

                case "GitRepositories_1b.txt":
                    file = Properties.Resources.GitRepositories_1b.Split();
                    break;

                case "GitRepositories_2a.txt":
                    file = Properties.Resources.GitRepositories_2a.Split();
                    break;

                case "3.txt":
                    file = Properties.Resources.GitRepositories_2b.Split();
                    break;

                case "2.txt":
                    file = Properties.Resources.GitRepositories_3a.Split();
                    break;

                case "1.txt":
                    file = Properties.Resources.GitRepositories_3b.Split();
                    break;
            }
            return file;
        }


    }
}
