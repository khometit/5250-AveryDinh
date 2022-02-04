using NUnit.Framework;
using Mine.Models;

namespace UnitTests.Models
{
    public class ItemModelTests
    {
        /// <summary>
        /// Test constructor with default value
        /// </summary>
        [Test]
        public void ItemModel_Constructor_Valid_Default_Should_Pass()
        {
            //Arrange

            //Act
            var result = new ItemModel();

            //Reset

            //Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Test set and get methods with default values
        /// </summary>
        [Test]
        public void ItemModel_Set_Get_Valid_Default_Should_Pass()
        {
            //Arrange

            //Act
            var result = new ItemModel();
            result.Description = "Description";
            result.Id = "ID";
            result.Text = "Text";
            result.Value = 1;
            //Reset

            //Assert
            Assert.AreEqual("Description", result.Description);
            Assert.AreEqual("ID", result.Id);
            Assert.AreEqual("Text", result.Text);
            Assert.AreEqual(1, result.Value);
        }

        /// <summary>
        /// Test get with default value
        /// </summary>
        [Test]
        public void ItemModel_Get_Valid_Default_Should_Pass()
        {
            //Arrange

            //Act
            var result = new ItemModel();

            //Reset

            //Assert
            Assert.AreEqual(0, result.Value);
        }
    }
}
