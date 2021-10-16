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
            CreateMap<Order, OrderViewModel>();
        }
    }
}