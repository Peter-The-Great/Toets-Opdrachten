namespace Test
{
    interface IMyInterface
    {
        int GetValue();
    }

    public class MyInterfaceMock : IMyInterface
    {
        public int GetValue()
        {
            return 5;
        }
    }

    public class MyClass
    {
        private readonly IMyInterface _myInterface;

        public MyClass(MyInterfaceMock myInterface)
        {
            _myInterface = myInterface;
        }

        public int GetDoubleValue()
        {
            return _myInterface.GetValue() * 2;
        }
    }
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var myInterfaceMock = new MyInterfaceMock();

            var myClass = new MyClass(myInterfaceMock);
            var result = myClass.GetDoubleValue();

            Assert.Equal(10, result);
        }
    }
    public class TestCalculator
    {
        [Fact]
        public void TestCalculateAdd()
        {
            //Arrange
            var mock = new MockCalculator<uint>();
            var calculator = new Calculator<uint>(mock);

            //Act
            var count = mock.Count();
            var calculate = calculator.Add(7, 23);

            //Assert
            Assert.Equal(1, Convert.ToInt32(count));
            Assert.Equal(30, Convert.ToInt32(calculate));
        }

        [Theory]
        [InlineData(700, 34)]
        public void TestCalculateSubstract(int a, int b)
        {
            //Arrange
            var mock = new MockCalculator<int>();
            var calculator = new Calculator<int>(mock);

            //Act
            var count = mock.Count();
            var calculate = calculator.Substract(a, b);

            //Assert
            Assert.Equal(1, Convert.ToInt32(count));
            Assert.Equal(666, Convert.ToInt32(calculate));
        }
    }
}