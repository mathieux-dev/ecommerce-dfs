using AutoMapper;
using games_ecommerce.Domain.Models;
using games_ecommerce.Resources;

namespace games_ecommerce.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile() : base()
        {
            CreateMap<Product, ProductResource>();
            CreateMap<Publisher, PublisherResource>();
            CreateMap<User, UserResource>();
            CreateMap<Purchase, PurchaseResource>();
        }
    }
}
