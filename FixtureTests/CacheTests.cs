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
                
                Assert.NotEmpty(allPersons);
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
            public void When_InsertADocument_DocumentShouldBeAdded()
            {
                var newPerson = new Person(5, "James");

                CacheFixture._cacheCollection.InsertOne(newPerson);

                var james = CacheFixture._cacheCollection.Find(x => x.Id == 5).FirstOrDefault();

                Assert.Equal(newPerson.Name, james.Name);
            }
        }
    }
}