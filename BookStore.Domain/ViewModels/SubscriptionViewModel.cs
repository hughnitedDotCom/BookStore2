namespace BookStore.Services.ViewModels
{
    public class SubscriptionViewModel
    {
        public SubscriptionViewModel()
        {
            Book = new BookViewModel();
            User = new UserViewModel();
        }

        public BookViewModel Book { get; set; }

        public UserViewModel User { get; set; }

    }
}
