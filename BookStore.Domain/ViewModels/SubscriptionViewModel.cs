namespace BookStore.Services.ViewModels
{
    public class SubscriptionViewModel
    {
        public SubscriptionViewModel()
        {
            Book = new BookViewModel();
            User = new UserViewModel();
        }

        public virtual BookViewModel Book { get; set; }

        public virtual UserViewModel User { get; set; }

    }
}
