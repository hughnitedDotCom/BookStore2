using BookStore.Services.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookStore.Repository
{
    public class BookStoreContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString: "FileName=BookStoreDb", (option) => {
                
                option.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
        }
    }
}
