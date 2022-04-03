using Microsoft.EntityFrameworkCore;
using MovieApp.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        Context _db;
        public BaseRepository(Context db)
        {
            _db = db;
        }
        public bool Create(T entity)
        {
            try
            {
                return Set().Add(entity) != null;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                return Set().Remove(Find(id)) != null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T Find(int id)
        {
            return Set().Find(id);
        }

        public List<T> List()
        {
            return Set().ToList();
        }

        public IQueryable<T> Query()
        {
            return Set().ToList().AsQueryable();
        }

        public DbSet<T> Set()
        {
            return _db.Set<T>();    
        }

        public bool Update(T entity)
        {
            try
            {
                return Set().Update(entity) != null;
            }
            catch (Exception)
            {
                throw;
            }
        }

      
    }
}
