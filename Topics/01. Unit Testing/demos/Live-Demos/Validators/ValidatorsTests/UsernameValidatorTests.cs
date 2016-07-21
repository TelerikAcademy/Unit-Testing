namespace ValidatorsTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Validators;
    using Validators.Exceptions;

    [TestClass]
    public class UsernameValidatorTests
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

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            // You can add common initialization logic here
            // Which is really not a good idea when you write unit tests
        }

        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            // You can cleanup common resources here
            // If you haven't listen to my previous advice
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {
            TestContext.WriteLine(TestContext.TestName);
            TestContext.WriteLine(TestContext.TestDeploymentDir);
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            TestContext.WriteLine(TestContext.CurrentTestOutcome.ToString());
        }


        [TestMethod]
        [TestCategory("UsernameValidationTests")]
        public void IsUsernameValid_ShouldReturnTrue_WhenUsernameDoesNotContainAnyWhitespaceOrSpecialCharacters()
        {
            // Arrange
            var usernameValidator = new UsernameValidator();
            var usernameToBeValidated = "IvanNikolaevKolev";
            var minRequiredUsernameLength = 5;
            var maxRequiredUsernameLength = 32;
            var expectedResult = true;

            // Act
            var actualResult = usernameValidator.IsUsernameValid(
                usernameToBeValidated, 
                minRequiredUsernameLength, 
                maxRequiredUsernameLength);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [TestCategory("UsernameValidationTests")]
        [ExpectedException(typeof(InvalidUsernameException), AllowDerivedTypes = true)]
        public void IsUsernameValid_ShouldThrowInvalidUsernameException_WhenUsernameContainsWhitespaceCharacters()
        {
            // Arrange
            var usernameValidator = new UsernameValidator();
            var usernameToBeValidated = "Ivan Nikolaev Kolev";
            var minRequiredUsernameLength = 5;
            var maxRequiredUsernameLength = 32;

            // Act
            usernameValidator.IsUsernameValid(
                usernameToBeValidated,
                minRequiredUsernameLength,
                maxRequiredUsernameLength);

            // In this test method, the "ExpectedException" attribute is our "Assertion"
        }

        [TestMethod]
        [TestCategory("UsernameValidationTests")]
        [ExpectedException(typeof(InvalidUsernameException), AllowDerivedTypes = true)]
        public void IsUsernameValid_ShouldThrowInvalidUsernameException_WhenUsernameContainsSpecialCharacters()
        {
            // Arrange
            var usernameValidator = new UsernameValidator();
            var usernameToBeValidated = "Iv@nNikolaevKo!ev";
            var minRequiredUsernameLength = 5;
            var maxRequiredUsernameLength = 32;

            // Act
            usernameValidator.IsUsernameValid(
                usernameToBeValidated,
                minRequiredUsernameLength,
                maxRequiredUsernameLength);

            // In this test method, the "ExpectedException" attribute is our "Assertion"
        }
    }
}
