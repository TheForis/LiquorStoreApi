using DataAccess.Interface;
using DomainModels;

namespace DataAccess.Implementation
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly LiquorStoreDbContext _dbContext;
        public OrderRepository(LiquorStoreDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }
    }
}
