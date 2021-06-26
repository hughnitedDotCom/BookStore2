using BookStore.Services.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;

namespace BookStore.Services.Entities
{
    /// <summary>
    /// Subscription Entity
    /// </summary>
    public class Subscription : BaseEntity
    {   
        public int BookId { get; set; }

        public int UserId { get; set; }
    
        public bool IsActive { get; set; }

        public virtual User User { get; set; }

        public virtual Book Book { get; set; }
    }
}
