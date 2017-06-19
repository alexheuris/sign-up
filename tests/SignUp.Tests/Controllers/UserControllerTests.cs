namespace SignUp.Tests.Controllers
{
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using SignUp.Controllers;
    using SignUp.Models;
    using SignUp.Services;
    using Xunit;

    public class UserControllerTests
    {
        private readonly Mock<IUserService> _userServiceMock = new Mock<IUserService>();

        public UserControllerTests()
        {
            _userServiceMock
                .Setup(u => u.GetUser(It.IsAny<string>()))
                .Returns(Task.FromResult<UserModel>(null));
        }

        [Fact]
        public async Task SigningUpWithAnInvalidUserModelReturnsAViewResult()
        {
            var controller = new UserController(_userServiceMock.Object);
            controller.ModelState.AddModelError("Key", "ErrorMessage");

            var response = await controller.Create(null);

            Assert.IsType<ViewResult>(response);
        }

        [Fact]
        public async Task SigningUpWithAUserModelThatHasAnEmailThatIsAlreadySignedUpReturnsAViewResult()
        {
            _userServiceMock
                .Setup(u => u.GetUser(It.Is<string>(e => e == "foo@bar.com")))
                .Returns(Task.FromResult<UserModel>(new UserModel()));

            var controller = new UserController(_userServiceMock.Object);

            var model = new UserModel
            {
                Email = "foo@bar.com",
                Password = "passwordpassword",
                ConfirmPassword = "passwordpassword"
            };

            var response = await controller.Create(model);

            Assert.IsType<ViewResult>(response);
        }

        [Fact]
        public async Task SigningUpWithAValidUserModelReturnsARedirectToActionResult()
        {
            var controller = new UserController(_userServiceMock.Object);

            var response = await controller.Create(new UserModel());

            Assert.IsType<RedirectToActionResult>(response);
        }

        [Fact]
        public async Task SigningUpWithAValidUserModelAddsThatUserModelToTheDatabase()
        {
            var controller = new UserController(_userServiceMock.Object);

            var model = new UserModel
            {
                Email = "foo@bar.com",
                Password = "passwordpassword",
                ConfirmPassword = "passwordpassword"
            };

            await controller.Create(model);

            _userServiceMock.Verify(u => u.AddUser(It.Is<UserModel>(m => m == model)), Times.Once);
        }
    }
}
