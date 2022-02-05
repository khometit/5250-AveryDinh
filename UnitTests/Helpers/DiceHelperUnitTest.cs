using Mine.Models;
using NUnit.Framework;
using Mine.Helpers;

namespace UnitTests.Helpers
{
    /// <summary>
    /// Class containing Dice Helper Unit Tests
    /// </summary>
    public class DiceHelperUnitTest
    {
        /// <summary>
        /// Test invalid roll of zero, should return 0
        /// </summary>
        [Test]
        public void RollDice_Invalid_Roll_Zero_Should_Return_Zero()
        {
            //Arrange

            //Act
            var result = DiceHelper.RollDice(0, 1);

            //Reset

            //Assert
            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// Test valid roll of 1 dice 6, should return a value from 1 to 6
        /// </summary>
        [Test]
        public void RollDice_Valid_Roll_1_Dice_6_Should_Return_Between_1_And_6()
        {
            //Arrange

            //Act
            var result = DiceHelper.RollDice(1, 6);

            //Reset

            //Assert
            Assert.AreEqual(true, result >= 1);
            Assert.AreEqual(true, result <= 6);
        }

        /// <summary>
        /// Test invalid roll, force 1, should return 1
        /// </summary>
        [Test]
        public void RollDice_Invalid_Roll_Forced_1_Should_Return_1()
        {
            //Arrange
            DiceHelper.ForceRollsToNotRandom = true;
            DiceHelper.ForcedRandomValue = 1;

            //Act
            var result = DiceHelper.RollDice(1, 1);

            //Reset
            DiceHelper.ForceRollsToNotRandom = false;

            //Assert
            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// Test invalid dice 0, should return 0
        /// </summary>
        [Test]
        public void RollDice_Invalid_Roll_1_Dice_0_Should_Return_Zero()
        {
            //Arrange

            //Act
            var result = DiceHelper.RollDice(1, 0);

            //Reset

            //Assert
            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// Test invalid dice 0, should return 0
        /// </summary>
        [Test]
        public void RollDice_Invalid_Roll_0_Dice_10_Should_Return_Zero()
        {
            //Arrange

            //Act
            var result = DiceHelper.RollDice(0, 10);

            //Reset

            //Assert
            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// Test Valid roll of 2, dice 6, should return between 2 and 12
        /// </summary>
        [Test]
        public void RollDice_Valid_Roll_2_Dice_6_Should_Return_Between_2_And_12()
        {
            //Arrange

            //Act
            var result = DiceHelper.RollDice(2, 6);

            //Reset

            //Assert
            Assert.AreEqual(true, result >= 2);
            Assert.AreEqual(true, result <= 12);
        }

        /// <summary>
        /// Test invalid roll 1 dice 10, force 5, should return 5
        /// </summary>
        [Test]
        public void RollDice_Valid_Roll_1_Dice_10_Forced_5_Should_Return_5()
        {
            //Arrange
            DiceHelper.ForceRollsToNotRandom = true;
            DiceHelper.ForcedRandomValue = 5;

            //Act
            var result = DiceHelper.RollDice(1, 10);

            //Reset
            DiceHelper.ForceRollsToNotRandom = false;

            //Assert
            Assert.AreEqual(5, result);
        }
    }
}
