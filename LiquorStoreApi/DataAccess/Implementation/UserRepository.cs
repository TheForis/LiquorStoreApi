using DataAccess.Interface;
using DomainModels;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace DataAccess.Implementation
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly LiquorStoreDbContext _dbContext;
        public UserRepository(LiquorStoreDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public User LogIn(string email, string password)
        {
            var result = _dbContext.Users.SingleOrDefault(x => x.Email == email && x.Password == password);
            if (result is not null)
                return result;
            else
                return null;
        }
    }
}
