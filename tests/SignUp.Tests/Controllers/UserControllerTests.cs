namespace SignUp.Tests.Controllers
{
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using SignUp.Controllers;
    using SignUp.Models;
    using Xunit;

    public class UserControllerTests
    {
        [Fact]
        public void SigningUpWithAnInvalidUserModelReturnsAViewResult()
        {
            var controller = new UserController();
            controller.ModelState.AddModelError("Key", "ErrorMessage");

            var response = controller.Create(null);

            Assert.IsType<ViewResult>(response);
        }

        [Fact]
        public void SigningUpWithAValidUserModelReturnsAnOkResult()
        {
            var controller = new UserController();

            var response = controller.Create(null);

            Assert.IsType<RedirectToActionResult>(response);
        }
    }
}
