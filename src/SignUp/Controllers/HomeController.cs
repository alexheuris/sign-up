namespace SignUp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using SignUp.Models;

    [Route("/")]
    [RequireHttps]
    public sealed class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = new UserModel();
            return View(model);
        }
    }
}
