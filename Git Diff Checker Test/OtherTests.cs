using System;
using System.Linq;
using NUnit.Framework;
using Git_Diff_Checker;
using Git_Diff_Checker.Enums;
namespace Git_Diff_Checker_Test
{
    public class OtherTests
    {
        [Test]
        [TestCase("1.txt", 4)]
        [TestCase("2.txt", 5)]
        [TestCase("3.txt", 3)]
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

        public void CommandCheckFalse()
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
        public void ValidFile()
        {


        }
    }
}
