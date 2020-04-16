//using System;
//using System.Linq;
//using NUnit.Framework;
//using Git_Diff_Checker;
//using Git_Diff_Checker.Enums;


//namespace Git_Diff_Checker_Test
//{
//    public class RemovalTests
//    {
//        private Removed _gitDiffChecker;

//        [SetUp]
//        public void Setup()
//        {
//            _gitDiffChecker = new Removed();
//        }
//        //testing removals
//        [Test]
//        public void HandlesBothArraysSameRemove()
//        {
//            // assign
//            var stringOrig = new string[] { "1", "2" };
//            var stringNew = new string[] { "1", "2" };

//            // action
//            var actualChanges = _gitDiffChecker.Changes(stringNew, stringOrig, Actions.Removal);

//            // assert
//            Assert.AreEqual(0, actualChanges.Count);
//        }
//        [Test]
//        public void HandlesBothArraysEmptyRemove()
//        {
//            // assign
//            var stringOrig = new string[] { };
//            var stringNew = new string[] { };

//            // action
//            var actualChanges = _gitDiffChecker.Changes(stringNew, stringOrig, Actions.Removal);

//            // assert
//            Assert.AreEqual(0, actualChanges.Count);
//        }
//        [Test]
//        public void HandlesEditedArraysEmptyRemove()
//        {
//            // assign
//            var stringOrig = new string[] { "1", "2" };
//            var stringNew = new string[] { };

//            // action
//            var actualChanges = _gitDiffChecker.Changes(stringNew, stringOrig, Actions.Removal);

//            // assert
//            Assert.AreEqual(2, actualChanges.Count);
//        }
//        [Test]
//        public void HandlesOrigArraysEmptyRemove()
//        {
//            // assign
//            var stringOrig = new string[] { };
//            var stringNew = new string[] { "1", "2" };

//            // action
//            var actualChanges = _gitDiffChecker.Changes(stringNew, stringOrig, Actions.Removal);

//            // assert
//            Assert.AreEqual(0, actualChanges.Count);
//        }
//    }
//}
