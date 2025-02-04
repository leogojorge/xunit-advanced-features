namespace FixtureTests
{
    public class CacheFixture : IDisposable
    {
        public Dictionary<string, bool> Cache { get; set; }

        public CacheFixture()
        {
            Cache = new()
            {
                { "id_1", true },
                { "id_2", true },
                { "id_3", false }
            };
        }

        public void Dispose()
        {
            this.Cache = null!;
        }
    }
}
