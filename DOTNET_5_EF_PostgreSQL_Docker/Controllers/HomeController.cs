using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOTNET_5_EF_PostgreSQL_Docker.Repository;

namespace DOTNET_5_EF_PostgreSQL_Docker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShopRepository _repository;

        public HomeController(ShopRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var phones = _repository.GetPhones();
            return View(phones);
        }
    }
}
