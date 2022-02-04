using NUnit.Framework;
using Mine.Models;

namespace UnitTests.Models
{
    public class ItemModelTests
    {
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
    }
}
