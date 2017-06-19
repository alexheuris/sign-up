namespace SignUp.Controllers
{
    using System;
    using System.Data.SqlClient;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using SignUp.Models;
    using SignUp.Services;

    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService = null)
        {
            _userService = userService ?? new UserService();
        }

        [HttpPost("/user")]
        public async Task<IActionResult> Create(UserModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            await _userService.AddUser(model);

            return RedirectToAction("Success", "Home");
        }
    }
}
