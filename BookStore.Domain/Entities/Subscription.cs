using BookStore.Services.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Services.Entities
{
    /// <summary>
    /// Subscription Entity
    /// </summary>
    public class Subscription : BaseEntity
    {   
        public int UserId { get; set; }
        public User User { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
