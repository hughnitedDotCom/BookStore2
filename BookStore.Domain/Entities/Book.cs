using BookStore.Services.Entities.Base;
using System.Collections.Generic;

namespace BookStore.Services.Entities
{
    /// <summary>
    /// Book Entity
    /// </summary>
    public class Book : BaseEntity
    {
        public Book()
        {
            Subscriptions = new List<Subscription>();

        }
        public string Name { get; set; }

        public string Text { get; set; }

        public double PurchasePrice { get; set; }

        public virtual List<Subscription> Subscriptions { get; set; }
    }
}
