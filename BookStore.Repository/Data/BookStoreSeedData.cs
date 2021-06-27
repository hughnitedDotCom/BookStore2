using BookStore.Services.Entities;
using System;
using System.Collections.Generic;

namespace BookStore.Repository.Seed
{
    public static class BookStoreSeedData
    {
        public static List<User> GenerateUsers()
        {
           return new List<User>
           {
               new User
               {
                    Id = 1,
                    FirstName = "Jo",
                    LastName = "Sample",
                    EmailAddress = "Jo@Sample.com",
                    Password = "strongPassword",
                    CreateDate = DateTime.Now
               },
               new User 
               {
                    Id = 2,
                    FirstName = "Marty",
                    LastName = "McFly",
                    EmailAddress = "Marty@McFly.com",
                    Password = "strongPassword",
                    CreateDate = DateTime.Now
                }
             };
        }

        public static List<Book> GenerateBooks()
        {
           return new List<Book>
           {
               new Book 
               {
                   Id = 1,
                   Name = "Adventures of 1",
                   Text = "Hello World 1",
                   PurchasePrice = 12.5,
                   CreateDate = DateTime.Now
               },
               new Book 
               {
                   Id = 2,
                   Name = "Adventures of 2",
                   Text = "Hello World 2",
                   PurchasePrice = 13.5,
                   CreateDate = DateTime.Now
                }
           };
        }

        public static List<Subscription> GenerateSubscriptions()
        {
           return new List<Subscription>
           {
                new Subscription
                {
                    Id = 1,
                    UserId = 1, 
                    BookId = 1, 
                    CreateDate = DateTime.Now
                },
                new Subscription
                {
                    Id = 2,
                    UserId = 1, 
                    BookId = 2, 
                    CreateDate = DateTime.Now
                },
                new Subscription
                {   
                    Id = 3,
                    UserId = 2, 
                    BookId = 1, 
                    CreateDate = DateTime.Now
                },
                new Subscription
                {   
                    Id = 4,
                    UserId = 2, 
                    BookId = 2, 
                    CreateDate = DateTime.Now
                },
            };
        }
    }
}
