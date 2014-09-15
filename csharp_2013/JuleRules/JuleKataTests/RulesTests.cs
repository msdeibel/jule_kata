using JuleKata;
using JuleKataTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace JuleKataTests
{
    [TestClass]
    public class RulesShould
    {
        [TestMethod]
        public void Return1To6ForARolledDie()
        {
            Assert.IsTrue(1 <= Rules.RollDie()
                            && 6 >= Rules.RollDie());
        }

        [TestMethod]
        public void SortThreeDiceFromHighToLow()
        {
            CollectionAssert.AreEqual(new int[] { 6, 2, 1 }, Rules.SortDice(1, 6, 2));
            CollectionAssert.AreEqual(new int[] { 1, 1, 1 }, Rules.SortDice(1, 1, 1));
        }

        [TestMethod]
        public void TransformDiceResultIntoCorrectInteger()
        {
            Assert.AreEqual(621, Rules.CalculateDiceValue(1,6,2));
        }

        [TestMethod]
        public void Recognize111asThree()
        {
            Assert.IsTrue(Rules.IsThree(111));
        }

        [TestMethod]
        public void Recognize421AsJule()
        {
            Assert.IsTrue(Rules.IsJule(421));
        }

        [TestMethod]
        public void RecognizeHards()
        {
            Assert.IsTrue(Rules.IsHards(511));
            Assert.IsTrue(Rules.IsHards(311));
            Assert.IsFalse(Rules.IsHards(111));
        }

        [TestMethod]
        public void RecognizeSofts()
        {
            Assert.IsTrue(Rules.IsSofts(222));
            Assert.IsTrue(Rules.IsSofts(333));
            Assert.IsFalse(Rules.IsSofts(111));
        }

        [TestMethod]
        public void RecognizeStraight()
        {
            Assert.IsTrue(Rules.IsStraight(321), "321");
            Assert.IsTrue(Rules.IsStraight(432), "432");
        }

        [TestMethod]
        public void UseCorrectNumberOfMarkers()
        {
            Assert.AreEqual(8, Rules.GetMarkersForDiceValue(111), "Three");
            Assert.AreEqual(7, Rules.GetMarkersForDiceValue(421), "Jule");
            Assert.AreEqual(6, Rules.GetMarkersForDiceValue(611), "6 Hards");
            Assert.AreEqual(3, Rules.GetMarkersForDiceValue(311), "3 Hards");
            Assert.AreEqual(3, Rules.GetMarkersForDiceValue(222), "2 Softs");
            Assert.AreEqual(2, Rules.GetMarkersForDiceValue(543), "Straight");
            Assert.AreEqual(1, Rules.GetMarkersForDiceValue(521), "Other values");
        }

    }
}
