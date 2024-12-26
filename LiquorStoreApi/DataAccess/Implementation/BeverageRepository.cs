using DataAccess.Interface;
using DomainModels;

namespace DataAccess.Implementation
{
    public class BeverageRepository : Repository<Beverage>, IBeverageRepository
    {
        private readonly LiquorStoreDbContext _dbContext;
        public BeverageRepository(LiquorStoreDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Beverage> GetAllBeverages()
        {
            return _dbContext.Beverages.ToList();
        }

        public List<Beverage> GetBeverageByNameOrType(string name, string type)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(type))
            {
                return _dbContext.Beverages.Where(x=>x.Name.ToLower() == name.ToLower() && x.Type.ToString().ToLower() == type.ToLower()).ToList();
            }
            if (!string.IsNullOrEmpty(type)) 
            {
                return _dbContext.Beverages.Where(x=> x.Type.ToString().ToLower()== type.ToLower()).ToList();
            }
            if (!string.IsNullOrEmpty(name))
            {
                return _dbContext.Beverages.Where(x => x.Name.ToLower() == name.ToLower()).ToList();
            }
            else
            {
                throw new Exception("There was a problem getting the beverages from the server.");
            }

        }
    }
}
