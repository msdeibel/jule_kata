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
        public void ShouldTransformDiceResultIntoCorrectInteger()
        {
            Assert.AreEqual(621, Rules.CalculateDiceValue(1,6,2));
        }

        [TestMethod]
        public void Recognize111asThree()
        {
            Assert.IsTrue(Rules.IsThree(111));
        }
    }
}
