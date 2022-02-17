using Mimari_Dal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli_Rep
{
    public class BaseRepository<T> : IBaseRepository<T> where T :class,new()
    {
        DataBaseContext db = new DataBaseContext();
        public void Add(T value)
        {
            Set().Add(value);
        }

        public T Bul(int id)
        {
         return   Set().Find(id);
        }

        public T Bul(string id)
        {
            return Set().Find(id);
        }

        public void Delete(T value)
        {
            Set().Remove(value);
        }

        public IQueryable<T> GetAllList()
        {
            return Set().AsQueryable();
        }

        public List<T> GetList()
        {
            return Set().ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public DbSet<T> Set()
        {
            return db.Set<T>();
        }
    }
}
