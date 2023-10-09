using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : BaseGet
    {
        public MyDBContext _dbContext { get; set; }
        public Repository(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public T Create(T entity)
        {
           return _dbContext.Set<T>().Add(entity).Entity;
        }

        public bool Delete(T Entity)
        {
            _dbContext.Set<T>().Remove(Entity);
            return true;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(e => e.IsDeleted == false).Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().Where(e => e.IsDeleted == false).ToList();
        }

        public T GetByID(int id)
        {
            return _dbContext.Set<T>().FirstOrDefault(e => e.ID == id && e.IsDeleted == false);
        }

        public T Update(T entity)
        {
            return _dbContext.Set<T>().Update(entity).Entity;
        }
    }
}
