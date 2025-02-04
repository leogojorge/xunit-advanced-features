namespace ParallelFixtureTests.SequentialExecutionTests
{
    //The next two classes are being setted inside the same collection by the attribute Collection
    //The parementer string name represents a the collection that the following class will belong
    //The name needs to be the same on every class that we choose to belong tho the same context

    //When we execute both classes at the same time, we can see that the total execution duration
    //will be around 6 seconds. It means that the Collection attibute wraped those 2 classes
    //into one fixture, rather than one fixture for each classe witch is the deafult for xunit.
    //So the tests executed were all being called inside the same context.

    //If we play around with the attribute name, making them different on each classe decoration, 
    //we will see that those tests will be executed in parallel, meaning that this shared context/fiture
    //no longer exists.
    [Collection("SequentialRunHere")]
    public class Class1Tests
    {
        [Fact]
        public void TesteSequencial4()
        {
            
            Thread.Sleep(1000);
        }

        [Fact]
        public void TesteSequencial5()
        {
            Thread.Sleep(1000);
        }

        [Fact]
        public void TesteSequencial6()
        {
            Thread.Sleep(1000);
        }
    }

    [Collection("SequentialRunHere")]
    public class Class2Tests
    {
        [Fact]
        public void TesteSequencial1()
        {
            Thread.Sleep(1000);
        }

        [Fact]
        public void TesteSequencial2()
        {
            Thread.Sleep(1000);
        }

        [Fact]
        public void TesteSequencial3()
        {
            Thread.Sleep(1000);
        }
    }
}
