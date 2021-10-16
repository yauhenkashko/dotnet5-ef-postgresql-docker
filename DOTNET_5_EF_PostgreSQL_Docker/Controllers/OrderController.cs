using Microsoft.AspNetCore.Mvc;
using DOTNET_5_EF_PostgreSQL_Docker.Models;
using DOTNET_5_EF_PostgreSQL_Docker.Services;

namespace DOTNET_5_EF_PostgreSQL_Docker.Controllers
{
    public class OrderController : Controller
    {
        private readonly IShopService _service;

        public OrderController(IShopService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            ViewBag.Title = "Order contact details.";
            ViewBag.Id = id;

            return View();
        }

        [HttpPost]
        public IActionResult Buy(OrderViewModel model)
        {
            ViewBag.Title = "Order contact details.";

            _service.SaveOrder(model);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
