using System.Linq;
using System.Threading.Tasks;
using DOTNET_5_EF_PostgreSQL_Docker.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace DOTNET_5_EF_PostgreSQL_Docker.Repository
{
    public sealed class ShopDBContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }

        public DbSet<Order> Orders { get; set; }

        public ShopDBContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public static async Task EndureInitialized(ShopDBContext context)
        {
            if (!context.Phones.Any())
            {
                context.Phones.AddRange(
                    new Phone
                    {
                        Manufacturer = "Nokia",
                        Model = "3310",
                        Price = 10
                    },
                    new Phone
                    {
                        Manufacturer = "Apple",
                        Model = "IPhone 11",
                        Price = 1300
                    }, new Phone
                    {
                        Manufacturer = "Xiaomi",
                        Model = "9 Light",
                        Price = 250
                    });

                await context.SaveChangesAsync();
            }
        }
    }
}