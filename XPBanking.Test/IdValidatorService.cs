namespace XPBanking.Test
{
    [TestFixture]
    public class IdValidatorService  
    {
        private IdValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new IdValidator();
        }

        [Test]
        public void IsValidId_PositiveId_ReturnsTrue()
        {
            // Arrange
            int id = 1;

            // Act
            bool isValid = validator.IsValidId(id);

            // Assert
            Assert.IsTrue(isValid);
        }

        [Test]
        public void IsValidId_NegativeId_ReturnsFalse()
        {
            int id = -1;

            bool isValid = validator.IsValidId(id);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValidId_ZeroId_ReturnsFalse()
        {
            int id = 0;

            bool isValid = validator.IsValidId(id);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValidId_LargePositiveId_ReturnsTrue()
        {
            int id = 1000;

            bool isValid = validator.IsValidId(id);

            Assert.IsTrue(isValid);
        }
    }
}