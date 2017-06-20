namespace SignUp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    [Route("/success")]
    [RequireHttps]
    public sealed class SuccessController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("Success");
        }
    }
}
