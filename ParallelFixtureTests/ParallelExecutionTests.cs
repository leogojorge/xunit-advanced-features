[assembly: CollectionBehavior(MaxParallelThreads = 2)]
//This attribute sets the max threads that will be uses to execute tests
//By default it's value is equals to the quatity of virtual cores the machine processor have.
//This default value means that the tests will always be executed on the maxine's max capacity

//By executing those 9 classes togather, the amount of execution time will be around 1 seconds,
    //don't trust the "Duration" information on the test exeplorer, because it will sum the amount
    //of each test duration. Instead, check the test output on the output window.
    //the last line will tell the amount of time spent.
//even though each test will last 1 second to be executed. It means that those tests are being
//executed in parallel
//If we play with the MaxParallelThreads, we can see different behaviors, for exemple:
//setting MaxParallelThreads to 1 is almost the same thing as run tests sequentially.
//The execution duration in this case will always be around 9 seconds because xUnity
//will be running each test alone, waiting for it's completion to run the next one.
//If we set MaxParallelThreads to 2, we will see the duration fall to around 5 seconds,
//meaning that at least 2 tests ware executed at the same time.

namespace ParallelFixtureTests.ParallelExecutionTests
{
    //9 different tests classes, in other words, 9 different collections fixtures
    public class Class1Tests
    {
        [Fact]
        public void Test1()
        {
            Thread.Sleep(1000);
        }
    }
    public class Class2Tests
    {
        [Fact]
        public void Test2()
        {
            Thread.Sleep(1000);
        }
    }
    public class Class3Tests
    {
        [Fact]
        public void Test3()
        {
            Thread.Sleep(1000);
        }
    }
    public class Class4Tests
    {
        [Fact]
        public void Test4()
        {
            Thread.Sleep(1000);
        }
    }
    public class Class5Tests
    {
        [Fact]
        public void Test5()
        {
            Thread.Sleep(1000);
        }
    }
    public class Class6Tests
    {
        [Fact]
        public void Test6()
        {
            Thread.Sleep(1000);
        }
    }
    public class Class7Tests
    {
        [Fact]
        public void Test7()
        {
            Thread.Sleep(1000);
        }
    }
    public class Class8Tests
    {
        [Fact]
        public void Test8()
        {
            Thread.Sleep(1000);
        }
    }
    public class Class9Tests
    {
        [Fact]
        public void Test9()
        {
            Thread.Sleep(1000);
        }
    }
}
