using BookStore.Services.Entities.Base;
using System.Collections.Generic;

namespace BookStore.Services.Entities
{
    /// <summary>
    /// User Entity
    /// </summary>
    public class User : BaseEntity
    {
        public User()
        {
            Subscriptions = new List<Subscription>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public virtual List<Subscription> Subscriptions { get; set; }
    }
}
