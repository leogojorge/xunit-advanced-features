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
            public void GetPersonByName()
            {
                string expectedPersonName = "Maria";
                var filter = Builders<Person>.Filter.Eq(x => x.Name, expectedPersonName);

                var person = CacheFixture._cacheCollection.Find(filter).ToList().FirstOrDefault();
                
                Assert.Equal(expectedPersonName, person!.Name);
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
            public void When_InsertingADocument_DocumentShouldBeAdded()
            {
                int expectedTotalQuantityOfDocuments = 4;
                Person brian = new Person(4, "Brian");
                CacheFixture._cacheCollection.InsertOne(brian);

                var allPersons = CacheFixture._cacheCollection.Find(x => true).ToList();

                Assert.Equal(expectedTotalQuantityOfDocuments, allPersons.Count);
            }
        }
    }
}