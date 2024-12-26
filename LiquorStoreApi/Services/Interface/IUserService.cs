using DTOs;

namespace Services.Interface
{
    public interface IUserService
    {
        UserDto LogInUser(string email, string password);
    }
}
