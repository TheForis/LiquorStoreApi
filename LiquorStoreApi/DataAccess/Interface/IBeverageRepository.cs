using DomainModels;

namespace DataAccess.Interface
{
    public interface IBeverageRepository : IRepository<Beverage>
    {
        List<Beverage> GetAllBeverages();
        List<Beverage> GetBeverageByNameOrType(string name, string  type);
    }
}
