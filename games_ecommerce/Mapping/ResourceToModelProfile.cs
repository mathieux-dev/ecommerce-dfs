using AutoMapper;
using games_ecommerce.Domain.Models;
using games_ecommerce.Resources;

namespace games_ecommerce.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile() : base()
        {
            CreateMap<ProductResource, Product>();
            CreateMap<PublisherResource, Publisher>();
            CreateMap<UserResource, User>();
            CreateMap<PurchaseResource, Purchase>();
        }
    }
}
