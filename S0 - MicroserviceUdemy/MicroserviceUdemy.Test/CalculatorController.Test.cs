
namespace MicroserviceUdemy.Test;


public class CalculatorControllerTest
{
    [SetUp]
    public void Setup()
    {
    }

        [Test]
        public void TestSumOperationWithValidInputs()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<CalculatorController>>();
            var controller = new CalculatorController(loggerMock.Object);
            string firstNumber = "5";
            string secondNumber = "3";

            // Act
            var result = controller.GetSum(firstNumber, secondNumber) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("8", result.Value.ToString());
        }

        // Verify sum operation returns BadRequest for non-numeric inputs
        [Test]
        public void TestSumOperationWithInvalidInputs()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<CalculatorController>>();
            var controller = new CalculatorController(loggerMock.Object);
            string firstNumber = "five";
            string secondNumber = "three";

            // Act
            var result = controller.GetSum(firstNumber, secondNumber) as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Invalid Input", result.Value);
        }
}