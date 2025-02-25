namespace ParallelFixtureTests
{
    //By default, xunit handlers each test class are one separeted collection fixture
    //It means that the test methods of one single class are all executed sequentially,
    //rather than parallel. In other words, those methods belongs to the same fixutre,
    //and "same fixture" means same context.

    //xunit provide us a way to create our own fixtures, making possible to gather more
    //than one test class to share the same context. And all of this tests of all the classes 
    //inside the same fixture will be running in parallel, changing the default behavior of xunit.

    //warning: collection definition can only be used on clesses inside the same assembly, but class fixture can be shared over different assemblies

    //Every class that belongs to the CollectionDifinition "NoParallelism" will be executed sequntially, one classe at a time and one method at a time.
    //Each class will have access to the fixture and its properties so the context can be shared between them.
    //The constructor of the CollectionFixture will be called one time before any test are executed of any class 
    //inside this collection, and will run the Dispose method, if created, one time after every test have runned.
    [CollectionDefinition("NoParallelism")]
    public class CollectionsFixture
    {
        //No code needed here. This class is only being used to define a collection fixture

        //But, if we want to create a new object instance to be shared, see the next class above
        //it will be necessary to hence from the ClassFixture interface typed by a class with the constructor with the
        //code needed. 
    }

    [CollectionDefinition("AnotherCollection")]
    public class CollectionFixtureWithConsntructor : IClassFixture<ClassInitialzeAObjectFixture>
    {
        //by hancing the IClassFixture<ClassInitialzeAObjectFixture>, it allows all the 
        //classes inside the collection the access of the ClassInitialzeAObjectFixture instance
        //with the `list` parameter initalized only once for this whole collection.
    }

    public class ClassInitialzeAObjectFixture
    {
        public List<int> list;
        public ClassInitialzeAObjectFixture()
        {
            this.list = [];
        }
    }
}
