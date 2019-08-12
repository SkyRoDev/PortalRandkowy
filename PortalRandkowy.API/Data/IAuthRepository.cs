using System.Threading.Tasks;
using PortalRandkowy.API.Models;

namespace PortalRandkowy.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Login(string username, string password);
         Task<User> Regiser(User user,string password);
         Task<bool> UserExists(string username);

    }
}