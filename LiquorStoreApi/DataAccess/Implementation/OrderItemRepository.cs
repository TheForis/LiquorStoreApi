using DataAccess.Interface;
using DomainModels;

namespace DataAccess.Implementation
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        private readonly LiquorStoreDbContext _dbContext;
        public OrderItemRepository(LiquorStoreDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
