using DomainModels;
using DTOs;

namespace Services.Helper
{
    public static class LiquorMapper
    {
        public static BeverageDto ToBeverageDto (Beverage beverage)
        {
            return new BeverageDto()
            {
                Name = beverage.Name,
                Type = beverage.Type.ToString(),
                Price = beverage.Price,
                AvailableQuantity = beverage.Quantity
            };
        }
    }
}
