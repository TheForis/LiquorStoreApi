using DTOs;

namespace Services.Interface
{
    public interface IBeverageService
    {
        List<BeverageDto> GetAllBeverages ();
        BeverageDto GetBeverage (int id);
        List<BeverageDto> GetBeveragesByNameOrType(string name, string type);
    }
}
