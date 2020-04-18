using System;
using NUnit.Framework;
using Git_Diff_Checker;

namespace Git_Diff_Checker_Test
{
    public class OtherTests
    {
        [Test]
        [TestCase("1.txt", 6)]
        [TestCase("2.txt", 5)]
        [TestCase("3.txt", 3)]
        [TestCase("GitRepositories_1a.txt", 79)]
        [TestCase("GitRepositories_1b.txt", 79)]
        [TestCase("GitRepositories_2a.txt", 100)]
        [TestCase("GitRepositories_2b.txt", 100)]
        [TestCase("GitRepositories_3a.txt", 135)]
        [TestCase("GitRepositories_3b.txt", 136)]
        public void SelectedFileConents(string fileName, int expectedSize)
        {
            //assign
            FileSelection gitDiffChecker = new FileSelection(fileName);

            //action
            string[] actualFile = gitDiffChecker.GetContents();

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

        [Test]
        [TestCase(new string[] { "1", "2" }, null)]
        [TestCase(null, new string[] { "1", "2" })]
        [TestCase(null, null)]
        public void FileCheckInvalidFilesThrown(string[] origFile, string[] newFile)
        {            
            //assign
            string functionInput = "diff";

            //action and assert
            Assert.Throws<NullReferenceException>(() => Git_Diff_Checker.CommandCheck.ValidCommand(functionInput, newFile, origFile));
        }

        [Test]
        [TestCase("dif")]
        [TestCase(" ")]
        [TestCase("123")]
        [TestCase("iff")]
        [TestCase("Diff")]
        public void InvalidCommandsReturnCorrectError(string commandIn)
        {
            //assign
            string[] stringOrig = { "1", "2" };
            string[] stringNew = new string[] { "1", "2" };

            //action
            string returnVal = Git_Diff_Checker.CommandCheck.ValidCommand(commandIn, stringNew, stringOrig);

            //assert
            Assert.AreEqual(":> [OUTPUT] Unknown command", returnVal);
        }
    }
}
