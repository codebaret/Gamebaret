using Games.Data.Model;
using Games.Queries.Models;
using System.Threading.Tasks;
using Games.API.Models.Login;
using Games.API.Models.Users;

namespace Games.Queries.Queries
{
    public interface ILoginQueryProcessor
    {
        UserWithToken Authenticate(string username, string password);
        Task<User> Register(RegisterModel model);
        Task ChangePassword(ChangeUserPasswordModel requestModel);
    }
}
