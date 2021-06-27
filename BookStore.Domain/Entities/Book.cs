using BookStore.Services.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Services.Entities
{
    /// <summary>
    /// Book Entity
    /// </summary>
    public class Book : BaseEntity
    {
        public string Name { get; set; }

        public string Text { get; set; }

        public double PurchasePrice { get; set; }

        public List<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    }
}
