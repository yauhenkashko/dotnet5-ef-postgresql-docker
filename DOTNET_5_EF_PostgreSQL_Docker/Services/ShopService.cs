﻿using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using DOTNET_5_EF_PostgreSQL_Docker.Models;
using DOTNET_5_EF_PostgreSQL_Docker.Repository;
using DOTNET_5_EF_PostgreSQL_Docker.Repository.Model;

namespace DOTNET_5_EF_PostgreSQL_Docker.Services
{
    public interface IShopService
    {
        IList<PhoneViewModel> GetPhones();
        void GetOrders();
    }

    public class ShopService : IShopService
    {
        private readonly IShopRepository _repository;
        private readonly IMapper _mapper;

        public ShopService(IShopRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public IList<PhoneViewModel> GetPhones()
        {
            var source = _repository.GetPhones();
            var result = _mapper.Map<IList<PhoneViewModel>>(source);

            return result;
        }

        public void GetOrders()
        {

        }
    }
}