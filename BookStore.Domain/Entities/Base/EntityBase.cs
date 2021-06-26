using System;

namespace BookStore.Domain.Entities.Base
{
    public abstract class EntityBase
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

    }
}
