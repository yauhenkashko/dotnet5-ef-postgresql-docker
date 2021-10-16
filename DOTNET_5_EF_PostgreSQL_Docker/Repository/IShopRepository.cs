using System;
using System.Collections.Generic;
using System.Linq;
using DOTNET_5_EF_PostgreSQL_Docker.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace DOTNET_5_EF_PostgreSQL_Docker.Repository
{
    public interface IShopRepository
    {
        IList<Phone> GetPhones();
        IList<Order> GetOrders(bool includePhoneInfo);
    }

    public class ShopRepository : IShopRepository
    {
        private readonly ShopDBContext _context;

        public ShopRepository(ShopDBContext context)
        {
            _context = context;
        }

        public IList<Phone> GetPhones()
        {
            var phones = _context.Phones.ToList();
            return phones;
        }

        public IList<Order> GetOrders(bool includePhoneInfo)
        {
            var orders = _context.Orders.Include(x => x.Phone).ToList();
            return orders;
        }
    }
}