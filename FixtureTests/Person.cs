namespace FixtureTests
{
    public class Person
    {
        public int Id { get; }
        public string? Name { get; }

        public Person(int id, string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("qual foi usuario, teu nome ta cagado");
            }
            
            Id = id;
            Name = name;
        }
    }
}
