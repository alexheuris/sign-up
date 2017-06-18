namespace SignUp.Tests.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using SignUp.Models;
    using Xunit;

    public class UserModelTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void WhenEmailIsNullOrEmptyThenAnErrorMessageIsReturned(string email)
        {
            var model = new UserModel
            {
                Email = email
            };

            var results = ValidateModel(model);

            Assert.Equal(GetErrorMessageFor(results, "Email"), "Please enter an email address");
        }

        [Fact]
        public void WhenEmailIsAnInvalidEmailAddressThenAnErrorMessageIsReturned()
        {
            var model = new UserModel
            {
                Email = "foo"
            };

            var results = ValidateModel(model);

            Assert.Equal(GetErrorMessageFor(results, "Email"), "Please enter a valid email address");
        }

        [Fact]
        public void WhenEmailIsAValidEmailAddressThenValidationIsSuccessful()
        {
            var model = new UserModel
            {
                Email = "foo@bar.com"
            };

            var results = ValidateModel(model);

            Assert.Null(GetErrorMessageFor(results, "Email"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void WhenPasswordIsNullOrEmptyThenAnErrorMessageIsReturned(string password)
        {
            var model = new UserModel
            {
                Password = password
            };

            var results = ValidateModel(model);

            Assert.Equal(GetErrorMessageFor(results, "Password"), "Please enter a password");
        }

        [Fact]
        public void WhenPasswordHasLengthLessThanTenCharactersThenAnErrorMessageIsReturned()
        {
            var model = new UserModel
            {
                Password = "abcdefghi"
            };

            var results = ValidateModel(model);

            Assert.Equal(GetErrorMessageFor(results, "Password"), "Please enter a password with a length between 10 and 32 characters");
        }

        [Fact]
        public void WhenPasswordHasLengthGreaterThanThirtyTwoCharactersThenAnErrorMessageIsReturned()
        {
            var model = new UserModel
            {
                Password = "abcdefghijklmnopqrstuvwxyzabcdefg"
            };

            var results = ValidateModel(model);

            Assert.Equal(GetErrorMessageFor(results, "Password"), "Please enter a password with a length between 10 and 32 characters");
        }

        [Fact]
        public void WhenPasswordHasLengthInBetweenTenAndThirtyTwoCharactersInclusiveThenValidationIsSuccessful()
        {
            var model = new UserModel
            {
                Password = "passwordpassword"
            };

            var results = ValidateModel(model);

            Assert.Null(GetErrorMessageFor(results, "Password"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void WhenConfirmPasswordIsNullOrEmptyThenAnErrorMessageIsReturned(string confirmPassword)
        {
            var model = new UserModel
            {
                ConfirmPassword = confirmPassword
            };

            var results = ValidateModel(model);

            Assert.Equal(GetErrorMessageFor(results, "ConfirmPassword"), "Please confirm password");
        }

        [Fact]
        public void WhenConfirmPasswordDoesNotEqualPasswordThenAnErrorMessageIsReturned()
        {
            var model = new UserModel
            {
                Password = "passwordpassword",
                ConfirmPassword = "password"
            };

            var results = ValidateModel(model);

            Assert.True(results.Any(r => r.ErrorMessage == "Passwords do not match"));
        }

        [Fact]
        public void WhenConfirmPasswordEqualsPasswordThenValidationIsSuccessful()
        {
            var model = new UserModel
            {
                Password = "passwordpassword",
                ConfirmPassword = "passwordpassword"
            };

            var results = ValidateModel(model);

            Assert.False(results.Any(r => r.ErrorMessage == "Passwords do not match"));
        }

        private List<ValidationResult> ValidateModel(UserModel model)
        {
            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(model, context, results, true);
            return results;
        }

        private string GetErrorMessageFor(IEnumerable<ValidationResult> results, string memberName)
            => results.FirstOrDefault(r => r.MemberNames.Contains(memberName))?.ErrorMessage;
    }
}
