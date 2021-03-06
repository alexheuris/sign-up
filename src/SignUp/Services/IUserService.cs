namespace SignUp.Services
{
    using System.Threading.Tasks;
    using SignUp.Models;

    public interface IUserService
    {
        Task<UserModel> GetUser(string email);
        Task<int> AddUser(UserModel model);
    }
}
