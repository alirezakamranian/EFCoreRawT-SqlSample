using JsonSample.Entities;
using Microsoft.EntityFrameworkCore;

namespace JsonSample.DataAccess
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().OwnsMany(u =>
            u.Articles, ownedNavigationBuilder =>
                {
                    ownedNavigationBuilder.ToJson();
                    ownedNavigationBuilder.OwnsMany(a => a.Comments);
                });

            modelBuilder.Entity<User>().HasKey(u => u.Id);
        }
    }
}
