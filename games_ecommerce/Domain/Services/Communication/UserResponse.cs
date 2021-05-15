using games_ecommerce.Domain.Models;

namespace games_ecommerce.Domain.Services.Communication
{
    public class UserResponse : BaseResponse
    {
        public User User { get; private set; }

        public UserResponse(string message, bool success, User user) : base(message, success)
        {
            User = user;
        }
        public UserResponse(User user) : this(string.Empty, true, user)
        {

        }
        public UserResponse(string message) : this(message, false, null)
        {

        }
    }
}