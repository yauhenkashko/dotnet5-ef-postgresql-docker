using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOTNET_5_EF_PostgreSQL_Docker.Controllers
{
    public class OrderController : Controller
    {
        [HttpPost]
        public IActionResult Index(int phoneId)
        {
            return View();
        }
    }
}
