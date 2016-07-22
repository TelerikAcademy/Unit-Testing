namespace ValidatorsTests
{
    using NUnit.Framework;
    using Validators;
    using Validators.Exceptions;

    [TestFixture]
    public class PasswordValidatorTests
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [Test]
        [Category("PasswordValidations")]
        public void IsPasswordLengthValid_ShouldReturnFalse_WhenPasswordLengthIsGreaterThanTheMaxRequiredPasswordLength()
        {
            // Arrange
            var passwordValidator = new PasswordValidator();
            var passwordToBeTested = "P@ssw0rd!ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";
            var minRequiredPasswordLength = 5;
            var maxRequiredPasswordLength = 32;

            // Act
            var isPasswordLengthValid = passwordValidator.IsPasswordLengthValid(
                passwordToBeTested,
                minRequiredPasswordLength,
                maxRequiredPasswordLength);

            // Assert
            Assert.IsFalse(isPasswordLengthValid);
        }

        [TestCase(5, 12)]
        [TestCase(3, 20)]
        [TestCase(6, 32)]
        [TestCase(3, 500)]
        [Category("PasswordValidations")]
        public void IsPasswordLengthValid_ShouldReturnTrue_WhenPasswordLengthIsValid(int minRequiredPasswordLength, int maxRequiredPasswordLength)
        {
            // Arrange
            var passwordValidator = new PasswordValidator();
            var passwordToBeTested = "P@ssw0rd!";
            var expectedResult = true;

            // Act
            var actualResult = passwordValidator.IsPasswordLengthValid(
                passwordToBeTested,
                minRequiredPasswordLength,
                maxRequiredPasswordLength);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [Category("PasswordValidations")]
        public void IsPasswordValid_ShouldThrowInvalidPasswordLengthException_WhenPasswordLengthIsNotValid()
        {
            // Arrange
            var passwordValidator = new PasswordValidator();
            var passwordToBeTested = "P@ssw0rd!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!";
            var minRequiredPasswordLength = 5;
            var maxRequiredPasswordLength = 32;
            var minRequiredDigitsCount = 1;
            var minRequiredUppercaseLettersCount = 2;
            var minRequiredLowercaseLettersCount = 2;
            var minRequiredSpecialCharactersCount = 1;

            // Act
            var exceptionThrown = 
                Assert.Throws<InvalidPasswordException>(
                    () => passwordValidator.IsPasswordValid(
                        passwordToBeTested,
                        minRequiredPasswordLength,
                        maxRequiredPasswordLength,
                        minRequiredDigitsCount,
                        minRequiredLowercaseLettersCount,
                        minRequiredUppercaseLettersCount,
                        minRequiredSpecialCharactersCount));

            // Assert
            StringAssert.Contains("Password", exceptionThrown.Message);
        }
    }
}
