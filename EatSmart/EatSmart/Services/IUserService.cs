using EatSmart.Models;

namespace EatSmart.Services
{
    public interface IUserService
    {
        long GetUserId(string name);
        User CreateUser(User user);
        User UpdateThisUser(long id, User user);
        User GetUserById(long id);
        bool DeleteThisUser(long id);
    }
}
