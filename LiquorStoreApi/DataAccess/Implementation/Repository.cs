using DataAccess.Interface;
using DomainModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly LiquorStoreDbContext _dbContext;
        private readonly DbSet<T> _table;

        public Repository(LiquorStoreDbContext dbContext)
        {
            _dbContext = dbContext;
            _table = dbContext.Set<T>();
        }
        public void Create(T entity)
        {
            if(_table.SingleOrDefault(entity) is null)
            {
                _table.Add(entity);
                _dbContext.SaveChanges();
            }
            else { throw new InvalidOperationException("Already exists in base"); }
        }

        public void Delete(T entity)
        {
            if (_table.SingleOrDefault(entity) is not null)
            {
                _table.Remove(entity);
                _dbContext.SaveChanges();
            }
            else { throw new MissingMemberException("The entity does not exist"); }
        }

        public void DeleteById(int id)
        {
            var item = GetById(id);
            Delete(item);

        }

        public T GetById(int id)
        {
            var result = _table.SingleOrDefault(x => x.Id == id);
            if (result is not null)
                return result;
            else
                throw new DirectoryNotFoundException("The entity does not exist");
        }

        public void Update(T entity)
        {
            var result = GetById(entity.Id);
            if (result is not null)
            {
                _table.Update(entity);
            }
        }
    }
}
