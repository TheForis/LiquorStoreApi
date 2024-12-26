using DomainModels;

namespace DataAccess.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteById (int id);
        T GetById (int id);
    }
}
