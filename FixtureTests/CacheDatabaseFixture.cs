using System.ComponentModel;
using MongoDB.Driver;

namespace FixtureTests
{
    
    public class CacheDatabaseFixture : IDisposable
    {
        public readonly IMongoCollection<Person> _cacheCollection;
        public readonly IMongoDatabase _database;

        public CacheDatabaseFixture()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");

            _database = mongoClient.GetDatabase("Db");
            _database.DropCollection("PersonCache");

            _cacheCollection = _database.GetCollection<Person>("PersonCache");

            var person1 = new Person(1, "Maria");
            var person2 = new Person(2, "Leonardo");
            var person3 = new Person(3, "Ana");
            
            _cacheCollection.InsertOne(person1);
            _cacheCollection.InsertOne(person2);
            _cacheCollection.InsertOne(person3);
        }

        public void Dispose()
        {
            _database.DropCollection("PersonCache");
        }
    }
}
