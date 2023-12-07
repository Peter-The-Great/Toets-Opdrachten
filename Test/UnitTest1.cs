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
}