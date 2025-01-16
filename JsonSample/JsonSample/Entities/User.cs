namespace JsonSample.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Article> Articles { get; set; }

    }
}
