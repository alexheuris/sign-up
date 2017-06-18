namespace SignUp.Controllers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using SignUp.Models;

    public class UserController : Controller
    {
        [HttpPost("/user")]
        public IActionResult Create(UserModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            return RedirectToAction("Success", "Home");
        }
    }
}
