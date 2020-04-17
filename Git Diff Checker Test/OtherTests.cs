﻿using System;
using System.Linq;
using NUnit.Framework;
using Git_Diff_Checker;
using Git_Diff_Checker.Enums;
namespace Git_Diff_Checker_Test
{
    public class OtherTests
    {
        [Test]
        [TestCase("1.txt", 6)]
        [TestCase("2.txt", 5)]
        [TestCase("3.txt", 3)]
        [TestCase("GitRepositories_1a.txt",77)]
        [TestCase("GitRepositories_1b.txt",77)]
        [TestCase("GitRepositories_2a.txt",97)]
        [TestCase("GitRepositories_2b.txt",97)]
        [TestCase("GitRepositories_3a.txt",133)]
        [TestCase("GitRepositories_3b.txt",134)]
        public void FileAcquisition(string fileName, int expectedSize)
        {
            //assign
            var gitDiffChecker = new FileSelection(fileName);
            //action
            var actualFile = gitDiffChecker.GetContents();
            //assert
            Assert.AreEqual(expectedSize, actualFile.Length);
        }

        [Test]
        public void LogFileLocationRetrieval()
        {

            //action
            string Location = LogFile.GetLogFile();
            //assert
            Assert.AreEqual("C:\\Users\\User\\Documents\\LogFile.txt", Location);
        }

        //[Ignore("not containing a return value needs checking by expert")]
        [Test]
        
        public void FileCheck()
        {
            
            //assign
            string[] stringOrig = null;
            var stringNew = new string[] { "1", "2" };
            var functionInput = "diff";
            //action
            //Git_Diff_Checker.CommandCheck.CheckCommand(functionInput, stringNew, stringOrig);

            //assert
            Assert.Throws<NullReferenceException>(() => Git_Diff_Checker.CommandCheck.ValidCommand(functionInput, stringNew, stringOrig));
        }
        [Test]
        [TestCase("dif")]
        [TestCase(" ")]
        [TestCase("123")]
        [TestCase("iff")]
        public void CheckForInvalidCommand(string commandIn)
        {
            //assign
            string[] stringOrig = { "1", "2" };
            var stringNew = new string[] { "1", "2" };
            //var functionInput = "dirf";
            //action
            //Git_Diff_Checker.CommandCheck.CheckCommand(functionInput, stringNew, stringOrig);
            var returnVal = Git_Diff_Checker.CommandCheck.ValidCommand(commandIn, stringNew, stringOrig);

            //assert
            Assert.AreEqual(":> [OUTPUT] Unknown command", returnVal);


        }
    }
}
