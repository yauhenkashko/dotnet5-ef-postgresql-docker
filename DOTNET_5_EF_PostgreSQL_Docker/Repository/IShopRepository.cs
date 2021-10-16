using System;
using System.Collections.Generic;
using System.Linq;
using DOTNET_5_EF_PostgreSQL_Docker.Repository.Model;

namespace DOTNET_5_EF_PostgreSQL_Docker.Repository
{
    public interface IShopRepository
    {
        IList<Phone> GetPhones();
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
    }
}