using BookStore.Services.Entities.Base;

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
    }
}
