using MongoDB.Driver;

namespace FixtureTests
{
    public class CacheTests
    {
        [Collection("CacheDatabase")]
        public class PersonCacheTests
        {
            public CacheDatabaseFixture CacheFixture { get; set; }

            public PersonCacheTests(CacheDatabaseFixture cacheFixture)
            {
                this.CacheFixture = cacheFixture;
            }

            [Fact]
            public void GetAllPersons()
            {
                var allPersons = CacheFixture._cacheCollection.Find(x => true).ToList();
                
                Assert.Equal(3, allPersons.Count);
            }

            [Fact]
            public void GetPersonById()
            {
                var person1 = CacheFixture._cacheCollection.Find(x => x.Id == 1).FirstOrDefault();
                var person2 = CacheFixture._cacheCollection.Find(x => x.Id == 2).FirstOrDefault();
                var person3 = CacheFixture._cacheCollection.Find(x => x.Id == 3).FirstOrDefault();

                Assert.Equal("Maria", person1.Name);
                Assert.Equal("Leonardo", person2.Name);
                Assert.Equal("Ana", person3.Name);
            }
        }

        [Collection("CacheDatabase")]
        public class PersonCacheUpdateTests
        {
            public CacheDatabaseFixture CacheFixture { get; set; }

            public PersonCacheUpdateTests(CacheDatabaseFixture cacheFixture)
            {
                this.CacheFixture = cacheFixture;
            }

            [Fact]
            public void When_UpdatingADocument_DocumentShouldBeModified()
            {
                string expectedName = "New Maria";
                var updateExpression = Builders<Person>.Update.Set(s => s.Name, expectedName);

                CacheFixture._cacheCollection.UpdateOne(x => x.Id == 1, updateExpression);

                var maria = CacheFixture._cacheCollection.Find(x => x.Id == 1).FirstOrDefault();

                Assert.Equal(expectedName, maria.Name);
            }
        }
    }
}