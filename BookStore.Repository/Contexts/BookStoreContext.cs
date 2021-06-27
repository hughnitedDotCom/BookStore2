using BookStore.Repository.Seed;
using BookStore.Services.Entities;
using Microsoft.EntityFrameworkCore;
using System;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subscription>()
                 .HasIndex(s => new { s.UserId, s.BookId })
                 .IsUnique(true);

            modelBuilder.Entity<Subscription>()
                .HasOne(u => u.User)
                .WithMany(sub => sub.Subscriptions)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<Subscription>()
                .HasOne(b => b.Book)
                .WithMany(sub => sub.Subscriptions)
                .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<User>().HasData(BookStoreSeedData.GenerateUsers());
            modelBuilder.Entity<Book>().HasData(BookStoreSeedData.GenerateBooks());
            modelBuilder.Entity<Subscription>().HasData(BookStoreSeedData.GenerateSubscriptions());

            base.OnModelCreating(modelBuilder);
        }
    }
}
