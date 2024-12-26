using DataAccess.Interface;
using DTOs;
using Services.Helper;
using Services.Interface;

namespace Services.Implementation
{
    public class BeverageService : IBeverageService
    {
        private readonly IBeverageRepository _repository;
        public BeverageService(IBeverageRepository repo)
        {
            _repository = repo;
        }
        public List<BeverageDto> GetAllBeverages()
        {
            var resultFromBase = _repository.GetAllBeverages();
            var resultList = resultFromBase.Select(x => 
                LiquorMapper.ToBeverageDto(x)).ToList();
            if (resultList.Count > 0)
            {
                return resultList;
            }
            else
            {
                throw new DataMisalignedException("There was a problem getting the List of beverages!");
            }
        }

        public BeverageDto GetBeverage(int id)
        {
            var resultFromBase = _repository.GetById(id);
            if (resultFromBase == null) 
            {
                throw new DirectoryNotFoundException($"No beverage with ID: [{id}]");
            }
            else
            {
                return LiquorMapper.ToBeverageDto(resultFromBase);
            }
        }

        public List<BeverageDto> GetBeveragesByNameOrType(string name, string type)
        {
            var resultFromBase = _repository.GetBeverageByNameOrType(name, type);
            var resultList = resultFromBase.Select(x=> LiquorMapper.ToBeverageDto(x)).ToList();
            return resultList;
        }
    }
}
