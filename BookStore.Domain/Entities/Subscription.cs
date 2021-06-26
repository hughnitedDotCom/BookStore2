using BookStore.Services.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Entities
{
    /// <summary>
    /// Subscription Entity
    /// </summary>
    public class Subscription : BaseEntity
    {
        public Subscription()
        {
            Book = new Book();
            User = new User();
        }

        public int BookId { get; set; }

        public int UserId { get; set; }

        public virtual Book Book { get; set; }

        public virtual User User { get; set; }

        public bool IsActive { get; set; }
    }
}
