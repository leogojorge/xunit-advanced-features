using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

[assembly: CollectionBehavior(MaxParallelThreads = 2)]
namespace ParallelFixtureTests.ComParalelismo
{
    //6 classes de teste diferentes, ou seja, 6 collections diferentes
    public class RandomTests
    {
        [Fact]
        public void RandomTest1()
        {
            Thread.Sleep(1000);
        }
    }
    public class OtherTest
    {
        [Fact]
        public void RandomTest2()
        {
            Thread.Sleep(1000);
        }
    }
    public class AnotherOneTest
    {
        [Fact]
        public void RandomTest3()
        {
            Thread.Sleep(1000);
        }
    }
    public class MoreRandomTest
    {
        [Fact]
        public void RandomTest4()
        {
            Thread.Sleep(1000);
        }
    }
    public class AnotherRandomTest
    {
        [Fact]
        public void RandomTest5()
        {
            Thread.Sleep(1000);
        }
    }
    public class TheLastOneTest
    {
        [Fact]
        public void RandomTest6()
        {
            Thread.Sleep(1000);
        }
    }
    public class TheLastOneTest1
    {
        [Fact]
        public void RandomTest6()
        {
            Thread.Sleep(1000);
        }
    }
    public class TheLastOneTest2
    {
        [Fact]
        public void RandomTest6()
        {
            Thread.Sleep(1000);
        }
    }
    public class TheLastOneTest3
    {
        [Fact]
        public void RandomTest6()
        {
            Thread.Sleep(1000);
        }
    }
}
