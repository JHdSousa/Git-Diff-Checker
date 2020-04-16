using System;
using System.Linq;
using NUnit.Framework;
using Git_Diff_Checker;
using Git_Diff_Checker.Enums;

namespace Git_Diff_Checker_Test
{
    public class AdditionTests
    {
        private DetailedDiff _gitDiffChecker;
        [SetUp]
        public void Setup()
        {
            _gitDiffChecker = new DetailedDiff();
        }
        

        //testing diff function
        //testing looking for additions
        [Test]
        public void HandlesBothArraysEmptyAdd()
        {
            // assign
            var stringOrig = new string[] {  };
            var stringNew = new string[] { };

            // action
            var actualChanges = _gitDiffChecker.Changes(stringNew, stringOrig, Actions.Addition);

            // assert
            Assert.AreEqual(0, actualChanges.Count);
        }

        [Test]
        public void HandlesEditedArrayEmptyAdd()
        {
            // assign
            var stringOrig = new string[] { "1" };
            var stringNew = new string[] {  };

            // action
            var actualChanges = _gitDiffChecker.Changes(stringNew, stringOrig, Actions.Addition);

            // assert
            //Assert.Throws<Exception>(() => gitDiffChecker.Changes(stringOrig, stringNew, Actions.Addition));
            Assert.AreEqual(1, actualChanges.Count);
            Assert.True(actualChanges.All(x => x.Word == "1"));
        }

        [Test]
        public void HandlesOriginalArrayEmptyAdd()
        {
            // assign
            var stringOrig = new string[] { };
            var stringNew = new string[] { "1" };

            // action
            var actualChanges = _gitDiffChecker.Changes(stringNew, stringOrig, Actions.Addition);

            // assert
            //Assert.Throws<Exception>(() => gitDiffChecker.Changes(stringOrig, stringNew, Actions.Addition));
            Assert.AreEqual(1, actualChanges.Count);
            Assert.True(actualChanges.All(x => x.Word == "1"));
        }

        [Test]
        public void HandlesBothArraysSameAdd()
        {
            // assign
            var stringOrig = new string[] { "1","2" };
            var stringNew = new string[] { "1", "2" };

            // action
            var actualChanges = _gitDiffChecker.Changes(stringNew, stringOrig, Actions.Addition);

            // assert
            Assert.Zero(actualChanges.Count);
        }

        [Ignore("not sorted")]
        [Test]
        [TestCase(new string[] { }, new string[] { }, 0, "")]
        [TestCase(new string[] { "1" }, new string[] { }, 1, "1")]
        public void HandlesOriginalArrayEmptyzzzzz(string[] stringOrig, string[] stringNew, int expectedDifferences, string found)
        {

            // action
            var actualChanges = _gitDiffChecker.Changes(stringNew, stringOrig, Actions.Addition);

            // assert
            //Assert.Throws<Exception>(() => gitDiffChecker.Changes(stringOrig, stringNew, Actions.Addition));
            Assert.AreEqual(expectedDifferences, actualChanges.Count);
            Assert.True(actualChanges.All(x => x.Word == found));
        }
        
    }
}