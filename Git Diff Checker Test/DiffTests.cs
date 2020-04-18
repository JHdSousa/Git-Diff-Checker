using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Git_Diff_Checker;
using Git_Diff_Checker.Enums;

namespace Git_Diff_Checker_Test
{
    public class DiffTests
    {
        private DetailedDiff _gitDiffChecker;
        [SetUp]
        public void Setup()
        {
            _gitDiffChecker = new DetailedDiff();
        }        

        //testing diff function
        [Test]
        public void HandlesBothArraysEmpty()
        {
            // assign
            string[] stringOrig = new string[] {  };
            string[] stringNew = new string[] { };

            // action
            List<Change> actualChanges = _gitDiffChecker.Changes(stringNew, stringOrig, Actions.Addition);

            // assert
            Assert.AreEqual(0, actualChanges.Count);
        }

        [Test]
        public void HandlesEditedArrayEmpty()
        {
            // assign
            string[] stringOrig = new string[] { "1" };
            string[] stringNew = new string[] {  };

            // action
            List<Change> actualChanges = _gitDiffChecker.Changes(stringNew, stringOrig, Actions.Addition);

            // assert
            Assert.AreEqual(1, actualChanges.Count);
            Assert.True(actualChanges.All(x => x.Word == "1"));
        }

        [Test]
        public void HandlesOriginalArrayEmpty()
        {
            // assign
            string[] stringOrig = new string[] { };
            string[] stringNew = new string[] { "1" };

            // action
            List<Change> actualChanges = _gitDiffChecker.Changes(stringNew, stringOrig, Actions.Addition);

            // assert
            Assert.AreEqual(1, actualChanges.Count);
            Assert.True(actualChanges.All(x => x.Word == "1"));
        }

        [Test]
        public void HandlesBothArraysSame()
        {
            // assign
            string[] stringOrig = new string[] { "1","2" };
            string[] stringNew = new string[] { "1", "2" };

            // action
            List<Change> actualChanges = _gitDiffChecker.Changes(stringNew, stringOrig, Actions.Addition);

            // assert
            Assert.Zero(actualChanges.Count);
        }

        [Test]
        [TestCase(new string[] { }, new string[] { }, 0, "")]
        [TestCase(new string[] { "1" }, new string[] { }, 1, "1")]
        public void HandlesOriginalArrayEmpty(string[] stringOrig, string[] stringNew, int expectedDifferences, string found)
        {
            // action
            List<Change> actualChanges = _gitDiffChecker.Changes(stringNew, stringOrig, Actions.Addition);

            // assert
            Assert.AreEqual(expectedDifferences, actualChanges.Count);
            Assert.True(actualChanges.All(x => x.Word == found));
        }        
    }
}