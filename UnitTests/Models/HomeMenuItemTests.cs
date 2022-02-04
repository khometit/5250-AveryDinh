using NUnit.Framework;
using Mine.Models;

namespace UnitTests.Models
{
    /// <summary>
    /// Class with UTs for HomeMenuItem
    /// </summary>
    public class HomeMenuItemTests
    {
        /// <summary>
        /// Test constructor with default value
        /// </summary>
        [Test]
        public void HomeMenuItem_Constructor_Valid_Default_Should_Pass()
        {
            //Arrange

            //Act
            var result = new HomeMenuItem();

            //Reset

            //Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Test set and get methods with default values
        /// </summary>
        [Test]
        public void HomeMenuItem_Set_Get_Valid_Default_Should_Pass()
        {
            //Arrange

            //Act
            var result = new HomeMenuItem();
            result.Title = "Title";
            result.Id = MenuItemType.Game;
            //Reset

            //Assert
            Assert.AreEqual("Title", result.Title);
            Assert.AreEqual(MenuItemType.Game, result.Id);

        }
    }
}
