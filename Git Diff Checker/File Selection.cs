using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using Git_Diff_Checker.Properties;


namespace Git_Diff_Checker
{
    class FileSelection
    {
        //choosing the first file
        public static void ChooseFile1()
        {
            Console.WriteLine("Please select file from avalible files: " + "\n"+
                "1. File_1a  " +
                "2. File_1b  " +
                "3. File2a  " +
                "4. File2b  " +
                "5. File3a  " +
                "6. File3b ");
          string FileChoice1 =  Console.ReadLine();
          string FileCheck1 = GetFile(FileChoice1);
            ChooseFile2(FileCheck1);
        }
        //choosing the second file
        public static void ChooseFile2(string fileOne)
        {
            Console.WriteLine("Please select file from avalible files: " + "\n" +
                "1. File_1a  " +
                "2. File_1b  " +
                "3. File_2a  " +
                "4. File_2b  " +
                "5. File_3a  " +
                "6. File_3b ");
            string FileChoice2 = Console.ReadLine();
            string FileCheck2 = GetFile(FileChoice2);
            functions.diff(fileOne, FileCheck2);
            
        }
        //assigns the users choice of file and converts the array to a string each time. 
        //the string is then returned to be used in the comparative function
        private static string GetFile(string choice)
        {
            if(choice == "1")
            {
                string[] FileC = Properties.Resources.GitRepositories_1a.Split("\n");
                string FileString = string.Join(",", FileC);
                return FileString;
            }
            else if(choice== "2")
            {
                string[] FileC = Properties.Resources.GitRepositories_1b.Split("\n");
                string FileString = string.Join(",", FileC);
                return FileString;
            }
           else if(choice== "3")
            {
                string[] FileC = Properties.Resources.GitRepositories_2a.Split("\n");
                string FileString = string.Join(",", FileC);
                return FileString;
            }
            else if(choice== "4")
            {
                string[] FileC = Properties.Resources.GitRepositories_2b.Split("\n");
                string FileString = string.Join(",", FileC);
                return FileString;
            }
            else if(choice== "5")
            {
                string[] FileC = Properties.Resources.GitRepositories_3a.Split("\n");
                string FileString = string.Join(",", FileC);
                return FileString;
            }
            else if(choice== "6")
            {
                string[] FileC = Properties.Resources.GitRepositories_3b.Split("\n");
                string FileString = string.Join(",", FileC);
                return FileString;
            }
            //if the file is not found the function is recalled
            else
            {
                Console.WriteLine("invalid file choice all files reset," +
                    " please enter a number between 1 and 6 to pick a file");
                //recall to repick both of the files, resetting the variables even if one file it chosen
                ChooseFile1();
                return "file not found";
            }

        }


    }
}
