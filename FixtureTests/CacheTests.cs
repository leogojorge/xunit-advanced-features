namespace FixtureTests
{
    public class CacheTests
    {
        public class FlagCacheTests : IClassFixture<CacheFixture>
        {
            public CacheFixture CacheFixture { get; set; }

            public FlagCacheTests(CacheFixture cacheFixture)
            {
                this.CacheFixture = cacheFixture;
            }

            [Fact]
            public void TestFlags()
            {
                Assert.True(this.CacheFixture.Cache["id_1"]);
                Assert.True(this.CacheFixture.Cache["id_2"]);
                Assert.False(this.CacheFixture.Cache["id_3"]);
            }
        }

        public class CacheInitializationTests : IClassFixture<CacheFixture>
        {
            public CacheFixture CacheFixture { get; set; }

            public CacheInitializationTests(CacheFixture cacheFixture)
            {
                this.CacheFixture = cacheFixture;
            }

            [Fact]
            public void TestCacheElements()
            {
                Assert.Equal(3, this.CacheFixture.Cache.Count);
                Assert.Equal(3, this.CacheFixture.Cache.Where(x => x.Key.StartsWith("id_")).Count());
            }
        }

        public class OtherCacheTests : IClassFixture<CacheFixture>
        {
            [Fact]
            public void TestCacheElements()
            {
                //other tests that do not need the cache instance, but
                //belongs to the same fixture
                //Assert... 
            }
        }
    }
}