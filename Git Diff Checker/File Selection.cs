﻿using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using Git_Diff_Checker.Properties;


namespace Git_Diff_Checker
{
    class FileSelection
    {
        //choosing the first file
        public static void ChooseFiles()
        {
            Console.WriteLine(":> [INPUT] ");
          string [] UserIn  = Console.ReadLine().Split();
            try
            {
            string file1 = GetFile(UserIn[1]);
            string file2 = GetFile(UserIn[2]);
            functions.CheckCommand(UserIn[0], file1, file2);
            }
            catch
            {
                Console.WriteLine("Input missing component");
            }
            
        }
        //choosing the second file
        
        //assigns the users choice of file and converts the array to a string each time. 
        //the string is then returned to be used in the comparative function
        private static string GetFile(string file1)
        {
            string file = "";
            switch (file1)
            {
                case "GitRepositories_1a.txt":
                    file = Properties.Resources.GitRepositories_1a;
                    break;

                case "GitRepositories_1b.txt":
                    file = Properties.Resources.GitRepositories_1b;
                    break;

                case "GitRepositories_2a.txt":
                    file = Properties.Resources.GitRepositories_2a;
                    break;

                case "GitRepositories_2b.txt":
                    file = Properties.Resources.GitRepositories_2b;
                    break;

                case "GitRepositories_3a.txt":
                    file = Properties.Resources.GitRepositories_3a;
                    break;

                case "GitRepositories_3b.txt":
                    file = Properties.Resources.GitRepositories_3b;
                    break;
            }
            return file;
        }


    }
}
