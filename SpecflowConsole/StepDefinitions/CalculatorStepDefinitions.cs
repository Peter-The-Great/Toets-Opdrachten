namespace SpecflowConsole.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        
        private Calculator calculator = new Calculator();
        private int result;

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            calculator.EnterNumber(number);
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic
            calculator.EnterNumber(number);
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            //TODO: implement act (action) logic

            result = calculator.Add();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int expectedResult)
        {
            //TODO: implement assert (verification) logic

            Assert.Equal(expectedResult, result);
        }
    }

    public class Calculator
    {
        private int _firstNumber;
        private int _secondNumber;

        public void EnterNumber(int number)
        {
            if (_firstNumber == 0)
                _firstNumber = number;
            else
                _secondNumber = number;
        }

        public int Add()
        {
            return _firstNumber + _secondNumber;
        }
    }
}
