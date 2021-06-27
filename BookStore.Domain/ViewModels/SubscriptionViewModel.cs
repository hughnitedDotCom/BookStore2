namespace BookStore.Services.ViewModels
{
    public class SubscriptionViewModel
    {
        public int BookId { get; set; }

        public int UserId { get; set; }

        public BookViewModel Book { get; set; } = new BookViewModel();

        public UserViewModel User { get; set; } = new UserViewModel();

    }
}
