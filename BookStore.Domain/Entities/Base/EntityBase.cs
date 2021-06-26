using System;

namespace BookStore.Services.Entities.Base
{
    public abstract class EntityBase
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

    }
}
