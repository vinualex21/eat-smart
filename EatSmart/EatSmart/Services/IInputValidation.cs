using EatSmart.Models;

namespace EatSmart.Services
{
    public interface IInputValidation
    {
        string? ValidateUser(User user);
    }
}
