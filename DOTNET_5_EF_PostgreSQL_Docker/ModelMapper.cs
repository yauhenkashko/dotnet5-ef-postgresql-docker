using AutoMapper;
using DOTNET_5_EF_PostgreSQL_Docker.Models;
using DOTNET_5_EF_PostgreSQL_Docker.Repository.Model;

namespace DOTNET_5_EF_PostgreSQL_Docker
{
    public class ModelMapper: Profile
    {
        public ModelMapper()
        {
            CreateMap<Phone, PhoneViewModel>();
            CreateMap<Order, OrderViewModel>()
                .ForMember(o => o.Model, c => c.MapFrom(m => m.Phone.Model))
                .ForMember(o => o.Manufacturer, c => c.MapFrom(m => m.Phone.Manufacturer))
                .ForMember(o => o.Price, c => c.MapFrom(m => m.Phone.Price));
            CreateMap<OrderViewModel, Order>();
        }
    }
}