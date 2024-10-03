using Microsoft.EntityFrameworkCore;
using RawT_SqlSample.Models.Entities;

namespace RawT_SqlSample.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<AuthorArticles> AuthorArticles { get; set; }
    }
}
