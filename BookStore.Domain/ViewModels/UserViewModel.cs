using System.Collections.Generic;

namespace BookStore.Services.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public List<BookViewModel> BookSubscriptions { get; set; }
    }
}
