using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOTNET_5_EF_PostgreSQL_Docker.Models;
using DOTNET_5_EF_PostgreSQL_Docker.Repository;
using DOTNET_5_EF_PostgreSQL_Docker.Services;

namespace DOTNET_5_EF_PostgreSQL_Docker.Controllers
{
    public class HomeController : Controller
    {
        private readonly IShopService _shopService;

        public HomeController(IShopService shopService)
        {
            _shopService = shopService;
        }

        public IActionResult Index()
        {
            var phones = _shopService.GetPhones();
            var orders = _shopService.GetOrders();
            var model = new PhoneOrderViewModel
            {
                Orders = orders,
                Phones = phones
            };

            return View(model);
        }
    }
}
