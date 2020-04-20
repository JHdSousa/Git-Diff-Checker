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
        [TestCase(new string[] { }, new string[] { "1"}, 1)]
        [TestCase(new string[] { }, new string[] { "Hello", "world" }, 2)]
        public void HandlesOriginalArrayEmpty(string[] original, string[] newString, int count)
        {
            // assign         

            // action
            List<Change> actualChanges = _gitDiffChecker.Changes(newString, original, Actions.Addition);

            // assert
            Assert.AreEqual(count, actualChanges.Count);
        }

        [Test]
        [TestCase(new string[] { "hello", "there" }, new string[] { "hello", "there" })]
        [TestCase(new string[] { "1", "2" }, new string[] { "1", "2" })]
        public void HandlesBothArraysSame(string[] orig, string[] newFile)
        {
            //// assign

            // action
            List<Change> actualChanges = _gitDiffChecker.Changes(newFile, orig, Actions.Addition);

            // assert
            Assert.Zero(actualChanges.Count);
        }

        [Test]
        [TestCase(new string[] { }, new string[] {"there" }, 1, "there")]
        [TestCase(new string[] {  }, new string[] { "1" }, 1, "1")]
        public void HandlesEditedArrayEmpty(string[] stringNew, string[] stringOrig, int expectedDifferences, string found)
        {
            // action          
            List<Change> actualChanges = _gitDiffChecker.Changes(stringNew, stringOrig, Actions.Addition);

            // assert
            Assert.AreEqual(expectedDifferences, actualChanges.Count);
            Assert.True(actualChanges.All(x => x.Word == found));
        }        
    }
}