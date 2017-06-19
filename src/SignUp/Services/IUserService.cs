namespace SignUp.Services
{
    using System.Threading.Tasks;
    using SignUp.Models;

    public interface IUserService
    {
        Task AddUser(UserModel model);
    }
}
