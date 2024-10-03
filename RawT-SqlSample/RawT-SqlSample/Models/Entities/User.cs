using System.ComponentModel.DataAnnotations;

namespace RawT_SqlSample.Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAuthor { get; set; }
        public Author Author { get; set; }
    }
}
