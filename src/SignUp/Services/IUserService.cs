namespace SignUp.Services
{
    using System.Threading.Tasks;
    using SignUp.Models;

    public interface IUserService
    {
        Task<int> AddUser(UserModel model);
    }
}
