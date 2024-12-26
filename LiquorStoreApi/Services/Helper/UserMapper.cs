using DomainModels;
using DTOs;

namespace Services.Helper
{
    public static class UserMapper
    {
        public static UserDto ToUserDto (User user, string token)
        {
            return new UserDto()
            {
                FullName = $"{user.FirstName} {user.LastName}",
                Email = user.Email,
                Token = token
            };
        }
    }
}
