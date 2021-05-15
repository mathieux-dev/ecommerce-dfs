using games_ecommerce.Domain.Models;

namespace games_ecommerce.Domain.Services.Communication
{
    public class PublisherResponse : BaseResponse
    {
        public Publisher Publisher { get; private set; }
        public PublisherResponse(string message, bool sucess, Publisher publisher) : base(message, sucess)
        {
            Publisher = publisher;
        }
        public PublisherResponse(Publisher publisher) : this(string.Empty, true, publisher)
        {

        }
        public PublisherResponse(string message) : this(message, false, null)
        {

        }
    }
}
