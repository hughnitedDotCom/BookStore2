using BookStore.Services.Entities.Base;

namespace BookStore.Services.Entities
{
    /// <summary>
    /// User Entity
    /// </summary>
    public class User : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }
    }
}
