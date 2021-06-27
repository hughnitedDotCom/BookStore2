namespace BookStore.Services.ViewModels
{
    public class SubscriptionViewModel
    {
        public SubscriptionViewModel()
        {
            Book = new BookViewModel();
            User = new UserViewModel();
        }


        public int BookId { get; set; }

        public int UserId { get; set; }

        public BookViewModel Book { get; set; }

        public UserViewModel User { get; set; }

    }
}
