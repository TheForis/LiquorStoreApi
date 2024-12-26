using DomainModels;

namespace DataAccess.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        User LogIn (string email, string password);
    }
}
